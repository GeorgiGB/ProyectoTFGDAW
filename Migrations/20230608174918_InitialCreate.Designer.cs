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
    [Migration("20230608174918_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.2");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("ProyectoTFG.Data.Atendido", b =>
                {
                    b.Property<long>("TrabajadorId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("PacienteId")
                        .HasColumnType("INTEGER");

                    b.HasKey("TrabajadorId", "PacienteId");

                    b.ToTable("Atendido", (string)null);
                });

            modelBuilder.Entity("ProyectoTFG.Data.Cita", b =>
                {
                    b.Property<int>("idCita")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("idCita");

                    b.Property<int>("Duracion")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("VARCHAR(20)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("DATETIME");

                    b.Property<int>("PacienteId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("PacienteID");

                    b.Property<int>("TrabajadorId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("TrabajadorID");

                    b.HasKey("idCita")
                        .HasName("PrimaryKey_idCita");

                    b.HasIndex("PacienteId");

                    b.HasIndex("TrabajadorId");

                    b.ToTable("Citas");
                });

            modelBuilder.Entity("ProyectoTFG.Data.Pacientes", b =>
                {
                    b.Property<int>("idPac")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("idPac");

                    b.Property<string>("PacApellido")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)")
                        .HasColumnName("pacApellido");

                    b.Property<string>("PacDireccion")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("pacDireccion");

                    b.Property<DateTime>("PacFechRegistro")
                        .HasColumnType("DATE")
                        .HasColumnName("pacFechRegistro");

                    b.Property<string>("PacGs")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)")
                        .HasColumnName("pacGS");

                    b.Property<string>("PacNombre")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)")
                        .HasColumnName("pacNombre");

                    b.Property<string>("PacSexo")
                        .IsRequired()
                        .HasColumnType("CHAR(1)")
                        .HasColumnName("pacSexo");

                    b.HasKey("idPac")
                        .HasName("PrimaryKey_idPac");

                    b.ToTable("Pacientes");
                });

            modelBuilder.Entity("ProyectoTFG.Data.Trabajadores", b =>
                {
                    b.Property<int>("idTrab")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("idTrab");

                    b.Property<string>("TrabApellido")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)")
                        .HasColumnName("trabApellido");

                    b.Property<string>("TrabCorreo")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)")
                        .HasColumnName("trabCorreo");

                    b.Property<string>("TrabDireccion")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("trabDireccion");

                    b.Property<DateTime>("TrabFechaContrato")
                        .HasColumnType("DATE")
                        .HasColumnName("trabFechaContrato");

                    b.Property<string>("TrabHorario")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)")
                        .HasColumnName("trabHorario");

                    b.Property<string>("TrabNombre")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)")
                        .HasColumnName("trabNombre");

                    b.Property<string>("TrabPuesto")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)")
                        .HasColumnName("trabPuesto");

                    b.Property<string>("TrabSexo")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)")
                        .HasColumnName("trabSexo");

                    b.Property<string>("TrabTel")
                        .IsRequired()
                        .HasColumnType("VARCHAR(15)")
                        .HasColumnName("trabTel");

                    b.HasKey("idTrab")
                        .HasName("PrimaryKey_idTrab");

                    b.ToTable("Trabajadores");
                });

            modelBuilder.Entity("ProyectoTFG.Data.Usuario", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ProyectoTFG.Data.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ProyectoTFG.Data.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectoTFG.Data.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ProyectoTFG.Data.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProyectoTFG.Data.Cita", b =>
                {
                    b.HasOne("ProyectoTFG.Data.Pacientes", "Paciente")
                        .WithMany()
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectoTFG.Data.Trabajadores", "Trabajador")
                        .WithMany()
                        .HasForeignKey("TrabajadorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Paciente");

                    b.Navigation("Trabajador");
                });
#pragma warning restore 612, 618
        }
    }
}
