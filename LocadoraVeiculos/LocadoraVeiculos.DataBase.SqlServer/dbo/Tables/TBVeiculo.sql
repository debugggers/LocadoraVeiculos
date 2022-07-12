CREATE TABLE [dbo].[TBVeiculo] (
    [Id]                uniqueidentifier NOT NULL,
    [Modelo]            VARCHAR (40)    NOT NULL,
    [Marca]             VARCHAR (40)    NOT NULL,
    [Placa]             VARCHAR (20)    NOT NULL,
    [Cor]               VARCHAR (20)    NOT NULL,
    [Tipo_Combustivel]  INT             NOT NULL,
    [Capacidade_Tanque] INT             NOT NULL,
    [Ano]               INT             NOT NULL,
    [Quilometragem]     INT             NOT NULL,
    [Foto]              VARBINARY (MAX) NOT NULL,
    [Grupo_Veiculo_Id]  uniqueidentifier NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TBVeiculo_TBGrupoVeiculo] FOREIGN KEY ([Grupo_Veiculo_Id]) REFERENCES [dbo].[TBGrupoVeiculo] ([Id])
);
