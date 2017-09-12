CREATE TABLE [dbo].[MenuItem]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] VARCHAR(50) NULL, 
    [Description] VARCHAR(MAX) NULL, 
    [MenuId] INT NULL,
	CONSTRAINT [FK_MenuItem_MenuId] FOREIGN KEY ([MenuId]) REFERENCES [dbo].[Menu] ([Id]) ON DELETE CASCADE
)
