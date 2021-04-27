CREATE TABLE [dbo].[Users] (
    [Id]           INT             IDENTITY (1, 1) NOT NULL,
    [FirstName]    NVARCHAR (250)  NOT NULL,
    [LastName]     NVARCHAR (250)  NOT NULL,
    [Username]     NVARCHAR (50)   NOT NULL,
    [Email]        NVARCHAR (250)  NOT NULL,
    [PhoneNumber]  NVARCHAR (11)   NOT NULL,
    [TcNo]         NVARCHAR (11)   NOT NULL,
    [Address]      NTEXT           NOT NULL,
    [PasswordSalt] VARBINARY (500) NOT NULL,
    [PasswordHash] VARBINARY (500) NOT NULL,
    [Status]       BIT             NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

