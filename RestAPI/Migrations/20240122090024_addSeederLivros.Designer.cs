﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestAPI.Model.restDbContext;

#nullable disable

namespace RestAPI.Migrations
{
    [DbContext(typeof(rest_api_db_context))]
    [Migration("20240122090024_addSeederLivros")]
    partial class addSeederLivros
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RestAPI.Model.Livros", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Autor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Estoque")
                        .HasColumnType("bit");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Preco")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("livros");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Autor = "Autor 1",
                            Estoque = true,
                            Nome = "Livro 1",
                            Preco = 19.989999771118164
                        },
                        new
                        {
                            Id = 2,
                            Autor = "Autor 2",
                            Estoque = false,
                            Nome = "Livro 2",
                            Preco = 29.989999771118164
                        },
                        new
                        {
                            Id = 3,
                            Autor = "Autor 3",
                            Estoque = true,
                            Nome = "Livro 3",
                            Preco = 39.990001678466797
                        },
                        new
                        {
                            Id = 4,
                            Autor = "Autor 4",
                            Estoque = false,
                            Nome = "Livro 4",
                            Preco = 49.990001678466797
                        },
                        new
                        {
                            Id = 5,
                            Autor = "Autor 5",
                            Estoque = true,
                            Nome = "Livro 5",
                            Preco = 59.990001678466797
                        },
                        new
                        {
                            Id = 6,
                            Autor = "Autor 6",
                            Estoque = false,
                            Nome = "Livro 6",
                            Preco = 69.989997863769531
                        });
                });

            modelBuilder.Entity("RestAPI.Model.Pessoa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrimeiroNome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UltimoNome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("pessoas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Endereco = "Rua A",
                            Genero = "Masculino",
                            PrimeiroNome = "João",
                            UltimoNome = "Silva"
                        },
                        new
                        {
                            Id = 2,
                            Endereco = "Rua B",
                            Genero = "Feminino",
                            PrimeiroNome = "Maria",
                            UltimoNome = "Santos"
                        },
                        new
                        {
                            Id = 3,
                            Endereco = "Rua C",
                            Genero = "Masculino",
                            PrimeiroNome = "Pedro",
                            UltimoNome = "Oliveira"
                        },
                        new
                        {
                            Id = 4,
                            Endereco = "Rua D",
                            Genero = "Feminino",
                            PrimeiroNome = "Ana",
                            UltimoNome = "Costa"
                        },
                        new
                        {
                            Id = 5,
                            Endereco = "Rua E",
                            Genero = "Masculino",
                            PrimeiroNome = "Lucas",
                            UltimoNome = "Pereira"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
