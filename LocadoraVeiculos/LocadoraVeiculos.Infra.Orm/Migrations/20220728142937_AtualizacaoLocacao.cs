using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LocadoraVeiculos.Infra.Orm.Migrations
{
    public partial class AtualizacaoLocacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBLocacao_TBPlanoCobranca_PlanoCobrancaId",
                table: "TBLocacao");

            migrationBuilder.DropIndex(
                name: "IX_TBLocacao_PlanoCobrancaId",
                table: "TBLocacao");

            migrationBuilder.DropColumn(
                name: "PlanoCobrancaId",
                table: "TBLocacao");

            migrationBuilder.AddColumn<int>(
                name: "PlanosCobranca",
                table: "TBLocacao",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlanosCobranca",
                table: "TBLocacao");

            migrationBuilder.AddColumn<Guid>(
                name: "PlanoCobrancaId",
                table: "TBLocacao",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_TBLocacao_PlanoCobrancaId",
                table: "TBLocacao",
                column: "PlanoCobrancaId");

            migrationBuilder.AddForeignKey(
                name: "FK_TBLocacao_TBPlanoCobranca_PlanoCobrancaId",
                table: "TBLocacao",
                column: "PlanoCobrancaId",
                principalTable: "TBPlanoCobranca",
                principalColumn: "Id");
        }
    }
}
