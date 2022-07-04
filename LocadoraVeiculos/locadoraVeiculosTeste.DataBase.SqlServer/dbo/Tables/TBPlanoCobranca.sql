CREATE TABLE [dbo].[TBPlanoCobranca] (
    [Id]                     INT            IDENTITY (1, 1) NOT NULL,
    [ValorDiario_Diario]     DECIMAL (5, 2) NOT NULL,
    [ValorPorKm_Diario]      DECIMAL (5, 2) NOT NULL,
    [ValorDiario_Livre]      DECIMAL (5, 2) NOT NULL,
    [ValorDiario_Controlado] DECIMAL (5, 2) NOT NULL,
    [ValorPorKm_Controlado]  DECIMAL (5, 2) NOT NULL,
    [ControleKm_Controlado]  INT            NOT NULL,
    [GrupoVeiculos_Id]       INT            NOT NULL,
    CONSTRAINT [PK_TBPlanoCobranca] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TBPlanoCobranca_TBGrupoVeiculo] FOREIGN KEY ([GrupoVeiculos_Id]) REFERENCES [dbo].[TBGrupoVeiculo] ([Id])
);

