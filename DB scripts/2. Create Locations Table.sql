USE [LocationsApi]
GO

/****** Object:  Table [dbo].[Locations]    Script Date: 4/04/2023 8:47:18 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Locations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
	[Address] [nvarchar](200) NOT NULL,
	[Email] [nvarchar](200) NOT NULL,
	[WebSite] [nvarchar](200) NOT NULL,
	[Phone] [nvarchar](15) NULL,
	[City] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO