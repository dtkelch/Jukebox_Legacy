USE [Jukebox]
GO
/****** Object:  User [tkelch]    Script Date: 04/29/2014 07:47:52 ******/
CREATE USER [Daniel] FOR LOGIN [Daniel-PC\Daniel] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[tblPlaylist]    Script Date: 04/29/2014 07:47:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblPlaylist](
	[PlaylistID] [int] IDENTITY(1,1) NOT NULL,
	[SongTitle] [varchar](50) NULL,
	[Score] [int] NULL,
	[Path] [varchar](150) NULL,
 CONSTRAINT [PK_tblPlaylist] PRIMARY KEY CLUSTERED 
(
	[PlaylistID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
