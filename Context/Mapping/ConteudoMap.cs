using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StreamingApi.Models;

namespace StreamingApi.Context.Mapping;

public class ConteudoMap : IEntityTypeConfiguration<Conteudo>
{
    public void Configure(EntityTypeBuilder<Conteudo> builder)
    {
        builder.ToTable("Conteudos");

        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id)
            .HasColumnName("Id")
            .IsRequired();

        builder.Property(u => u.Titulo)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(u => u.Tipo)
            .HasMaxLength(150)
            .IsRequired();

        builder.HasOne(c => c.Playlist)
        .WithMany(u => u.Conteudos)
        .HasForeignKey(c => c.PlaylistId)
        .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(c => c.Criador)
        .WithOne(u => u.Conteudo)
        .HasForeignKey<Criador>(u => u.ConteudoId);

    }
}