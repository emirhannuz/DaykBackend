CREATE TABLE [dbo].[StokCikisTeslimler] (
    [Id]                    INT      IDENTITY (1, 1) NOT NULL,
    [StokCikisId]           INT      NOT NULL,
    [TeslimEdenKullaniciId] INT      NOT NULL,
    [TeslimTarihi]          DATETIME NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_StokCikisTeslimler_StokCikislar] FOREIGN KEY ([StokCikisId]) REFERENCES [dbo].[StokCikislar] ([Id]),
    CONSTRAINT [FK_StokCikisTeslimler_Users] FOREIGN KEY ([TeslimEdenKullaniciId]) REFERENCES [dbo].[Users] ([Id])
);

