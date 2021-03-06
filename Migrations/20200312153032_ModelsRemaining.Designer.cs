﻿// <auto-generated />
using System;
using ActivosFijosAPI;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ActivosFijosAPI.Migrations
{
    [DbContext(typeof(ActivosFijosDb))]
    [Migration("20200312153032_ModelsRemaining")]
    partial class ModelsRemaining
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ActivosFijosAPI.Models.ActivoFijo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DepartamentoId");

                    b.Property<decimal>("DepreciacionAcumulada");

                    b.Property<string>("Descripcion");

                    b.Property<DateTime>("FechaRegistro");

                    b.Property<int>("TipoActivoId");

                    b.Property<decimal>("ValorCompra");

                    b.HasKey("Id");

                    b.HasIndex("DepartamentoId");

                    b.HasIndex("TipoActivoId");

                    b.ToTable("ActivosFijos");
                });

            modelBuilder.Entity("ActivosFijosAPI.Models.CalculoDepreciacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ActivoFijoId");

                    b.Property<int>("AnoPreceso");

                    b.Property<string>("CuentaCompra");

                    b.Property<string>("CuentaDepreciacion");

                    b.Property<decimal>("DepreciacionAcumulada");

                    b.Property<DateTime>("FechaProceso");

                    b.Property<int>("MesPreceso");

                    b.Property<decimal>("MontoDepreciado");

                    b.HasKey("Id");

                    b.HasIndex("ActivoFijoId");

                    b.ToTable("CalculosDepreciaciones");
                });

            modelBuilder.Entity("ActivosFijosAPI.Models.Departamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion");

                    b.Property<bool>("Estado");

                    b.HasKey("Id");

                    b.ToTable("Departamentos");
                });

            modelBuilder.Entity("ActivosFijosAPI.Models.Empleado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cedula");

                    b.Property<int>("DepartamentoId");

                    b.Property<bool>("Estado");

                    b.Property<DateTime>("FechaIngreso");

                    b.Property<string>("Nombre");

                    b.Property<int>("TipoPersona");

                    b.HasKey("Id");

                    b.HasIndex("DepartamentoId");

                    b.ToTable("Empleados");
                });

            modelBuilder.Entity("ActivosFijosAPI.Models.TipoActivo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CuentaContableCompra");

                    b.Property<string>("CuentaContableDepreciacion");

                    b.Property<string>("Descripcion");

                    b.Property<bool>("Estado");

                    b.HasKey("Id");

                    b.ToTable("TiposActivos");
                });

            modelBuilder.Entity("ActivosFijosAPI.Models.ActivoFijo", b =>
                {
                    b.HasOne("ActivosFijosAPI.Models.Departamento", "Departamento")
                        .WithMany("ActivosFijos")
                        .HasForeignKey("DepartamentoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ActivosFijosAPI.Models.TipoActivo", "TipoActivo")
                        .WithMany("ActivosFijos")
                        .HasForeignKey("TipoActivoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ActivosFijosAPI.Models.CalculoDepreciacion", b =>
                {
                    b.HasOne("ActivosFijosAPI.Models.ActivoFijo", "ActivoFijo")
                        .WithMany("CalculosDepreciaciones")
                        .HasForeignKey("ActivoFijoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ActivosFijosAPI.Models.Empleado", b =>
                {
                    b.HasOne("ActivosFijosAPI.Models.Departamento", "Departamento")
                        .WithMany("Empleados")
                        .HasForeignKey("DepartamentoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
