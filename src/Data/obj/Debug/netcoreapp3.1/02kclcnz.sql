IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Customers] (
    [Id] uniqueidentifier NOT NULL,
    [FullName] varchar(300) NOT NULL,
    [CustomerType] int NOT NULL,
    [Enable] bit NOT NULL,
    [CreatedOn] datetime2 NOT NULL,
    CONSTRAINT [PK_Customers] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Products] (
    [Id] uniqueidentifier NOT NULL,
    [ServiceName] varchar(300) NOT NULL,
    [Price] decimal(5,2) NOT NULL,
    [Enabled] bit NOT NULL,
    [CreatedOn] datetime2 NOT NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [ServiceLocations] (
    [Id] uniqueidentifier NOT NULL,
    [ServiceLocationName] varchar(300) NOT NULL,
    [ServiceLocationType] int NOT NULL,
    [Enable] bit NOT NULL,
    [CreatedOn] datetime2 NOT NULL,
    CONSTRAINT [PK_ServiceLocations] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [AddressBirths] (
    [Id] uniqueidentifier NOT NULL,
    [CustomerId] uniqueidentifier NOT NULL,
    [DateOfBirth] datetime2 NOT NULL,
    [BirthTime] datetime2 NOT NULL,
    [CityBirth] varchar(200) NOT NULL,
    [BirthOfState] varchar(200) NOT NULL,
    CONSTRAINT [PK_AddressBirths] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AddressBirths_Customers_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [Customers] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [AddressCurrents] (
    [Id] uniqueidentifier NOT NULL,
    [CustomerId] uniqueidentifier NOT NULL,
    [Address] varchar(300) NULL DEFAULT '',
    [Number] varchar(50) NULL DEFAULT '',
    [Complement] varchar(150) NULL DEFAULT '',
    [CEP] varchar(9) NULL DEFAULT '',
    [Neighborhoods] varchar(100) NULL,
    [City] varchar(250) NULL DEFAULT '',
    [State] varchar(200) NULL DEFAULT '',
    CONSTRAINT [PK_AddressCurrents] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AddressCurrents_Customers_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [Customers] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Contacts] (
    [Id] uniqueidentifier NOT NULL,
    [CustomerId] uniqueidentifier NOT NULL,
    [Email] varchar(100) NULL DEFAULT '',
    [Email2] varchar(100) NULL DEFAULT '',
    [Mobile] varchar(16) NULL DEFAULT '',
    [Mobile2] varchar(16) NULL DEFAULT '',
    [Telephone] varchar(15) NULL DEFAULT '',
    [Telephone2] varchar(15) NULL DEFAULT '',
    CONSTRAINT [PK_Contacts] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Contacts_Customers_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [Customers] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Scheduleds] (
    [Id] uniqueidentifier NOT NULL,
    [Name] varchar(150) NOT NULL,
    [Ticket] varchar(10) NOT NULL,
    [CustomerId] uniqueidentifier NOT NULL,
    [NameProducts] varchar(1000) NOT NULL,
    [ServiceLocationId] uniqueidentifier NOT NULL,
    [Discount] int NOT NULL,
    [Price] decimal(5,2) NOT NULL,
    [SchedulingType] int NOT NULL,
    [Date] datetime2 NOT NULL,
    [Hour] datetime2 NOT NULL,
    [Description] varchar(500) NULL DEFAULT '',
    [SituationCustomer] int NOT NULL,
    CONSTRAINT [PK_Scheduleds] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Scheduleds_Customers_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [Customers] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Scheduleds_ServiceLocations_ServiceLocationId] FOREIGN KEY ([ServiceLocationId]) REFERENCES [ServiceLocations] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Relations] (
    [Id] uniqueidentifier NOT NULL,
    [Ticket] varchar(10) NOT NULL,
    [ScheduleId] uniqueidentifier NOT NULL,
    [RelationType] int NOT NULL,
    [PaymentType] int NOT NULL,
    CONSTRAINT [PK_Relations] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Relations_Scheduleds_ScheduleId] FOREIGN KEY ([ScheduleId]) REFERENCES [Scheduleds] ([Id]) ON DELETE NO ACTION
);

GO

CREATE UNIQUE INDEX [IX_AddressBirths_CustomerId] ON [AddressBirths] ([CustomerId]);

GO

CREATE UNIQUE INDEX [IX_AddressCurrents_CustomerId] ON [AddressCurrents] ([CustomerId]);

GO

CREATE UNIQUE INDEX [IX_Contacts_CustomerId] ON [Contacts] ([CustomerId]);

GO

CREATE INDEX [IX_Relations_ScheduleId] ON [Relations] ([ScheduleId]);

GO

CREATE INDEX [IX_Scheduleds_CustomerId] ON [Scheduleds] ([CustomerId]);

GO

CREATE INDEX [IX_Scheduleds_ServiceLocationId] ON [Scheduleds] ([ServiceLocationId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200816155327_TabelasSistema', N'3.1.6');

GO

