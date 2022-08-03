using Microsoft.EntityFrameworkCore.Migrations;

namespace LocadoraVeiculos.Infra.Orm.Migrations
{
    public partial class AjusteTBGrupoVeiculosTBLocacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBLocacao_TBGrupoVeiculos_GrupoVeiculosId",
                table: "TBLocacao");

            migrationBuilder.AddForeignKey(
                name: "FK_TBLocacao_TBGrupoVeiculos_GrupoVeiculosId",
                table: "TBLocacao",
                column: "GrupoVeiculosId",
                principalTable: "TBGrupoVeiculos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBLocacao_TBGrupoVeiculos_GrupoVeiculosId",
                table: "TBLocacao");

            migrationBuilder.AddForeignKey(
                name: "FK_TBLocacao_TBGrupoVeiculos_GrupoVeiculosId",
                table: "TBLocacao",
                column: "GrupoVeiculosId",
                principalTable: "TBGrupoVeiculos",
                principalColumn: "Id");
        }
    }
}
