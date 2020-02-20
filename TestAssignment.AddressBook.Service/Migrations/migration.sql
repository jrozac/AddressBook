IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [CONTACT] (
    [ID] nvarchar(32) NOT NULL,
    [FIRST_NAME] nvarchar(100) NOT NULL,
    [LAST_NAME] nvarchar(100) NOT NULL,
    [PHONE] nvarchar(20) NOT NULL,
    [ADDRESS] nvarchar(250) NOT NULL,
    CONSTRAINT [PK_CONTACT] PRIMARY KEY ([ID])
);

GO

CREATE UNIQUE INDEX [IX_CONTACT_PHONE] ON [CONTACT] ([PHONE]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200220155421_InitialCreate', N'3.1.1');

GO

