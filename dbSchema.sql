USE [USTCareers]
GO
/****** Object:  Table [dbo].[ApplicationForms]    Script Date: 9/22/2016 12:23:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ApplicationForms](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_name] [varchar](250) NOT NULL,
	[user_surname] [varchar](250) NOT NULL,
	[user_email] [varchar](250) NOT NULL,
	[confirmation_guid] [varchar](50) NOT NULL,
	[status] [int] NOT NULL,
	[job_offer_id] [int] NOT NULL,
 CONSTRAINT [PK_ApplicationForms] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ApplicationForms_Files]    Script Date: 9/22/2016 12:23:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApplicationForms_Files](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[application_form_id] [int] NOT NULL,
	[file_id] [int] NOT NULL,
 CONSTRAINT [PK_ApplicationForms_Files] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Categories]    Script Date: 9/22/2016 12:23:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Categories](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[parent_id] [int] NULL,
	[name] [varchar](250) NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Files]    Script Date: 9/22/2016 12:23:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Files](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[hash] [varchar](50) NOT NULL,
	[upload_date] [varchar](50) NOT NULL,
 CONSTRAINT [PK_File] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[JobOffers]    Script Date: 9/22/2016 12:23:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[JobOffers](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [varchar](250) NOT NULL,
	[description] [varchar](max) NOT NULL,
	[publish_date] [varchar](50) NOT NULL,
	[hash] [varchar](50) NOT NULL,
	[category_id] [int] NOT NULL,
	[location_id] [int] NOT NULL,
 CONSTRAINT [PK_JobOffer] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Locations]    Script Date: 9/22/2016 12:23:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Locations](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[city] [varchar](250) NOT NULL,
	[street] [varchar](250) NOT NULL,
	[house_number] [varchar](50) NOT NULL,
	[region_id] [int] NOT NULL,
 CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Regions]    Script Date: 9/22/2016 12:23:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Regions](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](250) NOT NULL,
 CONSTRAINT [PK_Region] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[ApplicationForms]  WITH CHECK ADD  CONSTRAINT [FK_ApplicationForms_JobOffers] FOREIGN KEY([job_offer_id])
REFERENCES [dbo].[JobOffers] ([id])
GO
ALTER TABLE [dbo].[ApplicationForms] CHECK CONSTRAINT [FK_ApplicationForms_JobOffers]
GO
ALTER TABLE [dbo].[ApplicationForms_Files]  WITH CHECK ADD  CONSTRAINT [FK_ApplicationForms_Files_ApplicationForms] FOREIGN KEY([application_form_id])
REFERENCES [dbo].[ApplicationForms] ([id])
GO
ALTER TABLE [dbo].[ApplicationForms_Files] CHECK CONSTRAINT [FK_ApplicationForms_Files_ApplicationForms]
GO
ALTER TABLE [dbo].[ApplicationForms_Files]  WITH CHECK ADD  CONSTRAINT [FK_ApplicationForms_Files_Files] FOREIGN KEY([file_id])
REFERENCES [dbo].[Files] ([id])
GO
ALTER TABLE [dbo].[ApplicationForms_Files] CHECK CONSTRAINT [FK_ApplicationForms_Files_Files]
GO
ALTER TABLE [dbo].[JobOffers]  WITH CHECK ADD  CONSTRAINT [FK_JobOffers_Categories] FOREIGN KEY([category_id])
REFERENCES [dbo].[Categories] ([id])
GO
ALTER TABLE [dbo].[JobOffers] CHECK CONSTRAINT [FK_JobOffers_Categories]
GO
ALTER TABLE [dbo].[JobOffers]  WITH CHECK ADD  CONSTRAINT [FK_JobOffers_Locations] FOREIGN KEY([location_id])
REFERENCES [dbo].[Locations] ([id])
GO
ALTER TABLE [dbo].[JobOffers] CHECK CONSTRAINT [FK_JobOffers_Locations]
GO
ALTER TABLE [dbo].[Locations]  WITH CHECK ADD  CONSTRAINT [FK_Locations_Regions] FOREIGN KEY([region_id])
REFERENCES [dbo].[Regions] ([id])
GO
ALTER TABLE [dbo].[Locations] CHECK CONSTRAINT [FK_Locations_Regions]
GO
