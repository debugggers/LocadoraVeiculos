CREATE TABLE [dbo].[TBGrupoVeiculo] (
    [Id]   INT          IDENTITY (1, 1) NOT NULL,
    [Nome] VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_TBCategoriaVeiculo] PRIMARY KEY CLUSTERED ([Id] ASC)
);

