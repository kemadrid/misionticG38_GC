﻿// <auto-generated />
using System;
using Avicola.Persistencia;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Avicola.Persistencia.Migrations
{
    [DbContext(typeof(AppContext))]
    [Migration("20211013184018_Historicos")]
    partial class Historicos
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Avicola.Dominio.Galpon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<float>("CantidadAnimales")
                        .HasColumnType("real");

                    b.Property<DateTime>("FechaIngAnimales")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaSalAnimales")
                        .HasColumnType("datetime2");

                    b.Property<float>("Latitud")
                        .HasColumnType("real");

                    b.Property<float>("Longitud")
                        .HasColumnType("real");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("OperarioId")
                        .HasColumnType("int");

                    b.Property<string>("Ubicacion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("VeterinarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OperarioId");

                    b.HasIndex("VeterinarioId");

                    b.ToTable("Galpones");
                });

            modelBuilder.Entity("Avicola.Dominio.HistoricoIndicador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int?>("GalponId")
                        .HasColumnType("int");

                    b.Property<int?>("VeterinarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GalponId");

                    b.HasIndex("VeterinarioId");

                    b.ToTable("dbset_historicos");
                });

            modelBuilder.Entity("Avicola.Dominio.HistoricoIndicador_Variable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("HistoricoIndicadorId")
                        .HasColumnType("int");

                    b.Property<int?>("VariableId")
                        .HasColumnType("int");

                    b.Property<float>("valor_float")
                        .HasColumnType("real");

                    b.Property<string>("valor_string")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("HistoricoIndicadorId");

                    b.HasIndex("VariableId");

                    b.ToTable("dbset_historicosxvariables");
                });

            modelBuilder.Entity("Avicola.Dominio.Persona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("tipo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("dbset_personas");
                });

            modelBuilder.Entity("Avicola.Dominio.Variable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("dbset_variables");
                });

            modelBuilder.Entity("Avicola.Dominio.Galpon", b =>
                {
                    b.HasOne("Avicola.Dominio.Persona", "Operario")
                        .WithMany()
                        .HasForeignKey("OperarioId");

                    b.HasOne("Avicola.Dominio.Persona", "Veterinario")
                        .WithMany()
                        .HasForeignKey("VeterinarioId");

                    b.Navigation("Operario");

                    b.Navigation("Veterinario");
                });

            modelBuilder.Entity("Avicola.Dominio.HistoricoIndicador", b =>
                {
                    b.HasOne("Avicola.Dominio.Galpon", "Galpon")
                        .WithMany()
                        .HasForeignKey("GalponId");

                    b.HasOne("Avicola.Dominio.Persona", "Veterinario")
                        .WithMany()
                        .HasForeignKey("VeterinarioId");

                    b.Navigation("Galpon");

                    b.Navigation("Veterinario");
                });

            modelBuilder.Entity("Avicola.Dominio.HistoricoIndicador_Variable", b =>
                {
                    b.HasOne("Avicola.Dominio.HistoricoIndicador", "HistoricoIndicador")
                        .WithMany("Variables")
                        .HasForeignKey("HistoricoIndicadorId");

                    b.HasOne("Avicola.Dominio.Variable", "Variable")
                        .WithMany()
                        .HasForeignKey("VariableId");

                    b.Navigation("HistoricoIndicador");

                    b.Navigation("Variable");
                });

            modelBuilder.Entity("Avicola.Dominio.HistoricoIndicador", b =>
                {
                    b.Navigation("Variables");
                });
#pragma warning restore 612, 618
        }
    }
}
