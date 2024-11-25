﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StreamingApi.Context;

#nullable disable

namespace StreamingApi.Migrations
{
    [DbContext(typeof(StreamingContext))]
    partial class StreamingContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("StreamingApi.Models.Conteudo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    b.Property<int?>("CriadorId")
                        .HasColumnType("int");

                    b.Property<int?>("PlaylistId")
                        .HasColumnType("int");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("CriadorId");

                    b.HasIndex("PlaylistId");

                    b.ToTable("Conteudos", (string)null);
                });

            modelBuilder.Entity("StreamingApi.Models.Criador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("ConteudoId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("ConteudoId")
                        .IsUnique();

                    b.ToTable("Criadores", (string)null);
                });

            modelBuilder.Entity("StreamingApi.Models.Playlist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Playlists", (string)null);
                });

            modelBuilder.Entity("StreamingApi.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios", (string)null);
                });

            modelBuilder.Entity("StreamingApi.Models.Conteudo", b =>
                {
                    b.HasOne("StreamingApi.Models.Criador", null)
                        .WithMany("Conteudos")
                        .HasForeignKey("CriadorId");

                    b.HasOne("StreamingApi.Models.Playlist", "Playlist")
                        .WithMany("Conteudos")
                        .HasForeignKey("PlaylistId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Playlist");
                });

            modelBuilder.Entity("StreamingApi.Models.Criador", b =>
                {
                    b.HasOne("StreamingApi.Models.Conteudo", "Conteudo")
                        .WithOne("Criador")
                        .HasForeignKey("StreamingApi.Models.Criador", "ConteudoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Conteudo");
                });

            modelBuilder.Entity("StreamingApi.Models.Playlist", b =>
                {
                    b.HasOne("StreamingApi.Models.Usuario", "Usuario")
                        .WithMany("Playlists")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("StreamingApi.Models.Conteudo", b =>
                {
                    b.Navigation("Criador");
                });

            modelBuilder.Entity("StreamingApi.Models.Criador", b =>
                {
                    b.Navigation("Conteudos");
                });

            modelBuilder.Entity("StreamingApi.Models.Playlist", b =>
                {
                    b.Navigation("Conteudos");
                });

            modelBuilder.Entity("StreamingApi.Models.Usuario", b =>
                {
                    b.Navigation("Playlists");
                });
#pragma warning restore 612, 618
        }
    }
}
