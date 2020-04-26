---------------tworzenie bazy danych-------------------

CREATE DATABASE [quiz] 

GO

-----------tworzenie tabeli Tests----------------------


CREATE TABLE [dbo].[Tests](
	[Id] [int] NOT NULL,
	[Title] [varchar](255) NULL,
	[Description] [varchar](255) NULL,
 CONSTRAINT [PK_Tests] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

---------------tworzenie tabeli Questions-----------------


CREATE TABLE [dbo].[Questions](
	[Id] [int] NOT NULL,
	[QuestionText] [varchar](255) NULL,
 CONSTRAINT [PK_Questions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

-----------tworzenie tabeli Answers----------------


CREATE TABLE [dbo].[Answers](
	[Id] [int] NOT NULL,
	[Id_Quest] [int] NULL,
	[Correct] [int] NULL,
	[textAnswer] [varchar](255) NULL,
 CONSTRAINT [PK_Answers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Answers]  WITH CHECK ADD  CONSTRAINT [FK_Answers_Questions] FOREIGN KEY([Id_Quest])
REFERENCES [dbo].[Questions] ([Id])
GO

ALTER TABLE [dbo].[Answers] CHECK CONSTRAINT [FK_Answers_Questions]
GO

--------------tworzenie tabeli Table2----------------------------


CREATE TABLE [dbo].[Table2](
	[Id] [int] NOT NULL,
	[IdTest] [int] NULL,
	[IdQuest] [int] NULL,
 CONSTRAINT [PK_Table2] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Table2]  WITH CHECK ADD  CONSTRAINT [FK_Table2_Questions] FOREIGN KEY([IdQuest])
REFERENCES [dbo].[Questions] ([Id])
GO

ALTER TABLE [dbo].[Table2] CHECK CONSTRAINT [FK_Table2_Questions]
GO

ALTER TABLE [dbo].[Table2]  WITH CHECK ADD  CONSTRAINT [FK_Table2_Tests] FOREIGN KEY([IdTest])
REFERENCES [dbo].[Tests] ([Id])
GO

ALTER TABLE [dbo].[Table2] CHECK CONSTRAINT [FK_Table2_Tests]
GO

--------------------------------------------------------------------------