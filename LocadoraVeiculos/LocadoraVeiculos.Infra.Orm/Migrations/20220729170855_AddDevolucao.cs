using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LocadoraVeiculos.Infra.Orm.Migrations
{
    public partial class AddDevolucao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DevolucaoId",
                table: "TBTaxa",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TBDevolucao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LocacaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuilometragemVeiculo = table.Column<int>(type: "int", nullable: false),
                    DataDevolucao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NivelDoTanque = table.Column<double>(type: "float", nullable: false),
                    ValorTotal = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBDevolucao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBDevolucao_TBLocacao_LocacaoId",
                        column: x => x.LocacaoId,
                        principalTable: "TBLocacao",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBTaxa_DevolucaoId",
                table: "TBTaxa",
                column: "DevolucaoId");

            migrationBuilder.CreateIndex(
                name: "IX_TBDevolucao_LocacaoId",
                table: "TBDevolucao",
                column: "LocacaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_TBTaxa_TBDevolucao_DevolucaoId",
                table: "TBTaxa",
                column: "DevolucaoId",
                principalTable: "TBDevolucao",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBTaxa_TBDevolucao_DevolucaoId",
                table: "TBTaxa");

            migrationBuilder.DropTable(
                name: "TBDevolucao");

            migrationBuilder.DropIndex(
                name: "IX_TBTaxa_DevolucaoId",
                table: "TBTaxa");

            migrationBuilder.DropColumn(
                name: "DevolucaoId",
                table: "TBTaxa");
        }
    }
}
