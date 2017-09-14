CREATE TABLE [dbo].[Translation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ObjectType] [int] NOT NULL,
	[Modified] [datetimeoffset](3) NOT NULL,
	[Key] [varchar](255) NULL,
	[UpdateVersion] [timestamp] NULL,
	[ObjectId] [bigint] NULL,
	[IsDeleted] [bit] NOT NULL,
	[ExternalId] [int] NULL,
 CONSTRAINT [PK_Translation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Translation] ADD  CONSTRAINT [DF_Translation_Modified]  DEFAULT (sysdatetimeoffset()) FOR [Modified]
GO

ALTER TABLE [dbo].[Translation] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
