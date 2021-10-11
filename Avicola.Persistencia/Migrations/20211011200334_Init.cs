using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Avicola.Persistencia.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "dbset_personas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Cedula = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    tipo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbset_personas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "dbset_variables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbset_variables", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Galpones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Ubicacion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CantidadAnimales = table.Column<float>(type: "real", nullable: false),
                    FechaIngAnimales = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaSalAnimales = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Latitud = table.Column<float>(type: "real", nullable: false),
                    Longitud = table.Column<float>(type: "real", nullable: false),
                    OperarioId = table.Column<int>(type: "int", nullable: true),
                    VeterinarioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Galpones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Galpones_dbset_personas_OperarioId",
                        column: x => x.OperarioId,
                        principalTable: "dbset_personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Galpones_dbset_personas_VeterinarioId",
                        column: x => x.VeterinarioId,
                        principalTable: "dbset_personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Galpones_OperarioId",
                table: "Galpones",
                column: "OperarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Galpones_VeterinarioId",
                table: "Galpones",
                column: "VeterinarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dbset_variables");

            migrationBuilder.DropTable(
                name: "Galpones");

            migrationBuilder.DropTable(
                name: "dbset_personas");
        }
    }
}
