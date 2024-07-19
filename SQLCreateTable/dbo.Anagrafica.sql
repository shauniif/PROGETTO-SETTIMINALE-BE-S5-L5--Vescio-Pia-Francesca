CREATE TABLE [dbo].[Anagrafica] (
    [IdAnagrafica]  INT           IDENTITY (1, 1) NOT NULL,
    [Cognome]       NVARCHAR (50) NOT NULL,
    [Nome]          NVARCHAR (50) NOT NULL,
    [Indirizzo]     NVARCHAR (50) NOT NULL,
    [Citta]         NVARCHAR (40) NOT NULL,
    [CAP]           CHAR (5)      NOT NULL,
    [CodiceFiscale] CHAR (16)     NOT NULL,
    PRIMARY KEY CLUSTERED ([IdAnagrafica] ASC),
    UNIQUE NONCLUSTERED ([CodiceFiscale] ASC)
);

