CREATE TABLE [dbo].[TBPlanoCobranca](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ValorDiario_Diario] [decimal](5, 2) NOT NULL,
	[ValorPorKm_Diario] [decimal](5, 2) NOT NULL,
	[ValorDiario_Livre] [decimal](5, 2) NOT NULL,
	[ValorDiario_Controlado] [decimal](5, 2) NOT NULL,
	[ValorPorKm_Controlado] [decimal](5, 2) NOT NULL,
	[ControleKm_Controlado] [int] NOT NULL,
	[GrupoVeiculos_Id] [int] NOT NULL, 
    CONSTRAINT [PK_TBPlanoCobranca] PRIMARY KEY ([Id]),
	CONSTRAINT [FK_TBPlanoCobranca_TBGrupoVeiculo] FOREIGN KEY ([GrupoVeiculos_Id]) REFERENCES [dbo].[TBGrupoVeiculo] ([Id])
);
 


