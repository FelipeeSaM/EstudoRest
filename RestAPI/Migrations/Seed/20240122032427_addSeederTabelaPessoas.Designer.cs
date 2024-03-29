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
    [Migration("20240122032427_addSeederTabelaPessoas")]
    partial class addSeederTabelaPessoas
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

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
                            Id = -1,
                            Endereco = "Rua A",
                            Genero = "Masculino",
                            PrimeiroNome = "João",
                            UltimoNome = "Silva"
                        },
                        new
                        {
                            Id = -2,
                            Endereco = "Rua B",
                            Genero = "Feminino",
                            PrimeiroNome = "Maria",
                            UltimoNome = "Santos"
                        },
                        new
                        {
                            Id = -3,
                            Endereco = "Rua C",
                            Genero = "Masculino",
                            PrimeiroNome = "Pedro",
                            UltimoNome = "Oliveira"
                        },
                        new
                        {
                            Id = -4,
                            Endereco = "Rua D",
                            Genero = "Feminino",
                            PrimeiroNome = "Ana",
                            UltimoNome = "Costa"
                        },
                        new
                        {
                            Id = -5,
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
