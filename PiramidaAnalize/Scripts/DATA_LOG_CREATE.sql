USE [Piramida2000]
GO

/****** Object:  Table [dbo].[Data_log]    Script Date: 05/24/2016 11:14:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Data_log](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Object] [int] NOT NULL,
	[Item] [int] NOT NULL,
	[Data_date] [datetime] NOT NULL,
	[Parnumber] [int] NOT NULL,
	[Value] [float] NULL,
	[TimeStamp] [datetime] NOT NULL,
	[Action] [nvarchar](20) NOT NULL,
	[User_name] [nvarchar](20) NOT NULL,
	[Host_name] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Data_log] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


