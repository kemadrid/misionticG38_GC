using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Avicola.Persistencia.Migrations
{
    public partial class Historicos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "dbset_historicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GalponId = table.Column<int>(type: "int", nullable: true),
                    VeterinarioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbset_historicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbset_historicos_dbset_personas_VeterinarioId",
                        column: x => x.VeterinarioId,
                        principalTable: "dbset_personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_dbset_historicos_Galpones_GalponId",
                        column: x => x.GalponId,
                        principalTable: "Galpones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "dbset_historicosxvariables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HistoricoIndicadorId = table.Column<int>(type: "int", nullable: true),
                    VariableId = table.Column<int>(type: "int", nullable: true),
                    valor_float = table.Column<float>(type: "real", nullable: false),
                    valor_string = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbset_historicosxvariables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbset_historicosxvariables_dbset_historicos_HistoricoIndicadorId",
                        column: x => x.HistoricoIndicadorId,
                        principalTable: "dbset_historicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_dbset_historicosxvariables_dbset_variables_VariableId",
                        column: x => x.VariableId,
                        principalTable: "dbset_variables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_dbset_historicos_GalponId",
                table: "dbset_historicos",
                column: "GalponId");

            migrationBuilder.CreateIndex(
                name: "IX_dbset_historicos_VeterinarioId",
                table: "dbset_historicos",
                column: "VeterinarioId");

            migrationBuilder.CreateIndex(
                name: "IX_dbset_historicosxvariables_HistoricoIndicadorId",
                table: "dbset_historicosxvariables",
                column: "HistoricoIndicadorId");

            migrationBuilder.CreateIndex(
                name: "IX_dbset_historicosxvariables_VariableId",
                table: "dbset_historicosxvariables",
                column: "VariableId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dbset_historicosxvariables");

            migrationBuilder.DropTable(
                name: "dbset_historicos");
        }
    }
}
