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

CREATE TABLE [Customers] (
    [Id] int NOT NULL IDENTITY,
    [Name] VARCHAR(80) NOT NULL,
    [Phone] CHAR(11) NULL,
    [PostalCode] CHAR(8) NOT NULL,
    [State] CHAR(2) NOT NULL,
    [City] nvarchar(60) NOT NULL,
    CONSTRAINT [PK_Customers] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Product] (
    [Id] int NOT NULL IDENTITY,
    [BarCode] VARCHAR(14) NOT NULL,
    [Description] VARCHAR(60) NULL,
    [Price] decimal(18,2) NOT NULL,
    [ProductType] nvarchar(max) NOT NULL,
    [IsActive] bit NOT NULL,
    CONSTRAINT [PK_Product] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Orders] (
    [Id] int NOT NULL IDENTITY,
    [DeliveryChargeType] int NOT NULL,
    [OrderStatus] nvarchar(max) NOT NULL,
    [StartDate] datetime2 NOT NULL DEFAULT (GETDATE()),
    [EndDate] datetime2 NOT NULL,
    [Notes] VARCHAR(512) NULL,
    [CustomerId] int NOT NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Orders_Customers_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [Customers] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [OrderItem] (
    [Id] int NOT NULL IDENTITY,
    [Quantity] int NOT NULL DEFAULT 1,
    [Price] decimal(18,2) NOT NULL,
    [Discount] decimal(18,2) NOT NULL,
    [OrderId] int NOT NULL,
    [ProductId] int NOT NULL,
    CONSTRAINT [PK_OrderItem] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_OrderItem_Orders_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [Orders] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_OrderItem_Product_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Product] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IDX_CUSTOMER_PHONE] ON [Customers] ([Phone]);
GO

CREATE INDEX [IX_OrderItem_OrderId] ON [OrderItem] ([OrderId]);
GO

CREATE INDEX [IX_OrderItem_ProductId] ON [OrderItem] ([ProductId]);
GO

CREATE INDEX [IX_Orders_CustomerId] ON [Orders] ([CustomerId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210218191520_Initial', N'5.0.3');
GO

COMMIT;
GO

