using Microsoft.EntityFrameworkCore.Migrations;

namespace LocadoraVeiculos.Infra.Orm.Migrations
{
    public partial class AtualizandoTBFuncionarioTBLocacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "TBFuncionario",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "TBFuncionario");
        }
    }
}
