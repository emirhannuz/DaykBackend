CREATE TABLE [dbo].[Afetzedeler] (
    [Id]                  INT           IDENTITY (1, 1) NOT NULL,
    [KayitYapanId]        INT           NOT NULL,
    [TcYuNo]              NVARCHAR (11) NOT NULL,
    [Adi]                 NVARCHAR (50) NOT NULL,
    [Soyadi]              NVARCHAR (50) NOT NULL,
    [CepTelefonuNumarasi] NVARCHAR (11) NOT NULL,
    [AcikAdres]           NTEXT         NOT NULL,
    [KayitTarihi]         DATETIME      NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Afetzedeler_Users] FOREIGN KEY ([KayitYapanId]) REFERENCES [dbo].[Users] ([Id])
);

