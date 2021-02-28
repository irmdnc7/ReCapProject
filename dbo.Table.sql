CREATE TABLE [dbo].[Cars]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [BrandId] INT NOT NULL, 
    [ColorId] INT NOT NULL, 
    [ModelYear] DATETIME NOT NULL, 
    [DailyPrice] MONEY NOT NULL, 
    [Description] NVARCHAR(50) NULL
)
