using Microsoft.EntityFrameworkCore.Migrations;

namespace LocadoraVeiculos.Infra.Orm.Migrations
{
    public partial class AtualizandoTBVeiculoTBLocacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBLocacao_TBVeiculo_VeiculoId",
                table: "TBLocacao");

            migrationBuilder.AddForeignKey(
                name: "FK_TBLocacao_TBVeiculo_VeiculoId",
                table: "TBLocacao",
                column: "VeiculoId",
                principalTable: "TBVeiculo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBLocacao_TBVeiculo_VeiculoId",
                table: "TBLocacao");

            migrationBuilder.AddForeignKey(
                name: "FK_TBLocacao_TBVeiculo_VeiculoId",
                table: "TBLocacao",
                column: "VeiculoId",
                principalTable: "TBVeiculo",
                principalColumn: "Id");
        }
    }
}
