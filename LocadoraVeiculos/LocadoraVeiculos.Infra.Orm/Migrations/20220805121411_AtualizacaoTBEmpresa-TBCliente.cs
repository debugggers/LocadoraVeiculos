using Microsoft.EntityFrameworkCore.Migrations;

namespace LocadoraVeiculos.Infra.Orm.Migrations
{
    public partial class AtualizacaoTBEmpresaTBCliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBCliente_TBEmpresa_EmpresaId",
                table: "TBCliente");

            migrationBuilder.DropIndex(
                name: "IX_TBCliente_EmpresaId",
                table: "TBCliente");

            migrationBuilder.CreateIndex(
                name: "IX_TBCliente_EmpresaId",
                table: "TBCliente",
                column: "EmpresaId",
                unique: true,
                filter: "[EmpresaId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_TBCliente_TBEmpresa_EmpresaId",
                table: "TBCliente",
                column: "EmpresaId",
                principalTable: "TBEmpresa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBCliente_TBEmpresa_EmpresaId",
                table: "TBCliente");

            migrationBuilder.DropIndex(
                name: "IX_TBCliente_EmpresaId",
                table: "TBCliente");

            migrationBuilder.CreateIndex(
                name: "IX_TBCliente_EmpresaId",
                table: "TBCliente",
                column: "EmpresaId");

            migrationBuilder.AddForeignKey(
                name: "FK_TBCliente_TBEmpresa_EmpresaId",
                table: "TBCliente",
                column: "EmpresaId",
                principalTable: "TBEmpresa",
                principalColumn: "Id");
        }
    }
}
