USE [LocationsApi]
GO

/****** Object:  Table [dbo].[Schedules]    Script Date: 4/04/2023 9:03:20 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Schedules](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Day] [nvarchar](50) NOT NULL,
	[Open] [time] NOT NULL,
	[Close] [time] NOT NULL,
	[Observation] [nvarchar](50) NOT NULL,
	[LocationId] [int] NOT NULL,
 CONSTRAINT [PK_Schedules] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Schedules]  WITH CHECK ADD  CONSTRAINT [FK_Schedules_Locations_Id] FOREIGN KEY([LocationId])
REFERENCES [dbo].[Locations] ([Id])
GO

ALTER TABLE [dbo].[Schedules] CHECK CONSTRAINT [FK_Schedules_Locations_Id]
GO