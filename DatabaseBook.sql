USE [master]
GO
/****** Object:  Database [BookGrotto]    Script Date: 2/19/2023 10:28:49 PM ******/
CREATE DATABASE [BookGrotto]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BookGrotto', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\BookGrotto.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'BookGrotto_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\BookGrotto_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [BookGrotto] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BookGrotto].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BookGrotto] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BookGrotto] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BookGrotto] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BookGrotto] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BookGrotto] SET ARITHABORT OFF 
GO
ALTER DATABASE [BookGrotto] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BookGrotto] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BookGrotto] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BookGrotto] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BookGrotto] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BookGrotto] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BookGrotto] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BookGrotto] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BookGrotto] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BookGrotto] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BookGrotto] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BookGrotto] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BookGrotto] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BookGrotto] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BookGrotto] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BookGrotto] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BookGrotto] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BookGrotto] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BookGrotto] SET  MULTI_USER 
GO
ALTER DATABASE [BookGrotto] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BookGrotto] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BookGrotto] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BookGrotto] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [BookGrotto] SET DELAYED_DURABILITY = DISABLED 
GO
USE [BookGrotto]
GO
/****** Object:  Table [dbo].[tb_Adv]    Script Date: 2/19/2023 10:28:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_Adv](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](250) NULL,
	[Description] [nvarchar](500) NULL,
	[Image] [nvarchar](500) NULL,
	[Type] [int] NULL,
	[Link] [nvarchar](500) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](150) NULL,
	[ModifierDate] [datetime] NULL,
	[ModifierBy] [nvarchar](150) NULL,
 CONSTRAINT [PK_tb_Adv] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_Category]    Script Date: 2/19/2023 10:28:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](150) NULL,
	[Description] [nvarchar](500) NULL,
	[Position] [int] NULL,
	[SeoTitle] [nvarchar](250) NULL,
	[SeoDescription] [nvarchar](550) NULL,
	[SeoKeywords] [nvarchar](250) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](150) NULL,
	[ModifierDate] [datetime] NULL,
	[ModifierBy] [nvarchar](150) NULL,
 CONSTRAINT [PK_tb_Menu] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_Contact]    Script Date: 2/19/2023 10:28:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_Contact](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NULL,
	[Website] [nvarchar](150) NULL,
	[Email] [nvarchar](150) NULL,
	[Message] [nvarchar](4000) NULL,
	[IsRead] [bit] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](150) NULL,
	[ModifierDate] [datetime] NULL,
	[ModifierBy] [nvarchar](150) NULL,
 CONSTRAINT [PK_tb_Contact] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_New]    Script Date: 2/19/2023 10:28:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_New](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](250) NULL,
	[CategoryId] [int] NULL,
	[Description] [nvarchar](4000) NULL,
	[Detail] [nvarchar](max) NULL,
	[Image] [nvarchar](500) NULL,
	[SeoTitle] [nvarchar](250) NULL,
	[SeoDescription] [nvarchar](550) NULL,
	[SeoKeywords] [nvarchar](250) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](150) NULL,
	[ModifierDate] [datetime] NULL,
	[ModifierBy] [nvarchar](150) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_Order]    Script Date: 2/19/2023 10:28:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_Order](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](50) NULL,
	[CustomerName] [nvarchar](150) NULL,
	[Phone] [nvarchar](15) NULL,
	[Address] [nvarchar](500) NULL,
	[TotalAmount] [decimal](18, 0) NULL,
	[Quantity] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](150) NULL,
	[ModifierDate] [datetime] NULL,
	[ModifierBy] [nvarchar](150) NULL,
 CONSTRAINT [PK_tb_Order] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_OrderDetail]    Script Date: 2/19/2023 10:28:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_OrderDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NULL,
	[ProductId] [int] NULL,
	[Price] [decimal](18, 0) NULL,
	[Quantity] [int] NULL,
 CONSTRAINT [PK_tb_OrderDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_Post]    Script Date: 2/19/2023 10:28:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_Post](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](250) NULL,
	[CategoryId] [int] NULL,
	[Description] [nvarchar](4000) NULL,
	[Detail] [nvarchar](max) NULL,
	[Image] [nvarchar](500) NULL,
	[SeoTitle] [nvarchar](250) NULL,
	[SeoDescription] [nvarchar](550) NULL,
	[SeoKeywords] [nvarchar](250) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](150) NULL,
	[ModifierDate] [datetime] NULL,
	[ModifierBy] [nvarchar](150) NULL,
 CONSTRAINT [PK_tb_Post] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_Product]    Script Date: 2/19/2023 10:28:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](250) NOT NULL,
	[ProductCategoryID] [int] NULL,
	[Description] [nvarchar](4000) NULL,
	[Detail] [nvarchar](max) NULL,
	[Image] [nvarchar](500) NULL,
	[Price] [decimal](18, 2) NULL,
	[PriceSale] [decimal](18, 2) NULL,
	[Quantity] [int] NULL,
	[SeoTitle] [nvarchar](250) NULL,
	[SeoDescription] [nvarchar](550) NULL,
	[SeoKeywords] [nvarchar](250) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](150) NULL,
	[ModifierDate] [datetime] NULL,
	[ModifierBy] [nvarchar](150) NULL,
 CONSTRAINT [PK_tb_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_ProductCategory]    Script Date: 2/19/2023 10:28:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_ProductCategory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](150) NULL,
	[Description] [nvarchar](500) NULL,
	[Icon] [nvarchar](500) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](150) NULL,
	[ModifierDate] [datetime] NULL,
	[ModifierBy] [nvarchar](150) NULL,
 CONSTRAINT [PK_tb_ProductCategory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_Subscribe]    Script Date: 2/19/2023 10:28:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_Subscribe](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](150) NULL,
	[CreatedDate] [datetime] NULL,
 CONSTRAINT [PK_tb_Sub] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_SystemSetting]    Script Date: 2/19/2023 10:28:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_SystemSetting](
	[SettingKey] [nvarchar](50) NOT NULL,
	[SettingValue] [nvarchar](max) NULL,
	[SettingDescription] [nvarchar](250) NULL,
 CONSTRAINT [PK_tb_SystemSetting] PRIMARY KEY CLUSTERED 
(
	[SettingKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [BookGrotto] SET  READ_WRITE 
GO
