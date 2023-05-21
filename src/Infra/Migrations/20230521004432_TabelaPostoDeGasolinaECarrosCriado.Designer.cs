﻿// <auto-generated />
using System;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infra.Migrations
{
    [DbContext(typeof(BancoContext))]
    [Migration("20230521004432_TabelaPostoDeGasolinaECarrosCriado")]
    partial class TabelaPostoDeGasolinaECarrosCriado
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Model.Carro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NomeCarro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PostoDeGasolinaId")
                        .HasColumnType("int");

                    b.Property<int?>("PostoDeGasolinaId1")
                        .HasColumnType("int");

                    b.Property<int>("TempoAbastecimento")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PostoDeGasolinaId");

                    b.HasIndex("PostoDeGasolinaId1");

                    b.ToTable("Carros");
                });

            modelBuilder.Entity("Domain.Model.PostoDeGasolina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("QuantidadeBombas")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("PostoDeGasolina");
                });

            modelBuilder.Entity("Domain.Model.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Vendido")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("Domain.Model.Carro", b =>
                {
                    b.HasOne("Domain.Model.PostoDeGasolina", null)
                        .WithMany("CarrosAbastecidos")
                        .HasForeignKey("PostoDeGasolinaId");

                    b.HasOne("Domain.Model.PostoDeGasolina", null)
                        .WithMany("FilaDeEspera")
                        .HasForeignKey("PostoDeGasolinaId1");
                });

            modelBuilder.Entity("Domain.Model.PostoDeGasolina", b =>
                {
                    b.Navigation("CarrosAbastecidos");

                    b.Navigation("FilaDeEspera");
                });
#pragma warning restore 612, 618
        }
    }
}