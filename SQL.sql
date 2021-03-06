USE [master]
GO
/****** Object:  Database [Ecommerce]    Script Date: 03/03/2022 21:05:06 ******/
CREATE DATABASE [Ecommerce]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Ecommerce', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Ecommerce.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Ecommerce_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Ecommerce_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Ecommerce] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Ecommerce].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Ecommerce] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Ecommerce] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Ecommerce] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Ecommerce] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Ecommerce] SET ARITHABORT OFF 
GO
ALTER DATABASE [Ecommerce] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Ecommerce] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Ecommerce] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Ecommerce] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Ecommerce] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Ecommerce] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Ecommerce] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Ecommerce] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Ecommerce] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Ecommerce] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Ecommerce] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Ecommerce] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Ecommerce] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Ecommerce] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Ecommerce] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Ecommerce] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Ecommerce] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Ecommerce] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Ecommerce] SET  MULTI_USER 
GO
ALTER DATABASE [Ecommerce] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Ecommerce] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Ecommerce] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Ecommerce] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Ecommerce] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Ecommerce] SET QUERY_STORE = OFF
GO
USE [Ecommerce]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 03/03/2022 21:05:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[Email] [varchar](40) NOT NULL,
	[PassWord] [varchar](40) NULL,
	[Role] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cart]    Script Date: 03/03/2022 21:05:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cart](
	[IdCart] [int] IDENTITY(1,1) NOT NULL,
	[IdCus] [int] NULL,
	[IdPro] [int] NULL,
	[Number] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCart] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 03/03/2022 21:05:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[IdCus] [int] IDENTITY(1,1) NOT NULL,
	[CodeCus] [varchar](10) NULL,
	[NameCus] [ntext] NULL,
	[DateOfBirth] [date] NULL,
	[Phone] [char](10) NULL,
	[Email] [varchar](40) NULL,
	[Address] [ntext] NULL,
	[CMND] [char](12) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCus] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 03/03/2022 21:05:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[IdOrder] [int] IDENTITY(1,1) NOT NULL,
	[IdCus] [int] NULL,
	[IdPro] [int] NULL,
	[Number] [int] NULL,
	[SumPrice] [float] NULL,
	[Address] [ntext] NULL,
	[Status] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdOrder] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 03/03/2022 21:05:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[IdPro] [int] IDENTITY(1,1) NOT NULL,
	[CodePro] [varchar](10) NULL,
	[NamePro] [ntext] NULL,
	[Price] [float] NULL,
	[Amount] [int] NULL,
	[Image] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdPro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[Account] ([Email], [PassWord], [Role]) VALUES (N'duonghaiyen@gmail.com', N'12345', 1)
INSERT [dbo].[Account] ([Email], [PassWord], [Role]) VALUES (N'phanduclong@gmail.com', N'12345', 1)
INSERT [dbo].[Account] ([Email], [PassWord], [Role]) VALUES (N'trunglethanh@gmail.com', N'12345', 0)
GO
SET IDENTITY_INSERT [dbo].[Cart] ON 

INSERT [dbo].[Cart] ([IdCart], [IdCus], [IdPro], [Number]) VALUES (3, 2, 1, 3)
INSERT [dbo].[Cart] ([IdCart], [IdCus], [IdPro], [Number]) VALUES (6, 2, 5, 3)
INSERT [dbo].[Cart] ([IdCart], [IdCus], [IdPro], [Number]) VALUES (7, 2, 2, 1)
SET IDENTITY_INSERT [dbo].[Cart] OFF
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([IdCus], [CodeCus], [NameCus], [DateOfBirth], [Phone], [Email], [Address], [CMND]) VALUES (1, N'Cus1', N'Dương Hải Yến', CAST(N'2001-04-20' AS Date), N'0365124136', N'duonghaiyen@gmail.com', N'Quảng Nam', N'044236541236')
INSERT [dbo].[Customer] ([IdCus], [CodeCus], [NameCus], [DateOfBirth], [Phone], [Email], [Address], [CMND]) VALUES (2, N'Cus2', N'Phan Đức Long', CAST(N'2001-06-11' AS Date), N'0365124136', N'phanduclong@gmail.com', N'Quảng Ngãi', N'044236541236')
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([IdOrder], [IdCus], [IdPro], [Number], [SumPrice], [Address], [Status]) VALUES (2, 1, 3, 2, 400000, N'Qu
', 1)
INSERT [dbo].[Orders] ([IdOrder], [IdCus], [IdPro], [Number], [SumPrice], [Address], [Status]) VALUES (3, 1, 1, 3, 7500000, N'Qu
', 2)
INSERT [dbo].[Orders] ([IdOrder], [IdCus], [IdPro], [Number], [SumPrice], [Address], [Status]) VALUES (4, 2, 3, 2, 400000, N'lk', 0)
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([IdPro], [CodePro], [NamePro], [Price], [Amount], [Image]) VALUES (1, N'GHK', N'Giường hộc kéo Iris 1m6 Stone', 2400000, 20, N'/images/Product/GHK.jpg')
INSERT [dbo].[Product] ([IdPro], [CodePro], [NamePro], [Price], [Amount], [Image]) VALUES (2, N'BTD', N'Bàn trang điểm và đôn Hamony', 1200000, 11, N'/images/Product/BTD.jpg')
INSERT [dbo].[Product] ([IdPro], [CodePro], [NamePro], [Price], [Amount], [Image]) VALUES (3, N'NSV', N'Nệm Sen Việt', 200000, 25, N'/images/Product/NSV.jpg')
INSERT [dbo].[Product] ([IdPro], [CodePro], [NamePro], [Price], [Amount], [Image]) VALUES (4, N'BDG', N'Bàn đầu giường Mây', 500000, 10, N'/images/Product/BDG.jpg')
INSERT [dbo].[Product] ([IdPro], [CodePro], [NamePro], [Price], [Amount], [Image]) VALUES (5, N'GMC', N'Ghế một chân', 600000, 20, N'/images/Product/GMC..jpg')
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
ALTER TABLE [dbo].[Cart]  WITH CHECK ADD  CONSTRAINT [FK_Cart_Product] FOREIGN KEY([IdPro])
REFERENCES [dbo].[Product] ([IdPro])
GO
ALTER TABLE [dbo].[Cart] CHECK CONSTRAINT [FK_Cart_Product]
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_Account] FOREIGN KEY([Email])
REFERENCES [dbo].[Account] ([Email])
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_Account]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Customer] FOREIGN KEY([IdCus])
REFERENCES [dbo].[Customer] ([IdCus])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Customer]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Product] FOREIGN KEY([IdPro])
REFERENCES [dbo].[Product] ([IdPro])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Product]
GO
USE [master]
GO
ALTER DATABASE [Ecommerce] SET  READ_WRITE 
GO
