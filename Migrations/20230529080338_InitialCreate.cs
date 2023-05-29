using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProyectoTFG.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Atendido",
                columns: table => new
                {
                    TrabajadorId = table.Column<long>(type: "INT", nullable: false),
                    PacienteId = table.Column<long>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atendido", x => new { x.TrabajadorId, x.PacienteId });
                });

            migrationBuilder.CreateTable(
                name: "Citas",
                columns: table => new
                {
                    IdCita = table.Column<int>(type: "INT", nullable: false),
                    PacienteID = table.Column<int>(type: "INT", nullable: false),
                    TrabajadorID = table.Column<int>(type: "INT", nullable: false),
                    Fecha = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Duracion = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citas", x => x.IdCita);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    IdPac = table.Column<int>(type: "INT", nullable: false),
                    pacNombre = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    pacApellido = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    pacDireccion = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    pacSexo = table.Column<string>(type: "CHAR(1)", nullable: true),
                    pacGS = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    pacFechRegistro = table.Column<DateTime>(type: "DATE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.IdPac);
                });

            migrationBuilder.CreateTable(
                name: "Trabajadores",
                columns: table => new
                {
                    IdTrab = table.Column<int>(type: "INT", nullable: false),
                    trabNombre = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    trabApellido = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    trabDireccion = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    trabPuesto = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    trabHorario = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    trabCorreo = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    trabSexo = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    trabTel = table.Column<string>(type: "VARCHAR(15)", nullable: true),
                    trabFechNa = table.Column<DateTime>(type: "DATE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trabajadores", x => x.IdTrab);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    IdUsu = table.Column<int>(type: "INT", nullable: false),
                    usuNombre = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    usuPwd = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    usuRol = table.Column<string>(type: "VARCHAR(20)", nullable: false),
                    usuTrabId = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IdUsu);
                });

            migrationBuilder.InsertData(
                table: "Pacientes",
                columns: new[] { "IdPac", "pacApellido", "pacDireccion", "pacFechRegistro", "pacGS", "pacNombre", "pacSexo" },
                values: new object[,]
                {
                    { 1, "Apellido2", "direccion", new DateTime(2023, 5, 29, 10, 3, 38, 124, DateTimeKind.Local).AddTicks(5918), "A+", "Paciente12", "M" },
                    { 2, "Apellido3", "direccion", new DateTime(2023, 5, 29, 10, 3, 38, 124, DateTimeKind.Local).AddTicks(5951), "0+", "Paciente2", "F" }
                });

            migrationBuilder.InsertData(
                table: "Trabajadores",
                columns: new[] { "IdTrab", "trabApellido", "trabCorreo", "trabDireccion", "trabFechNa", "trabHorario", "trabNombre", "trabPuesto", "trabSexo", "trabTel" },
                values: new object[] { 0, "Apellido", "Correo", "Dirección", new DateTime(2023, 5, 29, 10, 3, 38, 124, DateTimeKind.Local).AddTicks(6054), "Horario", "Nombre", "Puesto", "M", "Teléfono" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "IdUsu", "usuNombre", "usuPwd", "usuRol", "usuTrabId" },
                values: new object[] { 1, "admin", "1", "admin", 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Atendido");

            migrationBuilder.DropTable(
                name: "Citas");

            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropTable(
                name: "Trabajadores");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
