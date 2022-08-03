using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LocadoraVeiculos.Infra.Orm.Migrations
{
    public partial class AtualizandoTBGrupoVeiculosTBVeiculo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBVeiculo_TBGrupoVeiculos_GrupoVeiculoId",
                table: "TBVeiculo");

            migrationBuilder.DropIndex(
                name: "IX_TBVeiculo_GrupoVeiculoId",
                table: "TBVeiculo");

            migrationBuilder.AddColumn<Guid>(
                name: "GrupoVeiculosId",
                table: "TBVeiculo",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TBVeiculo_GrupoVeiculosId",
                table: "TBVeiculo",
                column: "GrupoVeiculosId");

            migrationBuilder.AddForeignKey(
                name: "FK_TBVeiculo_TBGrupoVeiculos_GrupoVeiculosId",
                table: "TBVeiculo",
                column: "GrupoVeiculosId",
                principalTable: "TBGrupoVeiculos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBVeiculo_TBGrupoVeiculos_GrupoVeiculosId",
                table: "TBVeiculo");

            migrationBuilder.DropIndex(
                name: "IX_TBVeiculo_GrupoVeiculosId",
                table: "TBVeiculo");

            migrationBuilder.DropColumn(
                name: "GrupoVeiculosId",
                table: "TBVeiculo");

            migrationBuilder.CreateIndex(
                name: "IX_TBVeiculo_GrupoVeiculoId",
                table: "TBVeiculo",
                column: "GrupoVeiculoId");

            migrationBuilder.AddForeignKey(
                name: "FK_TBVeiculo_TBGrupoVeiculos_GrupoVeiculoId",
                table: "TBVeiculo",
                column: "GrupoVeiculoId",
                principalTable: "TBGrupoVeiculos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
