CREATE TABLE [dbo].[Urunler] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [UrunAdi]     NVARCHAR (250) NOT NULL,
    [TurId]       INT            NOT NULL,
    [OlcuBirimId] INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Urunler_OlcuBirimler] FOREIGN KEY ([OlcuBirimId]) REFERENCES [dbo].[OlcuBirimler] ([Id]),
    CONSTRAINT [FK_Urunler_Turler] FOREIGN KEY ([TurId]) REFERENCES [dbo].[Turler] ([Id])
);

