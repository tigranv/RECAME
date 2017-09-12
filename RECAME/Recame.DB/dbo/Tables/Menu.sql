CREATE TABLE [dbo].[Menu]
(
	[Id] INT NOT NULL , 
    [FoodShopId] INT NOT NULL, 
    [Type] VARCHAR(50) NULL, 
    PRIMARY KEY ([Id]),
	CONSTRAINT [FK_Menu_FoodShop] FOREIGN KEY ([FoodShopId]) REFERENCES [dbo].[FoodShop] ([Id]) ON DELETE CASCADE
)
