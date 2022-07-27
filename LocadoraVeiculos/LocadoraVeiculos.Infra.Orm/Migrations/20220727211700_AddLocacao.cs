using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LocadoraVeiculos.Infra.Orm.Migrations
{
    public partial class AddLocacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "LocacaoId",
                table: "TBTaxa",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TBLocacao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FuncionarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GrupoVeiculosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlanoCobrancaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VeiculoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KmVeiculo = table.Column<int>(type: "int", nullable: false),
                    DataLocacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataPrevistaEntrega = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValorPrevisto = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBLocacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBLocacao_TBCliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "TBCliente",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TBLocacao_TBFuncionario_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "TBFuncionario",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TBLocacao_TBGrupoVeiculos_GrupoVeiculosId",
                        column: x => x.GrupoVeiculosId,
                        principalTable: "TBGrupoVeiculos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TBLocacao_TBPlanoCobranca_PlanoCobrancaId",
                        column: x => x.PlanoCobrancaId,
                        principalTable: "TBPlanoCobranca",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TBLocacao_TBVeiculo_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "TBVeiculo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBTaxa_LocacaoId",
                table: "TBTaxa",
                column: "LocacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_TBLocacao_ClienteId",
                table: "TBLocacao",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_TBLocacao_FuncionarioId",
                table: "TBLocacao",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_TBLocacao_GrupoVeiculosId",
                table: "TBLocacao",
                column: "GrupoVeiculosId");

            migrationBuilder.CreateIndex(
                name: "IX_TBLocacao_PlanoCobrancaId",
                table: "TBLocacao",
                column: "PlanoCobrancaId");

            migrationBuilder.CreateIndex(
                name: "IX_TBLocacao_VeiculoId",
                table: "TBLocacao",
                column: "VeiculoId");

            migrationBuilder.AddForeignKey(
                name: "FK_TBTaxa_TBLocacao_LocacaoId",
                table: "TBTaxa",
                column: "LocacaoId",
                principalTable: "TBLocacao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBTaxa_TBLocacao_LocacaoId",
                table: "TBTaxa");

            migrationBuilder.DropTable(
                name: "TBLocacao");

            migrationBuilder.DropIndex(
                name: "IX_TBTaxa_LocacaoId",
                table: "TBTaxa");

            migrationBuilder.DropColumn(
                name: "LocacaoId",
                table: "TBTaxa");
        }
    }
}
