USE [master]
GO
/****** Object:  Database [dbventas]    Script Date: 23-Feb-21 3:54:53 PM ******/
CREATE DATABASE [dbventas]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'dbventas', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\dbventas.mdf' , SIZE = 3136KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'dbventas_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\dbventas_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [dbventas] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [dbventas].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [dbventas] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [dbventas] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [dbventas] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [dbventas] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [dbventas] SET ARITHABORT OFF 
GO
ALTER DATABASE [dbventas] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [dbventas] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [dbventas] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [dbventas] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [dbventas] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [dbventas] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [dbventas] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [dbventas] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [dbventas] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [dbventas] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [dbventas] SET  ENABLE_BROKER 
GO
ALTER DATABASE [dbventas] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [dbventas] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [dbventas] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [dbventas] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [dbventas] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [dbventas] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [dbventas] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [dbventas] SET RECOVERY FULL 
GO
ALTER DATABASE [dbventas] SET  MULTI_USER 
GO
ALTER DATABASE [dbventas] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [dbventas] SET DB_CHAINING OFF 
GO
ALTER DATABASE [dbventas] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [dbventas] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'dbventas', N'ON'
GO
USE [dbventas]
GO
/****** Object:  StoredProcedure [dbo].[spbuscar_articulo_nombre]    Script Date: 23-Feb-21 3:54:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spbuscar_articulo_nombre]
@textobuscar varchar(50)
as
SELECT dbo.articulo.idarticulo, dbo.articulo.codigo, dbo.articulo.nombre, dbo.articulo.descripcion, dbo.articulo.imagen, dbo.articulo.idcategoria, 
dbo.categoria.nombre AS Categoria, dbo.articulo.idpresentacion, dbo.presentacion.nombre AS Presentacion



FROM dbo.articulo INNER JOIN
dbo.categoria ON dbo.articulo.idcategoria = dbo.categoria.idcategoria INNER JOIN
dbo.presentacion ON dbo.articulo.idpresentacion = dbo.presentacion.idpresentacion
where dbo.articulo.nombre like @textobuscar + '%'		
order by dbo.articulo.idarticulo desc


GO
/****** Object:  StoredProcedure [dbo].[spbuscar_categoria]    Script Date: 23-Feb-21 3:54:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spbuscar_categoria] 
@textobuscar varchar(50)
as
select * from categoria
where  nombre like @textobuscar + '%'


GO
/****** Object:  StoredProcedure [dbo].[spbuscar_presentacion_nombre]    Script Date: 23-Feb-21 3:54:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spbuscar_presentacion_nombre]
@textobuscar varchar(50)
as
select * from presentacion
where nombre like @textobuscar + '%'

GO
/****** Object:  StoredProcedure [dbo].[spbuscar_proveedor_num_documento]    Script Date: 23-Feb-21 3:54:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[spbuscar_proveedor_num_documento]
@textobuscar varchar(11)
as
select * from proveedor
where num_documento like @textobuscar + '%'


GO
/****** Object:  StoredProcedure [dbo].[spbuscar_proveedor_razon_social]    Script Date: 23-Feb-21 3:54:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spbuscar_proveedor_razon_social]
@textobuscar varchar(50)
as
select * from proveedor
where razon_social like @textobuscar + '%'


GO
/****** Object:  StoredProcedure [dbo].[spbuscar_razon_social_num_documento]    Script Date: 23-Feb-21 3:54:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Buscar_razon_social
create proc [dbo].[spbuscar_razon_social_num_documento]
@textobuscar varchar(50)
as
select * from proveedor
where num_documento like @textobuscar + '%'

select * from proveedor

GO
/****** Object:  StoredProcedure [dbo].[spbuscar_trabajador_apellidos]    Script Date: 23-Feb-21 3:54:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Buscar Apellido
create proc [dbo].[spbuscar_trabajador_apellidos]
@textobuscar varchar(50)
as
select *  from trabajador
where apellidos like @textobuscar + '%'
order by apellidos asc

GO
/****** Object:  StoredProcedure [dbo].[spbuscar_trabajador_num_documento]    Script Date: 23-Feb-21 3:54:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Buscar Num_Documento

create proc [dbo].[spbuscar_trabajador_num_documento]
@textobuscar varchar(50)
as
select *  from trabajador
where num_documento like @textobuscar + '%'
order by apellidos asc

GO
/****** Object:  StoredProcedure [dbo].[speditar_articulo]    Script Date: 23-Feb-21 3:54:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[speditar_articulo]


@idarticulo int,
@codigo varchar(50),
@nombre varchar(50),
@descripcion varchar(1024),
@imagen image,
@idcategoria int,
@idpresentacion int
as

update articulo set codigo=@codigo, nombre=@nombre, descripcion=@descripcion, 
imagen=@imagen, idcategoria=@idcategoria, idpresentacion=@idpresentacion
where idarticulo=@idarticulo



GO
/****** Object:  StoredProcedure [dbo].[speditar_categoria]    Script Date: 23-Feb-21 3:54:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[speditar_categoria]
@idcategoria int,
@nombre varchar(50),
@descripcion varchar(256)
as
update categoria set nombre=@nombre,
descripcion=@descripcion
where idcategoria=@idcategoria


GO
/****** Object:  StoredProcedure [dbo].[speditar_presentacion]    Script Date: 23-Feb-21 3:54:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[speditar_presentacion]

@idpresentacion int,
@nombre varchar(50),
@descripcion varchar(256)
as
update presentacion set nombre=@nombre, descripcion=@descripcion
where idpresentacion=@idpresentacion


GO
/****** Object:  StoredProcedure [dbo].[speditar_proveedor]    Script Date: 23-Feb-21 3:54:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[speditar_proveedor]


@idproveedor int,
@razon_social varchar(150),
@sector_comercial varchar(50),
@tipo_documento varchar(20),
@num_documento varchar(11),
@direccion varchar(100),
@telefono varchar(10),
@email varchar(50),
@url varchar(100)
as
update proveedor set razon_social = @razon_social,
sector_comercial = @sector_comercial, tipo_documento = @tipo_documento,
num_documento = @num_documento, direccion = @direccion,telefono = @telefono,
email = @email, url = @url

where idproveedor = @idproveedor


GO
/****** Object:  StoredProcedure [dbo].[speditar_trabajador]    Script Date: 23-Feb-21 3:54:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[speditar_trabajador]

@idtrabajador int,
@nombre varchar (20),
@apellidos varchar (40),
@sexo varchar (1),
@fecha_nacimiento date,
@num_documento varchar(8),
@direccion varchar (100),
@telefono varchar (10),
@email varchar (50),
@acceso varchar (20),
@usuario varchar (20),
@password varchar (20)
as
update trabajador set nombre=@nombre, apellidos=@apellidos,
sexo=@sexo,fecha_nac=@fecha_nacimiento,num_documento=@num_documento,
direccion=@direccion,telefono=@telefono,email=@email,
acceso=@acceso,usuario=@usuario,password=@password
where idtrabajador=@idtrabajador

GO
/****** Object:  StoredProcedure [dbo].[speliminar_articulo]    Script Date: 23-Feb-21 3:54:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[speliminar_articulo]
@idarticulo int
as
delete from articulo
where idarticulo = @idarticulo


GO
/****** Object:  StoredProcedure [dbo].[speliminar_categoria]    Script Date: 23-Feb-21 3:54:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[speliminar_categoria]
@idcategoria int
as
delete from categoria
where idcategoria=@idcategoria


GO
/****** Object:  StoredProcedure [dbo].[speliminar_presentacion]    Script Date: 23-Feb-21 3:54:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[speliminar_presentacion]
@idpresentacion int
as
delete from presentacion
where idpresentacion=@idpresentacion


GO
/****** Object:  StoredProcedure [dbo].[speliminar_proveedor]    Script Date: 23-Feb-21 3:54:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[speliminar_proveedor]

@idproveedor int
as
delete from proveedor
where idproveedor =@idproveedor


GO
/****** Object:  StoredProcedure [dbo].[speliminar_trabajador]    Script Date: 23-Feb-21 3:54:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Eliminar
create proc [dbo].[speliminar_trabajador]
@idtrabajador int
as
delete from trabajador
where idtrabajador=@idtrabajador

GO
/****** Object:  StoredProcedure [dbo].[spinsertar_articulo]    Script Date: 23-Feb-21 3:54:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Procedimiento Insertar Articulo
create proc [dbo].[spinsertar_articulo]
@idarticulo int output,
@codigo varchar(50),
@nombre varchar(50),
@descripcion varchar(1024),
@imagen image,
@idcategoria int,
@idpresentacion int
as

insert into articulo (codigo, nombre, descripcion, imagen, idcategoria, idpresentacion)
values (@codigo,@nombre,@descripcion,@imagen,@idcategoria,@idpresentacion)


GO
/****** Object:  StoredProcedure [dbo].[spinsertar_categoria]    Script Date: 23-Feb-21 3:54:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spinsertar_categoria]
@idcategoria int output,
@nombre varchar(50),
@descripcion varchar(256)
as
insert into categoria (nombre,descripcion)
values (@nombre,@descripcion)


GO
/****** Object:  StoredProcedure [dbo].[spinsertar_presentacion]    Script Date: 23-Feb-21 3:54:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spinsertar_presentacion]
@idpresentacion int output,
@nombre varchar(50),
@descripcion varchar(256)
as
insert into presentacion (nombre, descripcion)
values (@nombre, @descripcion)


GO
/****** Object:  StoredProcedure [dbo].[spinsertar_proveedor]    Script Date: 23-Feb-21 3:54:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Insertar
create proc [dbo].[spinsertar_proveedor]
@idproveedor int output,
@razon_social varchar(150),
@sector_comercial varchar(50),
@tipo_documento varchar(20),
@num_documento varchar(11),
@direccion varchar(100),
@telefono varchar(10),
@email varchar(50),
@url varchar(100)
as
insert into proveedor (razon_social,sector_comercial,tipo_documento,num_documento,direccion,telefono,email,url)
values(@razon_social,@sector_comercial,@tipo_documento,@num_documento,@direccion,@telefono,@email,@url)



GO
/****** Object:  StoredProcedure [dbo].[spinsertar_trabajador]    Script Date: 23-Feb-21 3:54:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spinsertar_trabajador]
@idtrabajador int output,
@nombre varchar (20),
@apellidos varchar (40),
@sexo varchar (1),
@fecha_nacimiento date,
@num_documento varchar(8),
@direccion varchar (100),
@telefono varchar (10),
@email varchar (50),
@acceso varchar (20),
@usuario varchar (20),
@password varchar (20)
as
insert into trabajador (nombre, apellidos,sexo,fecha_nac,
num_documento, direccion,telefono,email,acceso, usuario,password)
values (@nombre,@apellidos,@sexo,@fecha_nacimiento,@num_documento,
@direccion,@telefono,@email,@acceso,@usuario,@password)

GO
/****** Object:  StoredProcedure [dbo].[splogin]    Script Date: 23-Feb-21 3:54:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[splogin]
@usuario varchar (20),
@password varchar(20)
as
select idtrabajador,apellidos,nombre,acceso
from trabajador
where usuario=@usuario and password=@password

GO
/****** Object:  StoredProcedure [dbo].[spmostrar_articulo]    Script Date: 23-Feb-21 3:54:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Procedimiento Mostrar Articulo

create proc [dbo].[spmostrar_articulo]
as

SELECT top 100 dbo.articulo.idarticulo, dbo.articulo.codigo, dbo.articulo.nombre, dbo.articulo.descripcion, dbo.articulo.imagen, dbo.articulo.idcategoria, 
              dbo.categoria.nombre AS Categoria, dbo.articulo.idpresentacion, dbo.presentacion.nombre AS Presentacion



FROM          dbo.articulo INNER JOIN
              dbo.categoria ON dbo.articulo.idcategoria = dbo.categoria.idcategoria INNER JOIN
              dbo.presentacion ON dbo.articulo.idpresentacion = dbo.presentacion.idpresentacion
			  order by dbo.articulo.idarticulo desc


GO
/****** Object:  StoredProcedure [dbo].[spmostrar_categoria]    Script Date: 23-Feb-21 3:54:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spmostrar_categoria]
as
select top 200 * from categoria
order by idcategoria desc


GO
/****** Object:  StoredProcedure [dbo].[spmostrar_presentacion]    Script Date: 23-Feb-21 3:54:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spmostrar_presentacion]
as
select top 100 * from presentacion
order by idpresentacion desc


GO
/****** Object:  StoredProcedure [dbo].[spmostrar_proveedor]    Script Date: 23-Feb-21 3:54:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[spmostrar_proveedor]
as
select top 100 * from proveedor
order by razon_social asc


GO
/****** Object:  StoredProcedure [dbo].[spmostrar_trabajador]    Script Date: 23-Feb-21 3:54:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spmostrar_trabajador]
as
select top 100 * from trabajador
order by apellidos asc

GO
/****** Object:  Table [dbo].[articulo]    Script Date: 23-Feb-21 3:54:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[articulo](
	[idarticulo] [int] IDENTITY(1,1) NOT NULL,
	[codigo] [varchar](50) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[descripcion] [varchar](1024) NULL,
	[imagen] [image] NULL,
	[idcategoria] [int] NOT NULL,
	[idpresentacion] [int] NOT NULL,
 CONSTRAINT [PK_articulo] PRIMARY KEY CLUSTERED 
(
	[idarticulo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[categoria]    Script Date: 23-Feb-21 3:54:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[categoria](
	[idcategoria] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[descripcion] [varchar](256) NULL,
 CONSTRAINT [PK_categoria] PRIMARY KEY CLUSTERED 
(
	[idcategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[cliente]    Script Date: 23-Feb-21 3:54:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[cliente](
	[idcliente] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[apellidos] [varchar](40) NULL,
	[sexo] [varchar](1) NULL,
	[fecha_nacimiento] [date] NOT NULL,
	[num_documento] [varchar](11) NOT NULL,
	[direccion] [varchar](100) NULL,
	[telefono] [varchar](10) NULL,
	[email] [varchar](10) NULL,
 CONSTRAINT [PK_cliente] PRIMARY KEY CLUSTERED 
(
	[idcliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[detalle_ingreso]    Script Date: 23-Feb-21 3:54:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[detalle_ingreso](
	[iddetalle_ingreso] [int] IDENTITY(1,1) NOT NULL,
	[idingreso] [int] NOT NULL,
	[idarticulo] [int] NOT NULL,
	[precio_compra] [money] NOT NULL,
	[precio_venta] [money] NOT NULL,
	[stock_inicial] [int] NOT NULL,
	[stock_actual] [int] NOT NULL,
	[fecha_produccion] [date] NOT NULL,
	[fecha_vencimiento] [date] NOT NULL,
 CONSTRAINT [PK_detalle_ingreso] PRIMARY KEY CLUSTERED 
(
	[iddetalle_ingreso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[detalle_venta]    Script Date: 23-Feb-21 3:54:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[detalle_venta](
	[iddatalle_venta] [int] IDENTITY(1,1) NOT NULL,
	[idventa] [int] NOT NULL,
	[iddetalle_ingreso] [int] NOT NULL,
	[cantidad] [int] NOT NULL,
	[precio_venta] [money] NOT NULL,
	[descuento] [money] NOT NULL,
 CONSTRAINT [PK_detalle_venta] PRIMARY KEY CLUSTERED 
(
	[iddatalle_venta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ingreso]    Script Date: 23-Feb-21 3:54:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ingreso](
	[idingreso] [int] IDENTITY(1,1) NOT NULL,
	[idtrabajador] [int] NOT NULL,
	[idproveedor] [int] NOT NULL,
	[fecha] [date] NOT NULL,
	[tipo_comprobante] [varchar](20) NOT NULL,
	[serie] [varchar](4) NOT NULL,
	[correlativo] [varchar](7) NOT NULL,
	[igv] [decimal](4, 2) NOT NULL,
 CONSTRAINT [PK_ingreso] PRIMARY KEY CLUSTERED 
(
	[idingreso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[presentacion]    Script Date: 23-Feb-21 3:54:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[presentacion](
	[idpresentacion] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[descripcion] [varchar](256) NULL,
 CONSTRAINT [PK_presentacion] PRIMARY KEY CLUSTERED 
(
	[idpresentacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[proveedor]    Script Date: 23-Feb-21 3:54:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[proveedor](
	[idproveedor] [int] IDENTITY(1,1) NOT NULL,
	[razon_social] [varchar](150) NOT NULL,
	[sector_comercial] [varchar](50) NOT NULL,
	[tipo_documento] [varchar](20) NOT NULL,
	[num_documento] [varchar](11) NOT NULL,
	[direccion] [varchar](100) NULL,
	[telefono] [varchar](10) NULL,
	[email] [varchar](50) NULL,
	[url] [varchar](100) NULL,
 CONSTRAINT [PK_proveedor] PRIMARY KEY CLUSTERED 
(
	[idproveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[trabajador]    Script Date: 23-Feb-21 3:54:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[trabajador](
	[idtrabajador] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](20) NOT NULL,
	[apellidos] [varchar](40) NOT NULL,
	[sexo] [varchar](1) NOT NULL,
	[fecha_nac] [date] NOT NULL,
	[num_documento] [varchar](8) NOT NULL,
	[direccion] [varchar](100) NULL,
	[telefono] [varchar](10) NULL,
	[email] [varchar](50) NULL,
	[acceso] [varchar](20) NOT NULL,
	[usuario] [varchar](20) NOT NULL,
	[password] [varchar](20) NOT NULL,
 CONSTRAINT [PK_trabajador] PRIMARY KEY CLUSTERED 
(
	[idtrabajador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[venta]    Script Date: 23-Feb-21 3:54:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[venta](
	[idventa] [int] IDENTITY(1,1) NOT NULL,
	[idcliente] [int] NOT NULL,
	[idtrabajador] [int] NOT NULL,
	[fecha] [date] NOT NULL,
	[tipo_comprobante] [varchar](20) NOT NULL,
	[serie] [varchar](4) NOT NULL,
	[correlativo] [varchar](7) NOT NULL,
	[igv] [decimal](4, 2) NOT NULL,
 CONSTRAINT [PK_venta] PRIMARY KEY CLUSTERED 
(
	[idventa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[Vista_Articulos]    Script Date: 23-Feb-21 3:54:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Vista_Articulos]
AS
SELECT        dbo.articulo.idarticulo, dbo.articulo.codigo, dbo.articulo.nombre, dbo.articulo.descripcion, dbo.articulo.imagen, dbo.articulo.idcategoria, 
                         dbo.categoria.nombre AS Expr1, dbo.articulo.idpresentacion, dbo.presentacion.nombre AS Expr2
FROM            dbo.articulo INNER JOIN
                         dbo.categoria ON dbo.articulo.idcategoria = dbo.categoria.idcategoria INNER JOIN
                         dbo.presentacion ON dbo.articulo.idpresentacion = dbo.presentacion.idpresentacion


GO
ALTER TABLE [dbo].[articulo]  WITH CHECK ADD  CONSTRAINT [FK_articulo_categoria] FOREIGN KEY([idcategoria])
REFERENCES [dbo].[categoria] ([idcategoria])
GO
ALTER TABLE [dbo].[articulo] CHECK CONSTRAINT [FK_articulo_categoria]
GO
ALTER TABLE [dbo].[articulo]  WITH CHECK ADD  CONSTRAINT [FK_articulo_presentacion] FOREIGN KEY([idpresentacion])
REFERENCES [dbo].[presentacion] ([idpresentacion])
GO
ALTER TABLE [dbo].[articulo] CHECK CONSTRAINT [FK_articulo_presentacion]
GO
ALTER TABLE [dbo].[detalle_ingreso]  WITH CHECK ADD  CONSTRAINT [FK_detalle_ingreso_articulo] FOREIGN KEY([idarticulo])
REFERENCES [dbo].[articulo] ([idarticulo])
GO
ALTER TABLE [dbo].[detalle_ingreso] CHECK CONSTRAINT [FK_detalle_ingreso_articulo]
GO
ALTER TABLE [dbo].[detalle_ingreso]  WITH CHECK ADD  CONSTRAINT [FK_detalle_ingreso_ingreso] FOREIGN KEY([idingreso])
REFERENCES [dbo].[ingreso] ([idingreso])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[detalle_ingreso] CHECK CONSTRAINT [FK_detalle_ingreso_ingreso]
GO
ALTER TABLE [dbo].[detalle_venta]  WITH CHECK ADD  CONSTRAINT [FK_detalle_venta_detalle_ingreso] FOREIGN KEY([iddetalle_ingreso])
REFERENCES [dbo].[detalle_ingreso] ([iddetalle_ingreso])
GO
ALTER TABLE [dbo].[detalle_venta] CHECK CONSTRAINT [FK_detalle_venta_detalle_ingreso]
GO
ALTER TABLE [dbo].[detalle_venta]  WITH CHECK ADD  CONSTRAINT [FK_detalle_venta_venta] FOREIGN KEY([idventa])
REFERENCES [dbo].[venta] ([idventa])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[detalle_venta] CHECK CONSTRAINT [FK_detalle_venta_venta]
GO
ALTER TABLE [dbo].[ingreso]  WITH CHECK ADD  CONSTRAINT [FK_ingreso_proveedor] FOREIGN KEY([idproveedor])
REFERENCES [dbo].[proveedor] ([idproveedor])
GO
ALTER TABLE [dbo].[ingreso] CHECK CONSTRAINT [FK_ingreso_proveedor]
GO
ALTER TABLE [dbo].[ingreso]  WITH CHECK ADD  CONSTRAINT [FK_ingreso_trabajador] FOREIGN KEY([idtrabajador])
REFERENCES [dbo].[trabajador] ([idtrabajador])
GO
ALTER TABLE [dbo].[ingreso] CHECK CONSTRAINT [FK_ingreso_trabajador]
GO
ALTER TABLE [dbo].[venta]  WITH CHECK ADD  CONSTRAINT [FK_venta_cliente] FOREIGN KEY([idcliente])
REFERENCES [dbo].[cliente] ([idcliente])
GO
ALTER TABLE [dbo].[venta] CHECK CONSTRAINT [FK_venta_cliente]
GO
ALTER TABLE [dbo].[venta]  WITH CHECK ADD  CONSTRAINT [FK_venta_trabajador] FOREIGN KEY([idtrabajador])
REFERENCES [dbo].[trabajador] ([idtrabajador])
GO
ALTER TABLE [dbo].[venta] CHECK CONSTRAINT [FK_venta_trabajador]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[65] 4[3] 2[23] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "articulo"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 272
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "categoria"
            Begin Extent = 
               Top = 0
               Left = 258
               Bottom = 200
               Right = 428
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "presentacion"
            Begin Extent = 
               Top = 6
               Left = 454
               Bottom = 157
               Right = 624
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Vista_Articulos'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Vista_Articulos'
GO
USE [master]
GO
ALTER DATABASE [dbventas] SET  READ_WRITE 
GO
