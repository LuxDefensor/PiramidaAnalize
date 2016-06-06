USE [Piramida2000]
GO

/****** Object:  Table [dbo].[Balance]    Script Date: 05/31/2016 13:42:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Balance](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[No] [int] NULL,
	[Sign] [smallint] NULL,
	[Object] [int] NULL,
	[Item] [int] NULL,
	[Parnumber] [smallint] NULL,
 CONSTRAINT [PK_Balance] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

EXEC sys.sp_addextendedproperty @name=N'MS_Orientation', @value=0x00 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Balance'
GO

