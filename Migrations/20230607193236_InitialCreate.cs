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
                name: "Pacientes",
                columns: table => new
                {
                    idPac = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    pacNombre = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    pacApellido = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    pacDireccion = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    pacSexo = table.Column<string>(type: "CHAR(1)", nullable: false),
                    pacGS = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    pacFechRegistro = table.Column<DateTime>(type: "DATE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrimaryKey_idPac", x => x.idPac);
                });

            migrationBuilder.CreateTable(
                name: "Trabajadores",
                columns: table => new
                {
                    idTrab = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    trabNombre = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    trabApellido = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    trabDireccion = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    trabPuesto = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    trabHorario = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    trabCorreo = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    trabSexo = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    trabTel = table.Column<string>(type: "VARCHAR(15)", nullable: false),
                    trabFechaContrato = table.Column<DateTime>(type: "DATE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrimaryKey_idTrab", x => x.idTrab);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    idUsu = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    usuNombre = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    usuPwd = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    usuRol = table.Column<string>(type: "VARCHAR(20)", nullable: false),
                    usuTrabId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.idUsu);
                });

            migrationBuilder.CreateTable(
                name: "Citas",
                columns: table => new
                {
                    idCita = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PacienteID = table.Column<int>(type: "INTEGER", nullable: false),
                    TrabajadorID = table.Column<int>(type: "INTEGER", nullable: false),
                    Fecha = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Duracion = table.Column<int>(type: "INTEGER", nullable: false),
                    Estado = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrimaryKey_idCita", x => x.idCita);
                    table.ForeignKey(
                        name: "FK_Citas_Pacientes_PacienteID",
                        column: x => x.PacienteID,
                        principalTable: "Pacientes",
                        principalColumn: "idPac",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Citas_Trabajadores_TrabajadorID",
                        column: x => x.TrabajadorID,
                        principalTable: "Trabajadores",
                        principalColumn: "idTrab",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Citas_PacienteID",
                table: "Citas",
                column: "PacienteID");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_TrabajadorID",
                table: "Citas",
                column: "TrabajadorID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Atendido");

            migrationBuilder.DropTable(
                name: "Citas");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropTable(
                name: "Trabajadores");
        }
    }
}
