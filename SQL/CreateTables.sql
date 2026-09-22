CREATE DATABASE [SIPLACE];
GO

USE [SIPLACE];
GO

CREATE TABLE [dbo].[Recipes]
(
	[RecipeId] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[RecipeName] NVARCHAR(255) NOT NULL,
	[LineName] NVARCHAR(255),
	[ModelName] NVARCHAR(255),
	[BoardSide] NVARCHAR(50),
	[ImportedDate] DATETIME NOT NULL DEFAULT GETDATE()
);
GO

CREATE TABLE [dbo].[SetupDetails]
(
	[DetailId] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[RecipeId] INT NOT NULL,

	[MachineName] NVARCHAR(255) NOT NULL,
	[Table] NVARCHAR(50) NOT NULL,
	[Track] NVARCHAR(50) NOT NULL,
	[PartNumber] NVARCHAR(255) NOT NULL,
	[Quantity] INT NOT NULL DEFAULT 1,
	[ReferenceDesignators] NVARCHAR(MAX),
	[FeederType] NVARCHAR(100),

	CONSTRAINT [FK_SetupDetails_Recipes]
	FOREIGN KEY ([RecipeId])
	REFERENCES [dbo].[Recipes]([RecipeId])
	ON DELETE CASCADE
);
GO

CREATE INDEX IX_RecipeId
ON [dbo].[SetupDetails]([RecipeId]);

CREATE INDEX IX_PartNumber 
ON [dbo].[SetupDetails]([PartNumber]);

CREATE INDEX IX_MachineName 
ON [dbo].[SetupDetails]([MachineName]);
GO