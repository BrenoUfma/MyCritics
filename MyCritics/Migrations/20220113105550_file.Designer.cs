﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyCritics.Data;

namespace MyCritics.Migrations
{
    [DbContext(typeof(MyCriticsContext))]
    [Migration("20220113105550_file")]
    partial class file
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyCritics.Models.Ator", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao");

                    b.Property<int?>("FilmeID");

                    b.Property<string>("Nome");

                    b.HasKey("ID");

                    b.HasIndex("FilmeID");

                    b.ToTable("Ator");
                });

            modelBuilder.Entity("MyCritics.Models.Diretor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataNasc");

                    b.Property<string>("Nome");

                    b.HasKey("ID");

                    b.ToTable("Diretor");
                });

            modelBuilder.Entity("MyCritics.Models.Figurino", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao");

                    b.Property<int?>("FilmeID");

                    b.HasKey("ID");

                    b.HasIndex("FilmeID");

                    b.ToTable("Figurino");
                });

            modelBuilder.Entity("MyCritics.Models.Filme", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Ano");

                    b.Property<string>("Descricao");

                    b.Property<string>("Nome");

                    b.HasKey("ID");

                    b.ToTable("Filme");
                });

            modelBuilder.Entity("MyCritics.Models.Roteiro", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao");

                    b.Property<int?>("FilmeID");

                    b.HasKey("ID");

                    b.HasIndex("FilmeID");

                    b.ToTable("Roteiro");
                });

            modelBuilder.Entity("MyCritics.Models.Sonoplastia", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao");

                    b.Property<int?>("FilmeID");

                    b.HasKey("ID");

                    b.HasIndex("FilmeID");

                    b.ToTable("Sonoplastia");
                });

            modelBuilder.Entity("MyCritics.Models.Usuario", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cidade");

                    b.Property<DateTime>("DataNascimento");

                    b.Property<string>("Email");

                    b.Property<string>("Estado");

                    b.Property<string>("Nome");

                    b.Property<string>("Password");

                    b.Property<string>("Sobrenome");

                    b.Property<string>("file");

                    b.HasKey("ID");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("MyCritics.Models.Ator", b =>
                {
                    b.HasOne("MyCritics.Models.Filme", "Filme")
                        .WithMany()
                        .HasForeignKey("FilmeID");
                });

            modelBuilder.Entity("MyCritics.Models.Figurino", b =>
                {
                    b.HasOne("MyCritics.Models.Filme", "Filme")
                        .WithMany()
                        .HasForeignKey("FilmeID");
                });

            modelBuilder.Entity("MyCritics.Models.Roteiro", b =>
                {
                    b.HasOne("MyCritics.Models.Filme", "Filme")
                        .WithMany()
                        .HasForeignKey("FilmeID");
                });

            modelBuilder.Entity("MyCritics.Models.Sonoplastia", b =>
                {
                    b.HasOne("MyCritics.Models.Filme", "Filme")
                        .WithMany()
                        .HasForeignKey("FilmeID");
                });
#pragma warning restore 612, 618
        }
    }
}
