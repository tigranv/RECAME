CREATE TABLE [dbo].[FoodShop]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [NameId] INT NOT NULL, 
    [Type] INT NOT NULL, 
    [DescriptionId] INT NULL
	CONSTRAINT [FK_FoodShop_Desription] FOREIGN KEY([DescriptionId]) REFERENCES [dbo].[Translation] ([Id]),
	CONSTRAINT [FK_FoodShop_Name] FOREIGN KEY([NameId]) REFERENCES [dbo].[Translation] ([Id])
)
