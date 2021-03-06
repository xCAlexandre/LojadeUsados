﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetoTS.Server;

namespace ProjetoTS.Server.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ProjetoTS.Shared.Automovel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(5,2)");

                    b.Property<int?>("UsuarioIdUsuario")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioIdUsuario");

                    b.ToTable("Automovels");
                });

            modelBuilder.Entity("ProjetoTS.Shared.DetalheAutomovel", b =>
                {
                    b.Property<int>("IdAutomovel")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("EstadodeConservacao")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("TempoDeUso")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("IdAutomovel");

                    b.ToTable("DetalheAutomovels");
                });

            modelBuilder.Entity("ProjetoTS.Shared.Tag", b =>
                {
                    b.Property<int>("TagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("TagId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("ProjetoTS.Shared.TagAutomovel", b =>
                {
                    b.Property<int>("TagId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("TagId", "Id");

                    b.HasIndex("Id");

                    b.ToTable("TagAutomovels");
                });

            modelBuilder.Entity("ProjetoTS.Shared.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cpf")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("DatadeNasc")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Endereco")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("email")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("telefone")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("IdUsuario");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("ProjetoTS.Shared.Automovel", b =>
                {
                    b.HasOne("ProjetoTS.Shared.Usuario", "Usuario")
                        .WithMany("Automovel")
                        .HasForeignKey("UsuarioIdUsuario");
                });

            modelBuilder.Entity("ProjetoTS.Shared.DetalheAutomovel", b =>
                {
                    b.HasOne("ProjetoTS.Shared.Automovel", "Automovel")
                        .WithOne("DetalheAutomovel")
                        .HasForeignKey("ProjetoTS.Shared.DetalheAutomovel", "IdAutomovel")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProjetoTS.Shared.TagAutomovel", b =>
                {
                    b.HasOne("ProjetoTS.Shared.Automovel", "automovel")
                        .WithMany("TagAutomovel")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjetoTS.Shared.Tag", "tag")
                        .WithMany("TagAutomovel")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
