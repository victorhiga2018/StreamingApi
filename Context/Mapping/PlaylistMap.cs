using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StreamingApi.Models;

namespace StreamingApi.Context.Mapping;

public class PlaylistMap : IEntityTypeConfiguration<Playlist>
{
    public void Configure(EntityTypeBuilder<Playlist> builder)
    {
        builder.ToTable("Playlists");

        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id)
            .HasColumnName("Id")
            .IsRequired();

        builder.Property(u => u.Nome)
            .HasMaxLength(100)
            .IsRequired();

        builder.HasOne(c => c.Usuario)
        .WithMany(u => u.Playlists)
        .HasForeignKey(c => c.UsuarioId);
    }
}
