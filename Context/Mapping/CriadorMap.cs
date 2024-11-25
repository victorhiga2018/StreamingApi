using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StreamingApi.Models;

namespace StreamingApi.Context.Mapping;

public class CriadorMap : IEntityTypeConfiguration<Criador>
{
    public void Configure(EntityTypeBuilder<Criador> builder)
    {
        builder.ToTable("Criadores");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Nome)
            .HasMaxLength(100)
            .IsRequired();

        builder.HasOne(c => c.Conteudo)
            .WithOne(c => c.Criador)
            .HasForeignKey<Criador>(c => c.ConteudoId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
