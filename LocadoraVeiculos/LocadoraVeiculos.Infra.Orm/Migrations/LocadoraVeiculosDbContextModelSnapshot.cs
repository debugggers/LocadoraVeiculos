﻿// <auto-generated />
using System;
using LocadoraVeiculos.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LocadoraVeiculos.Infra.Orm.Migrations
{
    [DbContext(typeof(LocadoraVeiculosDbContext))]
    partial class LocadoraVeiculosDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("GrupoVeiculos");
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

                    b.Property<int>("TipoCalculo")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("TBTaxa");
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
#pragma warning restore 612, 618
        }
    }
}
