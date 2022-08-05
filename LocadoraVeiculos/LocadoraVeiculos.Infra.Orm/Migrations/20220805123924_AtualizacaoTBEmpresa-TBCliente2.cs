using Microsoft.EntityFrameworkCore.Migrations;

namespace LocadoraVeiculos.Infra.Orm.Migrations
{
    public partial class AtualizacaoTBEmpresaTBCliente2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TBCliente_EmpresaId",
                table: "TBCliente");

            migrationBuilder.CreateIndex(
                name: "IX_TBCliente_EmpresaId",
                table: "TBCliente",
                column: "EmpresaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TBCliente_EmpresaId",
                table: "TBCliente");

            migrationBuilder.CreateIndex(
                name: "IX_TBCliente_EmpresaId",
                table: "TBCliente",
                column: "EmpresaId",
                unique: true,
                filter: "[EmpresaId] IS NOT NULL");
        }
    }
}
