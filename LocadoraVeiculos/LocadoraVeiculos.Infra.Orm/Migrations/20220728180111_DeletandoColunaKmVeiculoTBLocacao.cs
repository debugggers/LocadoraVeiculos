using Microsoft.EntityFrameworkCore.Migrations;

namespace LocadoraVeiculos.Infra.Orm.Migrations
{
    public partial class DeletandoColunaKmVeiculoTBLocacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KmVeiculo",
                table: "TBLocacao");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KmVeiculo",
                table: "TBLocacao",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
