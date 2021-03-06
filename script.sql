USE [Description]
GO

/****** Object:  Table [dbo].[DescriptionT]    Script Date: 8.6.2021. 22:55:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[DescriptionT](
	[Code] [int] NOT NULL,
	[Value] [int] NULL,
	[TimeStamp] [datetime] NULL,
	[DataSet] [int] NOT NULL,
	[ID] [int] IDENTITY(0,1) NOT NULL,
 CONSTRAINT [PK_DescriptionT] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


