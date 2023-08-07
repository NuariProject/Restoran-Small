USE [master]
GO
/****** Object:  Database [dbRestoranMakanan]    Script Date: 08/08/2023 06:15:13 ******/
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
/****** Object:  Table [dbo].[jabatan]    Script Date: 08/08/2023 06:15:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[jabatan](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[code] [varchar](5) NOT NULL,
	[jabatan] [varchar](20) NOT NULL,
	[createdBy] [varchar](50) NOT NULL,
	[createdDate] [datetime] NOT NULL,
	[modifiedBy] [varchar](50) NULL,
	[modofiedDate] [datetime] NULL,
	[isActive] [bit] NOT NULL,
 CONSTRAINT [PK__jabatan__3213E83FA86D0743] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[menu]    Script Date: 08/08/2023 06:15:14 ******/
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
	[createdBy] [varchar](50) NOT NULL,
	[createdDate] [datetime] NOT NULL,
	[modifiedBy] [varchar](50) NULL,
	[modofiedDate] [datetime] NULL,
	[isActive] [bit] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pengguna]    Script Date: 08/08/2023 06:15:14 ******/
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
	[createdBy] [varchar](50) NOT NULL,
	[createdDate] [datetime] NOT NULL,
	[modifiedBy] [varchar](50) NULL,
	[modofiedDate] [datetime] NULL,
	[isActive] [bit] NOT NULL,
 CONSTRAINT [PK__pengguna__3213E83F450FAE43] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ__pengguna__DF97D0EDE1EC0393] UNIQUE NONCLUSTERED 
(
	[nik] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pesananDetail]    Script Date: 08/08/2023 06:15:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pesananDetail](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idPesananHeader] [int] NOT NULL,
	[idMenu] [int] NOT NULL,
	[qty] [int] NOT NULL,
	[createdBy] [varchar](50) NOT NULL,
	[createdDate] [datetime] NOT NULL,
	[modifiedBy] [varchar](50) NULL,
	[modofiedDate] [datetime] NULL,
	[isActive] [bit] NOT NULL,
 CONSTRAINT [PK__pesananD__3213E83FA241EEFC] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pesananHeader]    Script Date: 08/08/2023 06:15:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pesananHeader](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[code] [varchar](15) NOT NULL,
	[namaCustomer] [varchar](25) NOT NULL,
	[noMeja] [int] NOT NULL,
	[createdBy] [varchar](50) NOT NULL,
	[createdDate] [datetime] NOT NULL,
	[modifiedBy] [varchar](50) NULL,
	[modofiedDate] [datetime] NULL,
	[isActive] [bit] NOT NULL,
	[isBayar] [bit] NOT NULL,
 CONSTRAINT [PK__pesananH__3213E83F0312DB34] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
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
