CREATE TABLE [dbo].[StokCikislar] (
    [Id]         INT IDENTITY (1, 1) NOT NULL,
    [AfetzedeId] INT NOT NULL,
    [UrunId]     INT NOT NULL,
    [Adet]       INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_StokCikislar_Afetzedeler] FOREIGN KEY ([AfetzedeId]) REFERENCES [dbo].[Afetzedeler] ([Id]),
    CONSTRAINT [FK_StokCikislar_Urunler] FOREIGN KEY ([UrunId]) REFERENCES [dbo].[Urunler] ([Id])
);

