USE [master]
GO
/****** Object:  Database [Gilbert]    Script Date: 28/09/2021 10:48:20 ******/
CREATE DATABASE [Gilbert]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Gilbert', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Gilbert.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Gilbert_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Gilbert_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Gilbert] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Gilbert].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Gilbert] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Gilbert] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Gilbert] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Gilbert] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Gilbert] SET ARITHABORT OFF 
GO
ALTER DATABASE [Gilbert] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Gilbert] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Gilbert] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Gilbert] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Gilbert] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Gilbert] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Gilbert] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Gilbert] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Gilbert] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Gilbert] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Gilbert] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Gilbert] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Gilbert] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Gilbert] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Gilbert] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Gilbert] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Gilbert] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Gilbert] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Gilbert] SET  MULTI_USER 
GO
ALTER DATABASE [Gilbert] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Gilbert] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Gilbert] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Gilbert] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Gilbert] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Gilbert] SET QUERY_STORE = OFF
GO
USE [Gilbert]
GO
/****** Object:  Table [dbo].[CR_AD_Detail]    Script Date: 28/09/2021 10:48:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CR_AD_Detail](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[IDAdHeader] [bigint] NOT NULL,
	[IDPosition] [bigint] NOT NULL,
	[MinAge] [int] NULL,
	[MaxAge] [int] NULL,
	[IDEducation] [bigint] NOT NULL,
	[IDExperience] [bigint] NOT NULL,
	[Qty] [int] NOT NULL,
	[PositionDescript] [varchar](500) NULL,
	[TaskDescrip] [varchar](500) NULL,
	[IDStatus] [int] NOT NULL,
 CONSTRAINT [PK_CR_AD_Detail] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CR_AD_Header]    Script Date: 28/09/2021 10:48:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CR_AD_Header](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[IDUserCreator] [bigint] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[FinishDate] [datetime] NOT NULL,
	[SDescrip] [varchar](120) NULL,
	[LDescrip] [varchar](500) NULL,
	[IDStatus] [int] NOT NULL,
	[Unique_ID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_CR_AD_Header] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CR_Company]    Script Date: 28/09/2021 10:48:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CR_Company](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[CompanyName] [varchar](200) NOT NULL,
	[Street] [varchar](120) NOT NULL,
	[StreetNumber] [int] NOT NULL,
	[PostCode] [int] NOT NULL,
	[IDState] [bigint] NOT NULL,
	[Telephone] [varchar](20) NULL,
	[TaxId] [varchar](20) NOT NULL,
	[IDStatus] [int] NOT NULL,
 CONSTRAINT [PK_CR_Company] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CR_User]    Script Date: 28/09/2021 10:48:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CR_User](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[IDCompany] [bigint] NOT NULL,
	[Email] [varchar](256) NOT NULL,
	[UserName] [varchar](80) NOT NULL,
	[UserLastName] [varchar](80) NOT NULL,
	[Telephone] [varchar](30) NULL,
	[Password] [varchar](80) NOT NULL,
	[IDStatus] [int] NOT NULL,
 CONSTRAINT [PK_CR_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MD_Country]    Script Date: 28/09/2021 10:48:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MD_Country](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SDescrip] [varchar](120) NULL,
	[LDescrip] [varchar](500) NULL,
	[IDStatus] [int] NULL,
 CONSTRAINT [PK_MD_Country] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MD_EducationLevel]    Script Date: 28/09/2021 10:48:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MD_EducationLevel](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[SDescrip] [varchar](120) NULL,
	[LDescrip] [varchar](500) NULL,
	[IDStatus] [int] NULL,
 CONSTRAINT [PK_MD_EducationLevel] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MD_EducationRequired]    Script Date: 28/09/2021 10:48:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MD_EducationRequired](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[SDescrip] [varchar](120) NULL,
	[LDescrip] [varchar](500) NULL,
	[IDStatus] [int] NULL,
 CONSTRAINT [PK_MD_EducationRequired] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MD_EducationSegment]    Script Date: 28/09/2021 10:48:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MD_EducationSegment](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[SDescrip] [varchar](120) NULL,
	[LDescrip] [varchar](500) NULL,
	[IDStatus] [int] NULL,
 CONSTRAINT [PK_MD_EducationSegment] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MD_EducationStatus]    Script Date: 28/09/2021 10:48:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MD_EducationStatus](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[SDescrip] [varchar](120) NULL,
	[LDescrip] [varchar](500) NULL,
	[IDStatus] [int] NULL,
 CONSTRAINT [PK_MD_EducationStatus] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MD_ExperienceRequired]    Script Date: 28/09/2021 10:48:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MD_ExperienceRequired](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[SDescrip] [varchar](120) NULL,
	[LDescrip] [varchar](500) NULL,
	[IDStatus] [int] NULL,
 CONSTRAINT [PK_MD_ExperienceRequired] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MD_Position]    Script Date: 28/09/2021 10:48:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MD_Position](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[SDescrip] [varchar](120) NULL,
	[LDescrip] [varchar](500) NULL,
	[IDStatus] [int] NULL,
 CONSTRAINT [PK_MD_Position] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MD_State]    Script Date: 28/09/2021 10:48:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MD_State](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[SDescrip] [varchar](120) NULL,
	[LDescrip] [varchar](500) NULL,
	[IDStatus] [int] NULL,
	[IDCountry] [int] NOT NULL,
 CONSTRAINT [PK_MD_State] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MD_Status]    Script Date: 28/09/2021 10:48:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MD_Status](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SDescrip] [varchar](120) NOT NULL,
	[LDescrip] [varchar](500) NOT NULL,
 CONSTRAINT [PK_MD_Status] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[USER_CV_Education]    Script Date: 28/09/2021 10:48:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USER_CV_Education](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[IDCVHeader] [bigint] NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[FinishDate] [datetime] NULL,
	[IDEducationSegment] [bigint] NOT NULL,
	[IDEducationLevel] [bigint] NOT NULL,
	[IDEducationStatus] [bigint] NULL,
	[PlaceDescrip] [nchar](10) NULL,
	[IDStatus] [int] NOT NULL,
 CONSTRAINT [PK_USER_CV_Education] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[USER_CV_WorkExperience]    Script Date: 28/09/2021 10:48:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USER_CV_WorkExperience](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[IDCVHeader] [bigint] NOT NULL,
	[StartDate] [date] NOT NULL,
	[FinishDate] [date] NULL,
	[IDPosition] [bigint] NOT NULL,
	[PositionDescrip] [varchar](500) NULL,
	[TaskDescrip] [varchar](500) NULL,
	[IDStatus] [int] NOT NULL,
 CONSTRAINT [PK_USER_CV_WorkExperience] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[USR_CV_Header]    Script Date: 28/09/2021 10:48:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USR_CV_Header](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[IDUser] [bigint] NOT NULL,
	[Street] [varchar](120) NULL,
	[StreetNumber] [varchar](30) NULL,
	[PostCode] [varchar](10) NULL,
	[IDState] [bigint] NULL,
	[IDNationality] [bigint] NULL,
	[Birthdate] [date] NULL,
	[Age] [int] NULL,
	[IDStatus] [int] NOT NULL,
 CONSTRAINT [PK_USR_CV_Header] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[USR_User]    Script Date: 28/09/2021 10:48:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USR_User](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](256) NULL,
	[UserName] [varchar](80) NULL,
	[UserLastName] [varchar](80) NULL,
	[Telephone] [varchar](30) NOT NULL,
	[UserPhoto] [varchar](80) NOT NULL,
	[Password] [varchar](80) NULL,
	[IDStatus] [int] NOT NULL,
 CONSTRAINT [PK_USR_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CR_AD_Detail] ADD  CONSTRAINT [DF_CR_AD_Detail_IDStatus]  DEFAULT ((1)) FOR [IDStatus]
GO
ALTER TABLE [dbo].[CR_AD_Header] ADD  CONSTRAINT [DF_CR_AD_Header_CreationDate]  DEFAULT (getdate()) FOR [CreationDate]
GO
ALTER TABLE [dbo].[CR_AD_Header] ADD  CONSTRAINT [DF_CR_AD_Header_RowID]  DEFAULT (newid()) FOR [Unique_ID]
GO
ALTER TABLE [dbo].[CR_Company] ADD  CONSTRAINT [DF_CR_Company_IDStatus]  DEFAULT ((1)) FOR [IDStatus]
GO
ALTER TABLE [dbo].[CR_User] ADD  CONSTRAINT [DF_CR_User_IDStatus]  DEFAULT ((1)) FOR [IDStatus]
GO
ALTER TABLE [dbo].[USER_CV_Education] ADD  CONSTRAINT [DF_USER_CV_Education_IDStatus]  DEFAULT ((1)) FOR [IDStatus]
GO
ALTER TABLE [dbo].[USER_CV_WorkExperience] ADD  CONSTRAINT [DF_USER_CV_WorkExperience_IDStatus]  DEFAULT ((1)) FOR [IDStatus]
GO
ALTER TABLE [dbo].[USR_CV_Header] ADD  CONSTRAINT [DF_USR_CV_Header_IDStatus]  DEFAULT ((1)) FOR [IDStatus]
GO
ALTER TABLE [dbo].[USR_User] ADD  CONSTRAINT [DF_USR_User_IDStatus]  DEFAULT ((1)) FOR [IDStatus]
GO
ALTER TABLE [dbo].[CR_AD_Detail]  WITH CHECK ADD  CONSTRAINT [FK_CR_AD_Detail_CR_AD_Header] FOREIGN KEY([IDAdHeader])
REFERENCES [dbo].[CR_AD_Header] ([ID])
GO
ALTER TABLE [dbo].[CR_AD_Detail] CHECK CONSTRAINT [FK_CR_AD_Detail_CR_AD_Header]
GO
ALTER TABLE [dbo].[CR_AD_Detail]  WITH CHECK ADD  CONSTRAINT [FK_CR_AD_Detail_MD_EducationRequired] FOREIGN KEY([IDEducation])
REFERENCES [dbo].[MD_EducationRequired] ([ID])
GO
ALTER TABLE [dbo].[CR_AD_Detail] CHECK CONSTRAINT [FK_CR_AD_Detail_MD_EducationRequired]
GO
ALTER TABLE [dbo].[CR_AD_Detail]  WITH CHECK ADD  CONSTRAINT [FK_CR_AD_Detail_MD_ExperienceRequired] FOREIGN KEY([IDExperience])
REFERENCES [dbo].[MD_ExperienceRequired] ([ID])
GO
ALTER TABLE [dbo].[CR_AD_Detail] CHECK CONSTRAINT [FK_CR_AD_Detail_MD_ExperienceRequired]
GO
ALTER TABLE [dbo].[CR_AD_Detail]  WITH CHECK ADD  CONSTRAINT [FK_CR_AD_Detail_MD_Position] FOREIGN KEY([IDPosition])
REFERENCES [dbo].[MD_Position] ([ID])
GO
ALTER TABLE [dbo].[CR_AD_Detail] CHECK CONSTRAINT [FK_CR_AD_Detail_MD_Position]
GO
ALTER TABLE [dbo].[CR_AD_Header]  WITH CHECK ADD  CONSTRAINT [FK_CR_AD_Header_CR_User] FOREIGN KEY([IDUserCreator])
REFERENCES [dbo].[CR_User] ([ID])
GO
ALTER TABLE [dbo].[CR_AD_Header] CHECK CONSTRAINT [FK_CR_AD_Header_CR_User]
GO
ALTER TABLE [dbo].[CR_Company]  WITH CHECK ADD  CONSTRAINT [FK_CR_Company_MD_State] FOREIGN KEY([IDState])
REFERENCES [dbo].[MD_State] ([ID])
GO
ALTER TABLE [dbo].[CR_Company] CHECK CONSTRAINT [FK_CR_Company_MD_State]
GO
ALTER TABLE [dbo].[CR_User]  WITH CHECK ADD  CONSTRAINT [FK_CR_User_CR_Company] FOREIGN KEY([IDCompany])
REFERENCES [dbo].[CR_Company] ([ID])
GO
ALTER TABLE [dbo].[CR_User] CHECK CONSTRAINT [FK_CR_User_CR_Company]
GO
ALTER TABLE [dbo].[MD_State]  WITH CHECK ADD  CONSTRAINT [FK_MD_State_MD_Country] FOREIGN KEY([IDCountry])
REFERENCES [dbo].[MD_Country] ([ID])
GO
ALTER TABLE [dbo].[MD_State] CHECK CONSTRAINT [FK_MD_State_MD_Country]
GO
ALTER TABLE [dbo].[USER_CV_Education]  WITH CHECK ADD  CONSTRAINT [FK_USER_CV_Education_MD_EducationLevel] FOREIGN KEY([IDEducationLevel])
REFERENCES [dbo].[MD_EducationLevel] ([ID])
GO
ALTER TABLE [dbo].[USER_CV_Education] CHECK CONSTRAINT [FK_USER_CV_Education_MD_EducationLevel]
GO
ALTER TABLE [dbo].[USER_CV_Education]  WITH CHECK ADD  CONSTRAINT [FK_USER_CV_Education_MD_EducationSegment] FOREIGN KEY([IDEducationSegment])
REFERENCES [dbo].[MD_EducationSegment] ([ID])
GO
ALTER TABLE [dbo].[USER_CV_Education] CHECK CONSTRAINT [FK_USER_CV_Education_MD_EducationSegment]
GO
ALTER TABLE [dbo].[USER_CV_Education]  WITH CHECK ADD  CONSTRAINT [FK_USER_CV_Education_MD_EducationStatus] FOREIGN KEY([IDEducationStatus])
REFERENCES [dbo].[MD_EducationStatus] ([ID])
GO
ALTER TABLE [dbo].[USER_CV_Education] CHECK CONSTRAINT [FK_USER_CV_Education_MD_EducationStatus]
GO
ALTER TABLE [dbo].[USER_CV_Education]  WITH CHECK ADD  CONSTRAINT [FK_USER_CV_Education_USR_CV_Header] FOREIGN KEY([IDCVHeader])
REFERENCES [dbo].[USR_CV_Header] ([ID])
GO
ALTER TABLE [dbo].[USER_CV_Education] CHECK CONSTRAINT [FK_USER_CV_Education_USR_CV_Header]
GO
ALTER TABLE [dbo].[USER_CV_WorkExperience]  WITH CHECK ADD  CONSTRAINT [FK_USER_CV_WorkExperience_MD_Position] FOREIGN KEY([IDPosition])
REFERENCES [dbo].[MD_Position] ([ID])
GO
ALTER TABLE [dbo].[USER_CV_WorkExperience] CHECK CONSTRAINT [FK_USER_CV_WorkExperience_MD_Position]
GO
ALTER TABLE [dbo].[USER_CV_WorkExperience]  WITH CHECK ADD  CONSTRAINT [FK_USER_CV_WorkExperience_USR_CV_Header] FOREIGN KEY([IDCVHeader])
REFERENCES [dbo].[USR_CV_Header] ([ID])
GO
ALTER TABLE [dbo].[USER_CV_WorkExperience] CHECK CONSTRAINT [FK_USER_CV_WorkExperience_USR_CV_Header]
GO
ALTER TABLE [dbo].[USR_CV_Header]  WITH CHECK ADD  CONSTRAINT [FK_USR_CV_Header_MD_State] FOREIGN KEY([IDState])
REFERENCES [dbo].[MD_State] ([ID])
GO
ALTER TABLE [dbo].[USR_CV_Header] CHECK CONSTRAINT [FK_USR_CV_Header_MD_State]
GO
ALTER TABLE [dbo].[USR_CV_Header]  WITH CHECK ADD  CONSTRAINT [FK_USR_CV_Header_USR_User] FOREIGN KEY([IDUser])
REFERENCES [dbo].[USR_User] ([ID])
GO
ALTER TABLE [dbo].[USR_CV_Header] CHECK CONSTRAINT [FK_USR_CV_Header_USR_User]
GO
USE [master]
GO
ALTER DATABASE [Gilbert] SET  READ_WRITE 
GO
