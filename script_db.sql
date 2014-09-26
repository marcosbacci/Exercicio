
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 09/26/2014 17:59:37
-- Generated from EDMX file: C:\Git\Exercicio\src\P3Image\P3Image.DAL\P3Image.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [P3Image];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Campos_SubCategoria]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Campos] DROP CONSTRAINT [FK_Campos_SubCategoria];
GO
IF OBJECT_ID(N'[dbo].[FK_Lista_Campos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Lista] DROP CONSTRAINT [FK_Lista_Campos];
GO
IF OBJECT_ID(N'[dbo].[FK_SubCategoria_Categoria]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SubCategoria] DROP CONSTRAINT [FK_SubCategoria_Categoria];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Campos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Campos];
GO
IF OBJECT_ID(N'[dbo].[Categoria]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Categoria];
GO
IF OBJECT_ID(N'[dbo].[Lista]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Lista];
GO
IF OBJECT_ID(N'[dbo].[SubCategoria]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SubCategoria];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Campos'
CREATE TABLE [dbo].[Campos] (
    [Codigo] int IDENTITY(1,1) NOT NULL,
    [CodigoSubCategoria] int  NOT NULL,
    [Ordem] int  NOT NULL,
    [Descricao] varchar(250)  NOT NULL,
    [Tipo] char(1)  NOT NULL,
    [Ativo] bit  NOT NULL
);
GO

-- Creating table 'Categoria'
CREATE TABLE [dbo].[Categoria] (
    [Codigo] int IDENTITY(1,1) NOT NULL,
    [Descricao] varchar(250)  NOT NULL,
    [Slug] varchar(250)  NOT NULL,
    [Ativo] bit  NOT NULL
);
GO

-- Creating table 'Lista'
CREATE TABLE [dbo].[Lista] (
    [Codigo] int IDENTITY(1,1) NOT NULL,
    [CodigoCampo] int  NOT NULL,
    [Descricao] varchar(250)  NOT NULL,
    [Ativo] bit  NOT NULL
);
GO

-- Creating table 'SubCategoria'
CREATE TABLE [dbo].[SubCategoria] (
    [Codigo] int IDENTITY(1,1) NOT NULL,
    [CodigoCategoria] int  NOT NULL,
    [Descricao] varchar(250)  NOT NULL,
    [Slug] varchar(250)  NOT NULL,
    [Ativo] bit  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Codigo] in table 'Campos'
ALTER TABLE [dbo].[Campos]
ADD CONSTRAINT [PK_Campos]
    PRIMARY KEY CLUSTERED ([Codigo] ASC);
GO

-- Creating primary key on [Codigo] in table 'Categoria'
ALTER TABLE [dbo].[Categoria]
ADD CONSTRAINT [PK_Categoria]
    PRIMARY KEY CLUSTERED ([Codigo] ASC);
GO

-- Creating primary key on [Codigo] in table 'Lista'
ALTER TABLE [dbo].[Lista]
ADD CONSTRAINT [PK_Lista]
    PRIMARY KEY CLUSTERED ([Codigo] ASC);
GO

-- Creating primary key on [Codigo] in table 'SubCategoria'
ALTER TABLE [dbo].[SubCategoria]
ADD CONSTRAINT [PK_SubCategoria]
    PRIMARY KEY CLUSTERED ([Codigo] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CodigoSubCategoria] in table 'Campos'
ALTER TABLE [dbo].[Campos]
ADD CONSTRAINT [FK_Campos_SubCategoria]
    FOREIGN KEY ([CodigoSubCategoria])
    REFERENCES [dbo].[SubCategoria]
        ([Codigo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Campos_SubCategoria'
CREATE INDEX [IX_FK_Campos_SubCategoria]
ON [dbo].[Campos]
    ([CodigoSubCategoria]);
GO

-- Creating foreign key on [CodigoCampo] in table 'Lista'
ALTER TABLE [dbo].[Lista]
ADD CONSTRAINT [FK_Lista_Campos]
    FOREIGN KEY ([CodigoCampo])
    REFERENCES [dbo].[Campos]
        ([Codigo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Lista_Campos'
CREATE INDEX [IX_FK_Lista_Campos]
ON [dbo].[Lista]
    ([CodigoCampo]);
GO

-- Creating foreign key on [CodigoCategoria] in table 'SubCategoria'
ALTER TABLE [dbo].[SubCategoria]
ADD CONSTRAINT [FK_SubCategoria_Categoria]
    FOREIGN KEY ([CodigoCategoria])
    REFERENCES [dbo].[Categoria]
        ([Codigo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SubCategoria_Categoria'
CREATE INDEX [IX_FK_SubCategoria_Categoria]
ON [dbo].[SubCategoria]
    ([CodigoCategoria]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------