Create Database SistemaPermisos
Go

USE [SistemaPermisos]
GO

/****** Object:  Table [dbo].[TipoPermiso]    Script Date: 11/16/2020 12:41:10 AM ******/
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
ALTER TABLE [dbo].[PERMISOS]  WITH CHECK ADD FOREIGN KEY([TipoPermisoId])
REFERENCES [dbo].[TipoPermiso] ([Id])
GO
/****** Object:  Table [dbo].[PERMISOS]    Script Date: 11/16/2020 12:41:09 AM ******/
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

