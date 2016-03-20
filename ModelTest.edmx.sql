
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/20/2016 15:13:56
-- Generated from EDMX file: C:\Users\Администратор\documents\visual studio 2015\Projects\Test\Test\ModelTest.edmx
-- --------------------------------------------------

create database Company

SET QUOTED_IDENTIFIER OFF;
GO
USE [Company];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ClientBank]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BankSet] DROP CONSTRAINT [FK_ClientBank];
GO
IF OBJECT_ID(N'[dbo].[FK_ZakazTovar]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TovarSet] DROP CONSTRAINT [FK_ZakazTovar];
GO
IF OBJECT_ID(N'[dbo].[FK_ZakazSklad]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SkladSet] DROP CONSTRAINT [FK_ZakazSklad];
GO
IF OBJECT_ID(N'[dbo].[FK_ZakazClient]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ClientSet] DROP CONSTRAINT [FK_ZakazClient];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Tests]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tests];
GO
IF OBJECT_ID(N'[dbo].[ClientSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ClientSet];
GO
IF OBJECT_ID(N'[dbo].[TovarSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TovarSet];
GO
IF OBJECT_ID(N'[dbo].[SkladSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SkladSet];
GO
IF OBJECT_ID(N'[dbo].[BankSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BankSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Tests'
CREATE TABLE [dbo].[Tests] (
    [IdOrder] int IDENTITY(1,1) NOT NULL,
    [Count] int  NULL,
    [Sum] int  NULL
);
GO

-- Creating table 'ClientSet'
CREATE TABLE [dbo].[ClientSet] (
    [IdClient] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Adress] nvarchar(max)  NOT NULL,
    [Tel] nvarchar(max)  NOT NULL,
    [OrderIdOrder] int  NOT NULL
);
GO

-- Creating table 'ProductSet'
CREATE TABLE [dbo].[ProductSet] (
    [IdProduct] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Price] int  NULL,
    [OrderIdOrder] int  NOT NULL
);
GO

-- Creating table 'StorageSet'
CREATE TABLE [dbo].[StorageSet] (
    [IdStorage] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [OrderIdOrder] int  NOT NULL
);
GO

-- Creating table 'BankSet'
CREATE TABLE [dbo].[BankSet] (
    [IdBank] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Adress] nvarchar(max)  NOT NULL,
    [Acount] nvarchar(max)  NULL,
    [ClientIdClient] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [IdOrder] in table 'Tests'
ALTER TABLE [dbo].[Tests]
ADD CONSTRAINT [PK_Tests]
    PRIMARY KEY CLUSTERED ([IdOrder] ASC);
GO

-- Creating primary key on [IdClient] in table 'ClientSet'
ALTER TABLE [dbo].[ClientSet]
ADD CONSTRAINT [PK_ClientSet]
    PRIMARY KEY CLUSTERED ([IdClient] ASC);
GO

-- Creating primary key on [IdProduct] in table 'ProductSet'
ALTER TABLE [dbo].[ProductSet]
ADD CONSTRAINT [PK_ProductSet]
    PRIMARY KEY CLUSTERED ([IdProduct] ASC);
GO

-- Creating primary key on [IdStorage] in table 'StorageSet'
ALTER TABLE [dbo].[StorageSet]
ADD CONSTRAINT [PK_StorageSet]
    PRIMARY KEY CLUSTERED ([IdStorage] ASC);
GO

-- Creating primary key on [IdBank] in table 'BankSet'
ALTER TABLE [dbo].[BankSet]
ADD CONSTRAINT [PK_BankSet]
    PRIMARY KEY CLUSTERED ([IdBank] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [OrderIdOrder] in table 'ProductSet'
ALTER TABLE [dbo].[ProductSet]
ADD CONSTRAINT [FK_OrderProduct]
    FOREIGN KEY ([OrderIdOrder])
    REFERENCES [dbo].[Tests]
        ([IdOrder])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderProduct'
CREATE INDEX [IX_FK_OrderProduct]
ON [dbo].[ProductSet]
    ([OrderIdOrder]);
GO

-- Creating foreign key on [OrderIdOrder] in table 'StorageSet'
ALTER TABLE [dbo].[StorageSet]
ADD CONSTRAINT [FK_OrderStorage]
    FOREIGN KEY ([OrderIdOrder])
    REFERENCES [dbo].[Tests]
        ([IdOrder])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderStorage'
CREATE INDEX [IX_FK_OrderStorage]
ON [dbo].[StorageSet]
    ([OrderIdOrder]);
GO

-- Creating foreign key on [OrderIdOrder] in table 'ClientSet'
ALTER TABLE [dbo].[ClientSet]
ADD CONSTRAINT [FK_OrderClient]
    FOREIGN KEY ([OrderIdOrder])
    REFERENCES [dbo].[Tests]
        ([IdOrder])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderClient'
CREATE INDEX [IX_FK_OrderClient]
ON [dbo].[ClientSet]
    ([OrderIdOrder]);
GO

-- Creating foreign key on [ClientIdClient] in table 'BankSet'
ALTER TABLE [dbo].[BankSet]
ADD CONSTRAINT [FK_ClientBank]
    FOREIGN KEY ([ClientIdClient])
    REFERENCES [dbo].[ClientSet]
        ([IdClient])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClientBank'
CREATE INDEX [IX_FK_ClientBank]
ON [dbo].[BankSet]
    ([ClientIdClient]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------