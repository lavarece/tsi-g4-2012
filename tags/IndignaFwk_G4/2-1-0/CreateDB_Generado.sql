USE [IndignadoFDb]
GO
/****** Object:  ForeignKey [FK_Sitio_FK_Imagen]    Script Date: 05/23/2012 01:47:10 ******/
ALTER TABLE [dbo].[Sitio] DROP CONSTRAINT [FK_Sitio_FK_Imagen]
GO
/****** Object:  ForeignKey [FK_Contenido_FK_Id_Sitio]    Script Date: 05/23/2012 01:47:10 ******/
ALTER TABLE [dbo].[Contenido] DROP CONSTRAINT [FK_Contenido_FK_Id_Sitio]
GO
/****** Object:  ForeignKey [FK_Usuario_FK_Id_Sitio]    Script Date: 05/23/2012 01:47:10 ******/
ALTER TABLE [dbo].[Usuario] DROP CONSTRAINT [FK_Usuario_FK_Id_Sitio]
GO
/****** Object:  ForeignKey [FK_Contenido_FK_Id_Tematica]    Script Date: 05/23/2012 01:47:10 ******/
ALTER TABLE [dbo].[UsuTematica] DROP CONSTRAINT [FK_Contenido_FK_Id_Tematica]
GO
/****** Object:  ForeignKey [FK_Contenido_FK_Id_Usuario]    Script Date: 05/23/2012 01:47:10 ******/
ALTER TABLE [dbo].[UsuTematica] DROP CONSTRAINT [FK_Contenido_FK_Id_Usuario]
GO
/****** Object:  ForeignKey [FK_Convocatoria_FK_Sitio]    Script Date: 05/23/2012 01:47:10 ******/
ALTER TABLE [dbo].[Convocatoria] DROP CONSTRAINT [FK_Convocatoria_FK_Sitio]
GO
/****** Object:  ForeignKey [FK_Convocatoria_FK_Tematica]    Script Date: 05/23/2012 01:47:10 ******/
ALTER TABLE [dbo].[Convocatoria] DROP CONSTRAINT [FK_Convocatoria_FK_Tematica]
GO
/****** Object:  ForeignKey [FK_Convocatoria_FK_UsuarioCreacion]    Script Date: 05/23/2012 01:47:10 ******/
ALTER TABLE [dbo].[Convocatoria] DROP CONSTRAINT [FK_Convocatoria_FK_UsuarioCreacion]
GO
/****** Object:  ForeignKey [FK_MarcaContenido_FK_Id_Contenido]    Script Date: 05/23/2012 01:47:10 ******/
ALTER TABLE [dbo].[MarcaContenido] DROP CONSTRAINT [FK_MarcaContenido_FK_Id_Contenido]
GO
/****** Object:  ForeignKey [FK_MarcaContenido_FK_Id_Usuario]    Script Date: 05/23/2012 01:47:10 ******/
ALTER TABLE [dbo].[MarcaContenido] DROP CONSTRAINT [FK_MarcaContenido_FK_Id_Usuario]
GO
/****** Object:  ForeignKey [FK_Notificacion_FK_Id_Convocatoria]    Script Date: 05/23/2012 01:47:10 ******/
ALTER TABLE [dbo].[Notificacion] DROP CONSTRAINT [FK_Notificacion_FK_Id_Convocatoria]
GO
/****** Object:  ForeignKey [FK_Notificacion_FK_Id_Usuario]    Script Date: 05/23/2012 01:47:10 ******/
ALTER TABLE [dbo].[Notificacion] DROP CONSTRAINT [FK_Notificacion_FK_Id_Usuario]
GO
/****** Object:  ForeignKey [FK_AsistenciaConvocatoria_FK_Id_Convocatoria]    Script Date: 05/23/2012 01:47:11 ******/
ALTER TABLE [dbo].[AsistenciaConvocatoria] DROP CONSTRAINT [FK_AsistenciaConvocatoria_FK_Id_Convocatoria]
GO
/****** Object:  ForeignKey [FK_AsistenciaConvocatoria_FK_Id_Usuario]    Script Date: 05/23/2012 01:47:11 ******/
ALTER TABLE [dbo].[AsistenciaConvocatoria] DROP CONSTRAINT [FK_AsistenciaConvocatoria_FK_Id_Usuario]
GO
/****** Object:  Table [dbo].[AsistenciaConvocatoria]    Script Date: 05/23/2012 01:47:11 ******/
ALTER TABLE [dbo].[AsistenciaConvocatoria] DROP CONSTRAINT [FK_AsistenciaConvocatoria_FK_Id_Convocatoria]
GO
ALTER TABLE [dbo].[AsistenciaConvocatoria] DROP CONSTRAINT [FK_AsistenciaConvocatoria_FK_Id_Usuario]
GO
DROP TABLE [dbo].[AsistenciaConvocatoria]
GO
/****** Object:  Table [dbo].[Notificacion]    Script Date: 05/23/2012 01:47:10 ******/
ALTER TABLE [dbo].[Notificacion] DROP CONSTRAINT [FK_Notificacion_FK_Id_Convocatoria]
GO
ALTER TABLE [dbo].[Notificacion] DROP CONSTRAINT [FK_Notificacion_FK_Id_Usuario]
GO
DROP TABLE [dbo].[Notificacion]
GO
/****** Object:  Table [dbo].[MarcaContenido]    Script Date: 05/23/2012 01:47:10 ******/
ALTER TABLE [dbo].[MarcaContenido] DROP CONSTRAINT [FK_MarcaContenido_FK_Id_Contenido]
GO
ALTER TABLE [dbo].[MarcaContenido] DROP CONSTRAINT [FK_MarcaContenido_FK_Id_Usuario]
GO
DROP TABLE [dbo].[MarcaContenido]
GO
/****** Object:  Table [dbo].[Convocatoria]    Script Date: 05/23/2012 01:47:10 ******/
ALTER TABLE [dbo].[Convocatoria] DROP CONSTRAINT [FK_Convocatoria_FK_Sitio]
GO
ALTER TABLE [dbo].[Convocatoria] DROP CONSTRAINT [FK_Convocatoria_FK_Tematica]
GO
ALTER TABLE [dbo].[Convocatoria] DROP CONSTRAINT [FK_Convocatoria_FK_UsuarioCreacion]
GO
DROP TABLE [dbo].[Convocatoria]
GO
/****** Object:  Table [dbo].[UsuTematica]    Script Date: 05/23/2012 01:47:10 ******/
ALTER TABLE [dbo].[UsuTematica] DROP CONSTRAINT [FK_Contenido_FK_Id_Tematica]
GO
ALTER TABLE [dbo].[UsuTematica] DROP CONSTRAINT [FK_Contenido_FK_Id_Usuario]
GO
DROP TABLE [dbo].[UsuTematica]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 05/23/2012 01:47:10 ******/
ALTER TABLE [dbo].[Usuario] DROP CONSTRAINT [FK_Usuario_FK_Id_Sitio]
GO
DROP TABLE [dbo].[Usuario]
GO
/****** Object:  Table [dbo].[Contenido]    Script Date: 05/23/2012 01:47:10 ******/
ALTER TABLE [dbo].[Contenido] DROP CONSTRAINT [FK_Contenido_FK_Id_Sitio]
GO
DROP TABLE [dbo].[Contenido]
GO
/****** Object:  Table [dbo].[Sitio]    Script Date: 05/23/2012 01:47:10 ******/
ALTER TABLE [dbo].[Sitio] DROP CONSTRAINT [FK_Sitio_FK_Imagen]
GO
DROP TABLE [dbo].[Sitio]
GO
/****** Object:  Table [dbo].[Tematica]    Script Date: 05/23/2012 01:47:10 ******/
DROP TABLE [dbo].[Tematica]
GO
/****** Object:  Table [dbo].[Administrador]    Script Date: 05/23/2012 01:47:09 ******/
DROP TABLE [dbo].[Administrador]
GO
/****** Object:  Table [dbo].[Imagen]    Script Date: 05/23/2012 01:47:09 ******/
DROP TABLE [dbo].[Imagen]
GO
/****** Object:  Table [dbo].[VariableSistema]    Script Date: 05/23/2012 01:47:09 ******/
DROP TABLE [dbo].[VariableSistema]
GO
/****** Object:  Table [dbo].[VariableSistema]    Script Date: 05/23/2012 01:47:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VariableSistema](
	[Id] [int] IDENTITY(4,1) NOT NULL,
	[Nombre] [nvarchar](250) NULL,
	[Valor] [nvarchar](250) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Imagen]    Script Date: 05/23/2012 01:47:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Imagen](
	[Id] [int] IDENTITY(4,1) NOT NULL,
	[Nombre] [nvarchar](250) NULL,
	[Referencia] [nvarchar](250) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Administrador]    Script Date: 05/23/2012 01:47:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Administrador](
	[Id] [int] IDENTITY(4,1) NOT NULL,
	[Email] [nvarchar](250) NULL,
	[Nombre] [nvarchar](250) NULL,
	[Password] [nvarchar](250) NULL,
	[Pregunta] [nvarchar](250) NULL,
	[Region] [nvarchar](250) NULL,
	[Respuesta] [nvarchar](250) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tematica]    Script Date: 05/23/2012 01:47:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tematica](
	[Id] [int] IDENTITY(4,1) NOT NULL,
	[Nombre] [nvarchar](250) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sitio]    Script Date: 05/23/2012 01:47:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sitio](
	[Id] [int] IDENTITY(4,1) NOT NULL,
	[Nombre] [nvarchar](250) NOT NULL,
	[LogoUrl] [nvarchar](250) NULL,
	[Descripcion] [nvarchar](max) NULL,
	[Template] [nvarchar](250) NULL,
	[FK_Id_Imagen] [int] NULL,
	[Url] [nvarchar](250) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Nombre] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contenido]    Script Date: 05/23/2012 01:47:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contenido](
	[Id] [int] IDENTITY(4,1) NOT NULL,
	[EstadoContenido] [nvarchar](250) NULL,
	[TipoContenido] [nvarchar](250) NULL,
	[FK_Id_Sitio] [int] NULL,
	[Url] [nvarchar](250) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 05/23/2012 01:47:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Id] [int] IDENTITY(4,1) NOT NULL,
	[Conectado] [nvarchar](1) NULL,
	[Descripcion] [nvarchar](max) NULL,
	[Email] [nvarchar](250) NULL,
	[FK_Id_Sitio] [int] NULL,
	[Nombre] [nvarchar](250) NULL,
	[Password] [nvarchar](250) NULL,
	[Pregunta] [nvarchar](250) NULL,
	[Region] [nvarchar](250) NULL,
	[Respuesta] [nvarchar](250) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsuTematica]    Script Date: 05/23/2012 01:47:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuTematica](
	[Id] [int] IDENTITY(4,1) NOT NULL,
	[FK_Id_Tematica] [int] NULL,
	[FK_Id_Usuario] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Convocatoria]    Script Date: 05/23/2012 01:47:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Convocatoria](
	[Id] [int] IDENTITY(4,1) NOT NULL,
	[Titulo] [nvarchar](250) NULL,
	[LogoUrl] [nvarchar](250) NULL,
	[Descripcion] [nvarchar](max) NULL,
	[Quorum] [int] NULL,
	[Coordenadas] [nvarchar](250) NULL,
	[FK_Id_UsuarioCreacion] [int] NULL,
	[FK_Id_Sitio] [int] NULL,
	[FK_Id_Tematica] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MarcaContenido]    Script Date: 05/23/2012 01:47:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MarcaContenido](
	[Id] [int] IDENTITY(4,1) NOT NULL,
	[FK_Id_Contenido] [int] NULL,
	[TipoMarca] [nvarchar](250) NULL,
	[FK_Id_Usuario] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Notificacion]    Script Date: 05/23/2012 01:47:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notificacion](
	[Id] [int] IDENTITY(4,1) NOT NULL,
	[Contenido] [nvarchar](250) NULL,
	[Visto] [nvarchar](1) NULL,
	[FK_Id_Convocatoria] [int] NULL,
	[FK_Id_Usuario] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AsistenciaConvocatoria]    Script Date: 05/23/2012 01:47:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AsistenciaConvocatoria](
	[Id] [int] IDENTITY(4,1) NOT NULL,
	[FK_Id_Convocatoria] [int] NULL,
	[FK_Id_Usuario] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_Sitio_FK_Imagen]    Script Date: 05/23/2012 01:47:10 ******/
