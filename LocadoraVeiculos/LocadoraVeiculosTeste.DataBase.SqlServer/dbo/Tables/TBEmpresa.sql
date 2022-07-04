CREATE TABLE [dbo].[TBEmpresa] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [Nome]     VARCHAR (50)  NOT NULL,
    [Email]    VARCHAR (50)  NOT NULL,
    [Telefone] VARCHAR (20)  NOT NULL,
    [Endereco] VARCHAR (100) NOT NULL,
    [Cnpj]     VARCHAR (20)  NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

