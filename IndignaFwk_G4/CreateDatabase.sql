USE [master]
GO

/****** Object:  Database [IndignadoFDb]    Script Date: 04/16/2012 19:12:11 ******/
IF  EXISTS (SELECT name FROM sys.databases WHERE name = N'IndignadoFDb2')
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

--TipoContenido
USE [IndignadoFDb]
GO
/****** Object:  Table [dbo].[TipoContenido]    Script Date: 04/16/2012 19:10:17 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TipoContenido]') AND type in (N'U'))
DROP TABLE [dbo].[TipoContenido]
GO
/****** Object:  Table [dbo].[TipoContenido]    Script Date: 04/16/2012 19:10:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TipoContenido]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TipoContenido](
	[Id] [int]  IDENTITY(4,1) NOT NULL PRIMARY KEY,
	[Descripción] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS 
) ON [PRIMARY]
END
GO

--EstadoContenido
USE [IndignadoFDb]
GO
/****** Object:  Table [dbo].[EstadoContenido]    Script Date: 04/16/2012 19:10:17 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EstadoContenido]') AND type in (N'U'))
DROP TABLE [dbo].[EstadoContenido]
GO
/****** Object:  Table [dbo].[EstadoContenido]    Script Date: 04/16/2012 19:10:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EstadoContenido]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[EstadoContenido](
	[Id] [int]  IDENTITY(4,1) NOT NULL PRIMARY KEY,
	[Descripción] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS 
) ON [PRIMARY]
END
GO

--TipoMarcaContenido
USE [IndignadoFDb]
GO
/****** Object:  Table [dbo].[TipoMarcaContenido]    Script Date: 04/16/2012 19:10:17 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TipoMarcaContenido]') AND type in (N'U'))
DROP TABLE [dbo].[TipoMarcaContenido]
GO
/****** Object:  Table [dbo].[TipoMarcaContenido]    Script Date: 04/16/2012 19:10:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TipoMarcaContenido]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TipoMarcaContenido](
	[Id] [int]  IDENTITY(4,1) NOT NULL PRIMARY KEY,
	[Descripción] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS
) ON [PRIMARY]
END
GO


--Imagen
USE [IndignadoFDb]
GO
/****** Object:  Table [dbo].[Imagen]    Script Date: 04/16/2012 19:10:17 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Imagen]') AND type in (N'U'))
DROP TABLE [dbo].[Imagen]
GO
/****** Object:  Table [dbo].[Imagen]    Script Date: 04/16/2012 19:10:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Imagen]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Imagen](
	[Id] [int]  IDENTITY(4,1) NOT NULL PRIMARY KEY,
	[Nombre] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS,
	[Referencia] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS
) ON [PRIMARY]
END
GO

--SITIO
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
	[Id] [int] IDENTITY(4,1) NOT NULL PRIMARY KEY,
	[Nombre] [nvarchar](250) NOT NULL UNIQUE,
	[LogoUrl] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS,
	[Descripcion] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS,
	[Template] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS,
	[FK_Id_Imagen] [int] ,
	[Url] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT FK_Sitio_FK_Imagen FOREIGN KEY (FK_Id_Imagen) REFERENCES Imagen(Id) 

) ON [PRIMARY]
END
GO



--Contenido
USE [IndignadoFDb]
GO
/****** Object:  Table [dbo].[Contenido]    Script Date: 04/16/2012 19:10:17 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Contenido]') AND type in (N'U'))
DROP TABLE [dbo].[Contenido]
GO
/****** Object:  Table [dbo].[Contenido]    Script Date: 04/16/2012 19:10:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Contenido]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Contenido](
	[Id] [int]  IDENTITY(4,1) NOT NULL PRIMARY KEY,
	[FK_Id_EstadoContenido] [int],
	[FK_Id_TipoContenido] [int],
	[FK_Id_Sitio] [int],
	[Url] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS,
CONSTRAINT FK_Contenido_FK_Id_EstadoContenido FOREIGN KEY (FK_Id_EstadoContenido) REFERENCES EstadoContenido(Id),
CONSTRAINT FK_Contenido_FK_Id_Sitio FOREIGN KEY (FK_Id_Sitio) REFERENCES Sitio(Id),
CONSTRAINT FK_Contenido_FK_Id_TipoContenido FOREIGN KEY (FK_Id_TipoContenido) REFERENCES TipoContenido(Id)
) ON [PRIMARY]
END
GO


--Convocatoria
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
	[Titulo] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS,
	[LogoUrl] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS,
	[Descripcion] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS,
	[Quorum] [int],
	[Categoria] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS,
	[Coordenada] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS,
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





--Usuario
USE [IndignadoFDb]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 04/16/2012 19:10:17 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Usuario]') AND type in (N'U'))
DROP TABLE [dbo].[Usuario]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 04/16/2012 19:10:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Usuario]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Usuario](
	[Id] [int]  IDENTITY(4,1) NOT NULL PRIMARY KEY,
	[Conectado] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS,
	[Descripcion] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS,
	[Email] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS,
	[FK_Id_Sitio] [int],
	[Nombre] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS,
	[Password] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS,
	[Pregunta] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS,
	[Region] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS,
	[Respuesta] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS,
CONSTRAINT FK_Usuario_FK_Id_Sitio FOREIGN KEY (FK_Id_Sitio) REFERENCES Sitio(Id)
--CONSTRAINT FK_USUARIO_idTipoUsuario FOREIGN KEY (idTipoUsuario) REFERENCES TIPO_USUARIO(idTipoUsuario)
  /* (
	   [Id] ASC
    )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
*/
) ON [PRIMARY]
END
GO


