USE [master]
GO
/****** Object:  Database [WM]    Script Date: 12/6/2019 12:55:54 PM ******/
CREATE DATABASE [WM]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'WM', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\WM.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'WM_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\WM_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [WM] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [WM].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [WM] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [WM] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [WM] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [WM] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [WM] SET ARITHABORT OFF 
GO
ALTER DATABASE [WM] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [WM] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [WM] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [WM] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [WM] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [WM] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [WM] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [WM] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [WM] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [WM] SET  DISABLE_BROKER 
GO
ALTER DATABASE [WM] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [WM] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [WM] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [WM] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [WM] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [WM] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [WM] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [WM] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [WM] SET  MULTI_USER 
GO
ALTER DATABASE [WM] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [WM] SET DB_CHAINING OFF 
GO
ALTER DATABASE [WM] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [WM] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [WM] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [WM] SET QUERY_STORE = OFF
GO
USE [WM]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [WM]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 12/6/2019 12:55:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[category_id] [int] IDENTITY(1,1) NOT NULL,
	[category_name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[category_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Manufacturer]    Script Date: 12/6/2019 12:55:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Manufacturer](
	[manufacturer_id] [int] IDENTITY(1,1) NOT NULL,
	[manufacturer_name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Manufacturer] PRIMARY KEY CLUSTERED 
(
	[manufacturer_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 12/6/2019 12:55:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[product_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[description] [nvarchar](250) NOT NULL,
	[price] [decimal](18, 2) NOT NULL,
	[category_id] [int] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[product_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductManufacturer]    Script Date: 12/6/2019 12:55:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductManufacturer](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[product_id] [int] NOT NULL,
	[manufacturer_id] [int] NOT NULL,
 CONSTRAINT [PK_ProductManufacturer] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductSupplier]    Script Date: 12/6/2019 12:55:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductSupplier](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[product_id] [int] NOT NULL,
	[supplier_id] [int] NOT NULL,
 CONSTRAINT [PK_ProductSupplier] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Supplier]    Script Date: 12/6/2019 12:55:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplier](
	[supplier_id] [int] IDENTITY(1,1) NOT NULL,
	[supplier_name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Supplier] PRIMARY KEY CLUSTERED 
(
	[supplier_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([category_id], [category_name]) VALUES (1, N'Lifestyle')
INSERT [dbo].[Category] ([category_id], [category_name]) VALUES (2, N'Sport')
SET IDENTITY_INSERT [dbo].[Category] OFF
SET IDENTITY_INSERT [dbo].[Manufacturer] ON 

INSERT [dbo].[Manufacturer] ([manufacturer_id], [manufacturer_name]) VALUES (1, N'Nike')
INSERT [dbo].[Manufacturer] ([manufacturer_id], [manufacturer_name]) VALUES (2, N'Addidas')
INSERT [dbo].[Manufacturer] ([manufacturer_id], [manufacturer_name]) VALUES (3, N'CocaCola')
SET IDENTITY_INSERT [dbo].[Manufacturer] OFF
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([product_id], [name], [description], [price], [category_id]) VALUES (1, N'Patike', N'Ovo su mnogo brze patike', CAST(999.99 AS Decimal(18, 2)), 2)
INSERT [dbo].[Product] ([product_id], [name], [description], [price], [category_id]) VALUES (2, N'Majica', N'Opustena jako', CAST(5.20 AS Decimal(18, 2)), 1)
INSERT [dbo].[Product] ([product_id], [name], [description], [price], [category_id]) VALUES (3, N'test', N'esadadas', CAST(412.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Product] ([product_id], [name], [description], [price], [category_id]) VALUES (5, N'Kapa', N'esadadas', CAST(2.22 AS Decimal(18, 2)), 1)
INSERT [dbo].[Product] ([product_id], [name], [description], [price], [category_id]) VALUES (6, N'Test 1', N'esadadas', CAST(2.22 AS Decimal(18, 2)), 1)
INSERT [dbo].[Product] ([product_id], [name], [description], [price], [category_id]) VALUES (7, N'Pomozi', N'Boze', CAST(2.22 AS Decimal(18, 2)), 1)
INSERT [dbo].[Product] ([product_id], [name], [description], [price], [category_id]) VALUES (8, N'Pomozi', N'Boze', CAST(241.22 AS Decimal(18, 2)), 2)
INSERT [dbo].[Product] ([product_id], [name], [description], [price], [category_id]) VALUES (9, N'Pomozi', N'Boze', CAST(2.22 AS Decimal(18, 2)), 1)
INSERT [dbo].[Product] ([product_id], [name], [description], [price], [category_id]) VALUES (10, N'perinprofil', N'esadadas', CAST(2.22 AS Decimal(18, 2)), 1)
INSERT [dbo].[Product] ([product_id], [name], [description], [price], [category_id]) VALUES (11, N'dsadasd', N'dsadasds', CAST(2.22 AS Decimal(18, 2)), 1)
INSERT [dbo].[Product] ([product_id], [name], [description], [price], [category_id]) VALUES (12, N'Kapa', N'esadadas', CAST(2.22 AS Decimal(18, 2)), 1)
INSERT [dbo].[Product] ([product_id], [name], [description], [price], [category_id]) VALUES (13, N'Kapa', N'esadadas', CAST(2.22 AS Decimal(18, 2)), 1)
INSERT [dbo].[Product] ([product_id], [name], [description], [price], [category_id]) VALUES (14, N'fsafdas', N'dsafas', CAST(2.22 AS Decimal(18, 2)), 1)
INSERT [dbo].[Product] ([product_id], [name], [description], [price], [category_id]) VALUES (15, N'fsafas', N'dsadasdas', CAST(2.22 AS Decimal(18, 2)), 1)
INSERT [dbo].[Product] ([product_id], [name], [description], [price], [category_id]) VALUES (16, N'Kapa', N'esadadas', CAST(2.22 AS Decimal(18, 2)), 1)
SET IDENTITY_INSERT [dbo].[Product] OFF
SET IDENTITY_INSERT [dbo].[ProductManufacturer] ON 

INSERT [dbo].[ProductManufacturer] ([id], [product_id], [manufacturer_id]) VALUES (1, 1, 1)
INSERT [dbo].[ProductManufacturer] ([id], [product_id], [manufacturer_id]) VALUES (2, 2, 2)
INSERT [dbo].[ProductManufacturer] ([id], [product_id], [manufacturer_id]) VALUES (3, 3, 1)
INSERT [dbo].[ProductManufacturer] ([id], [product_id], [manufacturer_id]) VALUES (4, 5, 1)
INSERT [dbo].[ProductManufacturer] ([id], [product_id], [manufacturer_id]) VALUES (5, 6, 1)
INSERT [dbo].[ProductManufacturer] ([id], [product_id], [manufacturer_id]) VALUES (6, 6, 2)
INSERT [dbo].[ProductManufacturer] ([id], [product_id], [manufacturer_id]) VALUES (7, 7, 1)
INSERT [dbo].[ProductManufacturer] ([id], [product_id], [manufacturer_id]) VALUES (8, 7, 2)
INSERT [dbo].[ProductManufacturer] ([id], [product_id], [manufacturer_id]) VALUES (9, 11, 1)
INSERT [dbo].[ProductManufacturer] ([id], [product_id], [manufacturer_id]) VALUES (10, 11, 2)
INSERT [dbo].[ProductManufacturer] ([id], [product_id], [manufacturer_id]) VALUES (11, 11, 3)
INSERT [dbo].[ProductManufacturer] ([id], [product_id], [manufacturer_id]) VALUES (12, 12, 1)
INSERT [dbo].[ProductManufacturer] ([id], [product_id], [manufacturer_id]) VALUES (13, 12, 2)
INSERT [dbo].[ProductManufacturer] ([id], [product_id], [manufacturer_id]) VALUES (14, 14, 1)
INSERT [dbo].[ProductManufacturer] ([id], [product_id], [manufacturer_id]) VALUES (15, 14, 2)
INSERT [dbo].[ProductManufacturer] ([id], [product_id], [manufacturer_id]) VALUES (16, 15, 1)
INSERT [dbo].[ProductManufacturer] ([id], [product_id], [manufacturer_id]) VALUES (17, 15, 2)
INSERT [dbo].[ProductManufacturer] ([id], [product_id], [manufacturer_id]) VALUES (18, 16, 1)
INSERT [dbo].[ProductManufacturer] ([id], [product_id], [manufacturer_id]) VALUES (19, 16, 2)
SET IDENTITY_INSERT [dbo].[ProductManufacturer] OFF
SET IDENTITY_INSERT [dbo].[ProductSupplier] ON 

INSERT [dbo].[ProductSupplier] ([id], [product_id], [supplier_id]) VALUES (1, 1, 1)
INSERT [dbo].[ProductSupplier] ([id], [product_id], [supplier_id]) VALUES (2, 1, 2)
INSERT [dbo].[ProductSupplier] ([id], [product_id], [supplier_id]) VALUES (3, 2, 2)
INSERT [dbo].[ProductSupplier] ([id], [product_id], [supplier_id]) VALUES (4, 3, 1)
INSERT [dbo].[ProductSupplier] ([id], [product_id], [supplier_id]) VALUES (5, 5, 1)
INSERT [dbo].[ProductSupplier] ([id], [product_id], [supplier_id]) VALUES (6, 6, 1)
SET IDENTITY_INSERT [dbo].[ProductSupplier] OFF
SET IDENTITY_INSERT [dbo].[Supplier] ON 

INSERT [dbo].[Supplier] ([supplier_id], [supplier_name]) VALUES (1, N'Pera')
INSERT [dbo].[Supplier] ([supplier_id], [supplier_name]) VALUES (2, N'Mika')
SET IDENTITY_INSERT [dbo].[Supplier] OFF
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category] FOREIGN KEY([category_id])
REFERENCES [dbo].[Category] ([category_id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Category]
GO
ALTER TABLE [dbo].[ProductManufacturer]  WITH CHECK ADD  CONSTRAINT [FK_Manufacturer_Product] FOREIGN KEY([manufacturer_id])
REFERENCES [dbo].[Manufacturer] ([manufacturer_id])
GO
ALTER TABLE [dbo].[ProductManufacturer] CHECK CONSTRAINT [FK_Manufacturer_Product]
GO
ALTER TABLE [dbo].[ProductManufacturer]  WITH CHECK ADD  CONSTRAINT [FK_Product_Manufacturer] FOREIGN KEY([product_id])
REFERENCES [dbo].[Product] ([product_id])
GO
ALTER TABLE [dbo].[ProductManufacturer] CHECK CONSTRAINT [FK_Product_Manufacturer]
GO
ALTER TABLE [dbo].[ProductSupplier]  WITH CHECK ADD  CONSTRAINT [FK_Product_Supplier] FOREIGN KEY([product_id])
REFERENCES [dbo].[Product] ([product_id])
GO
ALTER TABLE [dbo].[ProductSupplier] CHECK CONSTRAINT [FK_Product_Supplier]
GO
ALTER TABLE [dbo].[ProductSupplier]  WITH CHECK ADD  CONSTRAINT [FK_Supplier_Product] FOREIGN KEY([supplier_id])
REFERENCES [dbo].[Supplier] ([supplier_id])
GO
ALTER TABLE [dbo].[ProductSupplier] CHECK CONSTRAINT [FK_Supplier_Product]
GO
USE [master]
GO
ALTER DATABASE [WM] SET  READ_WRITE 
GO
