CREATE TABLE [dbo].[StokCikisOnaylar] (
    [Id]                   INT      IDENTITY (1, 1) NOT NULL,
    [StokCikisId]          INT      NOT NULL,
    [OnaylayanKullaniciId] INT      NOT NULL,
    [OnayTarihi]           DATETIME NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_StokCikisOnaylar_StokCikislar] FOREIGN KEY ([StokCikisId]) REFERENCES [dbo].[StokCikislar] ([Id]),
    CONSTRAINT [FK_StokCikisOnaylar_Users] FOREIGN KEY ([OnaylayanKullaniciId]) REFERENCES [dbo].[Users] ([Id])
);