--Asistencia Convocatoria
USE [IndignadoFDb]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 04/16/2012 19:10:17 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AsistenciaConvocatoria]') AND type in (N'U'))
DROP TABLE [dbo].[AsistenciaConvocatoria]
GO
/****** Object:  Table [dbo].[AsistenciaConvocatoria]    Script Date: 04/16/2012 19:10:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AsistenciaConvocatoria]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[AsistenciaConvocatoria](
	[Id] [int]  IDENTITY(4,1) NOT NULL PRIMARY KEY,
	[FK_Id_Convocatoria] [int],
	[FK_Id_Usuario] [int],
CONSTRAINT FK_AsistenciaConvocatoria_FK_Id_Convocatoria FOREIGN KEY (FK_Id_Convocatoria) REFERENCES Convocatoria(Id),
CONSTRAINT FK_AsistenciaConvocatoria_FK_Id_Usuario FOREIGN KEY (FK_Id_Usuario) REFERENCES Usuario(Id)
) ON [PRIMARY]
END
GO



--Notificacion
USE [IndignadoFDb]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 04/16/2012 19:10:17 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Notificacion]') AND type in (N'U'))
DROP TABLE [dbo].[Notificacion]
GO
/****** Object:  Table [dbo].[Notificacion]    Script Date: 04/16/2012 19:10:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Notificacion]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Notificacion](
	[Id] [int]  IDENTITY(4,1) NOT NULL PRIMARY KEY,
	[Contenido] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS,
	[Visto] [nvarchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS,
	[FK_Id_Convocatoria] [int],
	[FK_Id_Usuario] [int],
CONSTRAINT FK_Notificacion_FK_Id_Convocatoria FOREIGN KEY (FK_Id_Convocatoria) REFERENCES Convocatoria(Id),
CONSTRAINT FK_Notificacion_FK_Id_Usuario FOREIGN KEY (FK_Id_Usuario) REFERENCES Usuario(Id)
) ON [PRIMARY]
END
GO


--Marca contenido
USE [IndignadoFDb]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 04/16/2012 19:10:17 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MarcaContenido]') AND type in (N'U'))
DROP TABLE [dbo].[MarcaContenido]
GO
/****** Object:  Table [dbo].[MarcaContenido]    Script Date: 04/16/2012 19:10:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MarcaContenido]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[MarcaContenido](
	[Id] [int]  IDENTITY(4,1) NOT NULL PRIMARY KEY,
	[FK_Id_Contenido] [int],
	[FK_Id_TipoMarca] [int],
	[FK_Id_Usuario] [int],
CONSTRAINT FK_MarcaContenido_FK_Id_Contenido FOREIGN KEY (FK_Id_Contenido) REFERENCES Contenido(Id),
CONSTRAINT FK_MarcaContenido_FK_Id_Usuario FOREIGN KEY (FK_Id_Usuario) REFERENCES Usuario(Id),
CONSTRAINT FK_MarcaContenido_FK_Id_TipoMarca FOREIGN KEY (FK_Id_TipoMarca) REFERENCES TipoMarcaContenido(Id)
) ON [PRIMARY]
END
GO


--Tematica
USE [IndignadoFDb]
GO
/****** Object:  Table [dbo].[Tematica]    Script Date: 04/16/2012 19:10:17 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tematica]') AND type in (N'U'))
DROP TABLE [dbo].[Tematica]
GO
/****** Object:  Table [dbo].[Tematica]    Script Date: 04/16/2012 19:10:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tematica]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Tematica](
	[Id] [int]  IDENTITY(4,1) NOT NULL PRIMARY KEY,
	[Nombre] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS,
) ON [PRIMARY]
END
GO


--UsuTematica
USE [IndignadoFDb]
GO
/****** Object:  Table [dbo].[UsuTematica]    Script Date: 04/16/2012 19:10:17 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UsuTematica]') AND type in (N'U'))
DROP TABLE [dbo].[UsuTematica]
GO
/****** Object:  Table [dbo].[UsuTematica]    Script Date: 04/16/2012 19:10:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UsuTematica]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[UsuTematica](
	[Id] [int]  IDENTITY(4,1) NOT NULL PRIMARY KEY,
	[FK_Id_Tematica] [int],
	[FK_Id_Usuario] [int],
CONSTRAINT FK_Contenido_FK_Id_Tematica FOREIGN KEY (FK_Id_Tematica) REFERENCES Tematica(Id),
CONSTRAINT FK_Contenido_FK_Id_Usuario FOREIGN KEY (FK_Id_Usuario) REFERENCES Usuario(Id)
) ON [PRIMARY]
END
GO



--VariableSistema
USE [IndignadoFDb]
GO
/****** Object:  Table [dbo].[VariableSistema]    Script Date: 04/16/2012 19:10:17 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VariableSistema]') AND type in (N'U'))
DROP TABLE [dbo].[VariableSistema]
GO
/****** Object:  Table [dbo].[VariableSistema]    Script Date: 04/16/2012 19:10:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VariableSistema]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[VariableSistema](
	[Id] [int]  IDENTITY(4,1) NOT NULL PRIMARY KEY,
	[Nombre] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS,
	[Valor] [int]
) ON [PRIMARY]
END
GO

--Administrador
USE [IndignadoFDb]
GO
/****** Object:  Table [dbo].[Administrador]    Script Date: 04/16/2012 19:10:17 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Administrador]') AND type in (N'U'))
DROP TABLE [dbo].[Administrador]
GO
/****** Object:  Table [dbo].[Administrador]    Script Date: 04/16/2012 19:10:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Administrador]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Administrador](
	[Id] [int]  IDENTITY(4,1) NOT NULL PRIMARY KEY,
	[Email] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS,
	[Nombre] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS,
	[Password] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS,
	[Pregunta] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS,
	[Region] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS,
	[Respuesta] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS
) ON [PRIMARY]
END
GO

