using Microsoft.EntityFrameworkCore;
using StreamingApi.Context.Mapping;
using StreamingApi.Models;

namespace StreamingApi.Context;

public class StreamingContext : DbContext
{
    public StreamingContext(DbContextOptions<StreamingContext> options) : base(options)
    {
    }
    public DbSet<Conteudo> Conteudos { get; set; }
    public DbSet<Criador> Criadores { get; set; }
    public DbSet<Playlist> Playlists { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UsuarioMap());
        modelBuilder.ApplyConfiguration(new PlaylistMap());
        modelBuilder.ApplyConfiguration(new ConteudoMap());
        modelBuilder.ApplyConfiguration(new CriadorMap());

        base.OnModelCreating(modelBuilder);
    }
}
