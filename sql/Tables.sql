IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Prospects] (
    [Id] uniqueidentifier NOT NULL,
    [Name] varchar(200) NOT NULL,
    [ProActive] varchar(1) NOT NULL,
    [Competition] varchar(1) NOT NULL,
    [International] varchar(1) NOT NULL,
    [AutomaticPhase] varchar(2) NULL,
    [AutomaticStatus] varchar(2) NULL,
    [Opening] datetime2 NOT NULL,
    [FirstBriefing] datetime2 NULL,
    [FirstProposal] datetime2 NULL,
    [ExpectedSale] datetime2 NULL,
    [DeliveryJob] datetime2 NULL,
    [FirstSale] datetime2 NULL,
    [ValueEstimated] float NOT NULL,
    [ValueProposal] float NOT NULL,
    [ValueApproved] float NOT NULL,
    [ValueSold] float NOT NULL,
    [Type] int NOT NULL,
    CONSTRAINT [PK_Prospects] PRIMARY KEY ([Id])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200903163459_Update-Date', N'3.1.7');

GO

