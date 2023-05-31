using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

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
                    TrabajadorId = table.Column<long>(type: "INTEGER", nullable: false),
                    PacienteId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atendido", x => new { x.TrabajadorId, x.PacienteId });
                });

            migrationBuilder.CreateTable(
                name: "Citas",
                columns: table => new
                {
                    IdCita = table.Column<int>(type: "INTEGER", nullable: false),
                    PacienteID = table.Column<int>(type: "INTEGER", nullable: false),
                    TrabajadorID = table.Column<int>(type: "INTEGER", nullable: false),
                    Fecha = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Duracion = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citas", x => x.IdCita);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    IdPac = table.Column<int>(type: "INTEGER", nullable: false),
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
                    idtrab = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    trabNombre = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    trabApellido = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    trabDireccion = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    trabPuesto = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    trabHorario = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    trabCorreo = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    trabSexo = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    trabTel = table.Column<string>(type: "VARCHAR(15)", nullable: true),
                    trabFechaContrato = table.Column<DateTime>(type: "DATE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrimaryKey_idtrab", x => x.idtrab);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    IdUsu = table.Column<int>(type: "INTEGER", nullable: false),
                    usuNombre = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    usuPwd = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    usuRol = table.Column<string>(type: "VARCHAR(20)", nullable: false),
                    usuTrabId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IdUsu);
                });
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
