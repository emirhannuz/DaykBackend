CREATE TABLE [dbo].[Stoklar] (
    [Id]           INT      IDENTITY (1, 1) NOT NULL,
    [UrunId]       INT      NOT NULL,
    [KayitYapanId] INT      NOT NULL,
    [Adet]         INT      NOT NULL,
    [GirisTarihi]  DATETIME NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Stoklar_Urunler] FOREIGN KEY ([UrunId]) REFERENCES [dbo].[Urunler] ([Id]),
    CONSTRAINT [FK_Stoklar_Users] FOREIGN KEY ([KayitYapanId]) REFERENCES [dbo].[Users] ([Id])
);

