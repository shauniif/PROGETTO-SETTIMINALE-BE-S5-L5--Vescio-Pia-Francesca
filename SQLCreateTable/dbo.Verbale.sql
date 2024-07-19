CREATE TABLE [dbo].[Verbale] (
    [IdVerbale]               INT           IDENTITY (1, 1) NOT NULL,
    [DataViolazione]          DATETIME2 (7) NOT NULL,
    [IndirizzoViolazione]     NVARCHAR (50) NOT NULL,
    [NominativoAgente]        NVARCHAR (60) NOT NULL,
    [DataTrascrizioneVerbale] DATETIME2 (7) NOT NULL,
    [IdAnagrafica]            INT           NULL,
    [IdViolazione]            INT           NULL,
    [Importo]                 MONEY         NOT NULL,
    [DecurtamentoPunti]       INT           DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([IdVerbale] ASC),
    CONSTRAINT [fk_Anagrafica] FOREIGN KEY ([IdAnagrafica]) REFERENCES [dbo].[Anagrafica] ([IdAnagrafica]),
    CONSTRAINT [fk_TipoViolazione] FOREIGN KEY ([IdViolazione]) REFERENCES [dbo].[TipoViolazione] ([IdViolazione]),
    CHECK ([Importo]>(0))
);

