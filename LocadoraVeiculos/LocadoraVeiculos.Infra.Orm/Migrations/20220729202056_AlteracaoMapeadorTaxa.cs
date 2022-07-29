using Microsoft.EntityFrameworkCore.Migrations;

namespace LocadoraVeiculos.Infra.Orm.Migrations
{
    public partial class AlteracaoMapeadorTaxa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LocacaoTaxa_TBTaxa_TaxasId",
                table: "LocacaoTaxa");

            migrationBuilder.AddForeignKey(
                name: "FK_LocacaoTaxa_TBTaxa_TaxasId",
                table: "LocacaoTaxa",
                column: "TaxasId",
                principalTable: "TBTaxa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LocacaoTaxa_TBTaxa_TaxasId",
                table: "LocacaoTaxa");

            migrationBuilder.AddForeignKey(
                name: "FK_LocacaoTaxa_TBTaxa_TaxasId",
                table: "LocacaoTaxa",
                column: "TaxasId",
                principalTable: "TBTaxa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
