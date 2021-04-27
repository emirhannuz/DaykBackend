CREATE TABLE [dbo].[AfetzedeFotograflar] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [AfetzedeId]   INT            NOT NULL,
    [FotografYolu] NVARCHAR (250) NOT NULL,
    [EklemeTarihi] DATETIME       NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_AfetzedeFotograflar_Afetzedeler] FOREIGN KEY ([AfetzedeId]) REFERENCES [dbo].[Afetzedeler] ([Id])
);

