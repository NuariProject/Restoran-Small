USE [master]
GO
/****** Object:  Database [dbRestoranMakanan]    Script Date: 09/08/2023 23:43:31 ******/
CREATE DATABASE [dbRestoranMakanan]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'dbRestoranMakanan', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.NUARI_PROJECT\MSSQL\DATA\dbRestoranMakanan.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'dbRestoranMakanan_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.NUARI_PROJECT\MSSQL\DATA\dbRestoranMakanan_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [dbRestoranMakanan] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [dbRestoranMakanan].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [dbRestoranMakanan] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [dbRestoranMakanan] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [dbRestoranMakanan] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [dbRestoranMakanan] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [dbRestoranMakanan] SET ARITHABORT OFF 
GO
ALTER DATABASE [dbRestoranMakanan] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [dbRestoranMakanan] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [dbRestoranMakanan] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [dbRestoranMakanan] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [dbRestoranMakanan] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [dbRestoranMakanan] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [dbRestoranMakanan] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [dbRestoranMakanan] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [dbRestoranMakanan] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [dbRestoranMakanan] SET  ENABLE_BROKER 
GO
ALTER DATABASE [dbRestoranMakanan] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [dbRestoranMakanan] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [dbRestoranMakanan] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [dbRestoranMakanan] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [dbRestoranMakanan] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [dbRestoranMakanan] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [dbRestoranMakanan] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [dbRestoranMakanan] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [dbRestoranMakanan] SET  MULTI_USER 
GO
ALTER DATABASE [dbRestoranMakanan] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [dbRestoranMakanan] SET DB_CHAINING OFF 
GO
ALTER DATABASE [dbRestoranMakanan] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [dbRestoranMakanan] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [dbRestoranMakanan] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [dbRestoranMakanan] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [dbRestoranMakanan] SET QUERY_STORE = OFF
GO
USE [dbRestoranMakanan]
GO
/****** Object:  Table [dbo].[jabatan]    Script Date: 09/08/2023 23:43:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[jabatan](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[code] [varchar](5) NOT NULL,
	[jabatan] [varchar](20) NOT NULL,
	[createdDate] [datetime2](7) NOT NULL,
	[modifiedDate] [datetime2](7) NULL,
	[isActive] [bit] NOT NULL,
 CONSTRAINT [PK__jabatan__3213E83FA86D0743] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[menu]    Script Date: 09/08/2023 23:43:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[menu](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[code] [varchar](5) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[stok] [int] NOT NULL,
	[harga] [decimal](18, 2) NOT NULL,
	[createdDate] [datetime2](7) NOT NULL,
	[modifiedDate] [datetime2](7) NULL,
	[isActive] [bit] NOT NULL,
 CONSTRAINT [PK_menu] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pengguna]    Script Date: 09/08/2023 23:43:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pengguna](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nik] [int] NOT NULL,
	[nama] [varchar](50) NOT NULL,
	[idJabatan] [int] NOT NULL,
	[password] [varchar](20) NOT NULL,
	[createdDate] [datetime2](7) NOT NULL,
	[modifiedDate] [datetime2](7) NULL,
	[isActive] [bit] NOT NULL,
 CONSTRAINT [PK__pengguna__3213E83F450FAE43] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pesananDetail]    Script Date: 09/08/2023 23:43:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pesananDetail](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idPesananHeader] [int] NOT NULL,
	[idMenu] [int] NOT NULL,
	[qty] [int] NOT NULL,
	[createdDate] [datetime2](7) NOT NULL,
	[modifiedDate] [datetime2](7) NULL,
	[isActive] [bit] NOT NULL,
 CONSTRAINT [PK__pesananD__3213E83FA241EEFC] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pesananHeader]    Script Date: 09/08/2023 23:43:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pesananHeader](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[code] [varchar](15) NOT NULL,
	[namaCustomer] [varchar](25) NOT NULL,
	[noMeja] [int] NOT NULL,
	[createdDate] [datetime2](7) NOT NULL,
	[modifiedDate] [datetime2](7) NULL,
	[isActive] [bit] NOT NULL,
	[isBayar] [bit] NOT NULL,
 CONSTRAINT [PK__pesananH__3213E83F0312DB34] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[jabatan] ON 

INSERT [dbo].[jabatan] ([id], [code], [jabatan], [createdDate], [modifiedDate], [isActive]) VALUES (1, N'OD', N'Operator Dapur', CAST(N'2023-08-07T22:23:36.2533333' AS DateTime2), NULL, 1)
INSERT [dbo].[jabatan] ([id], [code], [jabatan], [createdDate], [modifiedDate], [isActive]) VALUES (2, N'PLY', N'Pelayan', CAST(N'2023-08-07T22:23:36.2533333' AS DateTime2), NULL, 1)
INSERT [dbo].[jabatan] ([id], [code], [jabatan], [createdDate], [modifiedDate], [isActive]) VALUES (3, N'KSR', N'Kasir', CAST(N'2023-08-07T22:23:36.2533333' AS DateTime2), NULL, 1)
SET IDENTITY_INSERT [dbo].[jabatan] OFF
GO
SET IDENTITY_INSERT [dbo].[menu] ON 

INSERT [dbo].[menu] ([id], [code], [name], [stok], [harga], [createdDate], [modifiedDate], [isActive]) VALUES (1, N'MNM01', N'Es Teh Manis', 25, CAST(3000.00 AS Decimal(18, 2)), CAST(N'2023-08-07T22:43:55.7100000' AS DateTime2), NULL, 1)
INSERT [dbo].[menu] ([id], [code], [name], [stok], [harga], [createdDate], [modifiedDate], [isActive]) VALUES (2, N'MNM02', N'Jus Alpukat', 25, CAST(15000.00 AS Decimal(18, 2)), CAST(N'2023-08-07T22:43:55.7100000' AS DateTime2), NULL, 1)
INSERT [dbo].[menu] ([id], [code], [name], [stok], [harga], [createdDate], [modifiedDate], [isActive]) VALUES (3, N'MNM03', N'Jus Jeruk', 25, CAST(7000.00 AS Decimal(18, 2)), CAST(N'2023-08-07T22:43:55.7100000' AS DateTime2), NULL, 1)
INSERT [dbo].[menu] ([id], [code], [name], [stok], [harga], [createdDate], [modifiedDate], [isActive]) VALUES (4, N'MNM04', N'Coklat Panas', 25, CAST(10000.00 AS Decimal(18, 2)), CAST(N'2023-08-07T22:43:55.7100000' AS DateTime2), NULL, 1)
INSERT [dbo].[menu] ([id], [code], [name], [stok], [harga], [createdDate], [modifiedDate], [isActive]) VALUES (5, N'MNM05', N'Aqua', 25, CAST(4000.00 AS Decimal(18, 2)), CAST(N'2023-08-07T22:43:55.7100000' AS DateTime2), NULL, 1)
INSERT [dbo].[menu] ([id], [code], [name], [stok], [harga], [createdDate], [modifiedDate], [isActive]) VALUES (6, N'MKN01', N'Nasi Goreng', 25, CAST(15000.00 AS Decimal(18, 2)), CAST(N'2023-08-07T22:43:55.7100000' AS DateTime2), NULL, 1)
INSERT [dbo].[menu] ([id], [code], [name], [stok], [harga], [createdDate], [modifiedDate], [isActive]) VALUES (7, N'MKN02', N'Mie Goreng', 25, CAST(13000.00 AS Decimal(18, 2)), CAST(N'2023-08-07T22:43:55.7100000' AS DateTime2), NULL, 1)
INSERT [dbo].[menu] ([id], [code], [name], [stok], [harga], [createdDate], [modifiedDate], [isActive]) VALUES (8, N'MKN03', N'Mie Ayam', 25, CAST(10000.00 AS Decimal(18, 2)), CAST(N'2023-08-07T22:43:55.7100000' AS DateTime2), NULL, 1)
INSERT [dbo].[menu] ([id], [code], [name], [stok], [harga], [createdDate], [modifiedDate], [isActive]) VALUES (9, N'MKN04', N'Baso Urat', 25, CAST(16000.00 AS Decimal(18, 2)), CAST(N'2023-08-07T22:43:55.7100000' AS DateTime2), NULL, 1)
INSERT [dbo].[menu] ([id], [code], [name], [stok], [harga], [createdDate], [modifiedDate], [isActive]) VALUES (10, N'MKN05', N'Soto Ayam', 25, CAST(12000.00 AS Decimal(18, 2)), CAST(N'2023-08-07T22:43:55.7100000' AS DateTime2), NULL, 1)
INSERT [dbo].[menu] ([id], [code], [name], [stok], [harga], [createdDate], [modifiedDate], [isActive]) VALUES (12, N'strin', N'string', 0, CAST(0.00 AS Decimal(18, 2)), CAST(N'2023-08-08T20:33:47.4166667' AS DateTime2), CAST(N'2023-08-08T21:47:37.7400000' AS DateTime2), 0)
INSERT [dbo].[menu] ([id], [code], [name], [stok], [harga], [createdDate], [modifiedDate], [isActive]) VALUES (13, N'as', N'ds', 0, CAST(0.00 AS Decimal(18, 2)), CAST(N'2023-08-08T21:44:39.4866667' AS DateTime2), CAST(N'2023-08-08T21:53:50.7200000' AS DateTime2), 0)
INSERT [dbo].[menu] ([id], [code], [name], [stok], [harga], [createdDate], [modifiedDate], [isActive]) VALUES (14, N'asd', N'dsa', 0, CAST(0.00 AS Decimal(18, 2)), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2023-08-08T22:13:11.9554416' AS DateTime2), 0)
INSERT [dbo].[menu] ([id], [code], [name], [stok], [harga], [createdDate], [modifiedDate], [isActive]) VALUES (15, N'as', N'sd', 0, CAST(0.00 AS Decimal(18, 2)), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2023-08-08T22:53:00.3368694' AS DateTime2), 0)
SET IDENTITY_INSERT [dbo].[menu] OFF
GO
SET IDENTITY_INSERT [dbo].[pengguna] ON 

INSERT [dbo].[pengguna] ([id], [nik], [nama], [idJabatan], [password], [createdDate], [modifiedDate], [isActive]) VALUES (3, 230801001, N'Operator Dapur', 1, N'admin123', CAST(N'2023-08-07T22:36:31.1733333' AS DateTime2), NULL, 1)
INSERT [dbo].[pengguna] ([id], [nik], [nama], [idJabatan], [password], [createdDate], [modifiedDate], [isActive]) VALUES (4, 230801002, N'Pelayan', 2, N'pelayan123', CAST(N'2023-08-07T22:36:31.1733333' AS DateTime2), NULL, 1)
INSERT [dbo].[pengguna] ([id], [nik], [nama], [idJabatan], [password], [createdDate], [modifiedDate], [isActive]) VALUES (5, 230801003, N'Kasir', 3, N'kasir123', CAST(N'2023-08-07T22:36:31.1733333' AS DateTime2), NULL, 1)
SET IDENTITY_INSERT [dbo].[pengguna] OFF
GO
SET IDENTITY_INSERT [dbo].[pesananDetail] ON 

INSERT [dbo].[pesananDetail] ([id], [idPesananHeader], [idMenu], [qty], [createdDate], [modifiedDate], [isActive]) VALUES (1, 1, 1, 2, CAST(N'2023-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2023-01-01T00:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[pesananDetail] ([id], [idPesananHeader], [idMenu], [qty], [createdDate], [modifiedDate], [isActive]) VALUES (2, 1, 2, 2, CAST(N'2023-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2023-01-01T00:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[pesananDetail] ([id], [idPesananHeader], [idMenu], [qty], [createdDate], [modifiedDate], [isActive]) VALUES (3, 1, 3, 3, CAST(N'2023-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2023-01-01T00:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[pesananDetail] ([id], [idPesananHeader], [idMenu], [qty], [createdDate], [modifiedDate], [isActive]) VALUES (4, 2, 1, 3, CAST(N'2023-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2023-01-01T00:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[pesananDetail] ([id], [idPesananHeader], [idMenu], [qty], [createdDate], [modifiedDate], [isActive]) VALUES (5, 2, 2, 3, CAST(N'2023-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2023-01-01T00:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[pesananDetail] ([id], [idPesananHeader], [idMenu], [qty], [createdDate], [modifiedDate], [isActive]) VALUES (6, 2, 3, 3, CAST(N'2023-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2023-01-01T00:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[pesananDetail] ([id], [idPesananHeader], [idMenu], [qty], [createdDate], [modifiedDate], [isActive]) VALUES (32, 10, 5, 3, CAST(N'2023-08-09T23:11:42.6829336' AS DateTime2), CAST(N'2023-08-09T23:11:42.6827162' AS DateTime2), 1)
SET IDENTITY_INSERT [dbo].[pesananDetail] OFF
GO
SET IDENTITY_INSERT [dbo].[pesananHeader] ON 

INSERT [dbo].[pesananHeader] ([id], [code], [namaCustomer], [noMeja], [createdDate], [modifiedDate], [isActive], [isBayar]) VALUES (1, N'ABC123', N'Kiki', 1, CAST(N'2023-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2023-01-01T00:00:00.0000000' AS DateTime2), 1, 0)
INSERT [dbo].[pesananHeader] ([id], [code], [namaCustomer], [noMeja], [createdDate], [modifiedDate], [isActive], [isBayar]) VALUES (2, N'ABC124', N'Koko', 2, CAST(N'2023-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2023-01-01T00:00:00.0000000' AS DateTime2), 1, 0)
INSERT [dbo].[pesananHeader] ([id], [code], [namaCustomer], [noMeja], [createdDate], [modifiedDate], [isActive], [isBayar]) VALUES (10, N'ABC100', N'Farhannuari', 10, CAST(N'2023-08-09T22:57:19.2611234' AS DateTime2), CAST(N'2023-08-09T23:12:09.9260916' AS DateTime2), 0, 0)
SET IDENTITY_INSERT [dbo].[pesananHeader] OFF
GO
/****** Object:  Index [UQ__pengguna__DF97D0EDE1EC0393]    Script Date: 09/08/2023 23:43:31 ******/
ALTER TABLE [dbo].[pengguna] ADD  CONSTRAINT [UQ__pengguna__DF97D0EDE1EC0393] UNIQUE NONCLUSTERED 
(
	[nik] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[jabatan]  WITH CHECK ADD  CONSTRAINT [FK_jabatan_jabatan] FOREIGN KEY([id])
REFERENCES [dbo].[jabatan] ([id])
GO
ALTER TABLE [dbo].[jabatan] CHECK CONSTRAINT [FK_jabatan_jabatan]
GO
ALTER TABLE [dbo].[pengguna]  WITH CHECK ADD  CONSTRAINT [FK_pengguna_jabatan] FOREIGN KEY([idJabatan])
REFERENCES [dbo].[jabatan] ([id])
GO
ALTER TABLE [dbo].[pengguna] CHECK CONSTRAINT [FK_pengguna_jabatan]
GO
USE [master]
GO
ALTER DATABASE [dbRestoranMakanan] SET  READ_WRITE 
GO
