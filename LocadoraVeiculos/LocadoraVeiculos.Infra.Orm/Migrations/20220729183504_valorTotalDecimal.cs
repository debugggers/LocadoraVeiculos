using Microsoft.EntityFrameworkCore.Migrations;

namespace LocadoraVeiculos.Infra.Orm.Migrations
{
    public partial class valorTotalDecimal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "ValorTotal",
                table: "TBDevolucao",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "NivelDoTanque",
                table: "TBDevolucao",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "ValorTotal",
                table: "TBDevolucao",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<double>(
                name: "NivelDoTanque",
                table: "TBDevolucao",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }
    }
}
