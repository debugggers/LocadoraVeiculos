CREATE TABLE [dbo].[TBCliente] (
    [Id]             INT           IDENTITY (1, 1) NOT NULL,
    [Nome]           VARCHAR (50)  NOT NULL,
    [Email]          VARCHAR (50)  NOT NULL,
    [Telefone]       VARCHAR (20)  NOT NULL,
    [Endereco]       VARCHAR (100) NOT NULL,
    [Cpf]            VARCHAR (50)  NOT NULL,
    [Cnh_Numero]     INT           NOT NULL,
    [Cnh_Nome]       VARCHAR (50)  NOT NULL,
    [Cnh_Vencimento] DATE          NOT NULL,
    [Empresa_Id] int,
    CONSTRAINT [PK__TBClient__3214EC078CA466E7] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TBCliente_TBEmpresa] FOREIGN KEY ([Empresa_Id]) REFERENCES [dbo].[TBEmpresa] ([Id])

);

