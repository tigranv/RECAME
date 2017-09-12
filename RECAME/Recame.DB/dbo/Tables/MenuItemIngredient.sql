CREATE TABLE [dbo].[MenuItemIngredient]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[MenuItemId] INT NOT NULL, 
    [IngredientId] INT NOT NULL, 
    CONSTRAINT [FK_MenuItemIngredient_MenuItemId] FOREIGN KEY ([MenuItemId]) REFERENCES [dbo].[MenuItem] ([Id]) ON DELETE CASCADE,
	CONSTRAINT [FK_MenuItemIngredient_IngredientId] FOREIGN KEY ([IngredientId]) REFERENCES [dbo].[Ingredient] ([Id]) ON DELETE CASCADE
)
