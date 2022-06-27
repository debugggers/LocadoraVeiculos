CREATE TABLE [dbo].[TBFuncionario] (
    [Id]            INT             IDENTITY (1, 1) NOT NULL,
    [Nome]          VARCHAR (50)    NOT NULL,
    [Login]         VARCHAR (50)    NOT NULL,
    [Senha]         VARCHAR (50)    NOT NULL,
    [Data_Admissao] VARCHAR (50)    NOT NULL,
    [Salario]       DECIMAL (10, 2) NOT NULL,
    [EhAdmin]       BIT             NOT NULL,
    CONSTRAINT [PK_TBFuncionario] PRIMARY KEY CLUSTERED ([Id] ASC)
);

