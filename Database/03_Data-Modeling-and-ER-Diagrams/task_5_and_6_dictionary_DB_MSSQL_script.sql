USE [master]
GO
/****** Object:  Database [Dictionary]    Script Date: 23.8.2014 г. 16:49:01 ч. ******/
CREATE DATABASE [Dictionary]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Dictionary', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Dictionary.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Dictionary_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Dictionary_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Dictionary] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Dictionary].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Dictionary] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Dictionary] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Dictionary] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Dictionary] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Dictionary] SET ARITHABORT OFF 
GO
ALTER DATABASE [Dictionary] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Dictionary] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Dictionary] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Dictionary] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Dictionary] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Dictionary] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Dictionary] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Dictionary] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Dictionary] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Dictionary] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Dictionary] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Dictionary] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Dictionary] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Dictionary] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Dictionary] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Dictionary] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Dictionary] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Dictionary] SET RECOVERY FULL 
GO
ALTER DATABASE [Dictionary] SET  MULTI_USER 
GO
ALTER DATABASE [Dictionary] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Dictionary] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Dictionary] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Dictionary] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Dictionary] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Dictionary', N'ON'
GO
USE [Dictionary]
GO
/****** Object:  Table [dbo].[HypernymHyponyms]    Script Date: 23.8.2014 г. 16:49:01 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HypernymHyponyms](
	[hypernymID] [int] NOT NULL,
	[hyponymID] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Language]    Script Date: 23.8.2014 г. 16:49:01 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Language](
	[languageID] [int] IDENTITY(1,1) NOT NULL,
	[language] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Language] PRIMARY KEY CLUSTERED 
(
	[languageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PartOfSpeechInformation]    Script Date: 23.8.2014 г. 16:49:01 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PartOfSpeechInformation](
	[partOfSpeechID] [int] IDENTITY(1,1) NOT NULL,
	[information] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_PartOfSpeechInformation] PRIMARY KEY CLUSTERED 
(
	[partOfSpeechID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Words]    Script Date: 23.8.2014 г. 16:49:01 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Words](
	[wordID] [int] IDENTITY(1,1) NOT NULL,
	[word] [nvarchar](50) NOT NULL,
	[languageID] [int] NOT NULL,
	[explanation] [ntext] NULL,
	[antonymID] [int] NULL,
	[partOfSpeechID] [int] NULL,
 CONSTRAINT [PK_Words] PRIMARY KEY CLUSTERED 
(
	[wordID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[WordSynonyms]    Script Date: 23.8.2014 г. 16:49:01 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WordSynonyms](
	[wordID] [int] NOT NULL,
	[synonymID] [int] NOT NULL,
 CONSTRAINT [PK_WordSynonyms] PRIMARY KEY CLUSTERED 
(
	[wordID] ASC,
	[synonymID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[WordTranslation]    Script Date: 23.8.2014 г. 16:49:01 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WordTranslation](
	[wordID] [int] NOT NULL,
	[translationWordID] [int] NOT NULL,
 CONSTRAINT [PK_WordTranslation] PRIMARY KEY CLUSTERED 
(
	[wordID] ASC,
	[translationWordID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[HypernymHyponyms]  WITH CHECK ADD  CONSTRAINT [FK_HypernymHyponyms_Words] FOREIGN KEY([hypernymID])
REFERENCES [dbo].[Words] ([wordID])
GO
ALTER TABLE [dbo].[HypernymHyponyms] CHECK CONSTRAINT [FK_HypernymHyponyms_Words]
GO
ALTER TABLE [dbo].[HypernymHyponyms]  WITH CHECK ADD  CONSTRAINT [FK_HypernymHyponyms_Words1] FOREIGN KEY([hyponymID])
REFERENCES [dbo].[Words] ([wordID])
GO
ALTER TABLE [dbo].[HypernymHyponyms] CHECK CONSTRAINT [FK_HypernymHyponyms_Words1]
GO
ALTER TABLE [dbo].[Words]  WITH CHECK ADD  CONSTRAINT [FK_Words_Language] FOREIGN KEY([languageID])
REFERENCES [dbo].[Language] ([languageID])
GO
ALTER TABLE [dbo].[Words] CHECK CONSTRAINT [FK_Words_Language]
GO
ALTER TABLE [dbo].[Words]  WITH CHECK ADD  CONSTRAINT [FK_Words_PartOfSpeechInformation] FOREIGN KEY([partOfSpeechID])
REFERENCES [dbo].[PartOfSpeechInformation] ([partOfSpeechID])
GO
ALTER TABLE [dbo].[Words] CHECK CONSTRAINT [FK_Words_PartOfSpeechInformation]
GO
ALTER TABLE [dbo].[Words]  WITH CHECK ADD  CONSTRAINT [FK_Words_Words] FOREIGN KEY([antonymID])
REFERENCES [dbo].[Words] ([wordID])
GO
ALTER TABLE [dbo].[Words] CHECK CONSTRAINT [FK_Words_Words]
GO
ALTER TABLE [dbo].[WordSynonyms]  WITH CHECK ADD  CONSTRAINT [FK_WordSynonyms_Words] FOREIGN KEY([wordID])
REFERENCES [dbo].[Words] ([wordID])
GO
ALTER TABLE [dbo].[WordSynonyms] CHECK CONSTRAINT [FK_WordSynonyms_Words]
GO
ALTER TABLE [dbo].[WordSynonyms]  WITH CHECK ADD  CONSTRAINT [FK_WordSynonyms_Words1] FOREIGN KEY([synonymID])
REFERENCES [dbo].[Words] ([wordID])
GO
ALTER TABLE [dbo].[WordSynonyms] CHECK CONSTRAINT [FK_WordSynonyms_Words1]
GO
ALTER TABLE [dbo].[WordTranslation]  WITH CHECK ADD  CONSTRAINT [FK_WordTranslation_Words] FOREIGN KEY([wordID])
REFERENCES [dbo].[Words] ([wordID])
GO
ALTER TABLE [dbo].[WordTranslation] CHECK CONSTRAINT [FK_WordTranslation_Words]
GO
ALTER TABLE [dbo].[WordTranslation]  WITH CHECK ADD  CONSTRAINT [FK_WordTranslation_Words1] FOREIGN KEY([translationWordID])
REFERENCES [dbo].[Words] ([wordID])
GO
ALTER TABLE [dbo].[WordTranslation] CHECK CONSTRAINT [FK_WordTranslation_Words1]
GO
USE [master]
GO
ALTER DATABASE [Dictionary] SET  READ_WRITE 
GO
