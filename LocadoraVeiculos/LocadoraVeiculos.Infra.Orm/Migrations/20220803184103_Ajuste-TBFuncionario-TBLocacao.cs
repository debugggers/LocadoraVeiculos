using Microsoft.EntityFrameworkCore.Migrations;

namespace LocadoraVeiculos.Infra.Orm.Migrations
{
    public partial class AjusteTBFuncionarioTBLocacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBLocacao_TBFuncionario_FuncionarioId",
                table: "TBLocacao");

            migrationBuilder.AddForeignKey(
                name: "FK_TBLocacao_TBFuncionario_FuncionarioId",
                table: "TBLocacao",
                column: "FuncionarioId",
                principalTable: "TBFuncionario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBLocacao_TBFuncionario_FuncionarioId",
                table: "TBLocacao");

            migrationBuilder.AddForeignKey(
                name: "FK_TBLocacao_TBFuncionario_FuncionarioId",
                table: "TBLocacao",
                column: "FuncionarioId",
                principalTable: "TBFuncionario",
                principalColumn: "Id");
        }
    }
}
