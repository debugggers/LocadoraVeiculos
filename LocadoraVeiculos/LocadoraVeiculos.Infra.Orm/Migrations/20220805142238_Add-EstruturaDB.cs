using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LocadoraVeiculos.Infra.Orm.Migrations
{
    public partial class AddEstruturaDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBEmpresa",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "Varchar(100)", nullable: false),
                    Email = table.Column<string>(type: "Varchar(100)", nullable: false),
                    Telefone = table.Column<string>(type: "Varchar(20)", nullable: false),
                    Endereco = table.Column<string>(type: "Varchar(100)", nullable: false),
                    CNPJ = table.Column<string>(type: "Varchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBEmpresa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBFuncionario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "Varchar(100)", nullable: false),
                    Login = table.Column<string>(type: "Varchar(100)", nullable: false),
                    Senha = table.Column<string>(type: "Varchar(100)", nullable: false),
                    DataAdmissao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Salario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EhAdmin = table.Column<bool>(type: "bit", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBFuncionario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBGrupoVeiculos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "Varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBGrupoVeiculos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBCliente",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "Varchar(100)", nullable: false),
                    Email = table.Column<string>(type: "Varchar(100)", nullable: false),
                    Telefone = table.Column<string>(type: "Varchar(20)", nullable: false),
                    Endereco = table.Column<string>(type: "Varchar(100)", nullable: false),
                    CPF = table.Column<string>(type: "Varchar(20)", nullable: false),
                    CnhNumero = table.Column<int>(type: "int", nullable: false),
                    CnhNome = table.Column<string>(type: "Varchar(100)", nullable: false),
                    CnhVencimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmpresaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBCliente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBCliente_TBEmpresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "TBEmpresa",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TBPlanoCobranca",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GrupoVeiculosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ValorDiario_Diario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorPorKm_Diario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorDiario_Livre = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorDiario_Controlado = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorPorKm_Controlado = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ControleKm = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBPlanoCobranca", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBPlanoCobranca_TBGrupoVeiculos_GrupoVeiculosId",
                        column: x => x.GrupoVeiculosId,
                        principalTable: "TBGrupoVeiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TBVeiculo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Modelo = table.Column<string>(type: "Varchar(100)", nullable: false),
                    Placa = table.Column<string>(type: "Varchar(10)", nullable: false),
                    Marca = table.Column<string>(type: "Varchar(100)", nullable: false),
                    Cor = table.Column<string>(type: "Varchar(100)", nullable: false),
                    TipoCombustivel = table.Column<int>(type: "int", nullable: false),
                    CapacidadeTanque = table.Column<int>(type: "int", nullable: false),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    QuilometragemPercorrida = table.Column<int>(type: "int", nullable: false),
                    Foto = table.Column<byte[]>(type: "Varbinary(max)", nullable: false),
                    GrupoVeiculosId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EstaDisponivel = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBVeiculo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBVeiculo_TBGrupoVeiculos_GrupoVeiculosId",
                        column: x => x.GrupoVeiculosId,
                        principalTable: "TBGrupoVeiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TBLocacao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FuncionarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GrupoVeiculosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlanosCobranca = table.Column<int>(type: "int", nullable: false),
                    VeiculoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TBLocacao_TBFuncionario_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "TBFuncionario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TBLocacao_TBGrupoVeiculos_GrupoVeiculosId",
                        column: x => x.GrupoVeiculosId,
                        principalTable: "TBGrupoVeiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TBLocacao_TBVeiculo_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "TBVeiculo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TBDevolucao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LocacaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuilometragemVeiculo = table.Column<int>(type: "int", nullable: false),
                    DataDevolucao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NivelDoTanque = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBDevolucao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBDevolucao_TBLocacao_LocacaoId",
                        column: x => x.LocacaoId,
                        principalTable: "TBLocacao",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TBTaxa",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "Varchar(100)", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TipoCalculo = table.Column<int>(type: "int", nullable: false),
                    DevolucaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBTaxa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBTaxa_TBDevolucao_DevolucaoId",
                        column: x => x.DevolucaoId,
                        principalTable: "TBDevolucao",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LocacaoTaxa",
                columns: table => new
                {
                    LocacoesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaxasId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocacaoTaxa", x => new { x.LocacoesId, x.TaxasId });
                    table.ForeignKey(
                        name: "FK_LocacaoTaxa_TBLocacao_LocacoesId",
                        column: x => x.LocacoesId,
                        principalTable: "TBLocacao",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LocacaoTaxa_TBTaxa_TaxasId",
                        column: x => x.TaxasId,
                        principalTable: "TBTaxa",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_LocacaoTaxa_TaxasId",
                table: "LocacaoTaxa",
                column: "TaxasId");

            migrationBuilder.CreateIndex(
                name: "IX_TBCliente_EmpresaId",
                table: "TBCliente",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_TBDevolucao_LocacaoId",
                table: "TBDevolucao",
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
                name: "IX_TBLocacao_VeiculoId",
                table: "TBLocacao",
                column: "VeiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_TBPlanoCobranca_GrupoVeiculosId",
                table: "TBPlanoCobranca",
                column: "GrupoVeiculosId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TBTaxa_DevolucaoId",
                table: "TBTaxa",
                column: "DevolucaoId");

            migrationBuilder.CreateIndex(
                name: "IX_TBVeiculo_GrupoVeiculosId",
                table: "TBVeiculo",
                column: "GrupoVeiculosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocacaoTaxa");

            migrationBuilder.DropTable(
                name: "TBPlanoCobranca");

            migrationBuilder.DropTable(
                name: "TBTaxa");

            migrationBuilder.DropTable(
                name: "TBDevolucao");

            migrationBuilder.DropTable(
                name: "TBLocacao");

            migrationBuilder.DropTable(
                name: "TBCliente");

            migrationBuilder.DropTable(
                name: "TBFuncionario");

            migrationBuilder.DropTable(
                name: "TBVeiculo");

            migrationBuilder.DropTable(
                name: "TBEmpresa");

            migrationBuilder.DropTable(
                name: "TBGrupoVeiculos");
        }
    }
}
