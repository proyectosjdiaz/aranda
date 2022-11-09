
USE [aranda] ;

-- -----------------------------------------------------
-- Table [aranda].[dbo].[categoria]
-- -----------------------------------------------------
CREATE TABLE [aranda].[dbo].[categoria] (
  [id] INT NOT NULL IDENTITY,
  [nombre] VARCHAR(255) NULL,
  PRIMARY KEY ([id]));


-- -----------------------------------------------------
-- Table [aranda].[dbo].[producto]
-- -----------------------------------------------------
CREATE TABLE [aranda].[dbo].[producto] (
  [id] INT NOT NULL IDENTITY,
  [categoria_id] INT NOT NULL,
  [nombre] VARCHAR(255) NULL,
  [descripcion] VARCHAR(255) NULL,
  [imagen] VARCHAR(255) NULL,
  PRIMARY KEY ([id]),
  INDEX [ix_producto_categoria] ([categoria_id] ASC),
  CONSTRAINT [fk_producto_categoria]
    FOREIGN KEY ([categoria_id])
    REFERENCES [aranda].[dbo].[categoria] ([id])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);
