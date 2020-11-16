create database SistemaPermisos
Go
USE [pruebaMardom]
GO
ALTER TABLE [dbo].[PERMISOS] DROP CONSTRAINT [FK__PERMISOS__TipoPe__2E1BDC42]
GO
/****** Object:  Table [dbo].[TipoPermiso]    Script Date: 11/16/2020 12:48:23 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TipoPermiso]') AND type in (N'U'))
DROP TABLE [dbo].[TipoPermiso]
GO
/****** Object:  Table [dbo].[PERMISOS]    Script Date: 11/16/2020 12:48:23 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PERMISOS]') AND type in (N'U'))
DROP TABLE [dbo].[PERMISOS]
GO
/****** Object:  Table [dbo].[PERMISOS]    Script Date: 11/16/2020 12:48:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PERMISOS](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NombreEmpleado] [varchar](60) NOT NULL,
	[ApellidosEmpleado] [varchar](60) NOT NULL,
	[TipoPermisoId] [int] NOT NULL,
	[FechaPermiso] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoPermiso]    Script Date: 11/16/2020 12:48:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoPermiso](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[PERMISOS] ON 
GO
INSERT [dbo].[PERMISOS] ([Id], [NombreEmpleado], [ApellidosEmpleado], [TipoPermisoId], [FechaPermiso]) VALUES (1, N'Luisa', N'Rodriguez', 1, CAST(N'2020-11-13T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[PERMISOS] ([Id], [NombreEmpleado], [ApellidosEmpleado], [TipoPermisoId], [FechaPermiso]) VALUES (6, N'Martha ', N'Perez', 3, CAST(N'2020-11-22T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[PERMISOS] ([Id], [NombreEmpleado], [ApellidosEmpleado], [TipoPermisoId], [FechaPermiso]) VALUES (7, N'Julia', N'Diaz', 1, CAST(N'2020-11-21T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[PERMISOS] ([Id], [NombreEmpleado], [ApellidosEmpleado], [TipoPermisoId], [FechaPermiso]) VALUES (8, N'Julia', N'Diaz', 1, CAST(N'2020-11-21T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[PERMISOS] ([Id], [NombreEmpleado], [ApellidosEmpleado], [TipoPermisoId], [FechaPermiso]) VALUES (9, N'Juan ', N'Martinez', 3, CAST(N'2020-11-21T00:00:00.000' AS DateTime))
GO

SET IDENTITY_INSERT [dbo].[PERMISOS] OFF
GO
SET IDENTITY_INSERT [dbo].[TipoPermiso] ON 
GO
INSERT [dbo].[TipoPermiso] ([Id], [Descripcion]) VALUES (1, N'Enfermedad')
GO
INSERT [dbo].[TipoPermiso] ([Id], [Descripcion]) VALUES (2, N'Estudios')
GO
INSERT [dbo].[TipoPermiso] ([Id], [Descripcion]) VALUES (3, N'Vacaciones')
GO
INSERT [dbo].[TipoPermiso] ([Id], [Descripcion]) VALUES (4, N'Diligencias')
GO
SET IDENTITY_INSERT [dbo].[TipoPermiso] OFF
GO
ALTER TABLE [dbo].[PERMISOS]  WITH CHECK ADD FOREIGN KEY([TipoPermisoId])
REFERENCES [dbo].[TipoPermiso] ([Id])
GO
