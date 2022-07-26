using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LocadoraVeiculos.Infra.Orm.Migrations
{
    public partial class AddPlanoCobrancaSemGV : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBPlanoCobranca",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GrupoVeiculosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ValorDiario_Diario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorPorKm_Diario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorDiario_Livre = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorDiario_Controlado = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorPorKm_Controlado = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ControleKm = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBPlanoCobranca", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBPlanoCobranca_TBGrupoVeiculos_GrupoVeiculosId",
                        column: x => x.GrupoVeiculosId,
                        principalTable: "TBGrupoVeiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBPlanoCobranca_GrupoVeiculosId",
                table: "TBPlanoCobranca",
                column: "GrupoVeiculosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBPlanoCobranca");
        }
    }
}
