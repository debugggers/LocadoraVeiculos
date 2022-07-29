using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LocadoraVeiculos.Infra.Orm.Migrations
{
    public partial class AlteracaoTBLocacao_Taxa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LocacaoTaxa_TBLocacao_LocacoesId",
                table: "LocacaoTaxa");

            migrationBuilder.AddColumn<Guid>(
                name: "LocacaoId",
                table: "LocacaoTaxa",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "TaxaId",
                table: "LocacaoTaxa",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_LocacaoTaxa_LocacaoId",
                table: "LocacaoTaxa",
                column: "LocacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_LocacaoTaxa_TaxaId",
                table: "LocacaoTaxa",
                column: "TaxaId");

            migrationBuilder.AddForeignKey(
                name: "FK_LocacaoTaxa_TBLocacao_LocacaoId",
                table: "LocacaoTaxa",
                column: "LocacaoId",
                principalTable: "TBLocacao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LocacaoTaxa_TBLocacao_LocacoesId",
                table: "LocacaoTaxa",
                column: "LocacoesId",
                principalTable: "TBLocacao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LocacaoTaxa_TBTaxa_TaxaId",
                table: "LocacaoTaxa",
                column: "TaxaId",
                principalTable: "TBTaxa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LocacaoTaxa_TBLocacao_LocacaoId",
                table: "LocacaoTaxa");

            migrationBuilder.DropForeignKey(
                name: "FK_LocacaoTaxa_TBLocacao_LocacoesId",
                table: "LocacaoTaxa");

            migrationBuilder.DropForeignKey(
                name: "FK_LocacaoTaxa_TBTaxa_TaxaId",
                table: "LocacaoTaxa");

            migrationBuilder.DropIndex(
                name: "IX_LocacaoTaxa_LocacaoId",
                table: "LocacaoTaxa");

            migrationBuilder.DropIndex(
                name: "IX_LocacaoTaxa_TaxaId",
                table: "LocacaoTaxa");

            migrationBuilder.DropColumn(
                name: "LocacaoId",
                table: "LocacaoTaxa");

            migrationBuilder.DropColumn(
                name: "TaxaId",
                table: "LocacaoTaxa");

            migrationBuilder.AddForeignKey(
                name: "FK_LocacaoTaxa_TBLocacao_LocacoesId",
                table: "LocacaoTaxa",
                column: "LocacoesId",
                principalTable: "TBLocacao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
