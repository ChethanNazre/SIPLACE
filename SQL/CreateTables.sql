IF DB_ID('SIPLACE') IS NULL
BEGIN
    CREATE DATABASE SIPLACE;
END
GO

USE SIPLACE;
GO

IF OBJECT_ID('dbo.Recipes', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Recipes
    (
        RecipeId INT NOT NULL PRIMARY KEY IDENTITY(1,1),
        RecipeName NVARCHAR(255) NOT NULL,
        LineName NVARCHAR(255),
        ModelName NVARCHAR(255),
        BoardSide NVARCHAR(50),
        ImportedDate DATETIME NOT NULL DEFAULT GETDATE()
    );
END
GO

IF OBJECT_ID('dbo.SetupDetails', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.SetupDetails
    (
        DetailId INT NOT NULL PRIMARY KEY IDENTITY(1,1),
        RecipeId INT NOT NULL,
        MachineName NVARCHAR(255) NOT NULL,
        [Table] NVARCHAR(50) NOT NULL,
        Track NVARCHAR(50) NOT NULL,
        PartNumber NVARCHAR(255) NOT NULL,
        Quantity INT NOT NULL DEFAULT 1,
        ReferenceDesignators NVARCHAR(MAX),
        FeederType NVARCHAR(100),

        CONSTRAINT FK_SetupDetails_Recipes
            FOREIGN KEY (RecipeId)
            REFERENCES dbo.Recipes(RecipeId)
            ON DELETE CASCADE
    );
END
GO

IF NOT EXISTS
(
    SELECT 1
    FROM sys.indexes
    WHERE name = 'IX_RecipeId'
      AND object_id = OBJECT_ID('dbo.SetupDetails')
)
BEGIN
    CREATE INDEX IX_RecipeId
    ON dbo.SetupDetails(RecipeId);
END
GO

IF NOT EXISTS
(
    SELECT 1
    FROM sys.indexes
    WHERE name = 'IX_PartNumber'
      AND object_id = OBJECT_ID('dbo.SetupDetails')
)
BEGIN
    CREATE INDEX IX_PartNumber
    ON dbo.SetupDetails(PartNumber);
END
GO

IF NOT EXISTS
(
    SELECT 1
    FROM sys.indexes
    WHERE name = 'IX_MachineName'
      AND object_id = OBJECT_ID('dbo.SetupDetails')
)
BEGIN
    CREATE INDEX IX_MachineName
    ON dbo.SetupDetails(MachineName);
END
GO