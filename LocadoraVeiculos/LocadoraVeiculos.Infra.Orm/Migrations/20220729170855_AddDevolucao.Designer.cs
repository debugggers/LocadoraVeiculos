﻿// <auto-generated />
using System;
using LocadoraVeiculos.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LocadoraVeiculos.Infra.Orm.Migrations
{
    [DbContext(typeof(LocadoraVeiculosDbContext))]
    [Migration("20220729170855_AddDevolucao")]
    partial class AddDevolucao
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LocacaoTaxa", b =>
                {
                    b.Property<Guid>("LocacoesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TaxasId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LocacoesId", "TaxasId");

                    b.HasIndex("TaxasId");

                    b.ToTable("LocacaoTaxa");
                });

            modelBuilder.Entity("LocadoraVeiculos.Dominio.ModuloCliente.Cliente", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("Varchar(20)");

                    b.Property<string>("CnhNome")
                        .IsRequired()
                        .HasColumnType("Varchar(100)");

                    b.Property<int>("CnhNumero")
                        .HasColumnType("int");

                    b.Property<DateTime>("CnhVencimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("Varchar(100)");

                    b.Property<Guid?>("EmpresaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("Varchar(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("Varchar(100)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("Varchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.ToTable("TBCliente");
                });

            modelBuilder.Entity("LocadoraVeiculos.Dominio.ModuloCliente.ClienteEmpresa.Empresa", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasColumnType("Varchar(20)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("Varchar(100)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("Varchar(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("Varchar(100)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("Varchar(20)");

                    b.HasKey("Id");

                    b.ToTable("TBEmpresa");
                });

            modelBuilder.Entity("LocadoraVeiculos.Dominio.ModuloDevolucao.Devolucao", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataDevolucao")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("LocacaoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("NivelDoTanque")
                        .HasColumnType("float");

                    b.Property<int>("QuilometragemVeiculo")
                        .HasColumnType("int");

                    b.Property<double>("ValorTotal")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("LocacaoId");

                    b.ToTable("TBDevolucao");
                });

            modelBuilder.Entity("LocadoraVeiculos.Dominio.ModuloFuncionario.Funcionario", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataAdmissao")
                        .HasColumnType("datetime2");

                    b.Property<bool>("EhAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("Varchar(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("Varchar(100)");

                    b.Property<decimal>("Salario")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("Varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("TBFuncionario");
                });

            modelBuilder.Entity("LocadoraVeiculos.Dominio.ModuloGrupoVeiculos.GrupoVeiculos", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("Varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("TBGrupoVeiculos");
                });

            modelBuilder.Entity("LocadoraVeiculos.Dominio.ModuloLocacao.Locacao", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClienteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataLocacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataPrevistaEntrega")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("FuncionarioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GrupoVeiculosId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("PlanosCobranca")
                        .HasColumnType("int");

                    b.Property<decimal>("ValorPrevisto")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("VeiculoId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("FuncionarioId");

                    b.HasIndex("GrupoVeiculosId");

                    b.HasIndex("VeiculoId");

                    b.ToTable("TBLocacao");
                });

            modelBuilder.Entity("LocadoraVeiculos.Dominio.ModuloPlanoCobranca.PlanoCobranca", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ControleKm")
                        .HasColumnType("int");

                    b.Property<Guid>("GrupoVeiculosId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("ValorDiario_Controlado")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ValorDiario_Diario")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ValorDiario_Livre")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ValorPorKm_Controlado")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ValorPorKm_Diario")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("GrupoVeiculosId");

                    b.ToTable("TBPlanoCobranca");
                });

            modelBuilder.Entity("LocadoraVeiculos.Dominio.ModuloTaxa.Taxa", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("Varchar(100)");

                    b.Property<Guid?>("DevolucaoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("TipoCalculo")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("DevolucaoId");

                    b.ToTable("TBTaxa");
                });

            modelBuilder.Entity("LocadoraVeiculos.Dominio.ModuloVeiculo.Veiculo", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Ano")
                        .HasColumnType("int");

                    b.Property<int>("CapacidadeTanque")
                        .HasColumnType("int");

                    b.Property<string>("Cor")
                        .IsRequired()
                        .HasColumnType("Varchar(100)");

                    b.Property<byte[]>("Foto")
                        .IsRequired()
                        .HasColumnType("Varbinary(max)");

                    b.Property<Guid?>("GrupoVeiculoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("Varchar(100)");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("Varchar(100)");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasColumnType("Varchar(10)");

                    b.Property<int>("QuilometragemPercorrida")
                        .HasColumnType("int");

                    b.Property<int>("TipoCombustivel")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GrupoVeiculoId");

                    b.ToTable("TBVeiculo");
                });

            modelBuilder.Entity("LocacaoTaxa", b =>
                {
                    b.HasOne("LocadoraVeiculos.Dominio.ModuloLocacao.Locacao", null)
                        .WithMany()
                        .HasForeignKey("LocacoesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LocadoraVeiculos.Dominio.ModuloTaxa.Taxa", null)
                        .WithMany()
                        .HasForeignKey("TaxasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LocadoraVeiculos.Dominio.ModuloCliente.Cliente", b =>
                {
                    b.HasOne("LocadoraVeiculos.Dominio.ModuloCliente.ClienteEmpresa.Empresa", "Empresa")
                        .WithMany()
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("LocadoraVeiculos.Dominio.ModuloDevolucao.Devolucao", b =>
                {
                    b.HasOne("LocadoraVeiculos.Dominio.ModuloLocacao.Locacao", "Locacao")
                        .WithMany()
                        .HasForeignKey("LocacaoId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Locacao");
                });

            modelBuilder.Entity("LocadoraVeiculos.Dominio.ModuloLocacao.Locacao", b =>
                {
                    b.HasOne("LocadoraVeiculos.Dominio.ModuloCliente.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("LocadoraVeiculos.Dominio.ModuloFuncionario.Funcionario", "Funcionario")
                        .WithMany()
                        .HasForeignKey("FuncionarioId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("LocadoraVeiculos.Dominio.ModuloGrupoVeiculos.GrupoVeiculos", "GrupoVeiculos")
                        .WithMany()
                        .HasForeignKey("GrupoVeiculosId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("LocadoraVeiculos.Dominio.ModuloVeiculo.Veiculo", "Veiculo")
                        .WithMany()
                        .HasForeignKey("VeiculoId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Funcionario");

                    b.Navigation("GrupoVeiculos");

                    b.Navigation("Veiculo");
                });

            modelBuilder.Entity("LocadoraVeiculos.Dominio.ModuloPlanoCobranca.PlanoCobranca", b =>
                {
                    b.HasOne("LocadoraVeiculos.Dominio.ModuloGrupoVeiculos.GrupoVeiculos", "GrupoVeiculos")
                        .WithMany()
                        .HasForeignKey("GrupoVeiculosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GrupoVeiculos");
                });

            modelBuilder.Entity("LocadoraVeiculos.Dominio.ModuloTaxa.Taxa", b =>
                {
                    b.HasOne("LocadoraVeiculos.Dominio.ModuloDevolucao.Devolucao", null)
                        .WithMany("Taxas")
                        .HasForeignKey("DevolucaoId")
                        .OnDelete(DeleteBehavior.NoAction);
                });

            modelBuilder.Entity("LocadoraVeiculos.Dominio.ModuloVeiculo.Veiculo", b =>
                {
                    b.HasOne("LocadoraVeiculos.Dominio.ModuloGrupoVeiculos.GrupoVeiculos", "GrupoVeiculo")
                        .WithMany()
                        .HasForeignKey("GrupoVeiculoId");

                    b.Navigation("GrupoVeiculo");
                });

            modelBuilder.Entity("LocadoraVeiculos.Dominio.ModuloDevolucao.Devolucao", b =>
                {
                    b.Navigation("Taxas");
                });
#pragma warning restore 612, 618
        }
    }
}