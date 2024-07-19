CREATE TABLE [dbo].[TipoViolazione] (
    [IdViolazione] INT           IDENTITY (1, 1) NOT NULL,
    [Descrizione]  NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([IdViolazione] ASC)
);

