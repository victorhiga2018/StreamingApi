
using Microsoft.EntityFrameworkCore;
using StreamingApi.Context;
using StreamingApi.Repositories;

var builder = WebApplication.CreateBuilder(args);
var connetionString = "Server=localhost;port=3307;Database=streaming;uid=root;password=P@ssWord;";

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<StreamingContext>(opt => opt.UseMySql(connetionString, ServerVersion.AutoDetect(connetionString)));

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
