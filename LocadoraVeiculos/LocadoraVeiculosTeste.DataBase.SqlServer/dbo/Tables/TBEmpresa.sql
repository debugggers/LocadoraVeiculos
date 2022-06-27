CREATE TABLE [dbo].[TBEmpresa] (
    [Id]         INT           IDENTITY (1, 1) NOT NULL,
    [Nome]       VARCHAR (50)  NOT NULL,
    [Email]      VARCHAR (50)  NOT NULL,
    [Telefone]   VARCHAR (20)  NOT NULL,
    [Endereco]   VARCHAR (100) NOT NULL,
    [Cnpj]       VARCHAR (20)  NOT NULL,
    [Cliente_Id] INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TBEmpresa_TBCliente] FOREIGN KEY ([Cliente_Id]) REFERENCES [dbo].[TBCliente] ([Id])
);