ALTER TABLE [dbo].[Sitio]  WITH CHECK ADD  CONSTRAINT [FK_Sitio_FK_Imagen] FOREIGN KEY([FK_Id_Imagen])
REFERENCES [dbo].[Imagen] ([Id])
GO
ALTER TABLE [dbo].[Sitio] CHECK CONSTRAINT [FK_Sitio_FK_Imagen]
GO
/****** Object:  ForeignKey [FK_Contenido_FK_Id_Sitio]    Script Date: 05/23/2012 01:47:10 ******/
ALTER TABLE [dbo].[Contenido]  WITH CHECK ADD  CONSTRAINT [FK_Contenido_FK_Id_Sitio] FOREIGN KEY([FK_Id_Sitio])
REFERENCES [dbo].[Sitio] ([Id])
GO
ALTER TABLE [dbo].[Contenido] CHECK CONSTRAINT [FK_Contenido_FK_Id_Sitio]
GO
/****** Object:  ForeignKey [FK_Usuario_FK_Id_Sitio]    Script Date: 05/23/2012 01:47:10 ******/
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_FK_Id_Sitio] FOREIGN KEY([FK_Id_Sitio])
REFERENCES [dbo].[Sitio] ([Id])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_FK_Id_Sitio]
GO
/****** Object:  ForeignKey [FK_Contenido_FK_Id_Tematica]    Script Date: 05/23/2012 01:47:10 ******/
ALTER TABLE [dbo].[UsuTematica]  WITH CHECK ADD  CONSTRAINT [FK_Contenido_FK_Id_Tematica] FOREIGN KEY([FK_Id_Tematica])
REFERENCES [dbo].[Tematica] ([Id])
GO
ALTER TABLE [dbo].[UsuTematica] CHECK CONSTRAINT [FK_Contenido_FK_Id_Tematica]
GO
/****** Object:  ForeignKey [FK_Contenido_FK_Id_Usuario]    Script Date: 05/23/2012 01:47:10 ******/
ALTER TABLE [dbo].[UsuTematica]  WITH CHECK ADD  CONSTRAINT [FK_Contenido_FK_Id_Usuario] FOREIGN KEY([FK_Id_Usuario])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[UsuTematica] CHECK CONSTRAINT [FK_Contenido_FK_Id_Usuario]
GO
/****** Object:  ForeignKey [FK_Convocatoria_FK_Sitio]    Script Date: 05/23/2012 01:47:10 ******/
ALTER TABLE [dbo].[Convocatoria]  WITH CHECK ADD  CONSTRAINT [FK_Convocatoria_FK_Sitio] FOREIGN KEY([FK_Id_Sitio])
REFERENCES [dbo].[Sitio] ([Id])
GO
ALTER TABLE [dbo].[Convocatoria] CHECK CONSTRAINT [FK_Convocatoria_FK_Sitio]
GO
/****** Object:  ForeignKey [FK_Convocatoria_FK_Tematica]    Script Date: 05/23/2012 01:47:10 ******/
ALTER TABLE [dbo].[Convocatoria]  WITH CHECK ADD  CONSTRAINT [FK_Convocatoria_FK_Tematica] FOREIGN KEY([FK_Id_Tematica])
REFERENCES [dbo].[Tematica] ([Id])
GO
ALTER TABLE [dbo].[Convocatoria] CHECK CONSTRAINT [FK_Convocatoria_FK_Tematica]
GO
/****** Object:  ForeignKey [FK_Convocatoria_FK_UsuarioCreacion]    Script Date: 05/23/2012 01:47:10 ******/
ALTER TABLE [dbo].[Convocatoria]  WITH CHECK ADD  CONSTRAINT [FK_Convocatoria_FK_UsuarioCreacion] FOREIGN KEY([FK_Id_UsuarioCreacion])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[Convocatoria] CHECK CONSTRAINT [FK_Convocatoria_FK_UsuarioCreacion]
GO
/****** Object:  ForeignKey [FK_MarcaContenido_FK_Id_Contenido]    Script Date: 05/23/2012 01:47:10 ******/
ALTER TABLE [dbo].[MarcaContenido]  WITH CHECK ADD  CONSTRAINT [FK_MarcaContenido_FK_Id_Contenido] FOREIGN KEY([FK_Id_Contenido])
REFERENCES [dbo].[Contenido] ([Id])
GO
ALTER TABLE [dbo].[MarcaContenido] CHECK CONSTRAINT [FK_MarcaContenido_FK_Id_Contenido]
GO
/****** Object:  ForeignKey [FK_MarcaContenido_FK_Id_Usuario]    Script Date: 05/23/2012 01:47:10 ******/
ALTER TABLE [dbo].[MarcaContenido]  WITH CHECK ADD  CONSTRAINT [FK_MarcaContenido_FK_Id_Usuario] FOREIGN KEY([FK_Id_Usuario])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[MarcaContenido] CHECK CONSTRAINT [FK_MarcaContenido_FK_Id_Usuario]
GO
/****** Object:  ForeignKey [FK_Notificacion_FK_Id_Convocatoria]    Script Date: 05/23/2012 01:47:10 ******/
ALTER TABLE [dbo].[Notificacion]  WITH CHECK ADD  CONSTRAINT [FK_Notificacion_FK_Id_Convocatoria] FOREIGN KEY([FK_Id_Convocatoria])
REFERENCES [dbo].[Convocatoria] ([Id])
GO
ALTER TABLE [dbo].[Notificacion] CHECK CONSTRAINT [FK_Notificacion_FK_Id_Convocatoria]
GO
/****** Object:  ForeignKey [FK_Notificacion_FK_Id_Usuario]    Script Date: 05/23/2012 01:47:10 ******/
ALTER TABLE [dbo].[Notificacion]  WITH CHECK ADD  CONSTRAINT [FK_Notificacion_FK_Id_Usuario] FOREIGN KEY([FK_Id_Usuario])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[Notificacion] CHECK CONSTRAINT [FK_Notificacion_FK_Id_Usuario]
GO
/****** Object:  ForeignKey [FK_AsistenciaConvocatoria_FK_Id_Convocatoria]    Script Date: 05/23/2012 01:47:11 ******/
ALTER TABLE [dbo].[AsistenciaConvocatoria]  WITH CHECK ADD  CONSTRAINT [FK_AsistenciaConvocatoria_FK_Id_Convocatoria] FOREIGN KEY([FK_Id_Convocatoria])
REFERENCES [dbo].[Convocatoria] ([Id])
GO
ALTER TABLE [dbo].[AsistenciaConvocatoria] CHECK CONSTRAINT [FK_AsistenciaConvocatoria_FK_Id_Convocatoria]
GO
/****** Object:  ForeignKey [FK_AsistenciaConvocatoria_FK_Id_Usuario]    Script Date: 05/23/2012 01:47:11 ******/
ALTER TABLE [dbo].[AsistenciaConvocatoria]  WITH CHECK ADD  CONSTRAINT [FK_AsistenciaConvocatoria_FK_Id_Usuario] FOREIGN KEY([FK_Id_Usuario])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[AsistenciaConvocatoria] CHECK CONSTRAINT [FK_AsistenciaConvocatoria_FK_Id_Usuario]
GO
