CREATE TABLE [dbo].[TranslationEntry](
	[TranslationId] [int] NOT NULL,
	[LanguageId] [char](2) NOT NULL,
	[Text] [nvarchar](400) NOT NULL,
	[Modified] [datetimeoffset](3) NOT NULL,
	[SessionId] [int] NOT NULL,
	[UpdateVersion] [timestamp] NOT NULL,
 CONSTRAINT [PK_TranslationEntry] PRIMARY KEY CLUSTERED 
(
	[TranslationId] ASC,
	[LanguageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[TranslationEntry] ADD  DEFAULT (sysdatetimeoffset()) FOR [Modified]
GO

ALTER TABLE [dbo].[TranslationEntry]  WITH NOCHECK ADD  CONSTRAINT [FK_TranslationEntry_Language] FOREIGN KEY([LanguageId])
REFERENCES [dbo].[Language] ([Id])
GO

ALTER TABLE [dbo].[TranslationEntry] CHECK CONSTRAINT [FK_TranslationEntry_Language]
GO

ALTER TABLE [dbo].[TranslationEntry]  WITH NOCHECK ADD  CONSTRAINT [FK_TranslationEntry_Translation] FOREIGN KEY([TranslationId])
REFERENCES [dbo].[Translation] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[TranslationEntry] CHECK CONSTRAINT [FK_TranslationEntry_Translation]
GO
