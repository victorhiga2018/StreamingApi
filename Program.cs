
using Microsoft.EntityFrameworkCore;
using StreamingApi.Context;
using StreamingApi.Repositories;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
var connetionString = "Server=localhost;port=3307;Database=streaming;uid=root;password=P@ssWord;";

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<StreamingContext>(opt => opt.UseMySql(connetionString, ServerVersion.AutoDetect(connetionString)));

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IPlaylistRepository, PlaylistRepository>();

builder.Services.AddControllers().AddJsonOptions(x =>
   x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

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
