﻿CREATE TABLE [dbo].[TBTaxa] (
    [Id]          uniqueidentifier NOT NULL,
    [Descricao]   VARCHAR (100)  NOT NULL,
    [Valor]       DECIMAL (5, 2) NOT NULL,
    [TipoCalculo] INT            NOT NULL,
    CONSTRAINT [PK_TBTaxa] PRIMARY KEY CLUSTERED ([Id] ASC)
);

