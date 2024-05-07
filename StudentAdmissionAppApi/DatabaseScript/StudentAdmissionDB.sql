USE [StudentAdmissionDB]
GO
/****** Object:  StoredProcedure [dbo].[SP_StudentAdmission]    Script Date: 4/19/2024 5:47:41 PM ******/
DROP PROCEDURE IF EXISTS [dbo].[SP_StudentAdmission]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Students]') AND type in (N'U'))
ALTER TABLE [dbo].[Students] DROP CONSTRAINT IF EXISTS [FK_Students_Standards]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Students]') AND type in (N'U'))
ALTER TABLE [dbo].[Students] DROP CONSTRAINT IF EXISTS [FK_Students_Stages]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Standards]') AND type in (N'U'))
ALTER TABLE [dbo].[Standards] DROP CONSTRAINT IF EXISTS [FK_Standards_Standards]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 4/19/2024 5:47:41 PM ******/
DROP TABLE IF EXISTS [dbo].[Students]
GO
/****** Object:  Table [dbo].[Standards]    Script Date: 4/19/2024 5:47:41 PM ******/
DROP TABLE IF EXISTS [dbo].[Standards]
GO
/****** Object:  Table [dbo].[Stages]    Script Date: 4/19/2024 5:47:41 PM ******/
DROP TABLE IF EXISTS [dbo].[Stages]
GO
/****** Object:  Table [dbo].[Stages]    Script Date: 4/19/2024 5:47:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stages](
	[StageId] [int] IDENTITY(1,1) NOT NULL,
	[StageName] [varchar](20) NOT NULL,
	[StageDescription] [varchar](max) NULL,
 CONSTRAINT [PK__Stages__03EB7AD80BD5AB62] PRIMARY KEY CLUSTERED 
(
	[StageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Standards]    Script Date: 4/19/2024 5:47:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Standards](
	[StandardId] [int] IDENTITY(1,1) NOT NULL,
	[StandardName] [varchar](50) NOT NULL,
	[ClassTeacherName] [varchar](50) NULL,
	[StageId] [int] NOT NULL,
 CONSTRAINT [PK_Standards] PRIMARY KEY CLUSTERED 
(
	[StandardId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 4/19/2024 5:47:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[StudentId] [int] IDENTITY(1,1) NOT NULL,
	[StageId] [int] NOT NULL,
	[StandardId] [int] NOT NULL,
	[StudentName] [varchar](50) NOT NULL,
	[StudentEmail] [varchar](50) NOT NULL,
	[IsPhysicallyDisabled] [bit] NOT NULL,
	[Gender] [varchar](1) NOT NULL,
	[DateOfApplication] [date] NOT NULL,
	[Image] [varchar](150) NULL,
	[Maths] [decimal](18, 0) NULL,
	[Science] [decimal](18, 0) NULL,
	[SocialStudies] [decimal](18, 0) NULL,
	[Hindi] [decimal](18, 0) NULL,
	[English] [decimal](18, 0) NULL,
	[Chemistry] [decimal](18, 0) NULL,
	[Biology] [decimal](18, 0) NULL,
	[Physics] [decimal](18, 0) NULL,
	[TotalMarks] [decimal](18, 0) NULL,
	[Percentages] [decimal](18, 0) NULL,
	[IsAdmisisonConfirmed] [bit] NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Stages] ON 
GO
INSERT [dbo].[Stages] ([StageId], [StageName], [StageDescription]) VALUES (1, N'Elementary', N'Standard 5 to Standard 7')
GO
INSERT [dbo].[Stages] ([StageId], [StageName], [StageDescription]) VALUES (2, N'Secondary', N'Standard 8 to Standard 10')
GO
INSERT [dbo].[Stages] ([StageId], [StageName], [StageDescription]) VALUES (3, N'Higher Secondary ', N'Standard 11 and 12')
GO
SET IDENTITY_INSERT [dbo].[Stages] OFF
GO
SET IDENTITY_INSERT [dbo].[Standards] ON 
GO
INSERT [dbo].[Standards] ([StandardId], [StandardName], [ClassTeacherName], [StageId]) VALUES (1, N'Fifth', N'William', 1)
GO
INSERT [dbo].[Standards] ([StandardId], [StandardName], [ClassTeacherName], [StageId]) VALUES (2, N'Sixth', N'John', 1)
GO
INSERT [dbo].[Standards] ([StandardId], [StandardName], [ClassTeacherName], [StageId]) VALUES (3, N'Seventh', N'Jonathan', 1)
GO
INSERT [dbo].[Standards] ([StandardId], [StandardName], [ClassTeacherName], [StageId]) VALUES (4, N'Eighth', N'Johnson', 2)
GO
INSERT [dbo].[Standards] ([StandardId], [StandardName], [ClassTeacherName], [StageId]) VALUES (5, N'Ninth', N'James', 2)
GO
INSERT [dbo].[Standards] ([StandardId], [StandardName], [ClassTeacherName], [StageId]) VALUES (6, N'Tenth', N'Jack', 2)
GO
INSERT [dbo].[Standards] ([StandardId], [StandardName], [ClassTeacherName], [StageId]) VALUES (7, N'Eleventh', N'Jacky', 3)
GO
INSERT [dbo].[Standards] ([StandardId], [StandardName], [ClassTeacherName], [StageId]) VALUES (8, N'Twelfth', N'Tom', 3)
GO
SET IDENTITY_INSERT [dbo].[Standards] OFF
GO
SET IDENTITY_INSERT [dbo].[Students] ON 
GO
INSERT [dbo].[Students] ([StudentId], [StageId], [StandardId], [StudentName], [StudentEmail], [IsPhysicallyDisabled], [Gender], [DateOfApplication], [Image], [Maths], [Science], [SocialStudies], [Hindi], [English], [Chemistry], [Biology], [Physics], [TotalMarks], [Percentages], [IsAdmisisonConfirmed]) VALUES (2, 1, 1, N'string', N'string', 1, N'M', CAST(N'2024-04-18' AS Date), N'string', CAST(0 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), NULL, NULL, NULL)
GO
INSERT [dbo].[Students] ([StudentId], [StageId], [StandardId], [StudentName], [StudentEmail], [IsPhysicallyDisabled], [Gender], [DateOfApplication], [Image], [Maths], [Science], [SocialStudies], [Hindi], [English], [Chemistry], [Biology], [Physics], [TotalMarks], [Percentages], [IsAdmisisonConfirmed]) VALUES (3, 1, 1, N'gaurang', N'gaurang@gmail.com', 0, N'M', CAST(N'2024-04-18' AS Date), N'string', CAST(75 AS Decimal(18, 0)), CAST(66 AS Decimal(18, 0)), CAST(76 AS Decimal(18, 0)), CAST(65 AS Decimal(18, 0)), CAST(76 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), NULL, NULL, NULL)
GO
INSERT [dbo].[Students] ([StudentId], [StageId], [StandardId], [StudentName], [StudentEmail], [IsPhysicallyDisabled], [Gender], [DateOfApplication], [Image], [Maths], [Science], [SocialStudies], [Hindi], [English], [Chemistry], [Biology], [Physics], [TotalMarks], [Percentages], [IsAdmisisonConfirmed]) VALUES (4, 3, 7, N'Shrey', N'shrey@gmail.com', 0, N'M', CAST(N'2024-04-18' AS Date), N'string', CAST(65 AS Decimal(18, 0)), CAST(43 AS Decimal(18, 0)), CAST(43 AS Decimal(18, 0)), CAST(65 AS Decimal(18, 0)), CAST(54 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), NULL, NULL, NULL)
GO
INSERT [dbo].[Students] ([StudentId], [StageId], [StandardId], [StudentName], [StudentEmail], [IsPhysicallyDisabled], [Gender], [DateOfApplication], [Image], [Maths], [Science], [SocialStudies], [Hindi], [English], [Chemistry], [Biology], [Physics], [TotalMarks], [Percentages], [IsAdmisisonConfirmed]) VALUES (5, 2, 5, N'Shubham', N'shubham@gail.com', 0, N'M', CAST(N'2024-04-19' AS Date), N'string', CAST(43 AS Decimal(18, 0)), CAST(87 AS Decimal(18, 0)), CAST(87 AS Decimal(18, 0)), CAST(76 AS Decimal(18, 0)), CAST(76 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(369 AS Decimal(18, 0)), CAST(74 AS Decimal(18, 0)), NULL)
GO
SET IDENTITY_INSERT [dbo].[Students] OFF
GO
ALTER TABLE [dbo].[Standards]  WITH CHECK ADD  CONSTRAINT [FK_Standards_Standards] FOREIGN KEY([StageId])
REFERENCES [dbo].[Stages] ([StageId])
GO
ALTER TABLE [dbo].[Standards] CHECK CONSTRAINT [FK_Standards_Standards]
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_Stages] FOREIGN KEY([StageId])
REFERENCES [dbo].[Stages] ([StageId])
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_Stages]
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_Standards] FOREIGN KEY([StandardId])
REFERENCES [dbo].[Standards] ([StandardId])
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_Standards]
GO
/****** Object:  StoredProcedure [dbo].[SP_StudentAdmission]    Script Date: 4/19/2024 5:47:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[SP_StudentAdmission]

AS
BEGIN

	SET NOCOUNT ON;

	SELECT st.stagename , sn.standardname, Count(s.StandardId)
		AS totalstudent
	FROM stages st INNER JOIN standards sn
	ON st.stageid = sn.stageid LEFT JOIN students s
	ON sn.standardid=s.standardid
	GROUP BY st.stagename,sn.standardname;
END
GO
