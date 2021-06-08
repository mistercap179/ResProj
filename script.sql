USE [Description]
GO
/****** Object:  Table [dbo].[DescriptionT]    Script Date: 5.6.2021. 13:34:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DescriptionT](
	[Code] [int] NOT NULL,
	[Value] [int] NULL,
	[TimeStamp] [datetime] NULL,
	[DataSet] [int] NOT NULL
) ON [PRIMARY]
GO
INSERT [dbo].[DescriptionT] ([Code], [Value], [TimeStamp], [DataSet]) VALUES (1, 15, CAST(N'2021-06-02T18:58:55.140' AS DateTime), 1)
INSERT [dbo].[DescriptionT] ([Code], [Value], [TimeStamp], [DataSet]) VALUES (2, 1, CAST(N'2021-06-02T18:54:58.083' AS DateTime), 1)
INSERT [dbo].[DescriptionT] ([Code], [Value], [TimeStamp], [DataSet]) VALUES (3, NULL, NULL, 2)
INSERT [dbo].[DescriptionT] ([Code], [Value], [TimeStamp], [DataSet]) VALUES (5, NULL, NULL, 3)
INSERT [dbo].[DescriptionT] ([Code], [Value], [TimeStamp], [DataSet]) VALUES (6, 55, CAST(N'2021-06-01T20:57:33.690' AS DateTime), 3)
INSERT [dbo].[DescriptionT] ([Code], [Value], [TimeStamp], [DataSet]) VALUES (8, NULL, NULL, 4)
INSERT [dbo].[DescriptionT] ([Code], [Value], [TimeStamp], [DataSet]) VALUES (4, 40, CAST(N'2021-06-02T13:49:42.473' AS DateTime), 2)
INSERT [dbo].[DescriptionT] ([Code], [Value], [TimeStamp], [DataSet]) VALUES (7, 22, CAST(N'2021-06-02T13:49:42.473' AS DateTime), 4)
GO
