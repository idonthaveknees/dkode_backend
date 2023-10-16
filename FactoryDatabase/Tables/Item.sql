CREATE TABLE [dbo].[Item]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] VARCHAR(20) NOT NULL, 
    [Description] VARCHAR(50) NULL, 
    [Price] MONEY NOT NULL
)
