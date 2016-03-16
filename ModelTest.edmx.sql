
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/13/2016 04:25:14
-- Generated from EDMX file: C:\Users\Администратор\documents\visual studio 2015\Projects\Test\Test\ModelTest.edmx
-- --------------------------------------------------

CREATE DATABASE TEST 

SET QUOTED_IDENTIFIER OFF;
GO
USE [TEST];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ZakaziClient]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ClientSet] DROP CONSTRAINT [FK_ZakaziClient];
GO
IF OBJECT_ID(N'[dbo].[FK_ZakaziTovar]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TovarSet] DROP CONSTRAINT [FK_ZakaziTovar];
GO
IF OBJECT_ID(N'[dbo].[FK_ZakaziSkladi]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SkladiSet] DROP CONSTRAINT [FK_ZakaziSkladi];
GO
IF OBJECT_ID(N'[dbo].[FK_ClientBank]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BankSet] DROP CONSTRAINT [FK_ClientBank];
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
IF OBJECT_ID(N'[dbo].[SkladiSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SkladiSet];
GO
IF OBJECT_ID(N'[dbo].[BankSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BankSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Tests'
CREATE TABLE [dbo].[Tests] (
    [IdZakaz] int IDENTITY(1,1) NOT NULL,
    [Kolich] int  NULL,
    [Sum] int  NULL
);
GO

-- Creating table 'ClientSet'
CREATE TABLE [dbo].[ClientSet] (
    [IdClient] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Adress] nvarchar(max)  NOT NULL,
    [Tel] nvarchar(max)  NOT NULL,
    [ZakaziIdZakaz] int  NOT NULL
);
GO

-- Creating table 'TovarSet'
CREATE TABLE [dbo].[TovarSet] (
    [IdTovar] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Csena] int  NULL,
    [ZakaziIdZakaz] int  NOT NULL
);
GO

-- Creating table 'SkladiSet'
CREATE TABLE [dbo].[SkladiSet] (
    [IdSklad] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [ZakaziIdZakaz] int  NOT NULL
);
GO

-- Creating table 'BankSet'
CREATE TABLE [dbo].[BankSet] (
    [IdBank] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Adress] nvarchar(max)  NOT NULL,
    [Schet] nvarchar(max)  NULL,
    [ClientIdClient] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [IdZakaz] in table 'Tests'
ALTER TABLE [dbo].[Tests]
ADD CONSTRAINT [PK_Tests]
    PRIMARY KEY CLUSTERED ([IdZakaz] ASC);
GO

-- Creating primary key on [IdClient] in table 'ClientSet'
ALTER TABLE [dbo].[ClientSet]
ADD CONSTRAINT [PK_ClientSet]
    PRIMARY KEY CLUSTERED ([IdClient] ASC);
GO

-- Creating primary key on [IdTovar] in table 'TovarSet'
ALTER TABLE [dbo].[TovarSet]
ADD CONSTRAINT [PK_TovarSet]
    PRIMARY KEY CLUSTERED ([IdTovar] ASC);
GO

-- Creating primary key on [IdSklad] in table 'SkladiSet'
ALTER TABLE [dbo].[SkladiSet]
ADD CONSTRAINT [PK_SkladiSet]
    PRIMARY KEY CLUSTERED ([IdSklad] ASC);
GO

-- Creating primary key on [IdBank] in table 'BankSet'
ALTER TABLE [dbo].[BankSet]
ADD CONSTRAINT [PK_BankSet]
    PRIMARY KEY CLUSTERED ([IdBank] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ZakaziIdZakaz] in table 'ClientSet'
ALTER TABLE [dbo].[ClientSet]
ADD CONSTRAINT [FK_ZakaziClient]
    FOREIGN KEY ([ZakaziIdZakaz])
    REFERENCES [dbo].[Tests]
        ([IdZakaz])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ZakaziClient'
CREATE INDEX [IX_FK_ZakaziClient]
ON [dbo].[ClientSet]
    ([ZakaziIdZakaz]);
GO

-- Creating foreign key on [ZakaziIdZakaz] in table 'TovarSet'
ALTER TABLE [dbo].[TovarSet]
ADD CONSTRAINT [FK_ZakaziTovar]
    FOREIGN KEY ([ZakaziIdZakaz])
    REFERENCES [dbo].[Tests]
        ([IdZakaz])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ZakaziTovar'
CREATE INDEX [IX_FK_ZakaziTovar]
ON [dbo].[TovarSet]
    ([ZakaziIdZakaz]);
GO

-- Creating foreign key on [ZakaziIdZakaz] in table 'SkladiSet'
ALTER TABLE [dbo].[SkladiSet]
ADD CONSTRAINT [FK_ZakaziSkladi]
    FOREIGN KEY ([ZakaziIdZakaz])
    REFERENCES [dbo].[Tests]
        ([IdZakaz])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ZakaziSkladi'
CREATE INDEX [IX_FK_ZakaziSkladi]
ON [dbo].[SkladiSet]
    ([ZakaziIdZakaz]);
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