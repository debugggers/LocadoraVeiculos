using Microsoft.EntityFrameworkCore.Migrations;

namespace LocadoraVeiculos.Infra.Orm.Migrations
{
    public partial class AtualizacaoTBClienteTBLocacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBCliente_TBEmpresa_EmpresaId",
                table: "TBCliente");

            migrationBuilder.DropForeignKey(
                name: "FK_TBLocacao_TBCliente_ClienteId",
                table: "TBLocacao");

            migrationBuilder.AddForeignKey(
                name: "FK_TBCliente_TBEmpresa_EmpresaId",
                table: "TBCliente",
                column: "EmpresaId",
                principalTable: "TBEmpresa",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TBLocacao_TBCliente_ClienteId",
                table: "TBLocacao",
                column: "ClienteId",
                principalTable: "TBCliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBCliente_TBEmpresa_EmpresaId",
                table: "TBCliente");

            migrationBuilder.DropForeignKey(
                name: "FK_TBLocacao_TBCliente_ClienteId",
                table: "TBLocacao");

            migrationBuilder.AddForeignKey(
                name: "FK_TBCliente_TBEmpresa_EmpresaId",
                table: "TBCliente",
                column: "EmpresaId",
                principalTable: "TBEmpresa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TBLocacao_TBCliente_ClienteId",
                table: "TBLocacao",
                column: "ClienteId",
                principalTable: "TBCliente",
                principalColumn: "Id");
        }
    }
}
