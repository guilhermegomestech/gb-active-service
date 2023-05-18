USE[GB_ACTIVE_SERVICE]

IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Dependencies] (
    [Id] uniqueidentifier NOT NULL,
    [Description] VARCHAR(200) NOT NULL,
    [Address] VARCHAR(200) NOT NULL,
    CONSTRAINT [PK_Dependencies] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Responsibles] (
    [Id] uniqueidentifier NOT NULL,
    [Name] VARCHAR(200) NOT NULL,
    [Phone] VARCHAR(20) NOT NULL,
    [Email] VARCHAR(100) NOT NULL,
    CONSTRAINT [PK_Responsibles] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Actives] (
    [Id] uniqueidentifier NOT NULL,
    [ResponsibleId] uniqueidentifier NOT NULL,
    [DependencyId] uniqueidentifier NOT NULL,
    [Name] VARCHAR(200) NOT NULL,
    [Brand] VARCHAR(200) NOT NULL,
    CONSTRAINT [PK_Actives] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Actives_Dependencies_DependencyId] FOREIGN KEY ([DependencyId]) REFERENCES [Dependencies] ([Id]),
    CONSTRAINT [FK_Actives_Responsibles_ResponsibleId] FOREIGN KEY ([ResponsibleId]) REFERENCES [Responsibles] ([Id])
);
GO

CREATE INDEX [IX_Actives_DependencyId] ON [Actives] ([DependencyId]);
GO

CREATE INDEX [IX_Actives_ResponsibleId] ON [Actives] ([ResponsibleId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230515232455_Initial', N'7.0.5');
GO

COMMIT;
GO

