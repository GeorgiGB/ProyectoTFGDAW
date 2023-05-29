﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProyectoTFG.Data;

#nullable disable

namespace ProyectoTFG.Migrations
{
    [DbContext(typeof(HospitalContext))]
    [Migration("20230529080338_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.2");

            modelBuilder.Entity("ProyectoTFG.Data.Atendido", b =>
                {
                    b.Property<long>("TrabajadorId")
                        .HasColumnType("INT");

                    b.Property<long>("PacienteId")
                        .HasColumnType("INT");

                    b.HasKey("TrabajadorId", "PacienteId");

                    b.ToTable("Atendido", (string)null);
                });

            modelBuilder.Entity("ProyectoTFG.Data.Cita", b =>
                {
                    b.Property<int>("IdCita")
                        .HasColumnType("INT")
                        .HasColumnName("IdCita");

                    b.Property<int>("Duracion")
                        .HasColumnType("INT");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("DATETIME");

                    b.Property<int>("PacienteId")
                        .HasColumnType("INT")
                        .HasColumnName("PacienteID");

                    b.Property<int>("TrabajadorId")
                        .HasColumnType("INT")
                        .HasColumnName("TrabajadorID");

                    b.HasKey("IdCita");

                    b.ToTable("Citas");
                });

            modelBuilder.Entity("ProyectoTFG.Data.Pacientes", b =>
                {
                    b.Property<int>("IdPac")
                        .HasColumnType("INT")
                        .HasColumnName("IdPac");

                    b.Property<string>("PacApellido")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)")
                        .HasColumnName("pacApellido");

                    b.Property<string>("PacDireccion")
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("pacDireccion");

                    b.Property<DateTime>("PacFechRegistro")
                        .HasColumnType("DATE")
                        .HasColumnName("pacFechRegistro");

                    b.Property<string>("PacGs")
                        .HasColumnType("VARCHAR(50)")
                        .HasColumnName("pacGS");

                    b.Property<string>("PacNombre")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)")
                        .HasColumnName("pacNombre");

                    b.Property<string>("PacSexo")
                        .HasColumnType("CHAR(1)")
                        .HasColumnName("pacSexo");

                    b.HasKey("IdPac");

                    b.ToTable("Pacientes");

                    b.HasData(
                        new
                        {
                            IdPac = 1,
                            PacApellido = "Apellido2",
                            PacDireccion = "direccion",
                            PacFechRegistro = new DateTime(2023, 5, 29, 10, 3, 38, 124, DateTimeKind.Local).AddTicks(5918),
                            PacGs = "A+",
                            PacNombre = "Paciente12",
                            PacSexo = "M"
                        },
                        new
                        {
                            IdPac = 2,
                            PacApellido = "Apellido3",
                            PacDireccion = "direccion",
                            PacFechRegistro = new DateTime(2023, 5, 29, 10, 3, 38, 124, DateTimeKind.Local).AddTicks(5951),
                            PacGs = "0+",
                            PacNombre = "Paciente2",
                            PacSexo = "F"
                        });
                });

            modelBuilder.Entity("ProyectoTFG.Data.Trabajadores", b =>
                {
                    b.Property<int>("IdTrab")
                        .HasColumnType("INT")
                        .HasColumnName("IdTrab");

                    b.Property<string>("TrabApellido")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)")
                        .HasColumnName("trabApellido");

                    b.Property<string>("TrabCorreo")
                        .HasColumnType("VARCHAR(50)")
                        .HasColumnName("trabCorreo");

                    b.Property<string>("TrabDireccion")
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("trabDireccion");

                    b.Property<DateTime>("TrabFechNa")
                        .HasColumnType("DATE")
                        .HasColumnName("trabFechNa");

                    b.Property<string>("TrabHorario")
                        .HasColumnType("VARCHAR(50)")
                        .HasColumnName("trabHorario");

                    b.Property<string>("TrabNombre")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)")
                        .HasColumnName("trabNombre");

                    b.Property<string>("TrabPuesto")
                        .HasColumnType("VARCHAR(50)")
                        .HasColumnName("trabPuesto");

                    b.Property<string>("TrabSexo")
                        .HasColumnType("VARCHAR(50)")
                        .HasColumnName("trabSexo");

                    b.Property<string>("TrabTel")
                        .HasColumnType("VARCHAR(15)")
                        .HasColumnName("trabTel");

                    b.HasKey("IdTrab");

                    b.ToTable("Trabajadores");

                    b.HasData(
                        new
                        {
                            IdTrab = 0,
                            TrabApellido = "Apellido",
                            TrabCorreo = "Correo",
                            TrabDireccion = "Dirección",
                            TrabFechNa = new DateTime(2023, 5, 29, 10, 3, 38, 124, DateTimeKind.Local).AddTicks(6054),
                            TrabHorario = "Horario",
                            TrabNombre = "Nombre",
                            TrabPuesto = "Puesto",
                            TrabSexo = "M",
                            TrabTel = "Teléfono"
                        });
                });

            modelBuilder.Entity("ProyectoTFG.Data.Usuario", b =>
                {
                    b.Property<int>("IdUsu")
                        .HasColumnType("INT")
                        .HasColumnName("IdUsu");

                    b.Property<string>("UsuNombre")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)")
                        .HasColumnName("usuNombre");

                    b.Property<string>("UsuPwd")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)")
                        .HasColumnName("usuPwd");

                    b.Property<string>("UsuRol")
                        .IsRequired()
                        .HasColumnType("VARCHAR(20)")
                        .HasColumnName("usuRol");

                    b.Property<int>("UsuTrabId")
                        .HasColumnType("INT")
                        .HasColumnName("usuTrabId");

                    b.HasKey("IdUsu");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            IdUsu = 1,
                            UsuNombre = "admin",
                            UsuPwd = "1",
                            UsuRol = "admin",
                            UsuTrabId = 0
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
