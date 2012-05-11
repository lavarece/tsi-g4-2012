USE [master]
GO

/****** Object:  Database [IndignadoFDb]    Script Date: 04/16/2012 19:12:11 ******/
IF  EXISTS (SELECT name FROM sys.databases WHERE name = N'IndignadoFDb')
DROP DATABASE [IndignadoFDb]
GO

USE [master]
GO

/****** Object:  Database [IndignadoFDb]    Script Date: 04/16/2012 19:12:11 ******/
CREATE DATABASE [IndignadoFDb] ON  PRIMARY 
( NAME = N'IndignadoFDb', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\IndignadoFDb.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'IndignadoFDb_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\IndignadoFDb_log.ldf' , SIZE = 4096KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [IndignadoFDb] SET COMPATIBILITY_LEVEL = 100
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [IndignadoFDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [IndignadoFDb] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [IndignadoFDb] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [IndignadoFDb] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [IndignadoFDb] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [IndignadoFDb] SET ARITHABORT OFF 
GO

ALTER DATABASE [IndignadoFDb] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [IndignadoFDb] SET AUTO_CREATE_STATISTICS ON 
GO

ALTER DATABASE [IndignadoFDb] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [IndignadoFDb] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [IndignadoFDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [IndignadoFDb] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [IndignadoFDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [IndignadoFDb] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [IndignadoFDb] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [IndignadoFDb] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [IndignadoFDb] SET  DISABLE_BROKER 
GO

ALTER DATABASE [IndignadoFDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [IndignadoFDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [IndignadoFDb] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [IndignadoFDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [IndignadoFDb] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [IndignadoFDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [IndignadoFDb] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [IndignadoFDb] SET  READ_WRITE 
GO

ALTER DATABASE [IndignadoFDb] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [IndignadoFDb] SET  MULTI_USER 
GO

ALTER DATABASE [IndignadoFDb] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [IndignadoFDb] SET DB_CHAINING OFF 
GO



USE [IndignadoFDb]
GO
/****** Object:  Table [dbo].[Convocatoria]    Script Date: 04/16/2012 19:10:17 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Convocatoria]') AND type in (N'U'))
DROP TABLE [dbo].[Convocatoria]
GO
/****** Object:  Table [dbo].[Convocatoria]    Script Date: 04/16/2012 19:10:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Convocatoria]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Convocatoria](
	[Id] [int] IDENTITY(4,1) NOT NULL,
	[Titulo] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[LogoUrl] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Descripcion] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Quorum] [int] NOT NULL,
	[Categoria] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Coordenada] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_Convocatoria] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET IDENTITY_INSERT [dbo].[Convocatoria] ON
INSERT [dbo].[Convocatoria] ([Id], [Titulo], [LogoURL], [Descripcion], [Quorum], [Categoria], [Coordenada]) VALUES (5, N'Agua', N'http://api.ning.com/files/I1-Je2KZq7cH7I5FJj7ypOJ1BsKV4n4oVTO2dN9whwPJra9QW4o-z8J5wSMvmGAxaZsFimDo2EWtm4SbI2gG0esG1CtDgh8j/greenpeace2.jpg?crop=1%3A1&width=64', N'¿Hay algo más relajante que escuchar el agua correr? Pero... ¿qué llevan nuestros ríos al mar?, ¿cómo están nuestros mares y océanos?, y ¿nuestros acuíferos, importantes reservas de agua para nosotros y para las futuras generaciones?, y... ¿el agua que bebemos?', 200, N'Medio Ambiente', N'http://maps.google.com/?ll=36.588168,-88.841924&spn=0.00258,0.004823&t=h&z=18')
INSERT [dbo].[Convocatoria] ([Id], [Titulo], [LogoURL], [Descripcion], [Quorum], [Categoria], [Coordenada]) VALUES (10, N'Atún', N'http://www.guiasnintendo.com/2a_WII/monster_hunter/monster_hunter_sp/imagenes/ilustraciones/enemigos/pez_atun.jpg', N'El atún es el pescado favorito en el mundo. Proporciona una parte importante de la dieta de millones de personas. También es la esencia del exclusivo mercado del sushi y el sashimi. Las 5 principales especies de atún que se consumen son: atún rabil, listado, patudo, rojo y bonito del norte.', 500, N'Medio ambiente', N'http://maps.google.com/?ll=36.588168,-88.841924&spn=0.00258,0.004823&t=h&z=18')
SET IDENTITY_INSERT [dbo].[Convocatoria] OFF



USE [IndignadoFDb]
GO
/****** Object:  Table [dbo].[Sitio]    Script Date: 04/16/2012 19:10:17 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sitio]') AND type in (N'U'))
DROP TABLE [dbo].[Sitio]
GO
/****** Object:  Table [dbo].[Sitio]    Script Date: 04/16/2012 19:10:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sitio]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Sitio](
	[Id] [int] IDENTITY(4,1) NOT NULL,
	[Nombre] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[LogoUrl] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Descripcion] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[FK_Id_Contenido] [int]NOT NULL,
	[FK_Id_Template] [int]NOT NULL,
	[FK_Id_Imagen] [int] NULL,
	[Url] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_Sitio] PRIMARY KEY CLUSTERED
 --CONSTRAINT FK_Sitio_FK_Contenido FOREIGN KEY (FK_Id_Contendio) REFERENCES Contenido(Id)
 --CONSTRAINT FK_Sitio_FK_Template FOREIGN KEY (FK_Id_Template) REFERENCES Template(Id)
 --CONSTRAINT FK_Sitio_FK_Imagen FOREIGN KEY (FK_Id_Imagen) REFERENCES Imagen(Id) 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/*SET IDENTITY_INSERT [dbo].[Sitio] ON
INSERT [dbo].[Eventos] ([Id], [Titulo], [LogoURL], [Descripcion], [CuorumMin], [Categoria], [EarthCoord]) VALUES (5, N'Agua', N'http://api.ning.com/files/I1-Je2KZq7cH7I5FJj7ypOJ1BsKV4n4oVTO2dN9whwPJra9QW4o-z8J5wSMvmGAxaZsFimDo2EWtm4SbI2gG0esG1CtDgh8j/greenpeace2.jpg?crop=1%3A1&width=64', N'¿Hay algo más relajante que escuchar el agua correr? Pero... ¿qué llevan nuestros ríos al mar?, ¿cómo están nuestros mares y océanos?, y ¿nuestros acuíferos, importantes reservas de agua para nosotros y para las futuras generaciones?, y... ¿el agua que bebemos?', 200, N'Medio Ambiente', N'http://maps.google.com/?ll=36.588168,-88.841924&spn=0.00258,0.004823&t=h&z=18')
INSERT [dbo].[Eventos] ([Id], [Titulo], [LogoURL], [Descripcion], [CuorumMin], [Categoria], [EarthCoord]) VALUES (10, N'Atún', N'http://www.guiasnintendo.com/2a_WII/monster_hunter/monster_hunter_sp/imagenes/ilustraciones/enemigos/pez_atun.jpg', N'El atún es el pescado favorito en el mundo. Proporciona una parte importante de la dieta de millones de personas. También es la esencia del exclusivo mercado del sushi y el sashimi. Las 5 principales especies de atún que se consumen son: atún rabil, listado, patudo, rojo y bonito del norte.', 500, N'Medio ambiente', N'http://maps.google.com/?ll=36.588168,-88.841924&spn=0.00258,0.004823&t=h&z=18')
SET IDENTITY_INSERT [dbo].[Eventos] OFF*/
