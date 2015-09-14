USE [master]
GO
/****** Object:  Database [Muebla]    Script Date: 14/09/2015 0:56:52 ******/
CREATE DATABASE [Muebla]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Muebla', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\Muebla.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Muebla_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\Muebla_log.ldf' , SIZE = 1792KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Muebla] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Muebla].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Muebla] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Muebla] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Muebla] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Muebla] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Muebla] SET ARITHABORT OFF 
GO
ALTER DATABASE [Muebla] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Muebla] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Muebla] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Muebla] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Muebla] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Muebla] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Muebla] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Muebla] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Muebla] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Muebla] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Muebla] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Muebla] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Muebla] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Muebla] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Muebla] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Muebla] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Muebla] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Muebla] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Muebla] SET RECOVERY FULL 
GO
ALTER DATABASE [Muebla] SET  MULTI_USER 
GO
ALTER DATABASE [Muebla] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Muebla] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Muebla] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Muebla] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Muebla', N'ON'
GO
USE [Muebla]
GO
/****** Object:  User [IIS APPPOOL\Muebla]    Script Date: 14/09/2015 0:56:53 ******/
CREATE USER [IIS APPPOOL\Muebla] FOR LOGIN [IIS APPPOOL\Muebla] WITH DEFAULT_SCHEMA=[IIS APPPOOL\Muebla]
GO
/****** Object:  Schema [IIS APPPOOL\Muebla]    Script Date: 14/09/2015 0:56:53 ******/
CREATE SCHEMA [IIS APPPOOL\Muebla]
GO
/****** Object:  StoredProcedure [dbo].[ALTA_CLIENTE_SP]    Script Date: 14/09/2015 0:56:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ALTA_CLIENTE_SP]
@usr VARCHAR(50),
@mail VARCHAR(50),
@nom VARCHAR(50),
@ape VARCHAR(50),
@pass VARCHAR(50),
@dni VARCHAR(50),
@cuil VARCHAR(50),
@tipo integer

AS
declare @id int;
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	INSERT INTO Usuario (apellido,nombre,baja,cuil, dni, idIdioma,idTipoUsuario,mail, usr, pass,idTipoDocumento )
	values(@ape,@nom,0,@cuil,@dni,1,2,@mail,@usr,@pass,@tipo);

	set @id = SCOPE_IDENTITY();

	insert into UsuarioRol(idUsuario,idRol) values (@id,2);
	return @id
END

GO
/****** Object:  StoredProcedure [dbo].[ALTA_DOMICILIO_SP]    Script Date: 14/09/2015 0:56:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ALTA_DOMICILIO_SP]
@usr integer,
@calle VARCHAR(50),
@nro VARCHAR(50),
@piso VARCHAR(50),
@dpto VARCHAR(50),
@loc integer

AS
declare @id int;
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	INSERT INTO Domicilio(calle,dpto,idLocalidad,idUsuario , numero,piso)
	values(@calle,@dpto,@loc,@usr,@nro,@piso);

	set @id = SCOPE_IDENTITY();
	return @id
END

GO
/****** Object:  StoredProcedure [dbo].[ALTA_LOG_SP]    Script Date: 14/09/2015 0:56:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ALTA_LOG_SP]
@usr integer,
@evento integer
AS
declare @id int;
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

		
    -- Insert statements for procedure here
	insert into Bitacora (codigoEvento, fecha, idUsuario) values (@evento,GETDATE(),@usr);
	set @id = SCOPE_IDENTITY();

	return @id
END

GO
/****** Object:  StoredProcedure [dbo].[ALTA_PRODUCTO_SP]    Script Date: 14/09/2015 0:56:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ALTA_PRODUCTO_SP]
@des VARCHAR(50),
@tipo INTEGER,
@sto INTEGER,
@stomin INTEGER,
@prov INTEGER,
@img varbinary(max)
AS
declare @id int;
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	INSERT INTO producto (baja,descripcion,idTipoProducto,stock,stockMinimo,imagen1)
	values(0,@des,@tipo,@sto,@stomin,@img);

	set @id = SCOPE_IDENTITY();

	return @id
END

GO
/****** Object:  StoredProcedure [dbo].[ALTA_PROVEEDOR_SP]    Script Date: 14/09/2015 0:56:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[ALTA_PROVEEDOR_SP]
@raz VARCHAR(50),
@mail VARCHAR(50),
@tel VARCHAR(50),
@cuit VARCHAR(50),
@dir VARCHAR(50)

AS
declare @id int;
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	INSERT INTO Proveedor(baja,cuil,direccion,mail, razonSocial)
	values(0,@cuit,@dir,@mail,@raz);

	set @id = SCOPE_IDENTITY();
END

GO
/****** Object:  StoredProcedure [dbo].[ALTA_TELEFONO_SP]    Script Date: 14/09/2015 0:56:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ALTA_TELEFONO_SP]
@usr integer,
@num VARCHAR(50),
@int VARCHAR(50),
@pre VARCHAR(50)

/*
repository.addParam("@usr", usr.id)
        repository.addParam("@num", usr.telefono.numero)
        repository.addParam("@int", usr.telefono.interno)
        repository.addParam("@pre", usr.telefono.prefijo)
*/
AS
declare @id int;
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	INSERT INTO Telefono(idUsuario,interno,numero,prefijo)
	values(@usr,@int,@num,@pre);

	set @id = SCOPE_IDENTITY();
	return @id
END

GO
/****** Object:  StoredProcedure [dbo].[BAJA_PRODUCTO_SP]    Script Date: 14/09/2015 0:56:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[BAJA_PRODUCTO_SP]
@id integer
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	update Producto set baja = 1 where id = @id;
END

GO
/****** Object:  StoredProcedure [dbo].[BUSCAR_BITACORAS_SP]    Script Date: 14/09/2015 0:56:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[BUSCAR_BITACORAS_SP]
@desde date,
@hasta date,
@usr varchar,
@tipo int,
@idioma int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	SELECT b.id,'',u.id,u.usr,te.id, ite.texto, ite.codigoEvento, b.fecha
	FROM Bitacora b 
	inner join TipoEvento te on b.codigoEvento = te.codigo
	inner join IdiomaTipoEvento ite on te.codigo = ite.codigoEvento
	inner join Usuario u on u.id = b.idUsuario
	where (@desde = '01/01/2500' or @desde <= b.fecha)   
	and (@hasta = '01/01/2500' or  b.fecha <= @hasta ) 
	and (@tipo = 0 or @tipo = te.codigo)
	and (@usr is null or u.usr like '%' + @usr + '%')
	and ite.idIdioma = @idioma ;
END

GO
/****** Object:  StoredProcedure [dbo].[BUSCAR_EXCEPCION_SP]    Script Date: 14/09/2015 0:56:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[BUSCAR_EXCEPCION_SP]
@cod integer,
@idioma integer
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	SELECT ie.texto
	from excepcion e
	inner join idiomaExcepcion ie on ie.idExcepcion = e.id
	where @cod = e.codigo
	and @idioma = ie.idIdioma;
END

GO
/****** Object:  StoredProcedure [dbo].[BUSCAR_IDIOMA_COMPONENTE_SP]    Script Date: 14/09/2015 0:56:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[BUSCAR_IDIOMA_COMPONENTE_SP]
@idioma integer
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	SELECT c.id,c.nombre,i.texto,c.pagina, c.formulario
	FROM IdiomaComponente i 
	inner join Componente c ON (c.id = i.idComponente)
	WHERE i.idIdioma = @idioma;
END

GO
/****** Object:  StoredProcedure [dbo].[BUSCAR_LOCALIDADES_SP]    Script Date: 14/09/2015 0:56:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[BUSCAR_LOCALIDADES_SP]
@prov integer
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	SELECT l.id, l.descripcion, l.idProvincia
	FROM Localidad l 
	where l.idProvincia = @prov;
END

GO
/****** Object:  StoredProcedure [dbo].[BUSCAR_PERMISOS_SP]    Script Date: 14/09/2015 0:56:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[BUSCAR_PERMISOS_SP]
@rol integer
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	SELECT c.id,c.nombre,c.texto,c.pagina,padre.id,padre.texto, c.formulario
	FROM RolComponente r 
	inner join Componente c ON (c.id = r.idComponente)
	left join Componente padre ON (padre.id = c.idComponente)
	WHERE r.idRol = @rol
	and c.formulario = 'mainTree';
END

GO
/****** Object:  StoredProcedure [dbo].[BUSCAR_PRODUCTO_SP]    Script Date: 14/09/2015 0:56:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[BUSCAR_PRODUCTO_SP]
@id integer
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	SELECT p.id, p.descripcion, t.id, t.descripcion
	FROM Producto p 
	inner join TipoProducto t on p.idTipoProducto = t.id
	WHERE (@id = p.id);
END

GO
/****** Object:  StoredProcedure [dbo].[BUSCAR_PRODUCTOS_SP]    Script Date: 14/09/2015 0:56:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[BUSCAR_PRODUCTOS_SP]
@tipo integer,
@nom VARCHAR(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	SELECT p.id, p.descripcion, t.id, t.descripcion
	FROM Producto p 
	inner join TipoProducto t on p.idTipoProducto = t.id
	WHERE (@tipo = 0 or @tipo = t.id)
	AND (@nom is null or p.descripcion like '%' + @nom + '%');
END

GO
/****** Object:  StoredProcedure [dbo].[BUSCAR_ROLES_SP]    Script Date: 14/09/2015 0:56:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[BUSCAR_ROLES_SP]
@usr integer
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	SELECT r.id,r.descripcion
	FROM UsuarioRol u 
	inner join Rol r ON (r.id = u.idRol)
	WHERE u.idUsuario = @usr;
END

GO
/****** Object:  StoredProcedure [dbo].[BUSCAR_TRADUCCION_SP]    Script Date: 14/09/2015 0:56:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[BUSCAR_TRADUCCION_SP]
@comp varchar(50),
@idioma integer
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	SELECT traduccion.texto
	FROM IdiomaComponente original
	inner join Componente c ON (c.id = original.idComponente)
	inner join IdiomaComponente traduccion on (traduccion.idComponente = c.id)
	WHERE original.texto like @comp
	and traduccion.idIdioma = @idioma;
END

GO
/****** Object:  StoredProcedure [dbo].[BUSCAR_USUARIOS_SP]    Script Date: 14/09/2015 0:56:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[BUSCAR_USUARIOS_SP]
@usr VARCHAR(50),
@mail VARCHAR(50),
@tipo integer
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	SELECT u.id,u.nombre, u.apellido, u.usr, t.id, t.descripcion,u.baja, u.mail
	FROM Usuario u 
	inner join TipoUsuario t on t.id = u.idTipoUsuario
	WHERE (@usr is null or u.usr like '%' + @usr + '%')
	AND (@mail is null or u.mail like '%' + @mail + '%')
	and (@tipo = 0 or @tipo = u.idTipoUsuario);
END

GO
/****** Object:  StoredProcedure [dbo].[GET_PRODUCTO_IMAGEN_SP]    Script Date: 14/09/2015 0:56:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GET_PRODUCTO_IMAGEN_SP]
@ID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	SELECT p.imagen1
	FROM Producto p
	where p.id = @ID;
END
GO
/****** Object:  StoredProcedure [dbo].[INSERTAR_BACKUP_SP]    Script Date: 14/09/2015 0:56:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[INSERTAR_BACKUP_SP]
@path VARCHAR(50),
@descripcion VARCHAR(50)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	INSERT INTO Resguardo(pathh,descripcion, fecha)
	values(@path,@descripcion, GETDATE());

END

GO
/****** Object:  StoredProcedure [dbo].[LISTAR_BACKUPS_SP]    Script Date: 14/09/2015 0:56:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LISTAR_BACKUPS_SP]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	SELECT r.id, r.pathh, r.descripcion, r.fecha
	FROM Resguardo r;
END
GO
/****** Object:  StoredProcedure [dbo].[LISTAR_IDIOMAS_SP]    Script Date: 14/09/2015 0:56:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[LISTAR_IDIOMAS_SP]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	SELECT i.id,i.nombre
	FROM Idioma i;
END

GO
/****** Object:  StoredProcedure [dbo].[LISTAR_PRODUCTOS_SP]    Script Date: 14/09/2015 0:56:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LISTAR_PRODUCTOS_SP]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	SELECT p.id,p.descripcion, p.imagen1, lpd.precio, lpd.idListaPrecioDetalle, lpd.idListaPrecio
	FROM Producto p
	inner join ListaPrecioDetalle lpd on lpd.idProducto = p.id 
	and lpd.baja = 0;
END
GO
/****** Object:  StoredProcedure [dbo].[LISTAR_PROVEEDORES_SP]    Script Date: 14/09/2015 0:56:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LISTAR_PROVEEDORES_SP]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	SELECT t.id, t.razonSocial
	from Proveedor t;
END

GO
/****** Object:  StoredProcedure [dbo].[LISTAR_PROVINCIAS_SP]    Script Date: 14/09/2015 0:56:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[LISTAR_PROVINCIAS_SP]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	SELECT t.id, t.descripcion
	from Provincia t;
END

GO
/****** Object:  StoredProcedure [dbo].[LISTAR_TIPO_EVENTOS_SP]    Script Date: 14/09/2015 0:56:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LISTAR_TIPO_EVENTOS_SP]
@id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	SELECT Te.id, ite.texto, te.codigo
	FROM TipoEvento te
	inner join IdiomaTipoEvento ite on ite.codigoEvento = te.codigo and ite.idIdioma = @id;
END

GO
/****** Object:  StoredProcedure [dbo].[LISTAR_TIPO_PRODUCTOS_SP]    Script Date: 14/09/2015 0:56:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LISTAR_TIPO_PRODUCTOS_SP]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	SELECT t.id, t.descripcion
	from TipoProducto t;
END

GO
/****** Object:  StoredProcedure [dbo].[LISTAR_TIPOS_DOCUMENTOS_SP]    Script Date: 14/09/2015 0:56:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[LISTAR_TIPOS_DOCUMENTOS_SP]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	SELECT t.id, t.descripcion
	from tIPOdOCUMENTO t;
END

GO
/****** Object:  StoredProcedure [dbo].[LISTAR_TIPOS_USUARIOS_SP]    Script Date: 14/09/2015 0:56:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LISTAR_TIPOS_USUARIOS_SP]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	SELECT t.id, t.descripcion
	from TipoUsuario t;
END

GO
/****** Object:  StoredProcedure [dbo].[LOGIN_SP]    Script Date: 14/09/2015 0:56:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LOGIN_SP]
@usr VARCHAR(50),
@pass VARCHAR(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	SELECT u.id,u.nombre, u.apellido, u.idIdioma
	FROM Usuario u 
	WHERE u.usr = @usr
	AND u.pass = @pass;
END

GO
/****** Object:  StoredProcedure [dbo].[SOLICITAR_CONTRASENA_SP]    Script Date: 14/09/2015 0:56:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[SOLICITAR_CONTRASENA_SP]
@mail VARCHAR(50),
@usr VARCHAR(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	SELECT u.pass
	FROM Usuario u 
	WHERE u.usr = @usr
	AND u.mail = @mail;
END

GO
/****** Object:  Table [dbo].[AsistenciaShowroom]    Script Date: 14/09/2015 0:56:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AsistenciaShowroom](
	[id] [int] NOT NULL,
	[asistio] [int] NULL,
	[fecha] [datetime] NULL,
	[cliente] [int] NULL,
 CONSTRAINT [PK_AsistenciaShowroom] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Back]    Script Date: 14/09/2015 0:56:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Back](
	[id] [int] NOT NULL,
	[descripcion] [text] NULL,
	[fecha] [datetime] NOT NULL,
 CONSTRAINT [PK_Backup] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Bitacora]    Script Date: 14/09/2015 0:56:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bitacora](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[codigoEvento] [int] NOT NULL,
	[idUsuario] [int] NOT NULL,
	[fecha] [datetime] NOT NULL,
 CONSTRAINT [PK_Bitacora] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Comentario]    Script Date: 14/09/2015 0:56:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comentario](
	[id] [int] NOT NULL,
	[comentario] [text] NULL,
	[idPedido] [int] NULL,
 CONSTRAINT [PK_Comentario] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Componente]    Script Date: 14/09/2015 0:56:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Componente](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[texto] [varchar](50) NOT NULL,
	[idComponente] [int] NULL,
	[pagina] [varchar](100) NULL,
	[formulario] [varchar](100) NULL,
 CONSTRAINT [PK_Componente] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Comprobante]    Script Date: 14/09/2015 0:56:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comprobante](
	[idTipoComprobante] [int] NULL,
	[nroComprobante] [int] NOT NULL,
	[fecha] [date] NULL,
	[total] [money] NULL,
	[letraComprobante] [text] NOT NULL,
	[sucComprobante] [int] NOT NULL,
	[idPedido] [int] NULL,
 CONSTRAINT [PK_Comprobante] PRIMARY KEY CLUSTERED 
(
	[nroComprobante] ASC,
	[sucComprobante] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ComprobanteDetalle]    Script Date: 14/09/2015 0:56:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ComprobanteDetalle](
	[id] [int] NOT NULL,
	[cantidad] [int] NULL,
	[idListaPrecioDetalle] [int] NULL,
	[nroComprobante] [int] NOT NULL,
	[sucComprobante] [int] NOT NULL,
	[letraComprobante] [text] NOT NULL,
	[idListaPrecio] [int] NULL,
 CONSTRAINT [PK_ComprobanteDetalle] PRIMARY KEY CLUSTERED 
(
	[id] ASC,
	[nroComprobante] ASC,
	[sucComprobante] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Domicilio]    Script Date: 14/09/2015 0:56:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Domicilio](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[calle] [text] NULL,
	[numero] [text] NULL,
	[piso] [text] NULL,
	[dpto] [text] NULL,
	[idLocalidad] [int] NULL,
	[idUsuario] [int] NULL,
 CONSTRAINT [PK_Domicilio] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Excepcion]    Script Date: 14/09/2015 0:56:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Excepcion](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[codigo] [int] NOT NULL,
 CONSTRAINT [PK_Excepcion] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Idioma]    Script Date: 14/09/2015 0:56:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Idioma](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [text] NOT NULL,
 CONSTRAINT [PK_Idioma] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[IdiomaComponente]    Script Date: 14/09/2015 0:56:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[IdiomaComponente](
	[idIdioma] [int] NOT NULL,
	[idComponente] [int] NOT NULL,
	[texto] [varchar](70) NOT NULL,
 CONSTRAINT [PK_IdiomaComponente] PRIMARY KEY CLUSTERED 
(
	[idIdioma] ASC,
	[idComponente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[IdiomaExcepcion]    Script Date: 14/09/2015 0:56:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[IdiomaExcepcion](
	[idExcepcion] [int] NOT NULL,
	[idIdioma] [int] NOT NULL,
	[texto] [varchar](100) NOT NULL,
 CONSTRAINT [PK_IdiomaExcepcion] PRIMARY KEY CLUSTERED 
(
	[idExcepcion] ASC,
	[idIdioma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[IdiomaTipoEvento]    Script Date: 14/09/2015 0:56:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[IdiomaTipoEvento](
	[idIdioma] [int] NOT NULL,
	[codigoEvento] [int] NOT NULL,
	[texto] [varchar](200) NOT NULL,
 CONSTRAINT [PK_IdiomaTipoEvento] PRIMARY KEY CLUSTERED 
(
	[idIdioma] ASC,
	[codigoEvento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ListaPrecio]    Script Date: 14/09/2015 0:56:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ListaPrecio](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NULL,
	[fechaDesde] [date] NULL,
	[fechaHasta] [date] NULL,
 CONSTRAINT [PK_ListaPrecio] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ListaPrecioDetalle]    Script Date: 14/09/2015 0:56:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ListaPrecioDetalle](
	[idListaPrecio] [int] NOT NULL,
	[idListaPrecioDetalle] [int] IDENTITY(1,1) NOT NULL,
	[idProducto] [int] NULL,
	[precio] [money] NULL,
	[baja] [int] NULL,
 CONSTRAINT [PK_ListaPrecioDetalle] PRIMARY KEY CLUSTERED 
(
	[idListaPrecio] ASC,
	[idListaPrecioDetalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Localidad]    Script Date: 14/09/2015 0:56:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Localidad](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [text] NULL,
	[idProvincia] [int] NULL,
 CONSTRAINT [PK_Localidad] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Pedido]    Script Date: 14/09/2015 0:56:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pedido](
	[id] [int] NOT NULL,
	[idUsuario] [int] NULL,
	[retiraCliente] [int] NULL,
	[fecha] [date] NULL,
 CONSTRAINT [PK_Pedido] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PedidoComprobante]    Script Date: 14/09/2015 0:56:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PedidoComprobante](
	[idPedido] [int] NOT NULL,
	[nroComprobante] [int] NOT NULL,
	[letraComprobante] [text] NOT NULL,
	[sucComprobante] [int] NOT NULL,
 CONSTRAINT [PK_PedidoComprobante] PRIMARY KEY CLUSTERED 
(
	[idPedido] ASC,
	[nroComprobante] ASC,
	[sucComprobante] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PedidoListaPrecioDetalle]    Script Date: 14/09/2015 0:56:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PedidoListaPrecioDetalle](
	[idListaPrecio] [int] NOT NULL,
	[idListaPrecioDetalle] [int] NOT NULL,
	[idPedido] [int] NOT NULL,
	[cantidad] [int] NULL,
 CONSTRAINT [PK_PedidoListaPrecioDetalle] PRIMARY KEY CLUSTERED 
(
	[idListaPrecio] ASC,
	[idListaPrecioDetalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PedidoProducto]    Script Date: 14/09/2015 0:56:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PedidoProducto](
	[idPedido] [int] NOT NULL,
	[idProducto] [int] NOT NULL,
	[cantidad] [int] NULL,
 CONSTRAINT [PK_PedidoProducto] PRIMARY KEY CLUSTERED 
(
	[idPedido] ASC,
	[idProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Producto]    Script Date: 14/09/2015 0:56:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Producto](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](200) NULL,
	[imagen1] [image] NULL,
	[imagen2] [image] NULL,
	[idTipoProducto] [int] NULL,
	[stock] [int] NULL,
	[stockMinimo] [int] NULL,
	[baja] [int] NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProductoCompuesto]    Script Date: 14/09/2015 0:56:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductoCompuesto](
	[id] [int] NOT NULL,
	[idProducto] [int] NULL,
	[cantidad] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Proveedor]    Script Date: 14/09/2015 0:56:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Proveedor](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[cuil] [varchar](50) NULL,
	[mail] [varchar](50) NULL,
	[direccion] [varchar](100) NULL,
	[razonSocial] [varchar](50) NULL,
	[baja] [int] NULL,
 CONSTRAINT [PK_Proveedor] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProveedorProducto]    Script Date: 14/09/2015 0:56:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProveedorProducto](
	[idProducto] [int] NOT NULL,
	[idProveedor] [int] NOT NULL,
 CONSTRAINT [PK_ProveedorProducto] PRIMARY KEY CLUSTERED 
(
	[idProducto] ASC,
	[idProveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Provincia]    Script Date: 14/09/2015 0:56:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Provincia](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [text] NULL,
 CONSTRAINT [PK_Provincia] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Resguardo]    Script Date: 14/09/2015 0:56:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Resguardo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[pathh] [varchar](200) NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
	[fecha] [datetime] NULL,
 CONSTRAINT [PK_Backup_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Rol]    Script Date: 14/09/2015 0:56:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rol](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [text] NOT NULL,
 CONSTRAINT [PK_Rol] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RolComponente]    Script Date: 14/09/2015 0:56:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RolComponente](
	[idRol] [int] NOT NULL,
	[idComponente] [int] NOT NULL,
 CONSTRAINT [PK_RolComponente] PRIMARY KEY CLUSTERED 
(
	[idRol] ASC,
	[idComponente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Telefono]    Script Date: 14/09/2015 0:56:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Telefono](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idUsuario] [int] NULL,
	[numero] [varchar](50) NULL,
	[prefijo] [varchar](50) NULL,
	[interno] [varchar](50) NULL,
 CONSTRAINT [PK_Telefono] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TipoComprobante]    Script Date: 14/09/2015 0:56:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoComprobante](
	[id] [int] NOT NULL,
	[descripcion] [text] NULL,
 CONSTRAINT [PK_TipoComprobante] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TipoDocumento]    Script Date: 14/09/2015 0:56:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TipoDocumento](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TipoDocumento] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TipoEvento]    Script Date: 14/09/2015 0:56:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoEvento](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[codigo] [int] NOT NULL,
 CONSTRAINT [PK_TipoEvento] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TipoProducto]    Script Date: 14/09/2015 0:56:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TipoProducto](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_TipoProducto] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TipoUsuario]    Script Date: 14/09/2015 0:56:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TipoUsuario](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TipoUsuario] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 14/09/2015 0:56:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuario](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[apellido] [varchar](50) NOT NULL,
	[cuil] [bigint] NULL,
	[dni] [bigint] NOT NULL,
	[mail] [varchar](50) NOT NULL,
	[idTipoUsuario] [int] NOT NULL,
	[baja] [int] NULL,
	[usr] [varchar](50) NULL,
	[pass] [varchar](50) NULL,
	[idIdioma] [int] NULL,
	[idTipoDocumento] [int] NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UsuarioRol]    Script Date: 14/09/2015 0:56:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuarioRol](
	[idUsuario] [int] NOT NULL,
	[idRol] [int] NOT NULL,
 CONSTRAINT [PK_UsuarioRol] PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC,
	[idRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Bitacora] ON 

INSERT [dbo].[Bitacora] ([id], [codigoEvento], [idUsuario], [fecha]) VALUES (1, 1, 3, CAST(N'2015-09-12 18:46:41.500' AS DateTime))
INSERT [dbo].[Bitacora] ([id], [codigoEvento], [idUsuario], [fecha]) VALUES (2, 1, 3, CAST(N'2015-09-12 18:49:13.807' AS DateTime))
INSERT [dbo].[Bitacora] ([id], [codigoEvento], [idUsuario], [fecha]) VALUES (3, 1, 3, CAST(N'2015-09-12 18:49:19.427' AS DateTime))
INSERT [dbo].[Bitacora] ([id], [codigoEvento], [idUsuario], [fecha]) VALUES (4, 1, 3, CAST(N'2015-09-12 18:49:55.477' AS DateTime))
INSERT [dbo].[Bitacora] ([id], [codigoEvento], [idUsuario], [fecha]) VALUES (5, 1, 3, CAST(N'2015-09-12 18:51:18.323' AS DateTime))
INSERT [dbo].[Bitacora] ([id], [codigoEvento], [idUsuario], [fecha]) VALUES (6, 1, 3, CAST(N'2015-09-12 18:53:25.013' AS DateTime))
INSERT [dbo].[Bitacora] ([id], [codigoEvento], [idUsuario], [fecha]) VALUES (7, 1, 3, CAST(N'2015-09-12 18:54:54.937' AS DateTime))
INSERT [dbo].[Bitacora] ([id], [codigoEvento], [idUsuario], [fecha]) VALUES (8, 1, 3, CAST(N'2015-09-12 18:59:43.003' AS DateTime))
INSERT [dbo].[Bitacora] ([id], [codigoEvento], [idUsuario], [fecha]) VALUES (9, 1, 3, CAST(N'2015-09-12 19:07:57.020' AS DateTime))
INSERT [dbo].[Bitacora] ([id], [codigoEvento], [idUsuario], [fecha]) VALUES (10, 1, 3, CAST(N'2015-09-12 18:37:34.410' AS DateTime))
INSERT [dbo].[Bitacora] ([id], [codigoEvento], [idUsuario], [fecha]) VALUES (11, 1, 3, CAST(N'2015-09-12 18:39:42.530' AS DateTime))
INSERT [dbo].[Bitacora] ([id], [codigoEvento], [idUsuario], [fecha]) VALUES (12, 1, 3, CAST(N'2015-09-14 00:32:13.343' AS DateTime))
INSERT [dbo].[Bitacora] ([id], [codigoEvento], [idUsuario], [fecha]) VALUES (13, 1, 3, CAST(N'2015-09-14 00:37:58.380' AS DateTime))
INSERT [dbo].[Bitacora] ([id], [codigoEvento], [idUsuario], [fecha]) VALUES (14, 1, 3, CAST(N'2015-09-14 00:43:12.883' AS DateTime))
INSERT [dbo].[Bitacora] ([id], [codigoEvento], [idUsuario], [fecha]) VALUES (15, 1, 3, CAST(N'2015-09-14 00:41:04.000' AS DateTime))
INSERT [dbo].[Bitacora] ([id], [codigoEvento], [idUsuario], [fecha]) VALUES (16, 1, 3, CAST(N'2015-09-13 23:59:27.960' AS DateTime))
INSERT [dbo].[Bitacora] ([id], [codigoEvento], [idUsuario], [fecha]) VALUES (17, 1, 3, CAST(N'2015-09-14 00:01:05.333' AS DateTime))
INSERT [dbo].[Bitacora] ([id], [codigoEvento], [idUsuario], [fecha]) VALUES (18, 1, 3, CAST(N'2015-09-14 00:29:19.233' AS DateTime))
INSERT [dbo].[Bitacora] ([id], [codigoEvento], [idUsuario], [fecha]) VALUES (19, 1, 3, CAST(N'2015-09-14 00:31:01.477' AS DateTime))
INSERT [dbo].[Bitacora] ([id], [codigoEvento], [idUsuario], [fecha]) VALUES (20, 1, 3, CAST(N'2015-09-14 00:53:12.610' AS DateTime))
INSERT [dbo].[Bitacora] ([id], [codigoEvento], [idUsuario], [fecha]) VALUES (21, 1, 3, CAST(N'2015-09-13 23:59:27.400' AS DateTime))
INSERT [dbo].[Bitacora] ([id], [codigoEvento], [idUsuario], [fecha]) VALUES (22, 1, 3, CAST(N'2015-09-14 00:00:55.157' AS DateTime))
INSERT [dbo].[Bitacora] ([id], [codigoEvento], [idUsuario], [fecha]) VALUES (23, 1, 3, CAST(N'2015-09-14 00:04:46.350' AS DateTime))
INSERT [dbo].[Bitacora] ([id], [codigoEvento], [idUsuario], [fecha]) VALUES (24, 1, 3, CAST(N'2015-09-14 00:12:24.743' AS DateTime))
INSERT [dbo].[Bitacora] ([id], [codigoEvento], [idUsuario], [fecha]) VALUES (25, 1, 3, CAST(N'2015-09-14 00:19:07.923' AS DateTime))
INSERT [dbo].[Bitacora] ([id], [codigoEvento], [idUsuario], [fecha]) VALUES (26, 1, 3, CAST(N'2015-09-14 00:22:00.510' AS DateTime))
INSERT [dbo].[Bitacora] ([id], [codigoEvento], [idUsuario], [fecha]) VALUES (27, 1, 3, CAST(N'2015-09-14 00:25:12.837' AS DateTime))
INSERT [dbo].[Bitacora] ([id], [codigoEvento], [idUsuario], [fecha]) VALUES (28, 1, 3, CAST(N'2015-09-14 00:28:36.290' AS DateTime))
INSERT [dbo].[Bitacora] ([id], [codigoEvento], [idUsuario], [fecha]) VALUES (29, 1, 3, CAST(N'2015-09-14 00:02:44.523' AS DateTime))
INSERT [dbo].[Bitacora] ([id], [codigoEvento], [idUsuario], [fecha]) VALUES (30, 1, 3, CAST(N'2015-09-14 00:08:58.063' AS DateTime))
INSERT [dbo].[Bitacora] ([id], [codigoEvento], [idUsuario], [fecha]) VALUES (31, 1, 3, CAST(N'2015-09-14 00:12:37.573' AS DateTime))
INSERT [dbo].[Bitacora] ([id], [codigoEvento], [idUsuario], [fecha]) VALUES (32, 1, 3, CAST(N'2015-09-14 00:24:12.677' AS DateTime))
INSERT [dbo].[Bitacora] ([id], [codigoEvento], [idUsuario], [fecha]) VALUES (33, 1, 3, CAST(N'2015-09-14 00:29:46.170' AS DateTime))
INSERT [dbo].[Bitacora] ([id], [codigoEvento], [idUsuario], [fecha]) VALUES (34, 1, 3, CAST(N'2015-09-14 00:33:39.217' AS DateTime))
INSERT [dbo].[Bitacora] ([id], [codigoEvento], [idUsuario], [fecha]) VALUES (35, 1, 3, CAST(N'2015-09-14 00:49:40.540' AS DateTime))
INSERT [dbo].[Bitacora] ([id], [codigoEvento], [idUsuario], [fecha]) VALUES (36, 1, 3, CAST(N'2015-09-14 00:45:55.720' AS DateTime))
INSERT [dbo].[Bitacora] ([id], [codigoEvento], [idUsuario], [fecha]) VALUES (37, 1, 3, CAST(N'2015-09-14 00:35:06.360' AS DateTime))
INSERT [dbo].[Bitacora] ([id], [codigoEvento], [idUsuario], [fecha]) VALUES (38, 1, 3, CAST(N'2015-09-14 00:01:08.183' AS DateTime))
INSERT [dbo].[Bitacora] ([id], [codigoEvento], [idUsuario], [fecha]) VALUES (39, 1, 3, CAST(N'2015-09-14 00:35:27.660' AS DateTime))
SET IDENTITY_INSERT [dbo].[Bitacora] OFF
SET IDENTITY_INSERT [dbo].[Componente] ON 

INSERT [dbo].[Componente] ([id], [nombre], [texto], [idComponente], [pagina], [formulario]) VALUES (1, N'proveedor', N'Proveedor', NULL, NULL, N'mainTree')
INSERT [dbo].[Componente] ([id], [nombre], [texto], [idComponente], [pagina], [formulario]) VALUES (2, N'producto', N'Productos', NULL, NULL, N'mainTree')
INSERT [dbo].[Componente] ([id], [nombre], [texto], [idComponente], [pagina], [formulario]) VALUES (4, N'pedidos', N'Pedidos', NULL, NULL, N'mainTree')
INSERT [dbo].[Componente] ([id], [nombre], [texto], [idComponente], [pagina], [formulario]) VALUES (5, N'ventas', N'Ventas', NULL, NULL, N'mainTree')
INSERT [dbo].[Componente] ([id], [nombre], [texto], [idComponente], [pagina], [formulario]) VALUES (6, N'usuarios', N'Usuario', NULL, NULL, N'mainTree')
INSERT [dbo].[Componente] ([id], [nombre], [texto], [idComponente], [pagina], [formulario]) VALUES (7, N'admin', N'Administrador', NULL, NULL, N'mainTree')
INSERT [dbo].[Componente] ([id], [nombre], [texto], [idComponente], [pagina], [formulario]) VALUES (8, N'altaProveedor', N'Alta Proveedor', 1, N'AltaProveedor.aspx', N'mainTree')
INSERT [dbo].[Componente] ([id], [nombre], [texto], [idComponente], [pagina], [formulario]) VALUES (9, N'administrarProveedores', N'Administrar Proveedores', 1, N'AdministrarProveedores.aspx', N'mainTree')
INSERT [dbo].[Componente] ([id], [nombre], [texto], [idComponente], [pagina], [formulario]) VALUES (10, N'altaProducto', N'Alta Producto', 2, N'AltaProducto.aspx', N'mainTree')
INSERT [dbo].[Componente] ([id], [nombre], [texto], [idComponente], [pagina], [formulario]) VALUES (11, N'administraProducto', N'Administrar Productos', 2, N'AdministrarProductos.aspx', N'mainTree')
INSERT [dbo].[Componente] ([id], [nombre], [texto], [idComponente], [pagina], [formulario]) VALUES (12, N'altaListaPrecio', N'Alta Lista Precio', 2, N'AltaListaPrecio.aspx', N'mainTree')
INSERT [dbo].[Componente] ([id], [nombre], [texto], [idComponente], [pagina], [formulario]) VALUES (13, N'modificarListaPrecio', N'Modificar Lista Precio', 2, N'ModificarListaPrecio.aspx', N'mainTree')
INSERT [dbo].[Componente] ([id], [nombre], [texto], [idComponente], [pagina], [formulario]) VALUES (14, N'promociones', N'Promociones', 2, N'Promociones.aspx', N'mainTree')
INSERT [dbo].[Componente] ([id], [nombre], [texto], [idComponente], [pagina], [formulario]) VALUES (15, N'misPedidos', N'Mis Pedidos', 4, N'MisPedidos.aspx', N'mainTree')
INSERT [dbo].[Componente] ([id], [nombre], [texto], [idComponente], [pagina], [formulario]) VALUES (16, N'compra', N'A Comprar', 5, N'Ventas.aspx', N'mainTree')
INSERT [dbo].[Componente] ([id], [nombre], [texto], [idComponente], [pagina], [formulario]) VALUES (17, N'solicAsistenciaShowroom', N'Solicitar Asistencia a Showroom', 5, N'solicitarShowroom.aspx', N'mainTree')
INSERT [dbo].[Componente] ([id], [nombre], [texto], [idComponente], [pagina], [formulario]) VALUES (18, N'altaUsuario', N'Alta Usuario', 6, N'AltaUsuario.aspx', N'mainTree')
INSERT [dbo].[Componente] ([id], [nombre], [texto], [idComponente], [pagina], [formulario]) VALUES (19, N'adminUsuarios', N'Administrar Usuarios', 6, N'AdministrarUsuarios.aspx', N'mainTree')
INSERT [dbo].[Componente] ([id], [nombre], [texto], [idComponente], [pagina], [formulario]) VALUES (20, N'datosPersonales', N'Datos Personales', 6, N'DatosPersonales.aspx', N'mainTree')
INSERT [dbo].[Componente] ([id], [nombre], [texto], [idComponente], [pagina], [formulario]) VALUES (21, N'bitacora', N'Bitacora', 7, N'Bitacora.aspx', N'mainTree')
INSERT [dbo].[Componente] ([id], [nombre], [texto], [idComponente], [pagina], [formulario]) VALUES (22, N'backup', N'Backup', 7, N'Backup.aspx', N'mainTree')
INSERT [dbo].[Componente] ([id], [nombre], [texto], [idComponente], [pagina], [formulario]) VALUES (23, N'restore', N'Restore', 7, N'Restore.aspx', N'mainTree')
INSERT [dbo].[Componente] ([id], [nombre], [texto], [idComponente], [pagina], [formulario]) VALUES (24, N'altaIdioma', N'Alta Idioma', 7, N'AltaIdioma.aspx', N'mainTree')
INSERT [dbo].[Componente] ([id], [nombre], [texto], [idComponente], [pagina], [formulario]) VALUES (25, N'adminIdiomas', N'Administrar Idiomas', 7, N'AdministrarIdiomas.aspx', N'mainTree')
INSERT [dbo].[Componente] ([id], [nombre], [texto], [idComponente], [pagina], [formulario]) VALUES (26, N'usuarioLabel', N'Usuario', NULL, NULL, NULL)
INSERT [dbo].[Componente] ([id], [nombre], [texto], [idComponente], [pagina], [formulario]) VALUES (27, N'nombreLabel', N'Nombre', NULL, NULL, NULL)
INSERT [dbo].[Componente] ([id], [nombre], [texto], [idComponente], [pagina], [formulario]) VALUES (28, N'apellidoLabel', N'Apellido', NULL, NULL, NULL)
INSERT [dbo].[Componente] ([id], [nombre], [texto], [idComponente], [pagina], [formulario]) VALUES (29, N'mailLabel', N'Mail', NULL, NULL, NULL)
INSERT [dbo].[Componente] ([id], [nombre], [texto], [idComponente], [pagina], [formulario]) VALUES (30, N'passLabel', N'Contraseña', NULL, NULL, NULL)
INSERT [dbo].[Componente] ([id], [nombre], [texto], [idComponente], [pagina], [formulario]) VALUES (31, N'rolesLabel', N'Roles', NULL, NULL, NULL)
INSERT [dbo].[Componente] ([id], [nombre], [texto], [idComponente], [pagina], [formulario]) VALUES (32, N'descripcionLabel', N'Descripcion', NULL, NULL, NULL)
INSERT [dbo].[Componente] ([id], [nombre], [texto], [idComponente], [pagina], [formulario]) VALUES (33, N'confirmarButton', N'Confirmar', NULL, NULL, NULL)
INSERT [dbo].[Componente] ([id], [nombre], [texto], [idComponente], [pagina], [formulario]) VALUES (34, N'buscarButton', N'Buscar', NULL, NULL, NULL)
INSERT [dbo].[Componente] ([id], [nombre], [texto], [idComponente], [pagina], [formulario]) VALUES (35, N'tipoProductoLabel', N'Tipo Producto', NULL, NULL, NULL)
INSERT [dbo].[Componente] ([id], [nombre], [texto], [idComponente], [pagina], [formulario]) VALUES (36, N'accionesLabel', N'Acciones', NULL, NULL, NULL)
INSERT [dbo].[Componente] ([id], [nombre], [texto], [idComponente], [pagina], [formulario]) VALUES (37, N'recuperarPassButton', N'Recuperar Contraseña', NULL, NULL, NULL)
INSERT [dbo].[Componente] ([id], [nombre], [texto], [idComponente], [pagina], [formulario]) VALUES (38, N'registroButton', N'Registro', NULL, NULL, NULL)
INSERT [dbo].[Componente] ([id], [nombre], [texto], [idComponente], [pagina], [formulario]) VALUES (39, N'greetingsLabel', N'Bienvenido!', NULL, NULL, NULL)
INSERT [dbo].[Componente] ([id], [nombre], [texto], [idComponente], [pagina], [formulario]) VALUES (40, N'usrTextBoxValidator', N'Requerido', NULL, NULL, NULL)
INSERT [dbo].[Componente] ([id], [nombre], [texto], [idComponente], [pagina], [formulario]) VALUES (42, N'requeridoValidator', N'Requerido', NULL, NULL, NULL)
INSERT [dbo].[Componente] ([id], [nombre], [texto], [idComponente], [pagina], [formulario]) VALUES (43, N'emailValidator', N'Email Invalido', NULL, NULL, NULL)
INSERT [dbo].[Componente] ([id], [nombre], [texto], [idComponente], [pagina], [formulario]) VALUES (44, N'numeroValidator', N'Solo Numeros', NULL, NULL, NULL)
INSERT [dbo].[Componente] ([id], [nombre], [texto], [idComponente], [pagina], [formulario]) VALUES (45, N'textoValidator', N'Solo Texto', NULL, NULL, NULL)
INSERT [dbo].[Componente] ([id], [nombre], [texto], [idComponente], [pagina], [formulario]) VALUES (46, N'registrarseButton', N'Registrarse', NULL, NULL, NULL)
INSERT [dbo].[Componente] ([id], [nombre], [texto], [idComponente], [pagina], [formulario]) VALUES (47, N'tipoEvento', N'Tipo Evento', NULL, NULL, NULL)
INSERT [dbo].[Componente] ([id], [nombre], [texto], [idComponente], [pagina], [formulario]) VALUES (48, N'fecha', N'Fecha', NULL, NULL, NULL)
INSERT [dbo].[Componente] ([id], [nombre], [texto], [idComponente], [pagina], [formulario]) VALUES (49, N'fechaDesdeLabel', N'Fecha Desde', NULL, NULL, NULL)
INSERT [dbo].[Componente] ([id], [nombre], [texto], [idComponente], [pagina], [formulario]) VALUES (50, N'fechaHastaLabel', N'Fecha Hasta', NULL, NULL, NULL)
INSERT [dbo].[Componente] ([id], [nombre], [texto], [idComponente], [pagina], [formulario]) VALUES (51, N'tipoEventoLabel', N'Tipo Evento', NULL, NULL, NULL)
INSERT [dbo].[Componente] ([id], [nombre], [texto], [idComponente], [pagina], [formulario]) VALUES (52, N'tipoUsuarioLabel', N'Tipo Usuario', NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Componente] OFF
SET IDENTITY_INSERT [dbo].[Domicilio] ON 

INSERT [dbo].[Domicilio] ([id], [calle], [numero], [piso], [dpto], [idLocalidad], [idUsuario]) VALUES (2, N'Cucha Cucha', N'1234', N'1', N'1', 1, 7)
SET IDENTITY_INSERT [dbo].[Domicilio] OFF
SET IDENTITY_INSERT [dbo].[Excepcion] ON 

INSERT [dbo].[Excepcion] ([id], [codigo]) VALUES (1, 1)
INSERT [dbo].[Excepcion] ([id], [codigo]) VALUES (2, 2)
INSERT [dbo].[Excepcion] ([id], [codigo]) VALUES (3, 3)
INSERT [dbo].[Excepcion] ([id], [codigo]) VALUES (4, 4)
INSERT [dbo].[Excepcion] ([id], [codigo]) VALUES (5, 5)
INSERT [dbo].[Excepcion] ([id], [codigo]) VALUES (6, 6)
INSERT [dbo].[Excepcion] ([id], [codigo]) VALUES (7, 7)
INSERT [dbo].[Excepcion] ([id], [codigo]) VALUES (8, 8)
INSERT [dbo].[Excepcion] ([id], [codigo]) VALUES (9, 9)
INSERT [dbo].[Excepcion] ([id], [codigo]) VALUES (10, 10)
SET IDENTITY_INSERT [dbo].[Excepcion] OFF
SET IDENTITY_INSERT [dbo].[Idioma] ON 

INSERT [dbo].[Idioma] ([id], [nombre]) VALUES (1, N'Español')
INSERT [dbo].[Idioma] ([id], [nombre]) VALUES (2, N'Ingles')
SET IDENTITY_INSERT [dbo].[Idioma] OFF
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (1, 1, N'Proveedor')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (1, 2, N'Productos')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (1, 4, N'Pedidos')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (1, 5, N'Ventas')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (1, 6, N'Usuario')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (1, 7, N'Administrador')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (1, 8, N'Alta Proveedor')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (1, 9, N'Administrar Proveedores')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (1, 10, N'Alta Producto')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (1, 11, N'Administrar Productos')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (1, 12, N'Alta Lista Precio')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (1, 13, N'Modificar Lista Precio')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (1, 14, N'Promociones')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (1, 15, N'Mis Pedidos')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (1, 16, N'A Comprar')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (1, 17, N'Solicitar Asistencia a Showroom')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (1, 18, N'Alta Usuario')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (1, 19, N'Administrar Usuarios')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (1, 20, N'Datos Personales')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (1, 21, N'Bitacora')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (1, 22, N'Backup')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (1, 23, N'Restore')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (1, 24, N'Alta Idioma')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (1, 25, N'Administrar Idiomas')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (1, 26, N'Usuario')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (1, 27, N'Nombre')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (1, 28, N'Apellido')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (1, 29, N'Mail')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (1, 30, N'Contraseña')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (1, 31, N'Roles')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (1, 32, N'Descripcion')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (1, 33, N'Confirmar')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (1, 34, N'Buscar')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (1, 35, N'Tipo Producto')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (1, 36, N'Acciones')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (1, 37, N'Recuperar Contraseña')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (1, 38, N'Registro')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (1, 39, N'Bienvenido!')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (1, 40, N'Requerido')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (1, 42, N'Requerido')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (1, 43, N'Email Invalido')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (1, 44, N'Solo Texto')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (1, 45, N'Solo Numeros')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (1, 46, N'Registrarse')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (1, 47, N'Tipo Evento')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (1, 48, N'Fecha')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (1, 49, N'Fecha Desde')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (1, 50, N'Fecha Hasta')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (1, 51, N'Tipo Evento')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (1, 52, N'Tipo Usuario')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (2, 1, N'Provider')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (2, 2, N'Products')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (2, 4, N'Requests')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (2, 5, N'Sales')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (2, 6, N'User')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (2, 7, N'Administrator')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (2, 8, N'Add Provider')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (2, 9, N'Manage Providers')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (2, 10, N'Add Product')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (2, 11, N'Manage Products')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (2, 12, N'Add Sales List')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (2, 13, N'Manage Sales List')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (2, 14, N'Promotions')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (2, 15, N'My requests')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (2, 16, N'Shop')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (2, 17, N'Go to Showroom')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (2, 18, N'Add User')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (2, 19, N'Manage Users')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (2, 20, N'Personal Data')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (2, 21, N'Log')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (2, 22, N'Backup')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (2, 23, N'Restore')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (2, 24, N'Add Language')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (2, 25, N'Manage Languages')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (2, 26, N'User')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (2, 27, N'Name')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (2, 28, N'Last Name')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (2, 29, N'Mail')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (2, 30, N'Password')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (2, 31, N'Rols')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (2, 32, N'Description')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (2, 33, N'Confirm')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (2, 34, N'Search')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (2, 35, N'Product Type')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (2, 36, N'Actions')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (2, 37, N'Retreive Password')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (2, 38, N'Sign in')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (2, 39, N'Welcome!')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (2, 40, N'Required')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (2, 42, N'Required')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (2, 43, N'Invalid Email')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (2, 44, N'Only Text')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (2, 45, N'Only Numbers')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (2, 46, N'Register')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (2, 47, N'Event Type')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (2, 48, N'Date')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (2, 49, N'Date From')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (2, 50, N'Date To')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (2, 51, N'Event Type')
INSERT [dbo].[IdiomaComponente] ([idIdioma], [idComponente], [texto]) VALUES (2, 52, N'User Type')
GO
INSERT [dbo].[IdiomaExcepcion] ([idExcepcion], [idIdioma], [texto]) VALUES (1, 1, N'Conexion BD Fallida')
INSERT [dbo].[IdiomaExcepcion] ([idExcepcion], [idIdioma], [texto]) VALUES (1, 2, N'Falied DB Conection')
INSERT [dbo].[IdiomaExcepcion] ([idExcepcion], [idIdioma], [texto]) VALUES (2, 1, N'Busqueda Sin resultados')
INSERT [dbo].[IdiomaExcepcion] ([idExcepcion], [idIdioma], [texto]) VALUES (2, 2, N'Search without results')
INSERT [dbo].[IdiomaExcepcion] ([idExcepcion], [idIdioma], [texto]) VALUES (3, 1, N'Fallo al eliminar')
INSERT [dbo].[IdiomaExcepcion] ([idExcepcion], [idIdioma], [texto]) VALUES (3, 2, N'Delete Failure')
INSERT [dbo].[IdiomaExcepcion] ([idExcepcion], [idIdioma], [texto]) VALUES (4, 1, N'Fallo al crear')
INSERT [dbo].[IdiomaExcepcion] ([idExcepcion], [idIdioma], [texto]) VALUES (4, 2, N'Insert Failure')
INSERT [dbo].[IdiomaExcepcion] ([idExcepcion], [idIdioma], [texto]) VALUES (5, 1, N'Fallo al modificar')
INSERT [dbo].[IdiomaExcepcion] ([idExcepcion], [idIdioma], [texto]) VALUES (5, 2, N'Update Failure')
INSERT [dbo].[IdiomaExcepcion] ([idExcepcion], [idIdioma], [texto]) VALUES (6, 1, N'Exito al Eliminar')
INSERT [dbo].[IdiomaExcepcion] ([idExcepcion], [idIdioma], [texto]) VALUES (6, 2, N'Delete Success')
INSERT [dbo].[IdiomaExcepcion] ([idExcepcion], [idIdioma], [texto]) VALUES (7, 1, N'Exito al crear')
INSERT [dbo].[IdiomaExcepcion] ([idExcepcion], [idIdioma], [texto]) VALUES (7, 2, N'Creation Success')
INSERT [dbo].[IdiomaExcepcion] ([idExcepcion], [idIdioma], [texto]) VALUES (8, 1, N'Exito al modificar')
INSERT [dbo].[IdiomaExcepcion] ([idExcepcion], [idIdioma], [texto]) VALUES (8, 2, N'Modification Success')
INSERT [dbo].[IdiomaExcepcion] ([idExcepcion], [idIdioma], [texto]) VALUES (9, 1, N'Usuario Creado Exitosamente')
INSERT [dbo].[IdiomaExcepcion] ([idExcepcion], [idIdioma], [texto]) VALUES (9, 2, N'User Created Successfully')
INSERT [dbo].[IdiomaExcepcion] ([idExcepcion], [idIdioma], [texto]) VALUES (10, 1, N'Usuario Y/O Pass Incorrecto')
INSERT [dbo].[IdiomaExcepcion] ([idExcepcion], [idIdioma], [texto]) VALUES (10, 2, N'Incorrect User and/or Password')
INSERT [dbo].[IdiomaTipoEvento] ([idIdioma], [codigoEvento], [texto]) VALUES (1, 1, N'Logueo Exitoso')
INSERT [dbo].[IdiomaTipoEvento] ([idIdioma], [codigoEvento], [texto]) VALUES (1, 2, N'Logout Exitoso')
INSERT [dbo].[IdiomaTipoEvento] ([idIdioma], [codigoEvento], [texto]) VALUES (2, 1, N'Succesfull Login')
INSERT [dbo].[IdiomaTipoEvento] ([idIdioma], [codigoEvento], [texto]) VALUES (2, 2, N'Successfull Logout')
SET IDENTITY_INSERT [dbo].[ListaPrecio] ON 

INSERT [dbo].[ListaPrecio] ([id], [descripcion], [fechaDesde], [fechaHasta]) VALUES (1, N'vigente', CAST(N'2014-01-01' AS Date), NULL)
SET IDENTITY_INSERT [dbo].[ListaPrecio] OFF
SET IDENTITY_INSERT [dbo].[ListaPrecioDetalle] ON 

INSERT [dbo].[ListaPrecioDetalle] ([idListaPrecio], [idListaPrecioDetalle], [idProducto], [precio], [baja]) VALUES (1, 1, 1, 5000.0000, 0)
INSERT [dbo].[ListaPrecioDetalle] ([idListaPrecio], [idListaPrecioDetalle], [idProducto], [precio], [baja]) VALUES (1, 2, 2, 6000.0000, 0)
INSERT [dbo].[ListaPrecioDetalle] ([idListaPrecio], [idListaPrecioDetalle], [idProducto], [precio], [baja]) VALUES (1, 3, 3, 7000.0000, 0)
INSERT [dbo].[ListaPrecioDetalle] ([idListaPrecio], [idListaPrecioDetalle], [idProducto], [precio], [baja]) VALUES (1, 4, 4, 8000.0000, 0)
INSERT [dbo].[ListaPrecioDetalle] ([idListaPrecio], [idListaPrecioDetalle], [idProducto], [precio], [baja]) VALUES (1, 1002, 6, 200.0000, 0)
SET IDENTITY_INSERT [dbo].[ListaPrecioDetalle] OFF
SET IDENTITY_INSERT [dbo].[Localidad] ON 

INSERT [dbo].[Localidad] ([id], [descripcion], [idProvincia]) VALUES (1, N'CABA', 1)
INSERT [dbo].[Localidad] ([id], [descripcion], [idProvincia]) VALUES (2, N'La Matanza', 2)
INSERT [dbo].[Localidad] ([id], [descripcion], [idProvincia]) VALUES (3, N'3 de Febrero', 2)
SET IDENTITY_INSERT [dbo].[Localidad] OFF
SET IDENTITY_INSERT [dbo].[Producto] ON 

INSERT [dbo].[Producto] ([id], [descripcion], [imagen1], [imagen2], [idTipoProducto], [stock], [stockMinimo], [baja]) VALUES (1, N'Mesa con 6 Sillas', 0xFFD8FFE000104A4649460001010100F000F00000FFE20C584943435F50524F46494C4500010100000C484C696E6F021000006D6E74725247422058595A2007CE00020009000600310000616373704D5346540000000049454320735247420000000000000000000000000000F6D6000100000000D32D4850202000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001163707274000001500000003364657363000001840000006C77747074000001F000000014626B707400000204000000147258595A00000218000000146758595A0000022C000000146258595A0000024000000014646D6E640000025400000070646D6464000002C400000088767565640000034C0000008676696577000003D4000000246C756D69000003F8000000146D6561730000040C0000002474656368000004300000000C725452430000043C0000080C675452430000043C0000080C625452430000043C0000080C7465787400000000436F70797269676874202863292031393938204865776C6574742D5061636B61726420436F6D70616E790000646573630000000000000012735247422049454336313936362D322E31000000000000000000000012735247422049454336313936362D322E31000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000058595A20000000000000F35100010000000116CC58595A200000000000000000000000000000000058595A200000000000006FA2000038F50000039058595A2000000000000062990000B785000018DA58595A2000000000000024A000000F840000B6CF64657363000000000000001649454320687474703A2F2F7777772E6965632E636800000000000000000000001649454320687474703A2F2F7777772E6965632E63680000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000064657363000000000000002E4945432036313936362D322E312044656661756C742052474220636F6C6F7572207370616365202D207352474200000000000000000000002E4945432036313936362D322E312044656661756C742052474220636F6C6F7572207370616365202D20735247420000000000000000000000000000000000000000000064657363000000000000002C5265666572656E63652056696577696E6720436F6E646974696F6E20696E2049454336313936362D322E3100000000000000000000002C5265666572656E63652056696577696E6720436F6E646974696F6E20696E2049454336313936362D322E31000000000000000000000000000000000000000000000000000076696577000000000013A4FE00145F2E0010CF140003EDCC0004130B00035C9E0000000158595A2000000000004C09560050000000571FE76D6561730000000000000001000000000000000000000000000000000000028F0000000273696720000000004352542063757276000000000000040000000005000A000F00140019001E00230028002D00320037003B00400045004A004F00540059005E00630068006D00720077007C00810086008B00900095009A009F00A400A900AE00B200B700BC00C100C600CB00D000D500DB00E000E500EB00F000F600FB01010107010D01130119011F0125012B01320138013E0145014C0152015901600167016E0175017C0183018B0192019A01A101A901B101B901C101C901D101D901E101E901F201FA0203020C0214021D0226022F02380241024B0254025D02670271027A0284028E029802A202AC02B602C102CB02D502E002EB02F50300030B03160321032D03380343034F035A03660372037E038A039603A203AE03BA03C703D303E003EC03F9040604130420042D043B0448045504630471047E048C049A04A804B604C404D304E104F004FE050D051C052B053A05490558056705770586059605A605B505C505D505E505F6060606160627063706480659066A067B068C069D06AF06C006D106E306F507070719072B073D074F076107740786079907AC07BF07D207E507F8080B081F08320846085A086E0882089608AA08BE08D208E708FB09100925093A094F09640979098F09A409BA09CF09E509FB0A110A270A3D0A540A6A0A810A980AAE0AC50ADC0AF30B0B0B220B390B510B690B800B980BB00BC80BE10BF90C120C2A0C430C5C0C750C8E0CA70CC00CD90CF30D0D0D260D400D5A0D740D8E0DA90DC30DDE0DF80E130E2E0E490E640E7F0E9B0EB60ED20EEE0F090F250F410F5E0F7A0F960FB30FCF0FEC1009102610431061107E109B10B910D710F511131131114F116D118C11AA11C911E81207122612451264128412A312C312E31303132313431363138313A413C513E5140614271449146A148B14AD14CE14F01512153415561578159B15BD15E0160316261649166C168F16B216D616FA171D17411765178917AE17D217F7181B18401865188A18AF18D518FA19201945196B199119B719DD1A041A2A1A511A771A9E1AC51AEC1B141B3B1B631B8A1BB21BDA1C021C2A1C521C7B1CA31CCC1CF51D1E1D471D701D991DC31DEC1E161E401E6A1E941EBE1EE91F131F3E1F691F941FBF1FEA20152041206C209820C420F0211C2148217521A121CE21FB22272255228222AF22DD230A23382366239423C223F0241F244D247C24AB24DA250925382568259725C725F726272657268726B726E827182749277A27AB27DC280D283F287128A228D429062938296B299D29D02A022A352A682A9B2ACF2B022B362B692B9D2BD12C052C392C6E2CA22CD72D0C2D412D762DAB2DE12E162E4C2E822EB72EEE2F242F5A2F912FC72FFE3035306C30A430DB3112314A318231BA31F2322A3263329B32D4330D3346337F33B833F1342B3465349E34D83513354D358735C235FD3637367236AE36E937243760379C37D738143850388C38C839053942397F39BC39F93A363A743AB23AEF3B2D3B6B3BAA3BE83C273C653CA43CE33D223D613DA13DE03E203E603EA03EE03F213F613FA23FE24023406440A640E74129416A41AC41EE4230427242B542F7433A437D43C044034447448A44CE45124555459A45DE4622466746AB46F04735477B47C04805484B489148D7491D496349A949F04A374A7D4AC44B0C4B534B9A4BE24C2A4C724CBA4D024D4A4D934DDC4E254E6E4EB74F004F494F934FDD5027507150BB51065150519B51E65231527C52C75313535F53AA53F65442548F54DB5528557555C2560F565C56A956F75744579257E0582F587D58CB591A596959B85A075A565AA65AF55B455B955BE55C355C865CD65D275D785DC95E1A5E6C5EBD5F0F5F615FB36005605760AA60FC614F61A261F56249629C62F06343639763EB6440649464E9653D659265E7663D669266E8673D679367E9683F689668EC6943699A69F16A486A9F6AF76B4F6BA76BFF6C576CAF6D086D606DB96E126E6B6EC46F1E6F786FD1702B708670E0713A719571F0724B72A67301735D73B87414747074CC7528758575E1763E769B76F8775677B37811786E78CC792A798979E77A467AA57B047B637BC27C217C817CE17D417DA17E017E627EC27F237F847FE5804780A8810A816B81CD8230829282F4835783BA841D848084E3854785AB860E867286D7873B879F8804886988CE8933899989FE8A648ACA8B308B968BFC8C638CCA8D318D988DFF8E668ECE8F368F9E9006906E90D6913F91A89211927A92E3934D93B69420948A94F4955F95C99634969F970A977597E0984C98B89924999099FC9A689AD59B429BAF9C1C9C899CF79D649DD29E409EAE9F1D9F8B9FFAA069A0D8A147A1B6A226A296A306A376A3E6A456A4C7A538A5A9A61AA68BA6FDA76EA7E0A852A8C4A937A9A9AA1CAA8FAB02AB75ABE9AC5CACD0AD44ADB8AE2DAEA1AF16AF8BB000B075B0EAB160B1D6B24BB2C2B338B3AEB425B49CB513B58AB601B679B6F0B768B7E0B859B8D1B94AB9C2BA3BBAB5BB2EBBA7BC21BC9BBD15BD8FBE0ABE84BEFFBF7ABFF5C070C0ECC167C1E3C25FC2DBC358C3D4C451C4CEC54BC5C8C646C6C3C741C7BFC83DC8BCC93AC9B9CA38CAB7CB36CBB6CC35CCB5CD35CDB5CE36CEB6CF37CFB8D039D0BAD13CD1BED23FD2C1D344D3C6D449D4CBD54ED5D1D655D6D8D75CD7E0D864D8E8D96CD9F1DA76DAFBDB80DC05DC8ADD10DD96DE1CDEA2DF29DFAFE036E0BDE144E1CCE253E2DBE363E3EBE473E4FCE584E60DE696E71FE7A9E832E8BCE946E9D0EA5BEAE5EB70EBFBEC86ED11ED9CEE28EEB4EF40EFCCF058F0E5F172F1FFF28CF319F3A7F434F4C2F550F5DEF66DF6FBF78AF819F8A8F938F9C7FA57FAE7FB77FC07FC98FD29FDBAFE4BFEDCFF6DFFFFFFDB00430001010101010101010101010101010101010101010101010101010101010101010101010102020101020101010202020202020202020102020202020202020202FFDB00430101010101010101010101020101010202020202020202020202020202020202020202020202020202020202020202020202020202020202020202020202020202FFC00011080048006403011100021101031101FFC4001C0000020301010101000000000000000000070806090A04050302FFC40032100001040202010303030401040300000002010304050607111208001321142231091541233251612517243342526391FFC4001D010002020203010000000000000000000005060407030800020901FFC4004211000201020502030505060403090000000102030411000512213106411322510714326171238191A1F03342B1C1D1F1155262822472E108163443536392A3B3FFDA000C03010002110311003F0049A053CD8C8255B6D2DB44FF00D42491227F3F09CAA7F3FE3D5B11BCC000B2123E7BFF001BE0E9A6406E80A5BBA923F86D8F69DBDCA299B575F7DB96C342466921A5E50053B17DC3FE917F8F5204FA6E5A306DF2B7FD3B7A631949D7613123E7BFDFEBF86266E678C48C5204EA1A4059B3DA074AD6732A0C889822A2C483CF671395F83754117FF82FA92CDA954A8B5F7DFD0F1894BA4461828D5EBFD076FCCE2B63C9BD5593FEFF0045E46EBDB62C776AE1973536365771DF6AADC9CCD73AD1D35C2BA280D85AC1991E1B68AA888FC7705B73B7B228AA5D4394256C2D5287C2AA87CCAE2C0875DD5BB6F7163CDC1DEF82D92E65250552B13AE097C92A1DC3C67E206FF7907B118D2FF8CDB3A3F90DA0753EE76E33512567988C4B1BA831F8F620E4D06449A6CA224744FEC8C37F5B604D27FEACBA03FC7A174930A9A6827D3A4C8A091E8C3661FF00C81FBB0E151188269231E6543B1EF622EA6FC6E0E1808B4C1ED12A073CB829F84F9E513FC27E113F8F59EC2F7C60637B6D6188965F9C6AEC39D8B8DE5BB2F13C46EEEE4D55646AD9570C26404DDDCF080D2315B10CE44027F97596E5BAD8331D5C47CCC5004BD775466BD85F10E5AA823251A5018DB6BEF626DC0DC7D4F1CE3ED9AEC6C2702AEB3A2A2930ACF2AAAA46CE931BA88E16110242709514AFB91A536DC4932E2C79090C15D16C95B0379E65A3070F22477B122C318E5AB440550DD80D80FCBB8E7F0F98188CE47B32DA165595D530D52E1C345112AAD8F3414BCA9A0C92863E596F3EBD993894969CCAB20B28CD5042AF88D496FABD0AC01B65D971D63BF9340DBBDFD3D3F97F6C6233B972BFB3B6DBF9AC7CC76D36DCDAC06DBDF6B8C1CF19A6BDB5C4F1AB3BB84306E6CF19A1B2B884DC57E1844B49F55125D8C54892889D882D4C7DF6FDA7555C6FDBE8E2F712F5F348DC5EF6C488E425119CF9EC09036DED7361DB7EDF763BE161EE04D8AE934ABD64B06AAA8BD78175B2554FF1F8F5C441A85BD47EBF5E98CC655B1039FE38C2F6C880E5BEC5DAF6E2DAC81B3CB6D517AA97433B7CDEFDE26DB70785E84E3C9C2A7CF52E517E39F5AFD9982CFB81AA59277D37E6E6DCFD2DBFF5C5B200868334704810D32ADFD0F9BF9DB6C598C2D7B7ADC665A6AB582065A6591EB5FEFA0A34C34DA07B8E1AA9708289F9F575C344CB122D80D200FC0018A39E500F3FAFC3169761AA3C99C4370E47A77CB4F1DB536B5C8ECFC7AC83726212F0EB585954C9CCC3B17A95A71EB6A9B5931A3C8664B1388DA5517C0E3B66BCB4E0F669C9B307CC4D52B428B1C2A6C429560E0A820EADFF007AFB7D311A7AAA1AB8A692060D2446CC74E9E4310471B796DDFF000C2AF2F1E49D54F03AD22A9443545514E57B34BFE53FDFA30D0928DF437C06D7716BDFF5FAFE58F531EC2D89381E10D01C6093655B4CCC68E6E37F52E23A3122B921B8C8BDDE8CD3D263A3C602480AF822FDC6084462A7D71C000172106FEAC3F85FBF1B8BE3848D04060348BEE7F57E781FF5C027C9ED432A468BD8B15C8AAFBBECD30882B4A62E147CB295394031FB8790E7854E7FCA73F1E96BAC29A44E9ECD4C64AC88AB620D883E22F16DFF00BE0B74C18E4CFF002B49556488C9E60C0104686E41B83D8F07D7164DFA66C7087E166A782ADB6D257D96C88280D8A00F0D67F7A685D05381E51D455FF65F3FEABDE9194CBD3D40ECC5D8F8A096DCDC4D20B5FE5C0F962C7EA5411E7154AAA11408AC00B0FD9ADB61B6FCFE38B12AB8CAFC6711A6C9C5073B12360464828DFDC44208BD47F1F2BF1CAFA63EC76C2F3DC0FD7D314D7BC761E9F81B4774CA9395EBA8B94CEDB790E051EA6DAE6AA2E51757E19478AED56445830CDDB13C73E8A8F293FDC803E9198AC4C20745D471A51A3A9B2684C90BD708E7A798C0D19075F880DAE179319F1118483CA54DEF7040587ACA1F7E314F5022579D627B6EE0334018AA8B96B2EA2BD8916EE716C1836A3CDA756D8B0F60DAD3155CB713B8816F696799DFEE17EC64BB2299DC4A1D8D746A3A5AEC8E882304E64DB2E8F31058623C3964E3EF3A257C4636F30B7371FAFEF87D9A2E8CA19D9A9EAEBB3B8E3991743411510960FB4F175334B50E922811088E961A8B1640AB6697EBDD137C98DC4813B766647369ABAFB0E9B7DAE717C235B545EC97B2E85941DDD4C36EB6D492C2AE505AD2B160AE2BCE356169CB8EBEADCA1E1B936B93F2E3F3C64AAEA6C996A276CABA3A8E9285A58E58E2A8967AA64D103C2C9AC3C1AA3959BDE1E323478C885469D419A74C6D940EBD14FA80A76717B9975111453354E489553EE55F9555555FCFAC80EDB6139A666248DAF73B6DCFC87007A0ED8F32EAA20D5D6CC9AF2B0CAB35D69218471C06C9E3835B26610B2045F79A030AAA89F844E5784F9F5C2C42B1BF00FDFB5ED8E472B348809E5941E7B9031897D33A865655BF308C5EC22A3CD657B1312912D60A34EB4AD4562CF2B908C3A8480E92460370910B84415FBBD51F53452B66D9642E2C4900DB7B6A9176FBBD3F962EF7A985F21CF244B9490281DAE006FC883CFCF1A09C8B4C9B735A18D50F8B6B0D8717A9400152749C717816A490FF00690A7C2A7E3F09EB62E3A7775BA4775048EDD8E35E24A840C35C96240F5C5B1F997510734F383413C8DB2EBB93781FB6D93EAA0A4E32D9DA59C3E39E14D09EF77AAA7E385E39F437A55C2BE63111C333DFFE768F6EFE9C73CDF03C4660CB733948B18AA634FA7C77DBE98A036A947F6F6C4DBF928CDA2A75FF00EB145FE3FCA2FF00FBE9E9E1D28C2DDBF5DF03D2A4707078D0B89B5906A6AD8815AF4A7C71B8CC8CB619E4A17B712C1854491EC9FB2E387ED74E553B1464E7FB55509D1C5FF0608884A1BC2077DC03B136E4D81B9B6C00EDB62423452EB1256A52685675D60F9CAAB10B7B802E542EF7B9616077C4DEFF004E63F235C640DDE210C7ABAAA992FACE147D5E1ABB5AF92FC6908D82223AE0455ECE2F0284E22A227E107679431C996D5AB6C9A771D88520FE1B581FA77C64C82AD9739CBB4B5FC496DF4B861F70C0ABF4F090A3E2AE34C365D520E7FB7E0B48689F6A45CF6D1A04244E3E111139E38FCF1EA8CE8E52B9144B6E27AB16F97BC4847E4717175135F34949EF1C3FFE4A306FDBBE3956F90D8C5A52E61B0B6654527B0C335F8F61792B38C5085DA7D51BD90D9B30EBD5FC826B9024FD18B139F7E0C568164458ADCE259285AAE805682B2D448880582AB695BF763B5DAE36B1240E40BEF853AEA38EB542CB2C8B191C2B69037DD8EDE624796CD7006E006DF19DAF3BFC3BB3F1EB23C6332D6736EAE590CB2BF12C96C9D92B22FCF28FD96A27524EAE8D5F0C061C7724BFC7B803D864CA6DB6CB92115ACFAE7209729A5A5CD280348D3B8591AE75789B08CD94003500C97ECDA7924610FA8B2C3451C755441CB02A19B7D41BF75B61617B1FA35B9B8C69B7C49C9F278FE345658EF7CB72065FC46CE06077206E54D23D2A43B3E8B1A855B3ECEBE1C798F1FEF36CD4571565B06E2097BA4A8848B62E532CF0E594AD98B859E354476636F3F9577276BEA36BF76ED86CF343042D55285711A172C401AAC01B936172DEA7763EA7162950CC1287192B823057B025121B511A06A234C4270A20B115B6C505A6015850111441440E1138F460EC4FAE3EB5C1B1E47E58930B2221CAA227089CAAF1F85E38FCFE3E7D77537B0BEFFAFEDFABE3135CEC37E7033DC516BDAD7B9BDEC8577DCC5F5D6C9B28A8C9208777305BB8EF23A3D179E5A5E0553AA8A92AA2F3EB1CEED1D3D4C9D96373CFA2961F4FD7189142AD256524478965885FBFC63F5BE32FFE2446AAB6F2175033002BAB24266397D8C08C0EB522433130FD28EB4FAB4C13A26F36277301B373FB07EA00D7933445AE2911AA333C8E665DEA2A505FD06AD56F9DEC6FF75F168E69510D36539DD2A4A15E28C1D008B91A7736E6D7DAE7BE34E7AC74AD5671473AE2C6DE503ED5C3B01123C386DB4ADC7ADAB7515056239F3DE4388BF77F1F8FF37EC24C71A85170DBEF6EF8D6ACCAB248EA74836B28E09F53F2C2E1E37671BBF7EF963A0ACB77DDE9662E755688DA1AC23D1EB9ADD9556B6B8DC3C6A2333AFEC24E5B4AEC593631A45AD5AF519D11A366749261B71C6D4463C5D2D98F4D2564D5CE8CB385DE39031BEB40069D2A45D8804F626D6E6C72B73AC8EAB2DAC832C8EAD65AD9525733A22A0656724A906E01048008626D7BE12BFF00A4796DDC5905450EB5C6A3BE71D5665BC1847C899A36BECBC5DFA9B48060AA29D81D034FB4C5558F37CC28B2FA87A391646A854573A101003DF4F98B28BF94DC0BE922C77DB00BA732DCCB3BA1199D2C902D13CB2C2A6494862F095120D288E574EB5F8B4937BA8B60D3E3EE25936AAC2A65265705B096702230CFED33E05A02BB1655B3C4D2213ED298AC7911BAAAA22293BD555385E3AD1F51E574F0469224E194007EC811B0B73AF7FE3F2C13A9E95CEE592CA29CAA0B86F1C8B93C8B7877047A9B0F436BE067B67C85D4F71A2F7FD363797C72D8745ACEE320B6C2A547719BCA1629EFA963580CF763FB9152432E4A615C06E53C88DC8124254EDD726775F4559D395F5547307D54E64B70E175AA1D4A782ADB30BEC7E5BE30F4F53D5D375565D45591787353548470087018A165B30B860C086046DF4370178F0427D9E1FE2C501E614F7B8C1D86CBD93320B7798F5F57BB320E4997B32E9A7C56245721BF5D242D2238CC91458EE35281E477DA5EFEA87C92B6832BCA605AFAA4A42D3CEA35937D4F3390348048041BDD8003D6C462F0CE619AB33194D3219808E3BE9B11B2A83637E41D881737BED7071DF5DE4D6EBB2B4CA25C2874DAD303A072FA5D4399EEBEC8263F92054CC3A48D3AEEDE5498838C63EE5934E2ABAD7B925C8C4525868596DB7E4B36639E64B9666699341432E7B56DA15DE090E9121B1648D92EBAAD70B74945C0D601708B5FD22E77999A8AA6A95C868A9D1E4535105D5A356D21A42FA58026CCFA1E321490B7D259A22E6F0D43B69CAEC9B3BDC3AB75CDC45D954B9E8E3EC526C8CC23AB58E05338DC276E5BC6E308C6921582A0F2B3DD5B705D28E2A881EBB7BA6695510BE5FE1C41AEAAEF16B2970CA1975D830FDEF436D8116C39274E66F2C28DFE1F2CC922AB6A8D2EA41170575D89560430F28BEC707DDD9B97507927A6F35D4DA4B75E98819CC6B96B6ADBD7C6819B3AF3F5550F8C1C927257DE544045EAF657015F9C4FAB711E468BA912F7059EAECB4D5652D439853CB490D54B1D9E311BF9D183E9F8F627B9EDB5AF852EA6E88AAEA0A16C96B277CB0968A52F2279B4C2E48B2DC5C120A920ED8787C77F22F5AD4E055186E5B90B551328229235964BB0937D41951CDB29AE3A14936A6BDF271220F517494CC095091B255121F4F19274A7546619653D6D2E455553472AEA4982AB2C80B1175B396B0208DD471E9859CDFABFA3B23CCA6CAB30EADA28731A5609242F2149236D2AC158B00B72AC08B36DDC8C09F27F2832DD819805256EC497A5301B190DB14D90E3ACE37FBF57D73CEBEDB59067B6794D158C88B3FDBAD98E1D453C1EB086C6BDA9B2A4B8F48363B3F4675ACA19DF24AEA28AE74848017B0EEEC564B16E422A8B0E4937B320F695ECAB2774A6CBF35C9BAAEBA35066A9ACAB77A4792D768A8E9A19E9754287ECFDE677796621A48E3A7428088709F30339DBDE19799103653F066679ABF58ED5811F25A8AE6F1D7730C4A7C4B9A2C5333769051B4AF913EB4E2CA436DA6197C64F769A6F9EA8B35306774992D59CFB2D9B2EABF0A603C489A23220D4AB22AB01F1290C6DB6F71B61EF393D0D3F5BC5FF007033BA5CE3222F4328F76AA5AC8E9E59A920A8A8A6132B3175A7AA69E994B333A9874C8C5D58E2957C21B2A485E4B6B8B8951A148B76656C2A44725203AE3D059C6C5D545526C950BEA99789108BAA2228170BC2FA47C9E31266FD2D0EB3E27BC3BB00480552291AC47046C3F3DB047A8CF8595E75294B2CBE0C4A6C2E0937FA9EF63CDB1A01AAD9F0D3F70EAF478DFF0022F72CC7920C8070CC714456E37DA27D511579442F9F944F8F5B1B4304429D4486CD7EF61D87A9071AFF005DA9AA0944040007C24EE2FDEDCE33F5E30FEA1FAFF4AEF3CBB6A6A282F5B6E5BEC464E2DB2F1CD8745758F6B4A8C1A4E41430E1546299143D98FDC4EBD52662C696F4D871D8169E36632917657117AE7DA85552B7BEC51AE6198574A04E65323DD551E54D049BB35F72D6B86FF3718B372BF65AF532CAB9C67B15565B0C11C74DEED247745B8553F00FB3551A06AB6E02900F9B16AFABFF00501D30F23F3331D0F9CD13775212659E45ADB6052E5B52FCB62BE0570C94A9BCAAAE7447E82BA0B62A7355C792229A9B84A6E156F2FB6CA5AAAB79F35CA9D272AAA4C72212406737D1208FBBB1B06DAE05F81868CABD90C991E5C683A7EBE24A479E6A9D334729BCB308C48C6447948D4235E100DAE1773872B12F247C1AD80DA0C7DD4FE19314D90285B3F12CAA8188F21F5E196645DE3E97101B5221544327C0150794244FC1EA1F695D279814D554F445C1369A274D873E601936EE436D88B57D1DD5F46188CBA3AF0A6D7A69E27373C796430B8BFA693CE08D8D787FE32E7551994BD771BC7ED8F90671416F4F719161D9061D7F7D9047B47E33F630E7B077633A432E1C38A26C130884B0DAEC1C827A7AA1CF7A72AA826A2A0AB8265AA56D6119497F10AB31650CC7CDA56F71BE91E9842AECBF39A3CE60CDB33CAEA686480C681E5864016387568412E9D1A519DC8B358176DF7BE0CD8568ADC7AC754C0C12BA74AC7E96A613F595306EEA32D05A8A2624B894955025B5640D355B1A21234CB222A2DB082C8AA361D512733E9CCB67A8768825389400DA62A6B31DEE4F891872DBEE59D81D88B627B664934CD24322BEF7F8C9F35EEC6C1BB9DFEB7BF3846F37F11B3CCC32837723D93364E392E2C9812AAE8D9CC634A272721C63933AD0F3217CE304775C426A2FD3BE4249D1F104F6CB943D1D43048256914BAEEA3C18000471E584A822FF00E63A41DEC6C4633BE6333821893190415579109BF3E6B923E96F95C0C006D7F4B1C42248182FDBDB49F76C12BE19544E9B5220E10B48D70CCF7E6A8C74178114888891117B297CAAD8B1D4B88C6B7D5617F807D0F07FA61C69FDA0552451C6D08511A81B0520585B6034D86DC6FE98FD6ABFD3471BD1398659B1DD9B92E415F9361B65AEA5D2D8DCD15CC29D1ACF25C76FEC22B8C45AA65D08AEC7C6FE9DF3535516F9040252EC81339822CC0518692FEED2F8962A749B8D201FCAD6ED80399F532D554BD4CC0833A2C3E51622ECEDB0BDB72E6FBFA7A6E667BC47B089570A2E38CCFADA58D14E353448950EFD1D730321F75808AED7A821B2DF7241FB539F955F9E7D5EFD2DED0E8329C8F2ACAFDDE18C50C29195F1741F28DEE1948049B936DB7C69F75BFB19ABEA0EA7CF73A5CC2A2F99D4492AFD82381ACDD40D1229B20B28BFA76C09F2AF197368E0D1C7C956AA4077ECFCD8B3A22BAAA2A462D2C990BC76FCF4445EC89C71E9BA1F69596B5C9A40EA7FCB3C67F90C2054FB05CE89220CD591C0DCB524DDF6FDD76DAFCED6C06F04F1576C61BE3479CB5CF5FE3F2728DA98762F86E332E61DA5644F6D66C274D994E3D0C8DC11824A2AAC0BA828BF2223CAAEBF7B4ECC867D2CCC83C1592128A1D86DB46A371DAC3B7738DADF62BD332F4952434D2CBEF930943968E361C1A866D4AC2E09693F003BDB15E7E3578CF9FEACDB91338D91946A9C8A9305A7CF321B5C770CD86D5FE453E6E4FDE831FAFB5A7811D993495F32CA58B6F3EFAB6451E34946914D0547573ACB32ABE83CB64EA91344D2D0472253AAC8198CD511B42802F209770431F84066B1206373FD9774453FB5DEB2C8BA2A55912925A83555C74580A5A7BBCAC5AFC08C1005BCD23225C026EF126D1CA449D30BA988AF3A6F18D7758115B335FF00C4DC56D10591104011144441011144E113D697D4F56F5056D44F57559E54CF5352ECEEED3CB7666376360D602E7651B28F28D863D5CA6F665D0D9753535051F48E5F4947471A45146296121238D4220D5A4163651776BB335D8924E33E3A3A0DB56E90DA95F77451E7C3B0D8B5F6C997BD42C95ED8BB36B243075F23205AF47CAA124FFDCAB084910E71FB8228E7455DF4EAE58DF202299166A9A5CC2275751F69A0D3C8847AE8B853B6C09B1B1DB1E2074897833302A078704D4D2A9BDACCFE2C4E09B0F8B67D8FA9B77C5C16A6CB3C7CC8351A6399464588E9DC84F74ECFB663309380DD5ADB44C4336B42CB31BB634C6AB9E27EAE1BEDA55B6C902B319BB271DF655B64BB3667943D0F9BD245EFF4D48F24CD505D9D1924F3CBAE39165886A5B21D0B73A401D8605F4C4DD5D947BDC62AEA50C66131942AE834A3ACA9E14A42D99C890DC8B91DCE069B17236359655714D8FE458BEDF8651E20B59BE193E141897713B04B8D32A6D6A4C3DC6BA972ACBF1915B703AB8D366243EAB2CCFD9665B3C4B274FE6B24291EA2A1DE2AA87704104A9D6BB77B96B6C77C58D47ED0ABE9A564CEA852A8B81A992396965B0B10403E46DF916D3DC138F4B18F253500BF259BCC9DEC0A6AC78D1C23E56CC789571C81463B931EB484AD82496C119357C9D6CCFA273D97ED5AB737E87EB1CA18CC29933348CB37894CE4C8073F03912004DC150A40BF6BE2C2CABAE3A6330FB21572658D2281E1D42058C9E3E34BC6C783762A4ED717C596E96DF5B8EA2114AD47E4364C558D3511CAE95173BB3B0C7AC5B71B47A403EC2487181415250041544FB853AA2270A229FAD33ECA99238F30ADCB5D4906159A42001B022198BA91EA0A906D82B57D27D3B9CA3C955965066C8D6B4AF0444924DCDE68951C11DACC08B8C3D188F98BE522CB6AA2FEBF0BD873106397392E0B5325B98931A43691FC9EA224775944645488C24A92AAA7C22F3E9B683DB2F565198C3D441992B587DBC3E1B8B1DFFF000E60249EDA949E773851AFF641D1F53A9A3A6AACA1AC4DE96A64319F985A91508003CDADF760DEEEFF00666D949ADCE741C7AC995A112D66CDC1B3BC8B167BACA601D49B061E4959670A7027B4A24092DAEA6CF0889CF3E9EA93DBBD4D3C6A739E9D257FCD4D3EADAFFF00A73C496F90335FE6709D55EC5524765C9BAA8B1D8E8ACA516FA78B4D29BDBB910E385CF2FF00C4B6D9834792647B0B0D7245935321B791E335595C77387B95F72461D68EBE8CAB8AEB6AAB1514917851552E9E9D72AF6B3D279BDD9A59A81946E27818283CFC7099D76D8DCDBD78C28E63ECB7AC689AC29693345BEDE05400C483B10950B11E7E77BED847FC82FD6C7C42D23945FEBFC2E4643B7B22C7277ED24E62B8DDC47A8392C3685205F7F2162B0623ADFDE240AE99A1364A41D5395219A75E65147178B4EDEFC1C5C14DD4836B104E916DFD6FDB936C67C9FA02A6B1D466739CBE53F1C217548877BA3105941005F61C6F7B629D3C92FD76BC87CF0DAA6D438F637AA28DC5275CB29931AC8EEDEE8688026C4486DB513A9137CA0C9797B12811708BE931FAEABF346D3013411A9E142966078B9D3B0B5CECDB8DEF87D87A3F25C950B45482BE623F693C9210A783A5118213B8BEA5E7CB6F4ABCD85E586E0D96332C76D6EACB7205751E91362CEBE914542DB04E20386E56C07990264B951FEB2BBD949139F9E3D4E866966612C9334BB7C4CC5AE76E0DFEFE7FA60066950D142D02B2D3A8BF923511201C6E140BFDFF005BE2C97C28AEABADF1A9ACD223AD2BDB872C97771DE8F14E18C9C335E248C431D356CC10CA13F933F9D49025E51D08CD388AA8229EB5C7DBC67EAEF92E4109DB5CB552FCC25E1881F90769EDB6E52FDB1BE1FF00622E8B3165DD5DD775080FBC8872EA56B70B615552CA7FD4BEEAA77F85AC7E23862CDBE8663ED472E09783124EA684884862A1FDC3C2A70BF9544E7FD7AA0523F2EF627E9FDF1BA5555C44BE5240207F3F96061B4AE20DD61D6B8A4584222F464742BDD438915E7631B6F0F58FF2D388A6CA2FF483B2970BFCAF1BFF009B5633D2C8BAEF15BF76C6C47A81F0EE3BDBFAF88197D0A2CE8556D25F86B80C0FD79DBD3FB27F2F129D362B4C53CD8F19CF681CF6524F200F2A9A3AC34C4A1436904DB4450F7055095538E7D235667751E1E8974C91AF07E42D6DC6D7F4201DADDB0DF4997405ACA0A33723E77BED7EC3D091E981ECCC3F2E801216682CA8F2D990139886EABF1DEE149157E958447E2C814E797115D1155F9214F9F4061EA37825229AB1E9892370E55BD2C58595D7FD2D6FC713E7C85668FEDA159411C150CBEBB2F2A76F8971031D6F8B1E1198E314F58B5F3321ACC923B332F2C5FB05836390036BEE4893205C7DB8412DBEC028AEF447386C9784E19A97AC3C0A3ACA7AA8BDF1EAA3645944855D0B05DCA11A5C0D3FE96B93B9C2DD574CA48F11A73EEBE09B9565D48DB936D77D6BBFFCC2C38C2FB575BBE3C7BC4F2EB0A2B1C9F12B693923F6949956017D28A18372431B8F0E614BA42508EA6EC47D15996DB269D57DC6BA9273385464D9D524304CB0D4B6A4BC53AAEBB79AFA43F988DED7527EBB60498B38C8FC796279A8D98B1596066D00B5AC495BA8E360E05F8B62C3F42FEA9DE41EBC903233AADA1D830AABD8F64EF59631DC897DEB0F655C0BFC6A3A238E2B6BC09BB19C2E0D54D55497D2E57F42657346EF4B2CB4132962447F6915825FF672DC8B5ADB328F4BE1A687AEF3588AA56C5157C7B0F380925CB5B678EC0FA8BA937B5CE2DA743FEAD9ABB6655B76192C8CCF5CC49F36D6AAF6265D5B5D9550C406254CAE422C831D23912A995E6DEEBEEC2615B69515405508FD2AD6F4B6739650CD56952955491207621D9182900EF1CA0A9B023E16363866CBFAA325CD2A2285E99E86AA672AA1955D2E09171245622F627CC836E7B9C2F9BCB766AEDD7B231AB7C4ED711CA6243C39B971A663EF449108DE66CE4AC48EECB8EE0BA731C64DA3107F830699075A70C5D441139A1CDA932C895E9DE89CC8F19BEC5902232B1DAC41D47704DEE470306A824CAAA2BDBC1AA4ADD29ABCA432AB6B234837BDCD89B305B002C4DF14E9BE5E88D6C6BE91514E6E595FE573E723912284A50659C460D63626EA22247862FF005202254013045E1497D14C9A4ADCC2942BC866782088052C6E4994B1B5C1B9ECDF2F963AE64B4B4752AF145E199E576B85BFC3168DEDC0E2C78B8DEF802A6B77A48D45B64D6AFB75CCCD58B674F8F4391617A301B65241CF576332F20117456C5B8ECBEE2B869F20BF3EAF0E8FE9CE9AD11D7F52753C5488CD77A487C433AA804FC4D1683736502212B5F6B8C51DD6FD43D6F0B3E5DD2FD1D3D6B840A95B3787EEC58902FE1A4BAECA2EC5A630AEDB2B601FBEF6265CFB79168DC170FA685ADEF731C5E763E3231B08FB0AD6D21D7458F590ACB2796492EDD976E2CE492477CDD0033146C5BE9C21DA8CDB24ACA8A94C8A99E87286653109632252B1AE962E4B3B799959ECC7820F9780833D17565265B0C79EBC198E6BFF009E5240B691DB546A0698D5946A54B22F6B6FCE34E9498E41D618561DAB22882B3AC30BC575F039195B469C9F8B55311324962082888DBF953B7D2117F25F56BC2FC7CE87F5FE63FE31D639D4E92F89051C9EE9113DD297ECCB7D5E5F1643EBAEF8F72BD8AF4E9E8FF649D19954B0886B2AE916BEA940B0151980152CB6DAC228DA28401C2C6071896D4C4D691E1039B0B2D5C7ACA638F3F5511869F309148D38501B96AACAA222ADA42B66D3E39EB1517F0A9E9FFD9FFB32A7EA7C85B36ADAEF7432544A91837F34718452FB7FEEF88BFEDC52BED83DB657F457570C8B28A015891524124C400744D2B48E1383BF80617FF7E132C77625365D5415B9047E96D0D3A1A82FB452D10004ACA33828251E60388AAEB6282A04A861CB67D5BB70E633CE8C3C42B258837E180BEC4717B6CC0F3F2C6890A4822D1F66342906D7F849DC32B7362783DB837C704BAE4594DCAAF68DE6A43AAB2EC2536F448E3204443DF524639194ADFB7EE923680E2B7DC950D1795B9A6215E370004F85458EDE837E2F7B0BDC5EDC1183A902394911EEC7E236B6F6EE00B5FD78F538F4522DCC40361162490EDD8D8F787DF51EA3CBF0A43EDA28970A2AA8A2AA9FDC3C7CAAAF54C71CDF68834B9EE05C03E8C3F9F1EB8230CB2440C6C7585E413BFDC79FBB1F16B1AC6B2390BEE1CA8B93C544101993AB989711B5E5045B726BAB16D639A8FC208119F1C2F0489E8799EAA9059955A263B90A4ADC7CB6607EF1F862788A9AA85C3697038240603EBC1FCEF8F1324D79794117EBEB4E1D849E14E556C647A0BA8DA7C2133093AFD512827260C997F911545EA99A0CCE176D32F96DC329BD8DFBF703E76DB106A32E96252D102D6E54ED71F2EC7E9F8612DDA67A66B2B24CDCBDB89895B48791A916552EB50AEEC24B4EFBCCB058F8B06D4E3135E7FAED46711138391CAFC3EE519BE70CCB4C92B56C1A4F91AF269422D70D7D6BB77B953E984EAFC9B2C951EA64856865BEF25C44A58104060DE5637EC06AEC2E70B76139D41A26D69EAE64DB1AD5FDF6642B57E23F54FCB6D5FB4B268A455CA75DFA290AA622A80E18A170BDD5153D31E732193A6F32460239668553C336622ED1AFC486D6B589BEF6DB7230B1963252E7D4AAB219E2A795D84803229F2BBFC0E030DF602DB9ED6C5C4C1F1771EF19B12D756A1999E6393EC8A01CB720ED5E9551F1A7870AA3FA6A5AEAE71B4904CB6737839128CD641B1DD8169B4505A93A83A9E1CF6434946882932E21010F79198055632C4C14C57D1E4035AB29B891FF007760E5F66553ECFB2FC96BF329E49730EA78A49DAF1058230A10AA534AACDE3E9F140999FC3911C056823D8B0030CC2A6ECAC9F634F815CF4A6286253B525BF648901DB2B3B7719753815E455B887C2FC27D8BF3C227AE94D99265290867B19C003E8AABB76B1BFA7D7067A7BA7E5EA11983471174A38E3B8B706479083F3D94FF006C41B2ED7B2299F7DB754E13A8A5C834BEE28A8AF2A9EE02FF0072F29F0ABFCFE79F46D33E69C795882DE86E3F8F18ED53D26B4AFA5D00B76B58E267E396B3AFC8774EBA7EEEB9320AAC72F93389CB6B0827C78F1303872F2F428EDCE0208EE2CBA58A0241C1013A9F08BC7A990E6D240DE31A83A630CED663F044AD2BDC7CD23607E44F38870F4AD3E675B4942D46B33544D144A590310D2CA91210483B86916D6C3FE3325CD047263A0F3D355F9725D3246D7DF926EC890AEBAE17D8EFBCE3BC0AFC1F0A9F95455D610CD33C93CBFB4958BB7A92C4BB7DD724E3D31AA648238E0807D940AB12017D95404402DE8AABC71FC11EF2B365BB176A0E1905A8CE39AD713C6708B5952D5D77EAEF9A867925DB91853E588EDD9649223F42E490E1992FC12226E4E4397D4E57D37D3797D3C376A7A285A5245AF3CE5AA65EE3869B4DFD463CC9EB3CD20CF3AD3ABB3BA99DBC2CCF309CD388D9005A5A7D347083AF7BB2D36BDB6B38EF7C79EE8DA4BB33BEB256C65D9F5764BB4B5931A8F05FE89ECCE6243B11B6DD7C0FA2BA7D401D0520215EEA5E82575451AC9AA84B01B1757650EE45C79541243117DB737D26FCE2A4A28EA74FFC595D63652818AA036D8B102EB7B5F816BFCAC6FD6D993F2425C42781D9511E16E55784616824912A036F32E4CE43E99D515FC0910197B6E2F551325FAF5D616475D6928BAB83E5617B5EDCAB03B3293B11B722E6A8A400BAA795E2362B6DD4DAE05CEC5586EAF6DC6C77071D9B267D2BB56536BC63D3B905A6CCEB26CE69865F8EAA4A7D2491F11CC4D0FDB15246C48905041B2550C5408C8FF697923726E46E41DAE6DE9EBF8DC9C7DAE97C5405008E44B73600F279F51DBF03B6E134CB7C87C6299A6E23A722FAC91AFF008EAAAA6C12421A2F4123791875D92D12F44216DA71B5245EC62880425BFC2A394C8F18D4B7DD89B27FB8921411C8DF55B81C8C066CD84215646BC846CABBBF1D956E6DF80E7EB85733CF24B73E63165C06A7CCC3F1B80DB6095A4F93D60EB5EEFB2BC30930C9814543E1B27950D4104184E051255364393412C6FB54CD29B5A325501B5EC646009BF72A05BBB6234B9F66B511B465BDD214B0F3D9E43BDAFA14955B0E012C4F1A70A0671316C62A589D92DECB6DD98D4B9F3267D5C886F2834E37184BB7566408189283403D548517954E11AA869CC73786B0FBA425548551A43D89D44F7606D6D4C4DC7181536614DE149F6DEFD560B2F88C43BC4762003B8460083A50023604639B18D873E35EFECF364BEFC46E49B6DBAA60E2C561B6089D469931443156C0D3AA9227F53E7FCFA93599647265E4AA0B48A09163B92C0EE41BF363EBB61763CC41CD2425C878A5B763B7048047A5F9D8DFB634FDBDB786B3DBCC6AD91AF329837DFB2623913790C021362E319973E0C43ACAFBDAE71A0720C828F0662B3CF607059256CC85108B5AB2ACB2B72F8EA5AB21282A5C686B82B205621B4B03BE92CB7E08B8B81C63797DB1759F4DF574DD312F4E66295B151D3CE258C2B47242D20A72A2585BCD133786FB7C24A3142CB6243FE206533AAB03F21EEA242AC944E596075D21650984961D6D8CA64A3D1AC58547212A8CC21FB85C617AFF0059BF815F52FA8EA520ACCAA965A28EB29A51231BEB8E55B6855314D1B064360750659236DB5C66C2C7FD8550AD5F4EF5B66095D2515653B50C51E9D1242D749DDC4D4F2294946EBA595A29937F0E640CC0C169A4C0D9F9EDCC47E4855C5853562FED33163B476121A017DD41BC3148EF2F455E01C28A4A42BC22FC27A9E628D208A4CB6AC0965171054B2C4FE9A639BCB4F212761ADA027B2DCE278A6398E63574D99D194A7A56D26A28D1E743B5F5CB4FE6AB8940DDBC25AA55EED617C37383E3D1F1AB5B4AE8750F41912307CCA24729EC2B6E07BF4CB25BF6C45387DA722312510939171153855454558A95752C337CBAAE37A6AE1435DA63914A30714B2B7079BC7ACA9170C0DC120E0DD374ED2D1D674D67742F1D6E511E69976B9E175923D06B224BDD6FA74CC620E080E86E18022D8EBA4698B0BAA4AC755A835B63695EC4C3925C4662BDA744ED24BA429F636DC019AE9127F6A097C2F289E90B20CB7FC5F3CCAB2B5DC661530447D34C922AB1FA042C7E4062F1EB2CF97A7BA4FA873E95F41C9686AEA6E7621A185DD3FF00B1547CFD7151998E498767D9F6C4CC6CF2E7E3B991E77935C4470ABDA6FEB2BECEC5C9F0A50B325F438ED7B3251B06CBE40238A1705CA27A1B5FD2F9A6572430CE16169E313055606C8E5B486BDB4B002DA45EC2D737B81E2664BEDBFA6FAC20A9ADC8C54494996CC689E494786269A148DA49620189689CCA2CEE1199839D017493FFD9, NULL, 1, 1, 1, 1)
INSERT [dbo].[Producto] ([id], [descripcion], [imagen1], [imagen2], [idTipoProducto], [stock], [stockMinimo], [baja]) VALUES (2, N'Banqueta', 0xFFD8FFE000104A46494600010101006000600000FFED003650686F746F73686F7020332E30003842494D04040000000000191C0267001450524D61626954474D62596A335A51707956344D00FFE20BF84943435F50524F46494C4500010100000BE800000000020000006D6E74725247422058595A2007D90003001B00150024001F61637370000000000000000000000000000000000000000100000000000000000000F6D6000100000000D32D0000000029F83DDEAFF255AE7842FAE4CA83390D00000000000000000000000000000000000000000000000000000000000000106465736300000144000000796258595A000001C00000001462545243000001D40000080C646D6464000009E0000000886758595A00000A680000001467545243000001D40000080C6C756D6900000A7C000000146D65617300000A9000000024626B707400000AB4000000147258595A00000AC80000001472545243000001D40000080C7465636800000ADC0000000C7675656400000AE8000000877774707400000B70000000146370727400000B84000000376368616400000BBC0000002C64657363000000000000001F735247422049454336313936362D322D3120626C61636B207363616C65640000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000058595A2000000000000024A000000F840000B6CF63757276000000000000040000000005000A000F00140019001E00230028002D00320037003B00400045004A004F00540059005E00630068006D00720077007C00810086008B00900095009A009F00A400A900AE00B200B700BC00C100C600CB00D000D500DB00E000E500EB00F000F600FB01010107010D01130119011F0125012B01320138013E0145014C0152015901600167016E0175017C0183018B0192019A01A101A901B101B901C101C901D101D901E101E901F201FA0203020C0214021D0226022F02380241024B0254025D02670271027A0284028E029802A202AC02B602C102CB02D502E002EB02F50300030B03160321032D03380343034F035A03660372037E038A039603A203AE03BA03C703D303E003EC03F9040604130420042D043B0448045504630471047E048C049A04A804B604C404D304E104F004FE050D051C052B053A05490558056705770586059605A605B505C505D505E505F6060606160627063706480659066A067B068C069D06AF06C006D106E306F507070719072B073D074F076107740786079907AC07BF07D207E507F8080B081F08320846085A086E0882089608AA08BE08D208E708FB09100925093A094F09640979098F09A409BA09CF09E509FB0A110A270A3D0A540A6A0A810A980AAE0AC50ADC0AF30B0B0B220B390B510B690B800B980BB00BC80BE10BF90C120C2A0C430C5C0C750C8E0CA70CC00CD90CF30D0D0D260D400D5A0D740D8E0DA90DC30DDE0DF80E130E2E0E490E640E7F0E9B0EB60ED20EEE0F090F250F410F5E0F7A0F960FB30FCF0FEC1009102610431061107E109B10B910D710F511131131114F116D118C11AA11C911E81207122612451264128412A312C312E31303132313431363138313A413C513E5140614271449146A148B14AD14CE14F01512153415561578159B15BD15E0160316261649166C168F16B216D616FA171D17411765178917AE17D217F7181B18401865188A18AF18D518FA19201945196B199119B719DD1A041A2A1A511A771A9E1AC51AEC1B141B3B1B631B8A1BB21BDA1C021C2A1C521C7B1CA31CCC1CF51D1E1D471D701D991DC31DEC1E161E401E6A1E941EBE1EE91F131F3E1F691F941FBF1FEA20152041206C209820C420F0211C2148217521A121CE21FB22272255228222AF22DD230A23382366239423C223F0241F244D247C24AB24DA250925382568259725C725F726272657268726B726E827182749277A27AB27DC280D283F287128A228D429062938296B299D29D02A022A352A682A9B2ACF2B022B362B692B9D2BD12C052C392C6E2CA22CD72D0C2D412D762DAB2DE12E162E4C2E822EB72EEE2F242F5A2F912FC72FFE3035306C30A430DB3112314A318231BA31F2322A3263329B32D4330D3346337F33B833F1342B3465349E34D83513354D358735C235FD3637367236AE36E937243760379C37D738143850388C38C839053942397F39BC39F93A363A743AB23AEF3B2D3B6B3BAA3BE83C273C653CA43CE33D223D613DA13DE03E203E603EA03EE03F213F613FA23FE24023406440A640E74129416A41AC41EE4230427242B542F7433A437D43C044034447448A44CE45124555459A45DE4622466746AB46F04735477B47C04805484B489148D7491D496349A949F04A374A7D4AC44B0C4B534B9A4BE24C2A4C724CBA4D024D4A4D934DDC4E254E6E4EB74F004F494F934FDD5027507150BB51065150519B51E65231527C52C75313535F53AA53F65442548F54DB5528557555C2560F565C56A956F75744579257E0582F587D58CB591A596959B85A075A565AA65AF55B455B955BE55C355C865CD65D275D785DC95E1A5E6C5EBD5F0F5F615FB36005605760AA60FC614F61A261F56249629C62F06343639763EB6440649464E9653D659265E7663D669266E8673D679367E9683F689668EC6943699A69F16A486A9F6AF76B4F6BA76BFF6C576CAF6D086D606DB96E126E6B6EC46F1E6F786FD1702B708670E0713A719571F0724B72A67301735D73B87414747074CC7528758575E1763E769B76F8775677B37811786E78CC792A798979E77A467AA57B047B637BC27C217C817CE17D417DA17E017E627EC27F237F847FE5804780A8810A816B81CD8230829282F4835783BA841D848084E3854785AB860E867286D7873B879F8804886988CE8933899989FE8A648ACA8B308B968BFC8C638CCA8D318D988DFF8E668ECE8F368F9E9006906E90D6913F91A89211927A92E3934D93B69420948A94F4955F95C99634969F970A977597E0984C98B89924999099FC9A689AD59B429BAF9C1C9C899CF79D649DD29E409EAE9F1D9F8B9FFAA069A0D8A147A1B6A226A296A306A376A3E6A456A4C7A538A5A9A61AA68BA6FDA76EA7E0A852A8C4A937A9A9AA1CAA8FAB02AB75ABE9AC5CACD0AD44ADB8AE2DAEA1AF16AF8BB000B075B0EAB160B1D6B24BB2C2B338B3AEB425B49CB513B58AB601B679B6F0B768B7E0B859B8D1B94AB9C2BA3BBAB5BB2EBBA7BC21BC9BBD15BD8FBE0ABE84BEFFBF7ABFF5C070C0ECC167C1E3C25FC2DBC358C3D4C451C4CEC54BC5C8C646C6C3C741C7BFC83DC8BCC93AC9B9CA38CAB7CB36CBB6CC35CCB5CD35CDB5CE36CEB6CF37CFB8D039D0BAD13CD1BED23FD2C1D344D3C6D449D4CBD54ED5D1D655D6D8D75CD7E0D864D8E8D96CD9F1DA76DAFBDB80DC05DC8ADD10DD96DE1CDEA2DF29DFAFE036E0BDE144E1CCE253E2DBE363E3EBE473E4FCE584E60DE696E71FE7A9E832E8BCE946E9D0EA5BEAE5EB70EBFBEC86ED11ED9CEE28EEB4EF40EFCCF058F0E5F172F1FFF28CF319F3A7F434F4C2F550F5DEF66DF6FBF78AF819F8A8F938F9C7FA57FAE7FB77FC07FC98FD29FDBAFE4BFEDCFF6DFFFF64657363000000000000002E4945432036313936362D322D312044656661756C742052474220436F6C6F7572205370616365202D20735247420000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000058595A2000000000000062990000B785000018DA58595A20000000000000000000500000000000006D656173000000000000000100000000000000000000000000000000000000000000000258595A20000000000000031600000333000002A458595A200000000000006FA2000038F50000039073696720000000004352542064657363000000000000002D5265666572656E63652056696577696E6720436F6E646974696F6E20696E204945432036313936362D322D31000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000058595A20000000000000F6D6000100000000D32D7465787400000000436F7079726967687420496E7465726E6174696F6E616C20436F6C6F7220436F6E736F727469756D2C20323030390000736633320000000000010C44000005DFFFFFF326000007940000FD8FFFFFFBA1FFFFFDA2000003DB0000C075FFDB0043000201010201010202020202020202030503030303030604040305070607070706070708090B0908080A0807070A0D0A0A0B0C0C0C0C07090E0F0D0C0E0B0C0C0CFFDB004301020202030303060303060C0807080C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0CFFC0001108008000C003012200021101031101FFC4001F0000010501010101010100000000000000000102030405060708090A0BFFC400B5100002010303020403050504040000017D01020300041105122131410613516107227114328191A1082342B1C11552D1F02433627282090A161718191A25262728292A3435363738393A434445464748494A535455565758595A636465666768696A737475767778797A838485868788898A92939495969798999AA2A3A4A5A6A7A8A9AAB2B3B4B5B6B7B8B9BAC2C3C4C5C6C7C8C9CAD2D3D4D5D6D7D8D9DAE1E2E3E4E5E6E7E8E9EAF1F2F3F4F5F6F7F8F9FAFFC4001F0100030101010101010101010000000000000102030405060708090A0BFFC400B51100020102040403040705040400010277000102031104052131061241510761711322328108144291A1B1C109233352F0156272D10A162434E125F11718191A262728292A35363738393A434445464748494A535455565758595A636465666768696A737475767778797A82838485868788898A92939495969798999AA2A3A4A5A6A7A8A9AAB2B3B4B5B6B7B8B9BAC2C3C4C5C6C7C8C9CAD2D3D4D5D6D7D8D9DAE2E3E4E5E6E7E8E9EAF2F3F4F5F6F7F8F9FAFFDA000C03010002110311003F00FDFCA28A2800A28A2800A2BE73F8F5FF000558F81FFB3AFC42D3FC2BAF78B1AE75DBED76D7C37243A6594B7B169D7D72C56286EA745F26072C0FCB23861B58EDC2B11F307C61FF0082FCEADE0DF1FEADA0E91F0CFC136BFD992B2B4DE23F89D61677888395796C618E5961DE877AF98CB900FAAEEC69E270F39CA9AAB0528EAD39C62F7B6CDABD9E8FB75DD0548CE138D39425795AD68C9EF669E89E8D34D775AA3F4AE8AFCB2D6FFE0B6BF1524F86EBE26807ECF361A45CDEFD82D6E135FD4AF5EF645DE5D61096F82E150B6C237EDF9B6119C78AF8A3FE0B09FB55FC40BC68B45D534BF0ADBA98E633C7E08BE902432B6227669ACA4558DBFBE400DDBD2AB2FA91C64BF7328F2DDAE6E785AEB75A49BBDDDAD6BDCDF33A31C041BC54F9656BA8B8CD4A4BFBB78A4FBDEE9596FAABFEDBD19AFC81F1DFFC146356F06F847C290FC54F8E7AA683E2F867B85D52D2D236B986FE028850C91E8D25ACD6EE1640F1B636BFCC1B38C8F29F1F7EDC5A0EA776B7FE12FDAD7E2EE8EAE985B0D42C75ED4514292AAC641749D700F20E49E79C8ADE54DFB4E58FBD1FE78DE51F2B3576EFBAB27A6F630CBDC71947DB52695ED6527CADF7B37EEE9D6ED7CCFDD4CE280D935F8ADA1F8E7F6A6F147C2EF0FEA9A3FC6CD6B5CF0DF88A29E5D3354B7D3EF9645119C7FA439B90F0EE63B53CEFBE548E4035A1E18F1CFED8DE05F0DDBF8921F1D6BDE25B1B880CAB6F6F61A9DD6A2B82C0F9F6978636831B721922911948652E8C18F362B114A82E694D3574B452EAECB78AEBE7EB63DEC2F0FD7AD495593514EE936E2D36B749C5CB55DB77D2E7ECCD15F90BF0D3FE0BA1F143E1FD8DE59F8DBC2BE3AF106A1A4AB2CF736FE1AB768D64CE409D41B6DBC1182A470475EA7B2B6FF839AFC2FA7470AEADF0DBC4B6B3B604BF6875B48A3EF907323B7D0A0CF5C8E95D50A15E6AF1A727E8AF7F44AEFF0003CBAB8470A9ECDCE3DAFCC92FBE565F79FA91457CAFF003FE0AD7F0EFF684D0ED6E343D37C557D7970159AD2CB4AB899A252BB8B6E9238C32800925370C63D6BD1B41FDBD3E18EBD2794BAD6A16B72AC15A0B9D1AF637524E00CF9454E7D89EA3D4571D1C552AB7E496CECFC9ADD3ECD754F53AAA64B9853694A8CB557568B69A7B34D68D3E8D68FA1EC545733E1CF8CDE16F15E9F1DD58EB9A7B41300636964F20C80F42A24DA483D881835D15A5EC37D109219639A36E8C8C194FE22B68C94B6679B529CA12E49AB3ECF4649451466A890A28A2800A28A2800A28A2800A28A2803F988FDBABE2B2F8B3E32EBDA3F8675EFECF9AFBC750E9FA89B6B5824B88B514D592F4788229154B4CCB8BA8DB27EFC5267EF383CF7893E1A69BFB407EC9D1685A6EA56E752D2F518751FECBD15E499F4A8AF59E683EDA1801757CEAE3CD9892CC506E398C574DFF000555FD867C5BFB30FED99E2CB0F881717107877C61A95CEA5E18F1168DA79F2E3B0BAD4D6E669530EACB35AACB701A35DECAF2A82BE4CA920F1BF84BFB4369FF000F75BB76D0EE6DB41D3F58227BDFB19D8EF75712D92DC46F14B26E921B58C5D0B572DBC2B172CADE62D7C566193CA9E591A3819AA7384D493DDF3269A73DDCB9BDEBE8F569D8FACC2E3E9D5C5F36223EE38A8EBB38F552715769AF75B5AAD17C2AC7ACCBE2A8FC35F0335ED27C07AA43A7F8161D20F87E5D56F6437135C3F998BA92101E358632EA0EF9433924ED40855EBCDFE20FED79E3FF001078B745D424F175E3EA5A45BC7629A8DBCAC8C6DDC07630063888B82ABF26DC1CED209AB3E21B9D1BC49F0A3C2B26BBA3EB7ACF8AAD1CD9C9A9EA1A3B1B9D535796EE68A0B49AF8A9578625FBC0CAE4F9D09DA4C4E8BE5BE38B7BAB9D7B574D41A192E7C37A85B595D79EB88E79A4DEA50AE7091AB1D9B4649049249EB864795C70D2945C757294AF251E67CD68B937AF373AB37B4754B9559A5F8571C57AD5F3993C754F6D0A6B9232B3514A2ED1518B5A257B24F66EFAEACFB97F664FDA76D358BF9A2F10693A1DB6A76F6525E4D26ACF235C5FAC20C93F936B67B22B9900DEFE5C93C4E465F040664F20F8C5FB7D58F8CFE376A9A6789BC45E2EB4D0F581E437867C1F757963A549678FDDADCC325D3892468953745122296E773649AE4FE01F8435C5D1BECEFA4C9E28D2F50862D43467B2D4522D6B4992DE62A7C9F34AA3CD6F214DCA5D582B63F7886450789FF649FF0085F1F1E7C23AA6B1A0FF00C22B75AB69E9757B6B622396CEDE4B791C3B326582EE645DD0EF3B7CD084EE049F13119C51CB71F5AAD5AEE149C1A7C925CCA495EE936E71BF2B4EC95A50D373EE7C22CA7071A339470D19578B53539B93A7ECD7C7170BF2B925AA4F9B4BD95D2BFD35F1A7C65E05F197EC75A678D3E19DEEA32693E13F2FC3B7B35C78D63D526D113CC54815E19258EE2D52573279714492C6CAACD88C62497E78F86BFB60EA9A76A12F9FAEF8A351B268BCB9161D66EE0CC676FEED8A4A8590E00DBB8738EF8A975ABAD2FF0064BF8B126BDA26AC96D796307FC237F16F4C856EED1F51D27519E248F53888619789AEA1CB4455F7488CA3E691AB77C33FB4678BBC216FAC6A1FB39F85FC23F0D7C13E1F8A4D013C7F7FA73DEDFEB8CF7B24AD1D8348584A9E6A4ADBE5DDB52141BA364852BF59C8B8E294F20A581CC6856A918A7255A53507C9CD77CF5346A517F0A8C6529C251B24D492F4B19C3F8DC2715D4CC32A8D38BAAFDDA72A7CF4E4A4AC9C6152EDA9C5A7772567769AD2DF4AFC34F86FF15F523770F857E12FC6ED22FBC250B24CD0F8F2EACE1B4006E9208419103480B0C471B39259B726462BCEBC7BF123E327C20F152E9F1EBFE2FF0008EA7759BAB7D2B52F17C5FDA0B6C4677CB1CB7065518DC412003B189C76F9ABF649FF00829CF8C352F8D569E1BD6AE6FE4F03EAD79F69BEB1B7758269BC95924539766CC814BAF05C7CDBB680081D57C30FD9CBC71FB455A78E7C45E3FD596FB5AD37C3773E2A8AE63B9F3E186DA1BB96116F1ED21633B629E611004222C60846930BE3F0CE752C3E672A39DA54A09464B9B135AACA4E6DAB28D46E2F55793B26AE959AD4F7B8DF1B80C06475331A4E1569CA4E9F343094E128BF75DD494B9A2D74516AF14ECEF78BFB17F677FDA52EBC43A341A0FC548352D175AD4E27B4F0D78EB59F0EC5AB436B34F0B184CF1CD0C82FE19339036B3ED3949915DC8FA0FC47FF0004C3F1A7C4792FAFAE2CBC01F0FF00C4111B64D1F52D13C2B6F79A3EAA27395522682E67B6552C8B9776032C090AAB9F917F63FF00829FB43783EFBE3569165F11AF3C21E27F80B7F61ADDCE85E2B924BFF0AF892D9E3BF944AF14E1E25056C84915CF967E5756DD1BC68E9EB907ED41A77ED57FB16EA9E34F0B788BC471DCF83756B8F18CCDA049A8E9DA878512D763EAD04570B0848E192C6F16741E748C674843AC81664B5FBCE22FECFC557BE573519D36B99424ACEF1534EDC895A51926FE284B4D39AF7F87E13C0D5A18D8E13195E33A755A8A94A1CCE3CDA24DB95ED7B5A4A519455ECEC925E47FB4BDC7ED55FB02EA2DE1CD7F5ED074ED1669CBC0965A3E92FA5DD34A1DF7C517D9BE40DB24E5634E6361FC38AF0DD2FF006E0F1A5878A05CEB1A969BA8FDAD952588C71DB2820606C16DE5C71FE080E792AD926BEC6F8FFE37F157ED93F083C41F05FC69A9FF00C251E3FF00075B7F6D786BC509642197C43A23C8A8659E38BE5373697290AC863004904DE66DFF0058CDF94BF133E1ED8FC33D6DBC3AAD0EB1E2C49CC524561E634369B47CE5A6650CD22B01C221418387272AB7C3F88CB3319D6C0E65421EDE0EFA4651E6A4F95292E48C9A6A4E509494A2AEA2D24E692FB4E20C0F10F0B5584F2EAF3A706AD24A778A9A6DD92935CD19C546718B8B7ACA2EFC923F55BFE09BBFF0503FF84C75968F5FD6B5CF02E9D34C9A4B6A6FAEC977617B2CCDB80FB3168E55740C8C1EDE74650CBF2B2E54FDEFFB3A7C50F1BF847E39EA5E0FB9D6BE24EAFE163692DCE9DA8F8BAC6DAE6682EA2B97865B69268A38CC919411BC6CB236F575612B7CE83F9ECFD8A7F67CD6BE36DD5B7893FE120D3345B3F0C5E25D447559E1B782E12DFF00D267962795E340B1470EE94973E5A9577F9706BF5C3E38FEDEDE22F825E1BF1EE93E32B2B1B3BED0F4DBED47482F2A583EB9E1DB78D61BE4D3EEA4758A5BC5F3AC658864BBF9ADB558600F87CD29AC3663530F8094A71BC5A8FB39DA9A4D73C25395D4DC945B524DB8CA4E3A2B23BB14F119CE5F4330C4CE14AA415A7294E9F3544DC5466A118A946DCD65192D629493DD9FA43FB3B7ED1BA5FED0569E204B1DBF6CF0AEA72E91A8796AE23F39091C6F5041206EDBCED0C06E6EB5E8F5F0AFFC10D7E2AE8FF1BBE1BF8FFC49A347AA42B26AB6D6578F7501B65D4A7485A417FE4C9FBE8E69A09A013799856961778F3132337DD55D746356304AB34E5D6DB7E6FF0033C1CC3EADF5897D4DB74FA5F7FC975F2D828A28AD0E30A28A2800A28A2803C9BF6CCFD8D3C19FB71FC17BCF06F8C6CF729267D33528547DB345BA0A425CC0C7A30C9054FCAEA5958152457F307FF0516FF827F78ABF617F8D1AD7867C43A7AC6B6E7ED1E7C31916B75031223BEB727FE583E0861FF2CA45643C2FC9FD6AD7877EDF5FB07F84FF006FCF8253F85F5FDBA7EB167BE7D075C8E012CFA3DC918276E479B0B801658490B2281CABAC72270E2F0BCFEFC3E25F8F97F91DB85C5727B93F85FE1E7FE67E14FF00C113FF00E0AA7E09F07788743F813FB4F68DE1BF187C306BA8E2F067893C4D610DE37802E8B7EEE0925994B4564CF8D9302BF64723388096B7FD5DF8EBFF0006E6FECBDF1B2C35A5B5F0D788FC0F7DE209D6E6F6FF00C3BAECEB2C92ACBE68711DD19E0560E49CAC60F27DABF9F3FDBE7F60FF00167EC3DF1BF56F08F8B7475B09AD583AF96C64B4B881CB08E7824207996D261B63100AB2B46E15D1D57F4CBFE0DCFF00F82E659E896B65FB3BFC6AF13456B069F1087C0DE27D5EE44712C48BC69375339C29551FE8EEE70C0790486102C9186AD09FC4B55DF7D3FC99966195D2A9EF4E2A4B7DAFB3BAB7CF5F537FFE0A01FF000489B1FF0082767C35BEF8BBE1DF8B96E9A76942DA38F40D6F465FB46B3A9AAF976ED6F2DBBAAACF226F8A50900436E652C008C15FCF4F863FB51D9FC219BC67A4F81E6D3742B5D4B57BAD42C2DB5BF366B5D3536C32C28AEB858F7849E170C3E569616DF88CB0F56FF82D17FC1532EBF6EAF8F9249A4CED0FC3FF00094D3E99E12B40854DEB33624D4640C036E9551582B01E5C4B1AED57690BFAE7FC1B79FF0004C087F68DF8B527C64F1958ADDF827E1DDFAA69304C47FC4DB5D5F2E65761C968AD95D243D034CF10C9F2E543F3D3CB3095EB72D3A49AD16AAF7E5774DA77568DFDD7D3A35B1E86474E195519FB15684ACE507AC5B5B68FAAFF0081B1F11FED8DA078A3C23E11D3FC11E28D375FD1F5F86C2EA3D37C47AF69F73A75F78934768BED91C772B3462565B6F2157738C4609C88C257A87C1DF8BBF0F34DFDA06E350BFB8D426B8D7AE6D3C11E14F0FE8AD05E6936BA688EDD626902314731C918425198990CA5558A9C7F4F1E2AF07691E3BD126D335CD2F4ED674DB852B2DA5F5B25C41282082191C1539048E47426BE7FF177FC121BF66EF167882D7568FE127857C3FAA58412DB5B5C787E16D1842B28937FEEAD4C713E4CD2B7EF1186E7638C935EEE372B8E27072C1D66E519DD35B269AB74EAB74FB954F3894B17F59AFAF476DED7BBB7F2EEF6D8FC15F18FC12F0BFECDFF0018FC71F10BC45E17BABAD3E449C936D0C8C970F752642E322384860DBA43B369507AC8A1ACE9979F1297E13C7E15D3B4AD26EDBC75A8C5A7D9E9BA02966B2B692433C8F2DD990A48AFE5431B302220A59B7E057EA8FED1FF00F06F4E97AE7C10B7D03E14FC58F1FF00836FBC3A8B2E8D0DECF15CC25A3131481A78D22B808C6444DCEF288D618F6A7CA437E46EBEDE32F83DF149A66F0E693E1BD7BC3B7F3DB6B31D94324205CAB18CBBD8B48D6B14D148B2B131A9426539C81F3FC265FC335B035684F1B3556AC65A4E7AC5282FDDEF2BC5DF5938A77BA8E914D9E0F891471D9AE5B2A7944D4A2A3AD28C5C1369E9376BA94A5BBEDB26CD5FF82817ED0DE3BF81BF113C55A1EB7F15F5AD7BE207887C3F6BA66ACDA45FDC5A5BE9D6F2C9E7B59E54AAB402167022548E31F6D7C0C870DE79FF0004B5FF0082825AFEC1DF1BF5B6F1268ABE23F877F1034E4F0FF8AF4C6552F259994132A2B637B246F70BE59744759DF2785C792F8BFE116B1F10BE2FEBB77A85F5D451DEEA325CDC5EEA3BAE6F3C9790932B003F7D2043C8046E61C6339AFDA0FD8BBFE0D62F8511DAF87FC75E3CF8A9AC7C5A8AF92D356B08F4CB282C745BD848496359565FB435D42CBB4104A2BA9C15C315AFD972DC760A9E023877353A91497BB1492B2B2B249251DECBB596EAE7CF649C3F88CBF050A756FCCFDE6DB77E6D36BEBA7DFD7A9F3CE95ADEB5FB2F7EDBFF000ABC1BE17D3E1F8A9AA783752B8FF847751B4D5628A0D63C31A869570E96D797120C5ADCC366219983AED68E28E5E03A33F8ACDE1FF06F89BC61F1A3C41E13B7D4FC59E389AC9F4ED3348F0F58B6A9716D3CBE5DBC8A8B0C7E66E757918C853259DBEEE2456FDF6F85BFF04D0F81FF0008F546D434EF00E997FAA4A976935EEB334DABCD39BB60D76CC6E5E41BA62ABBC80370555FBAA00EEBC5DACF807F640F831E22F135C59E8BE0DF087866C66D53516B0B24B78A38E242CC4471A8DCE40C2A805998850092057CE66B8378B9A71A92846CE3249DB9A2DC1B8B6ADA7B8BBEA95EEAF197ED35B8DE9D4E49D4A0AA558C6094E5BF3414D2928DE51DE6EC924ECE4AE9B8B8FF003AFF00077C7FE17FD90FF620F107C11F8E1E13F117877C45F1295750BCD27C47A76A1A2CDA7582492FD9EED57EC735C191E40EA8238769304A1E580052DE61E14FDA975AF0D6BF3EA5E03F08FC35B5D1347F0D6A9E18D1CDD785AEDBF77A948AF713996FEE6EE679212842F992347B65BA8422A4849AFF001C3E24788BFE0A2BFB5D78C7E2E78B92F2DEC75BBD69EDED59C1FB25A46025B58C446176C5088D59D701DF7B7DE909AFABFF00E0923FB17C5FB6CFED4D67A6EA7A6AB780FC1E916B1E234118FB3CD1ABE2DEC08C1189E44C15380D0DBDC630D5C35388EBCB10F0F8449CA52949F939C9CDFC936DDBA2D1DCF9DAD93519D2FACE2744A304B7DA105056F5496BD5ED657BFEB0FF00C11D7E14EBDE01FD8E6D35EF1468B67A0EBDF11B55BDF174965029592DADAF26696D527C9FF5C2068F70C02B9084650D7D574515ED463CB1513C3C4579D6A92AB3DDBB85145154621451450014514500145145007CEBFF000528FF008273F84BFE0A33F02E6F0EEB49069FE25D352497C3FADF93BE4D3667037238EAF6F2ED512479E42AB0C3A232FF0028DFB68FECCDE25FD923E39788BC15E26D3E5D2F5BF0DDCFD9EF6D1DFCDF20300D1B2B71E64122323A49FC4AEA783915FD767EDB5FB5DF873F61BFD9ABC4BF123C4DFBEB6D120DB6760B288E6D5EF1CED82D233838691C805B042287761B5188FE52BF693F885AC7ED2FF16FC49E36F18DE2EA9E2BF135E49A96A57BB0801DFEEC48092563440888849089122F415E5E2EA53A75535F13DFD3CCF4308A73838743CAFE1BF8FEE7C59A82B6AD237DA20C450DCBAEEE7A7CC3232DC027919C72477FE98BFE09BDFF000550FD907C0BFB3E782FE19F84FE2143E0987C37A7ADB2DA78CADDB479A49492F34D2DC38FB234D34CF248DE5CC41790E001815FCE3C1F08AEBC1705BC5AF5ADE6973DCC70DCC292DA342E619E359A19591803B2489E391187CAC922B03B4827A4D0FC3D369C9B1A686F6CFEE86036BC241C743FCB767D3D2B87EB2A94DCE925DADFE4774B0B29D351933FB06D03C45A7F8B346B7D4B4BBEB3D4B4FBC4F320BAB599668665FEF2BA92AC3DC1AB99AFE483E14FC4EF1D7C01D6DB51F87FE30F13F82EF19834AFA1EA735819FDA41132EF1D3860C0F718AFADFE0D7FC1C9FF00B4BFC08BCB7B5F134FE18F899A5A901C6B7A58B4BD541FC29716A625DC47F14B1C84FB9AEDA19AD39BE592B338EA65B523AAD4FE8A2BF327FE0BC1FB01C9A9E9B3FC78F07D93497DA740B078D2CE34C8BAB445091EA181CEE8542C729E7F7211B2A206DD47F67CFF0083AA7E0BF8F5A1B5F889E11F197C37BC6FF5B730A0D734D87FEDA42A970DF85B11EF9C0AFBABE05FEDA7F063F6C1D24DBF813E21F827C6AB7D6C5A7D32DB508A4BC58997959AD1889A30413959231C7515BE229D1C5D2749BFF34CCA84EB616AAA96DBF147F36B7DA01B9D623743E5B11FBB7233F2F42A7D40FF00D98F3CD7E9F7FC1BDDFB7247E1C964F81BE22BC0BA7EA8F3EA5E0C9A472CB14C32D79A703D002CB24E8303E6FB40272514FCD7FF000554FD83EE3F60EF8F71A6976D3FFC2BAF14CCF7BE1AB90ECCB62EBCC9A748C79DD103F216C978594E59E3908F9CECBC4579E12D66C754D26E6EB4BBC86EA2D4F4FBD80EC96C2F2270C1E36E76B2C8AAC0FA9CF2071F1746B55C0E26D2E9BAF2EBFE68FADAD4A9E330F78ECF67D9FF005A33FA86CE2BF1FF00FE0E32FDAF26F8AFE33D27F673F0DDDC89A5E8F25BEBDE399A272BE74A4092C74E201F9B0196E9C11D4DA156C8703EA6F863FF000589F0EF88FF00E09AFA9FC5ED4A3B1FF84DBC3718D1AFFC3EB2797F6AD74AED8234524B0827389B72EFF2E212E4B185F1F8AFE25F1C6A1E21F136B1AC6B57B26A9E25F145ECBA9EA77F2FCAF712CAECF2C871C28058E02F0BB97030315ED67B9C285050C3BBCA6AFE88F2F23CA5CEB39D7568C1FDEFFAFD0CBD49D740B1B5D36C6091983AAC30DBC659E403808A8BCB1CB0C00A49608075AFE817FE095FFB178FD8ABF650D2B47D4AD6187C65E226FEDAF12B2E18C777228DB6C18120AC1184886D3B4B23B803CC35F9C5FF000411FD8EBFE1A27E3FDD7C52D76D567F08FC399E3FECB575CC77BAB155922EC41FB3A91391C15924B4604E081FB5DD2A78672EF674FEB13DDEDE9D5FCD93C418FF006953D84365BFE8BE4828A28AFAA3E6C28A28A0028A28A0028A28A0028CD15F9FBFF05FEFF82883FECA9FB3A27C3AF0A6A0D6FF00113E27C125AABDBBFEFF0048D2BEE5C5C8C729249930C47839695D4EE84D655AB46941CE5B22E9D373928A3F37FF00E0BB3FF05205FDB7FF00695FF845BC2D7CD75F0CBE19CD2DA58B412EE875AD4B263B8BE18E1D0730C2467E412BAB6D9C81E7BFF046CFF826EFFC3C27F6B7B5B7D76CDEE3E1DF83562D5FC56E432C7791EE3E469E1877B87460C383E4C539055B667E7AF06783AEBC57ADE9FE1BF0FE9F26A5ABEAD750E99A658DB2832DEDCCAC238E38C74F99C841DBA9E057F4D5FF0004D1FD8634BFF827E7ECABA2F826DDADEEF5FB82753F126A30E76EA3A8CAABE632E403E546AA9146303F771212371627C6C1D1957A9ED67D7FA48F52B555429FB386E7997FC15B7FE0933E1FFF0082827C305D4B45B7B1D1FE27786ACCC5A3DF1511C3A940A4B0B0B923FE591624C6FD6176247CACEADF8023C11AFF00C01F8A0D0DF69674DF107862FCC373A7EAF631DC0B59E22775BDC5BCAAD1CCA4646C756495095F981C57F5955F05FF00C167BFE091F1FEDB3E04BAF1D7C3EB5B5B3F8BDA1DA15584B2C30F8B6D906459CAE70A97007FA999B80708E4210F16D98E5EEA7EF68E92FCFF00E08B2FC7AA6FD9D5D63F91F3CFEC9FFF0004FAFD963FE0AEFF0003E5F11F8674AD47E0FF00C48D1B6C3E25D27C2FA91FB2D9DCBA9F2E58ED6E04B18B3976B347E508F3B5D0B6F8D88F1FFDA67FE0D8EF8B9E118A6B8F03EBDE19F895651F29067FB0F54727B08E667B638FEF35C2E7FBA3B7CAFF00B1578CFF00680FD96FF6B1D3EFBE1FFC3FF89507C42F0FC861D47C3B27866F7CEBCB572AD2DADE5B88F708250AADB880159525460551C7F4C9F0BBC5B7FE3CF86FA16B5AA681A8F85752D5AC61BABAD1EFDE37BAD324740CD048D1B32165248241EDD8F033C251A75D5AA47966BAAD3FE01A62AAD4C3CAF4A578BDBAFF00C13F942F8F9FB12FC44FD9A35936BE36F09F88BC23348E6243ACE9EF6B05CB8EA229F0619BEA8E457985FF00872E3469639AEED5E1F25C3ACA060290721838C8C8FAE6BFB20D5F45B3F106977163A85ADBDF595D218A7B7B88C4B14C87AAB2B64303E8457C8DFB447FC10A7F675F8FF24D756FE139BE1FEAD37FCBE784671A7463EB6A55ED0E7B9F2771F5AD2A65F38FC0EFEA4D3CCA0F4A8ADE9FE47F3D975FB7FF00C60D47E11CFE05D53E216BDE2CF05CD2C370349F114ABAAADB3C5831B5B5C4E1E6B565E40F25D1486652195994EE7843C7567E24D11BE68CC5788A8F9E1A36E8AFD700E783E8475C026BEF0FDA8FFE0D6DF1C6831DDDF7C39F12786FC6D085675B4B98CE85AA1F44520BDB4AD8EACED08F6AFCE4FDA3FF00655F8ADFB0BF8A63D3FC69E15F10785E5BE6916DEDF54B2DB6F7BE5ED12B413A1682E02EF8C39898E3CC8F3D467C9C7606756DCEAD25B3E9F79EB607194E1A41A69FF5B1D4E83E2EB9D275A96DE66668A274FB420276CA30EA926DEEEAAEF83D7E623F8DABB8D17C117BF1C7C6FA0F847C316726A1E20F195C45656D69BC2990C8E6340CDD153392CE785524B602D78CFC30F1C7FC279A5C8B359CD1EABA520DD842AB731B1C0C3100160474FBDF303CE6BF493FE0DDDD67E1BDEFEDA371FF00090EE6F1E1D1664F06C8CAAB6EFF007DAF00E73F69F2376CC0FF00542E813C0AF1E3972AB8A8C27EEBBD9FE7FF000DE67A7531CE961E538EABA7F5F99FAF3FB1DFECC1A27EC71FB397863E1E682AAF6FA0DB62E6E826D6D42E9C97B8B86192419256660327682AA38502BD368A2BF44845462A31D91F0129393E67B8514515448514514005145140051451401C77ED03F1D7C37FB32FC17F1278FBC5D7BF60F0EF85EC9AF6EE400191C0C048A35246E96472B1A2672CEEAA3935FCBFFED63FB4EF89BF6BFF008FDE26F89DE2A27FB5BC493E2DAD964CC5A5DA2FC905AC3C0F9228C05DD81BD8BC87E62C4FF445FF000538FF00827D7FC3C6FE04D9F835BC6DAB7837FB37515D522305B25CD9DECAA8C8AB731651E4550EC542C8A0310C4395503E3CF82DFF0006BD784F4DBF4BCF88FF0013B5DF106C20A69FE1FD3E2D2E05F54792633BC8A4704A889B93CE4927CEC561EA56A8A3F657E2CEDC3568528B97DA7F91E7BFF06D8FFC13A86ADACDC7ED11E2BB0DD6F67E7699E0A8665237CBCC577A801E8A37DBC7E99B8C8C8535FB2958BF0E7E1DE8BF093C05A3F863C39A7C3A5E83A0DA47636169164AC10C6A155724924E072CC492724924935B55D94692A70E547356A8EA4B998514515A998514514005145140106A9A9DB689A6DC5EDE5C41676767134D3CF3C8238E18D41667663C2A800924F000AFE6C7FE0A53FB4E5E7FC1477F6B5D63C6D7725E5BF822C5BFB1BC2362EA6393FB3A373894A100AC970E5E662C03289238CE44608FD4DFF82F77ED9BFF000ACBE0FDAFC21D12EBCBD6FC7F6ED3EB8C8F86B4D18315643CF4B9756888E418A3B8538DCA6BF1EB4E756BA975295545A4398E103F889C7F881F53ED5F259F66CE33FAAD2DFABFD0FAAC8B2D4E3F59ABF24519BC3169A6F878E9F670FD94D9A1B9468C67C9763B10B7FB0776D249190F8EAE738DE1DD6B58F0278FEC75EF0F5CDC68DAE68F7915F59DC40DFBDB0BC898491BA83C1E403C8C36DE410D8AFD98FF00822CFF00C13DF4AB9FD98FC45E36F885A25BEA537C5FD39F4C86CEE4360684E739CF0C3ED2C1640C0FFAB8EDD94839AFCE9FF82847EC51AD7EC2FF00B42CDE19BA696EB4B667D43C37AA4AA3FE26D60495DACC0051345BB64800041C36D092479F39E0EB51A31C44B697DEBB7DFF0099E8C71B4AB569D08EEBF1EFF77E47EDD7FC1397F6E1D27F6F8FD99F4BF18DAADBD9EBD6A7FB3FC47A6459C69BA82282EAB924F94E19648C924EC91413BD5C0F78AFE76FFE099BFB72EA5FB06FED5D6BAECC97737817C50174FF00175A45F32C56E0931DD851C992DD999D4056251A78C0064057FA1CD2756B5D7B4BB6BEB1B9B7BCB2BC8967B7B882412453C6C032BA32E432B020823820E6BEBB2DC62C4524DFC4B7FF003F99F2998E0FEAF56CBE17B7F97C8B1451457A079E1451450014514500145145001451450014514500145145001451450015CCFC65F8B9A1FC05F855AFF8CBC49742CB43F0DD9497F7927058A20CEC4048DD239C2A20E599954724574D5F92BFF05FDFDB59FC5BE36D3FE09F87EE9BFB2FC3F247AAF8A6446216E2E8A6FB6B424632B1AB0998720BB43C86888AE1CC71B1C2D0755EFD3CDF43B72FC1CB155D528FCFC91F06FED2BF1C35EFDA97E36EB9E3AF1048A9AB78AAECDCF90B26F5D3E0002C5027032B144A880E06E2A588DCCC4F71FB057ECA72FEDB1FB5A7873E1FAC2FFF0008C69AA754F11CF1E5441A7C4543A6EC822494B242A412419CBE08438F11D19FED325E6AB237EE61568E227E5040FBC73D073C7E0C7BF1FBA1FF00045CFD8A7FE193BF658875AD5ED6487C69F123CAD6355F350A4B696FB58DA5A153CA948E469194F2B2DC4AB921571F0B9360E58BC5B955D56EFF00AF367DA66D8A584C37253D1ECBFAF247D77A66996DA2E9D6F67676F0DA5A5AC6B0C1043188E3851400A8AA3855000000E0015E09FF000527FD84F4CFDBEFF66CD47C2ED25BE9BE2CD3F37FE17D62407FE2597EA3E50E54126093FD5CAB83953B80DE88CBF41515FA254A719C5C24B467C0D3A928494E2F547F2A37D6DE22F877F11AF3C0FF00103C37AB7817C6FA49952E74DD5EDCDABCA91B1569612DF2CF16E1812C25E370C195994E4FED5FFC1BE9F18BC7FE30FD9B2FBC2DE27D135C93C23E1931B7847C45776ED1DBDEDABB3892CE37603CD481D7E4742CA11FCBF97CA50DF73F8F7E19F86FE2AE910E9FE28F0FE89E24D3EDEE23BC8ADB54B18AF218E78CE63955245650EA790C0641E86B6A38D62455550AAA3000E80579785CA561EBFB5A737CBDBFE09EA62B35788A3ECE7057EFFF00007514515EC1E4051451400514514005145140051451400514514005145140051451401E3BFB767ED69A77EC5DFB37EB5E34BC586E752502C744B1909C6A3A8481BC98B0082546D691F072238A423918AFE73BC7BE33D4BC79E22BEBED42FE6BED67C497B25E5DDECB869AE5E462F248DEECC59CF18C93C0AFDF1FF8297FFC13521FF8286F86B4255F1B6AFE13D5BC2EB71FD9E1604BAD3A533ECDED3439473262355575906C0CFF002B6E22BE2BFD9FBFE0DC8F17DDF8FA4BEF899E38D074CD1ECDCC7043E1CF32F2EAEE3E413BE78E3480918C1292FBAF39AF91CF3078CC4E2231846F05B6AB7EAD9F59926330786C3C9CE569BDF47B744BBFFC1F23CB7FE08EBFB10AFED3BFB45D8EA9A95AAB7817E1BC91DFEA31BAAB45A85D60FD9AD0839DC370F31C104148F69C6F06BF720702BCD7F656FD933C13FB1AFC301E13F0369F359E9F25CBDF5DCD713B5C5D6A172EAAAF3CAEDD5884518002A8501554002BD2ABDCCAB2F584A1C8FE27AB7E7FF00F1734C77D6AB73AF85689797FC10A28A2BD23CD0A28A2800A28A2800A28A2803FFFD9, NULL, 1, 1, 1, 0)
INSERT [dbo].[Producto] ([id], [descripcion], [imagen1], [imagen2], [idTipoProducto], [stock], [stockMinimo], [baja]) VALUES (3, N'Mesa', 0xFFD8FFE000104A46494600010101006000600000FFED003650686F746F73686F7020332E30003842494D04040000000000191C026700145A4138462D63325A63473243556D6B765448736500FFE2021C4943435F50524F46494C450001010000020C6C636D73021000006D6E74725247422058595A2007DC00010019000300290039616373704150504C0000000000000000000000000000000000000000000000000000F6D6000100000000D32D6C636D7300000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000A64657363000000FC0000005E637072740000015C0000000B777470740000016800000014626B70740000017C000000147258595A00000190000000146758595A000001A4000000146258595A000001B80000001472545243000001CC0000004067545243000001CC0000004062545243000001CC0000004064657363000000000000000363320000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000074657874000000004642000058595A20000000000000F6D6000100000000D32D58595A20000000000000031600000333000002A458595A200000000000006FA2000038F50000039058595A2000000000000062990000B785000018DA58595A2000000000000024A000000F840000B6CF63757276000000000000001A000000CB01C903630592086B0BF6103F15511B3421F1299032183B92460551775DED6B707A0589B19A7CAC69BF7DD3C3E930FFFFFFDB0043000201010201010202020202020202030503030303030604040305070607070706070708090B0908080A0807070A0D0A0A0B0C0C0C0C07090E0F0D0C0E0B0C0C0CFFDB004301020202030303060303060C0807080C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0CFFC00011080095009603012200021101031101FFC4001F0000010501010101010100000000000000000102030405060708090A0BFFC400B5100002010303020403050504040000017D01020300041105122131410613516107227114328191A1082342B1C11552D1F02433627282090A161718191A25262728292A3435363738393A434445464748494A535455565758595A636465666768696A737475767778797A838485868788898A92939495969798999AA2A3A4A5A6A7A8A9AAB2B3B4B5B6B7B8B9BAC2C3C4C5C6C7C8C9CAD2D3D4D5D6D7D8D9DAE1E2E3E4E5E6E7E8E9EAF1F2F3F4F5F6F7F8F9FAFFC4001F0100030101010101010101010000000000000102030405060708090A0BFFC400B51100020102040403040705040400010277000102031104052131061241510761711322328108144291A1B1C109233352F0156272D10A162434E125F11718191A262728292A35363738393A434445464748494A535455565758595A636465666768696A737475767778797A82838485868788898A92939495969798999AA2A3A4A5A6A7A8A9AAB2B3B4B5B6B7B8B9BAC2C3C4C5C6C7C8C9CAD2D3D4D5D6D7D8D9DAE2E3E4E5E6E7E8E9EAF2F3F4F5F6F7F8F9FAFFDA000C03010002110311003F00F48861CFF9EB5D07832DFF00E26BB7FD96FE558966BB8FE35D2F83A2FF0089CC6BFDE57FFD04D774AFB1F706D451E07418AB1126E614F16841FF0039AB3676A7CCEBDEAB96C67CC4D6D0EEFBB5A961A3497084EDF9554B127A281C924FA573FF00123E24E83F02FC0375E26F11DC3C3636C4451451287B8BD9DB252089491BA46DA4F2405556662AAACC3E15F899F1F7E24FEDC1AE5C697636AD63E1A5919534B8653FD9D1856C7EFCFCA6EDC10012F88D5B2155181066F27254E0AF27D3F57D91D14B0FCD17526D462B76FF0024BAB3EAEF89DFB7DFC2BF843E742356B8F15DF5B92AF6FE1F892E91587506E1D92DF20F50252C3FBB5E07E39FF82BF6B1E2CB5BAD3FC2BF0D7419EC6E11A093FB5E79F5613291821E28561550476F31BEBDEAB7C39FD81343804771E24B8975DBAE33102560403A0031DBD5429AF7BF06FC16D0FC2D1C634DD0F4EB5DA31BD600D263FDF6CB7EB5D0B2FAAD7EF276F24BF57FE4632C760E1A53A6E6FBC9DBF05FAB3E68F0DFED81FB484DE1C5B3F0DE9FA3E8B60ACF22A41A6433312CC59999EEA4B8958927AC8E5B1819C002B6F41F899FB5E78DF4D9A27D7FC3535B5D46F0CB67A9E9DA3A473C4E30C8CAD6DB594A9C1539C8241AFA962F86A75197CCD926DEDC54BA77C39FB34F78238E3DD1CC0332A2AB126343F311C9EBC6E2719E319A7FD9B4DC7954A5F7FF009227FB5A7CD75461FF0080DCF92F4FF8D7FB557ECD7E168F4BB1F00FC397F0EE9A0F936DA6E9DA72DAC2A58B31586C6E2165C9249C275273573C37FF00059DD53C2B7315AFC46F85371A7EF3B4DCE9D3CB6ACDEE905CA156FF00BFE057D4D3F81A4C10CBB57D3AE6B9BF15FC0FF0EF8B2078754D1ACEE0382ACCABE5B91FEF2E09FC734BFB2656FDD556BD6CC3FB5A8CBF8F417FDBADAFD6C58F821FB6EFC28FDA4AE61B3F0FF89A2B2D6AE0ED8F49D5D3EC379237F7630C7CB99BDA27735E95A8694F6CE5595BE538208E95F0AFED01FF0004A6D23C4B617177E0BBB5B1BAE5C59481155CF5E00DB1B73D8843FED9AE6FF666FDBFFC71FB2278C2D7C0BF197FB4B56F0AEFFB3C3A8DD2BCD7DA40070595C8DF342991BE270644520A12BB51B1AB1AD87D6BABC7F996DF35D3F234861F0F894DE0E5AAFB2F7F93D9FA6E7DF7756DB43735526870B8E306B62736F7D650DD59CF0DD5ADDC4B3413C2E1E396361B95D587054820823820D66CCBB47F9E6AFCCE0F233EEA0CFE1C62997F0E07BD59B84C8FCC513C1E63E3FA52B08C930B13D08A2B9DF899FB447823E0CEA90E9FAF6ACEB7F227986DED6DDEEA4857381BC203B09C1C0383C6718C64AB5166329A4C6D8001C7D6BA8F062675DB71D061B3C7FB06B99B11FBD1C0AE9FC123FE27F6BCE793C7FC04D4F53D294B43AB65018E3F955BD3A1124C31B7155A44396E3DEAE68C85EE54FBD5F2983933E36FDB17535FDA07F6DEB5F01EA5AA2E97E13F02698F797E7CCD84A8B417D74E982099244304036FCC80332F24E7CF3F669FDBDFC25F197C32DE11D37498FC0FE2AD32E5EDDF4D629B2E95798C230C296542A36AF000E00CED0DFF008285F877EC9FB41FC6ED62DE1B792E747D025D5A312C7B91DA1D160936B74254ED2080464135F06F80BC5FA27C57F0378B7C5163A4EADA2DD7996D2EA32194DD5B5ADF04956292191479D16EC0C16042B7CBBF2577F1E0F16E9CE4D2EAEFE76DBEE3BB31A719AA345CADEE45A5EBAB7EB7DD3E9B1FA851789B5F867F92F1D7FCFF00BD5D1687E28F13305DBAA48ABF4FFEBD79DFEC1B15FF00C78F06FC3FB4D53566B8BAD7208A297532826329C1024232BBF381CE4139CE735F49691E08F85D6BAADE69EFF18BC2F15F69F73259DC5ACE61B39A39A3728E8566994E559587191C57D13C4689B6780F0EF64AE71F26BBE2E9748B9167AC7FA6794DE479A76C664C7CBB88C90B9C648071E86B91F075E7C461E26D4ED6FA46D3F4E8F50179F6D91D33759030B1A2B37381CB36DC1E991C1FA32F7E107827C35711C7A978FAD6C5A6884D189E4B580CB1B670EBBA6E54E0E08C838AAF2786FE13DAA37DA3E24694CD9E08D674F8C7E397359CAA2BDEE0A9CADA23CE58EB170A77EB174C7D3CDFFEB542DA7EA25FF797D7327FC0EBD0B5DB1F859E13F0D5BEB3A87C40B1B3D26F5DE2B6BD9756B4F22EDD490C91300448CB83909923078AC1F0D7897E1CFC4EF0FF0089EEBC13E26BDF115C785BECBF6B3F6778A18CCEECA8373C49BF2239394240C0CF519DA35A2DF2DF531961E5CAE56D175394B982F2D46EFB55C7CBCF321AE17E337C3CF0DFC78F821E2FFF0084B961B13A6D95C0D3B54C6E9ADEEE24DD6D231EA479844781D52465CE0F1EA77C3CFB7C6DEDD71D6B97D4BC32BE20F81FE29B768D8A4D712AB6074FDEA01FAE07E3555BDEA72E6D5599584BC6B41C1D9DD6BF339BFF00823C7C51BEF887FB1BC9A6EA0F2487C19AC4BA559BBE4FFA2B4515C46B93D42199D07A2A28ED5F4A5D1C67DFFC2BE5BFF823CBF95F027C6D0701A0F1046B91DFFD0ADF9FC457D3D72F906BE5F2FA8E7878C99F419A414717512EE4322E41FAD5D8E1C5DAF1DEAB470B4CDB4579F68FFB65F81E3F8B3E33F09F8926BAF04EB1E0B334B30D6F64316A56D1124CF6CC189903461640806F6571B4360E37A95A14DA5376BE8BD4F365351F88F923E396856B6A3C6DA92C31ADF4BF11F58B469B1F37948B13AA67D0348E7F1A2B1FE37FED47F09EF74AF11D9D8EB5E28D5350BEF1B5FEBCAD6DA188ED92DEE628C05CC9287661E5A1CED51F3302380494BFB73050F75D4479352B53E6DFFAB9F69588F987A66BA8F0471E24B3F5F300FCC62B93B293F7EBFE35D57825CFFC24B63FED4E83F323FC6B63E89EC76CE9891BEBD2AD68E9FBD5F6351B8C5C367D78AB1A4AFEFF00AD68729F24FED1BE06B5F1CFC7DFDA1AC6EA30C2E3E196B6F1FA964F0DEE07F0DB5F9C9FF04BDF035C6B1FB3AFC5ED421B7B6B8B7D1753F0F5C48ADBBED01C5C4D227967EE73E4B290FB40DC1B77CA55BF4FFE30F8857C23FB5CFC45B8F31775C782B564008076FF00C53AFC73C10700F35F3EFECC5ADFC3FD1BC36DA5C3E2CF0EF822DFE20690A34BD424B52CD79E4421ED1EF44656398D94970D11208F315150852013C581A2AA54943ADE56FC0ACDB15EC674AB3FE48EBF79EC3FB00F8DED7E267C44F877AD5AC06DE1D5AF52E5636408C819DC804066008E8406619EE7A9F75F897FB027C33F177FC13E3F68CF1FEADE1CB7BDF1B69FE30D627B1D57CE96396D145CC184DAAC1187CD21F994FF00AC3ED8F9B7FE0925E64F73F087ED56DF63BA33422E2D8C6D19B6937B878CAB1254A9C82A4E474AFD1CBD861BBFD807F688D3FF0076A8FE29D441DC3E505EE20049F607A9EC2BD7AB47969C2DB5D7E87156C4CFDA3E576DB6F53E43F871FB1EF847F6B2FDBE7E09F87FC6D66F7BE1F7F86B6DE7DB24CD6EF2948AF1D007521800E14E075C62BDD3C2DFF045EF80979E2DF8FF006F75E12BAB88FC2724634151AA5CA9B156D3566FE1907987CD627E7DDC003A641F3AF00EBD27847FE0A41F0164B5DC1E4F09246A1782C3ECB78C057D6FF077C6736B5E28FDAF9831924B59E028A5F32206D197193D38ED8EB838ED5C78A85A6EDD92DFADD7E8188AD5972B8C9DAC9FFE4D63F2FF00E137C1CD0BC7DF0AFF00658F0CEBB610DFE8579F1267B3BCB672CA93C525EB864254860181C7CA41E6BEADF1FF00ECF7E17F811FB40FED2BA4F84346B1F0FE836EBE153069F67088ADEDC9B542FB40FEF33B3B1EA5DD89C926BE74FD992F85F7C3CFD962E9A64561F14D719243396D47185E0F233BB9C00149CE700FDA9FB445B1B9F8E1FB46BB0DACEBE1B1C1CA9DB0C6323F2AECA74D3C4C5AEC5632A49464AFA6BFFA5A3E71B8B5FF00476E39C5755FB217812C7E2078CECECB52845C5B47ABDC4A51B804E0A648EFF2B9EBF5AC2D42CCC16CDCF63DAB7FF655BB6D1D353D4964DBFD9B773DC74FBDFBCDB8F6E48FCABD5947DD6BC99E453A9AAB773E70FF00824DCCA3E0EF8ACAF3E66A90487DF3670D7D305B2FCFCBC8E6BE55FF008245DEB5DFC1AF1716EA35685481CE3FD0E1AFA8E7981660DC8AF8CCA636C2457AFE6CFB3CDBFDEEA7AFE87CC7F16BE3E7C70F897AA6A1FF000ADFC17E20F0C787B45F3EC849A95B4706ADE21D4195E3B748124C88ED966F2DA59411889656F3508007C8BFB76FECB3F123C11E1BD3BE22789A6D635459AE5B45D4358D46EDEE2EAFAEA1D8A6E8ABAAB2DA4CE644B73C968AD924609E6AA9FD53FB430FBBB87205709FB79FC0AD1FF687F80FA869DAA43FE99A7CC93E9F751DA433DD5B39750E909907C8645014952A4F009C641E7CCB2D96228CA376E5BA5B2B9E062709ED22F577E9D8FC51B7F18C8CDFE8B248F3468A2799D1583391D0023A0C019C678F7A2B613E0D6BDA778AB50D1A7D22FA1D5ACDDBED16A62293445480C1948C8C16C72075A2BF35A951A93B267C5E22388F68F913B1FB2962FF00BC4E7FFAD5D6784B31EBFA7B7613C7CE3B6E15F355E7ED237BE21F1B6ADE1CF0B7F65BEB1A0B247742ED2468D257884B1C590546594AF2090BB867B8AF15D1FF00E0A41F187C477CB2E93A2E87A62DBC83CA1259B4C242A3E624B636856DA32783CF3C57EB73C4538BB5F63F4B516F43F4FEF0137727BF22A4D324D9703EA335E51F017E3FDC7C62B591EEE18E199AD21BAF2D3F80B0F9D7A9CED6E2BD334895E4997BEE3C575C1A92BA39A54DC5F2C8F93BF6D5B986C3F6AFD452E2F1AC2DB54D1A6B4B8B955CB5B432E9324523819E76A866F7E95E6FA3FC40D67E08FC21D1F4CF0BDA5C6BBE37BEB4FB2D8ADE59DB5E6913DF369B2DC4C44933AC4CAB6F0CF8720856DA411C32F69FF0515D2754D6BF69B6B0D274FBFD4EF2EFC3F194B7B4B592E653BE0BA8776C8D59F683D4807F3AF8A6C209BE1D7883C33FDB1756F6F79A0E9660B896DB53170D13C3A4C9188922F315A276CB6E4745752EA4A91C1E7C3C67ECEAB827A37AAE9B7F577A1EC4A31E6A1CC934D453BABAB5DDF4FEAF73F407F61AFDA2B43FDA2BF694F04F882CE6906B9A96A36F16B48F6A60DFA942EC976CBD415320765058B15EE40E3EC5F1C783BC55A3693F117C0ADE31F0BE8763E3EBB9F5DB8B49E0BBB89921B99D9217DCB6A4264C006D57FBC87B727F05FF0064EF18F8A3E1F6BF63AD786FED93DF5AF896E278A449A48E28E617814A00AC70CE4E4B000F4DA061F77DF9E31F83FF00133E22786FC1BE2486FF00C3BE1386E61BDD527B2B4F1659F85EFAE6D6C64B3086F6E5CBDBBCCF71777ADE580C170D860AA891FBD87C4431515F58D2D6BDBCADAEBF7FA9F178AC47B1C67B1A492BADAD7B2BDF45E5D3B687D0FF00193F662F885A8FC61F87DE34F01F8CFC37A1EB1E03D1134CB7BF9ED9EE1659556481E548E48CA952ACE3122E41CF00E0D33C31F0DBF696F06EA5E3AD42CFE30783E0BCF88E21FEDF71E1F89D2EFCA83C84DA861DB1E23F97F76AB9EA7279AF31F09FFC1412C752F04788F4B9FC5DE1ED2750BBD1E768EFAEFC5B6D79A85B4CD68AAA96EB676C804ABB46E660364A1C1E770AEC7C0BFB7BF80754D234396FBC6BE078D0FEEAFED6E756B893512AB19F9C36230ADCABB131CC7E47E3E6057B2B61F0526DBD7CF5FD02388C546D0B7DF15EBD7CFA19DE19FD8D3C47F0D3E0BFC36D221F1869761A87C38F135C789ADB538EC249A177561222E183728D2293B9581CA8C7383F42786749D63C41E07F8B5E32D67C47A7F89B51F115CE9D637F716F0496EEB7766D146C86368224C796F08CC608241E7766BE4FF8B7FB5C783FE34A5FE8FE17F1ACBA2DD5EA4563F6C8BC6B6B61A65B4722B869A39A48B292961B7EF2B1DC9C02540FA2BF655F857AA78AFF00E09E73786A2F1458EA178D3EB3A6EA3A847A89BFCDC0B8960867370A773AED48D8381965C1C0AE8A785C34A5195396BA27E5E5B9E7E699857A3879B9A7D5FC3BBDEC9F9BE9E57671DADD9DD5E5EDAD8C31B7DA351B94B2B7571B049339015013C649238AB763E04D73E12FC03F1B5DEA0B1DAADD473A5ADC2C80A3B9BA555DB9C139C120818239E95CB7FC1487C43A97C05FD9B3E16E85617525FDA5B3A5B5C2C57B716BE64B671C122BA4F6F247329690EE2432B6027A64FC796BFB695E5C78922F0F49E1792DF47D6AF0335C5EF8B757D464B611899E36093CED1171E638276004B138ACAB4D538B955834B5D6FB7AAF3F53CFCB6B4ABE2A9D1A1523CD78B7169EBD5F2B5DBCD2BB3D13FE08F57424F841E38FF675B87FF48E1AFA92E2F3F7A7EB5F33FF00C12A3E14F8BFE18FECFDAB6ABE20D1AE2C34FF00174F6BAC6952F991CBE75A35A46164708CC62DD8C85942B60838C1AF7BF11EA4D6DA55C4AAD86D84AE3BD7C4E53CB3C3C545A7BEDEA7EA19CD3943173E74D7AA392F89DFB4BC7E01D452C74DD35B58D4A47F2E28CEF44958150CA8550862B91B9999234CE1A453C561F86FF6BFD63E2D8F0D69FAD7866D34FB4F185A2EAB6D756B3481AC7CB2CC61B98DC131BFC98196C1278CD723F1AFC4BA4FC29F835E29BEF1B4D73AC587F6ADD5F6910C573776F6D1425D2280C9F65DCE0089618CBEC2ED938DA24661E95F0B3C69F047C33E1FD3FC33AD6ADE0C935FD52D6DF5096DF58B08EC1D9678C34223866FF549B4AED8C3330CE5CB48599BD3962A307284295D46EAFAF4D2F7E9AB5A68BA753C154672E59BA966ECEDA6CF5B5BAE89ABEFD7A58F1FFDA1B56D2E0F8837DAD28B35BFB893CA9275DBE6146DCE10B7DE2A08E01A2BE97B8FD923E15F8811AE8F83747F2656DC1ECA21E5C8DCFF0074638F5F7A2BCDFAC4B78DBFAF91EA7EE7FBDF72FF0033F3D3E03EB1F60FDA3BE326F9A386587C41633282CAA086B5E3AF7C2F5159DE26F1469F65F11759B3B5F3956DE69627DF808D28998663C13F290571EE3A0AF5FF00869FB3E782FC13E3CF1AF8FF00C61E36BCB8B7F168B0BA8743F0DD8299D8410F9786B9B8F97CD6DC095488A8006242491547C3BFB71D8F8011EFFE1B7C39F08FC3ED42F333B6B1347FDB5AF6F6273FE9772088F27219123DA08E315EC61B84F1D89A9CF25CB196AAFBF4E9FE763E531DC6397E1538DF99C5B5E57D74BD9F67B267BE7EC55E02F11F82F444F1478AAD57C1BE17367243FDA5E219574D89899014DAB290EC08070CAA57DF9AA7FB55FF00C145AD7E1543630FC39BFB5D6BECB3799AADECBA54A616832A07D98C9B77B03BB7E508C3215CF35F20FC4AF8D5E20F8A1A97DBFC49ADEA5AE6A19DE92DF4ED2B46A41C8404E141C9F95703BE2B9ED47575D7F419638F734D0BA322755C1F91F8CE49DACC401D4E2BEBA8F0BD2C2D1E693E66BBEDF71E1653C78B199AD1A5282F6729462FD1BB5FAED7BFE879A7ED09FF000502F8B5F1FB5BD4349F19F8B2F9A3B49E4B3BBD36C9BEC9607CB62B868D30240A7705F34B9193823273D37C074F0BF8FF00F67FBA5F116A8BA2DD43E24B6B5B0D42E67966B4B679227989FB336600EC2D994B168D9C0D819B2CAFE0FA8FC22F13FC52FDA02C3C37E17D26EBC41AF789E285AD6CEC63DEF3CAAA62998F40AA248657676215572CC540247ED0FF00C1323FE097FA1FEC6BE078F54F175C5A78ABC7F7B3477BF2C61F4FF0F4A8AEAA2D4B0DCF28123069CE3B04550BBDFE7E52A6E7C9557328CB549DAEAFAABF4BAD3D1B47EB389CC23470AE9C1F2CF55A2BEA9DB55757B357D5EFAD9DAC78DFEC47FF000449D07C27E37D3FC55F103C41E25F1269725C8BC8FC373ABE996D713BB06F3AE63490B28CE5BCA1B5B3B771C028DFA2BF0ABF638F839E1FF825F122F34FF87FE1BB1D434793C9B59C23B496D0B2EEC0258B30C83C1C9FD2ACEDB77B889954E15C1EBC75A946A7AA58695AFE9B62EB6FA7EBF286B905158CC00C7520900FB633C7358E21426EF18A8ABECAFA796BA9F1918CD3E7BFBDD5E89BD6EF6B1F3DBAF893E044DA3EB3FF000A4AC6F2DF4B120B6D3ED752935686EEDE0B6510BE6293F8F0A8AA407185F91BE6DBBDF0B7F6C4F0DDF78E756B8D63E09D8E92DAC59C02694D95E5AC7A79DA50451C72056DE5BCA6765254B36E2C36135E89E32F038F10F8761B68E5B746863DAA650FF7BB91B594FF003AF09F88DFB3A7C4CD491A2D2751F0B4513670F71AA5E16C67FBBE5F3FF7DFE55E1D5FAE5DA6DCBB5DDADE9E9FAB3BA9C70EECF9795F5B75F5F5FD0D8F8643E1BFC71B7F0F6992693AF457771AF79573A2F8823B97374A92A977C3BB23C47970F8C1DA4F5C13EE5F117E1968BF053C53F107C35E0BD2AC3C2FE1BD6ADF4FB8B8D3B4D8560B79A57B6892562AA3AB2920FB1C57C9FF000F7F647F893E18BE86F24D6B4987C450DCF9E350B7B89B6BA0C158407DC54060AD8C90C40C8E057ACCFE18F897E23D7B5DD5FC4BAAC6DA8EA31DA46648582C6FE4A84C845C28255573C0C9C9EF5D983752293A8F5F4B158AA71ABD7DDECDDFB7467CC1FB4FFEC3377E0FD2352D7BC056B7D7BA6C8C93DEE87192EF64137EE96DD4F2EA43F2832CA146DC8F957E317963F1D7C4DF0868D69731EFD6F568B4F4657C9CCA1D0631DF2457EC5E9FA7DF5B59AACD70D2C8A416EA32457CD1FB487FC139B4EF1CFC44D37E26F8016CF41F1B68B7C750BBB11044967AEC83710F92079371B8825D48473F7F04992BA732C557960A74A0B99B5F3FF8270E4F90E0A19B52C5CE5C8A2D68969F9AB2D7CFE47BA788254F0968663D1992182C6110D944AFB562DA3CB897D40CED1E98F6AF98FC19F10FC55F1FBF6E3B7F873A4EA4B67E1BB3595F5695A0599C436CA44F2B3B6599DA6658C1C8C96524F5355ADFF6CDFEC9F0E5DE8FAED8DC58F88B4BBC8FEDF6172FE432244C2494E5BEEE1509C1E4F180D95075BFE08DDA10F14789BE2778EA6905C3B3DB68504E3F89B06E6EB1ECCCD6E7EAB5F8D64184C47D7A114DC7DED6CDAD16AD3FB8FEA2E2CC7613FB12B567052B4524DA4F595945A6FB5DFDC7ACFED0DFB1F78C7588F4CBCF05F8834F5BAD15A36B68AEA02726331B21C12C3868C305C601E9B4018F90DBF62FF18E9BF1B17C61F119BCCBBBAF1742AF1CB10692EEDE39079521F2CB2471B2A16DBBBE50DB78AFD35BBBF6B694B7F0E7031DAB13E21EB8F2F8723B3568D6E356B88EC2DA5750C2DDE438F3067BA8C91EF815FB053C456A70A90567ED1A6DB5AF7B732D6D749DB5D51FCD552850AB52139DD382B2B3D3B5F95E97577AA6B7B1F22FC08F87FA7EA7FB4078BA1B6B8BAB2B78F4D825DB6B3B44A59AEEEC1385207441F9515D67C7FF0089DE11FD96BE2E0D3740D09750D5AEB4B89F54B992E489235F36530A33747762D339E32015ECC002B870B2A6A169EEB43D0C4529A9DD6CD27F269347CE7AFA69B2A3DAE99A8E95AE58E9B773DBA6A3693078E49011248BBC12B9533638246548ED5E1FE34B6FEC46BE8D76A49A7EA12302ADB032CC1675FC0195803DF6D5BFF826E78D2D7E20FC08F18E9CDA7AD92786F59B6BB81412C248AE207462EC7D1ADD7A0273201CF5AA1FB58696FA36AB14D66DB7FB4AC8BB007003C2E3AF4EA26FFC77DABF55E1DC639E5742AC9DDA8A4DFA69F8B48FC2B8C32F51CDB15452D252E65E57B4BF04E472FA878C239A68D61709260B8213E6C0E4FD7D3A5769FB2BFECFDE3AFDAE7C6F2697E11B1F2A38C2497FAADDA34763A58C9F9A460090CD83B6350CEC01C0C0623B4FF8275FFC1343C4DFB5BC56BE24F137DB7C2DF0F239770D4828179AEE18EE4B3561F733C19D814073B448CA547EB87C2DF85BE1AF827E07B1F0CF84349B3D0B41B1CF956F067E673F7A4763969256232CEE4B37735E66699CB9274A1ABDBD0F6B8778654397113D367E6FFC8F39FD9BFF00640F06FECA16170BE1DB159F5AD42211EA3ADDC44BF6CBC4F31A4F254E3F7502B92C21538CF2C5DF2C7D420E84ED2DC75C83BBE95A1A8AE6E57E5F9563E33D8F350C03ECB133CD26E5C6599D8ED1F81E2BE5EF7D59FA2559CAA49CE5AB7B94EFE392DEC1763087710BBB1F7739E78A926BCB84555591D768E0679C7D2A0DFF006BD463590AEC5C90A7AFA03EB8C7F9E952CA16E03ED7C375C8EA450668925D4DEED163963019463706C67B556936C9FC414F519EB9A5580470B1DCB85C724F5FF0AAF96C9CAE578CF1C0CFF9F4ACB951412CCD14FB82EFDBC839E454371A84B3EEDF23FA0FE10DF5AB1F660EB8F30FCC38CD519613348EACB195CE339196EB9FF3F5A7B17CAEFA957CFF00B3DBB79D221C705871FD4FF3ACFBA91628A458CFCADDC1C63278F6EF57B54B66B38372B4BB58FF00773FAD67EA102DED8BCCA17CE61865E1B3CF5FD2A646B1DCF1EFDAB3F622F0CFED8FE03BA8AE66FEC1F1759C2D1D8EBB126E3B769021B95FF96B173EA1D3AA900B2B7CFF00FB15F8CFC45FF04F5D22E3E1DF8F74DFECFB89B509EF4DD42FE6C3781D822CD1B8E1E3648D083C15E430560547DB3A4CB343048B865F9FF853A573BF14BE16685F1BBC232687E27B36BAB72C65B7B84212E2C64C63CC89F0769F518DA470C08AF35E069AADF5882F7BF3BF7FF33DA8E7188FAABC0D49374EE9D9F4B76F2D6F6FB8E93C2FF12F4DF1AD9C135BCF1CB1CCA19590E430A87C41A643AF7C5CF0DDAA5D4465D26DEE35278B767311023CB0F690C2CBF4635F1278A34EF1C7EC1FE328C5C48DAC784AF24DB697C80F91375210F5F265C67E43C1C12A480709E32FDACB5782D7C47E26F0CCC3CC788C0D35E5C08FC94BC845B3411A282F2BAC922CA3A2A98012F8408D18AC6CA9C55A37D75F2567AF9EC6784CB635A7CBCD64F6FBD7E9FD58E5FC63E386F8ADE3CD7BC5123197FE120D425B9819BB5B29F2ADD7F08638FF001CD1593E07D2DAE2C21B68A4DAB6B084C7D3028AE68C1A8A3AEB4B9E6E696FF8797C8F15FF00827EFC44D1EC3E3ADFF86EDE366B7F10681710945411A2CB118E740A8382DF2381B7272FD58E0D7DFF00F05FFE09A3A478EF5DD3FC5BF13F4DDD6D6737DA74FF000E31389FE5201BC1CFC9820F93C1240DE40051BE44FF008250FC5EF85FF007E23F89B56F14786350D63C5D05BC32E87A90B15B88F49802CA2E9F2F2C6913B130AAB9058E4AA91B886FB262FF0082C5FC2ABC95626BFB8F319B6FFC7A023824769CF5F5F7AF4B26CFBD865BF56E6B26DBD5EB6D34F2D6EF4EE7879EF0CC7199A2C7385DA8A56E97D75F3D1DBE5D4FADDAE6348556358EDEDE1458E28D502246AA30AAA06005030001C01D29D6D72D31DCAC8AA0F04FDD51F5EE6BE5BD3BFE0A99F0F6F73E65FBE1B2550D985C8CFCBC79D9FCC75AE861FF008296FC3B45FDE6A395039260E07E529A9FED6C26DED17DE8DFFB1F19FF003EDFDC7D01A8CD34D3E368F2C00BBF3CB77FC07E7515D6A634FB7669DB73302101E10E074FAF15E0A7FE0A59F0D6D209A49F55F311792B1DB191B1D3A6FA90FF00C1473E0BEA36C7ED1E23823590637184EF4F6C6FCFE15A4732C2BFF9791FBD7F9932CA714BFE5DBFB99EE966D204593E53E58DB91C83EA40A75C4EB2A6FE8C380D8E56BC063FF8293FC29B08E411788B4D9A242486646463E8305FB0F4FD2AAC5FF053EF85771733C71F8834B8CC1B72645655CB0E304BF3EF8C8153FDA784BDBDA47EF5FE657F63E32D7F66FEE7FE47D0CB2FEE0A15DAD8FE1E9ED834D7462ABBB6B7CA01C8CB7F9FAD7CF6FF00F0534F85E91473AEBBA7CC5B2A44513B96C7D1BEBF9D25EFFC14D3E19C1261B5AB2C95FE1B695B1F886A3FB4B0BFF3F23F7AFF003296538CFF009F72FB99EFE0B0195F99471E98AABA9BB30F315B0B8EC79F6AF098BFE0A6DF0CE547FF0089A2A851919B1997A7B139ED59F77FF0535F8716D7CCCBA9DBB4240DEBF659B7023F1E68FED2C2FF00CFC8FDEBFCC3FB2F17FF003EDFDCCF7AD45B75B7EED99594AB81BB018E7A7AFB7159F737CB72EC91FF00AB9017DBF7B61CFF00FA8D780EBDFF00055CF85F616F245FDABE62B12D94D3E762A3E99CF15C4D87FC158FE1CD8EAE24FED085E1C60AB69D70A7D41EB8FC053FAED06BE35F7A1FF65E293D60FEE3EA8F33C88E0511C65A462EC376D6C74C6DEF4DB8BC65BA558DD995B919E36F1E84D7CABE26FF0082C27C3FD3EE7ED56F796B3472021924D32E32BDCE066B93D43FE0B65F0DEE238A4332C7342CCA55B48BBC6DCF1939C67F1FCAA56328EFCCBEF45FF66E23AC59F64F88B4AB3F11E8575A56AD6569AA6977C9E55CDADCA078E553EA0F7EE0F5070460F35F04FED77FB0B6B3F06F594F1478545D6B5E07B591AE6E622C64BBD1BE5DABBC759201BDFF007BD57187E9BDBA797FE0B7DF0E51B9B85DB8278D22E8E7F5ACA6FF0082F4FC3BD26F774370AFB720A7F645CF4E411F7BBFA7F3AC2B55C3D556E64694E9D7C2CB9A5657BAD5DB756FD4F2AD2BE264DE11F0B35E2CCB6ED24E916F6F983021CE3FF1DA2B1FF6B7F889E1FF0088F6FA36B5E0BB1B3D3749F1016BD36F64AC902C8A0062AA58ECFF0059CA8C0077600C515E4D7C44A33E58BFC4FA2C24A94292F6895DF95CF9F7E10FC3F87C4FE31D63EDD83F68B15789B39CC8268F1DBA15279F5AF745F07E99A27876E2E6D6D4BDE078219143961833468FF2F5CFCC0FE75E71FB37781751D3D64D4668D96C6F0476D894E5D83C8BC8CE3D31D3BD75BF1AFC530780B47D62EEE7CE5B7B7682E2431287919728D950580621B19E471EB5F170C74EB54F6709697DBEE47D0D4C353A54DD492E9BFDECF6DF0969FA74DE0C82E83084F98F686DE388ACCCF19DA4C8DDB3D42804E083BB92045E13F17DEEAEDA87D96F05B58D8CBF656DF6E2599D80070A0E0AF51CB641FEEE39AE0BE037C654F8C7F0E23D62DDFCEB586792CB3750086766508C72572597E6E012467B0AD88FC416FA5DCC932F916F71C2CAD06F491C7A6E520B0EF83D2BDBA3C379ACA3ED150934F54ED74781538AF2784BD9CB1104D6EAFA9E88B6F1DE5BB44D04F3C981927E6F33209246EC2E7A740067D2A4B0B28753D252799A68D979FB146E9E7C4413C36E25BA7380A3D891C9F2C8FF00692B2F3D6DF7379DFF002CFF0071E6E4FAB1279ED5BB75F136E6E2DFCCBCD3ED1ADCB6D467890E4F63B707AFD7F2ADE9F0F6693BA85093F930A9C5193D3D6788825EA8DEBCD3F46D46F19058471BEF31EC695A42E719CFCCC47E42B0BC6DA2DBE9762668F4BBABB915D63F261070AA4F2EC76E703AE10163E99AAA7C6722691717EB67A5C6D18DEAFB6459222B9390BBB0091E9517893C7BAB6916F6736A50C325BCD298C289A46C101C9C8E9FC079FA578F9C6171797F2FD6A2E9F36DCD757B6F6BBF43D9CA733C0E60A4F05355396D771B3B5F6BFAD8B5A35D5A6996CABFDAD70AAEB9F20471DAAFBE44A4B9EDD00CFA76AB3797F0D95B798BA85E490818291A44C57D4F1181FAD71FFF000B12FBC4376D6BA72CCACF9F910100B053C02D9C9EBC019E2B075F5BED3ED26B8BBB868A68C01BA6DA36AF7C7C83B7419AF0BDE9CFE25AF9AFF23D794A315B3D3D4EC3C41AED88B397125C33282371D9F376C72001F8FBF5EB5C1CFE2458EF36AC722AB1285F6A8E7775E98238EDEA2A0B1F8896D058337DA9BCC99721DA290AC838EC186013D0F71CF4EA975E318C68B2DC89B4F78D59436D576646CE3953DFA1C1EDD38AA93A94AFCEADF33352A7277463EB9E2536174C7CBB868611CF970649FC8127F1F5AE27C41E3FB782E57FD16F3695CAFEE26CB753C76CFD2BADD1AFE2F1CEA2C96FE20F0F68E0C42553AA5EC5651DC0C81B51A4E09E41C641C67AE29FAE783E1B56F2E6F177C37924C29607C436BF519DA0E7F9D77E1E9D79C39941B5EBFF000E7354AB4E32B7325F23C93C53ABC9AACF08836B171B8C57172B09453C7466193EDDBF5AC4D674892DFC3ED713359A79670881C33B0C1CFF00111DBB1CD7A77887E16DF6AD6CD347AAF80FEC8AA794D622F2C0F5CECDA3FCF35C8EA7F0AAE2DEC6DF76A9E0154BA3E5DB14D5A31E7E0F2178F9B9C038FEB5E952A588924B96CBEFFEBEE39E788A51BB72FEBEEFD4F28D627B7D9148BB42B2F4030CA7BE464D655CE9EB6FAB467E55F3232C7DFA1FEB5D678E3E1ADF78536ADC49A65C34EC553C8B81263A75C0E9C8AE5EE142DEC39DDB8864F5C0E3FC2BD4A7EEE87CAE3A2EA3E792EAACED6EB667BD6897626F809E0B8639AE3CC8CDF33884E1941B82013F5C7FE3A68AE020F145D697E17D0D6D6F10F976D2A3C4CFCC44DC48D8C6780739E71D68AC7DA544FDDD8F5BD92718DFB2EBDF5FD4FD24F19FC12B6F87FF00B3F49A95ADC9B8923BBB0C923688B74CAA304E483F3608E3E8315F2D7ED517926BBF0A7C40D346D6B7104637A6EF33780EA39E001EBEBC7BD7DDBFB5EBC3E11FD9B2EACE4B5BA65D45ED648DF86481E1BA85DB71278381C6064F3E95F077ED2D35BCDF0E7C44A817E6B6F302AF6C2E47F9F6AFCF786EAC9F2CE7D65A7A687D567B4E3C938C7F97F1B33DC3FE0949A0786EEFF62FBEB9D534DB5B8BAB7F125D624962DD8FDCDB9519FF0001FE35EBFF00107E11B7C5DF86AB63E05F0EF85F49F17DB799234F3C92429708506093B5F956C86000C8E473C0F1BFF82496B50C1FB2CEAF6AF1B2C91EBF712890A6E5E60B7E3D7B7F2AF65F1E78924F0DD98558E48E1BB570B3A4CEAECCC307F780EF04293C107A7DE0381A66B9F66343135214EBCD28CAE929C92B7924D69E4832DC872CAB83A53AB87836E2AEDC22DDEDBDDA7AF99E27F15FC391E99E305B7BEF06F85741BCB43B64934696792DE67FEF0699C617DB04FD6B434E91BC4F7D63A4C2DA6C9236D93CBB86F2CCBB4E5801856240C9C6E071923A5764F6B0DDA2FD9916EAE1A13B6FAF482B1AED24845F5C77EDEB5D37ECF5E0CB1D3BC3F72BAD68B6167A95F3B08B52941F31D5B911905BE418C7CC31BBEA013E455E2ACEA94A7ECB13523E9397E1EF5FF53A65C35944E2954C2D397AD387FF002363CC7E30F87ADBC31E1CD66FACF4F162F6B64258E38E5693E70A3AB3139CF3D477AE57F684F8B171A1F87A1D5AC7416D5EE6DEEDA630710C107CB2AB0DCC49F94907001073C639C7A17ED55E1C6F02FC34F1459CB335C49FD8D3DC2330E80A3E179FBD8C751FD2BE31F8BFF1935AF122A5BCDE5B166FF5312FCABD719EDE871F8D77E1F118DCD9D29E32ABABCBA7BF293D1A5DDDFF0012A381C1602128E0A9468F36BEE4631D55FB2B3FB99D47C3CFDB0F4FBDD76FAFB56F3AD0C88CA21F243F944E39465195518EE0E7F1CD765ABFED15E1FF00895E18B8D3E692C756994078449288DF8EE7763E61D7A83C75E735E13E07F1DE97E1B964B4BFB7B4B89A43FF001F453773DE339C80BF4C7F5ACCF8830F876FA4F3D6D26B1930487B4002CBE80AF407DEBD6FECFA3F58E58C6515D1A775FA3FC6E79F3AD5553BC9A93EBD3FCD7F5D0EFBC4DE2854859AD7CE6B765E58E1F20F7FFEB1E327D6B8ABCB19AE6D2E26B3BCBADB32956507F79823F8BD4F1C67F027B7076BA95D59BAEDB895829C805BF5C56A5AFC48D43479D9D8ACED28C1FEF20F63E95EBAC0D582FDDBBBF3EA707D72972DE69AFEBC8B5696A935E46B3DC5DDD3430B063712EE55451C05C80463A62B9BD4E08FCF6C4ADB4B11B17B7E15BFA2F8B3FE122D56E24936EF16EFD7E5E38FFEBFE75CF3DDA79D2720B9638C76E4F4AEDC3A9A9BE6EC8CB152A12C3C791AB36ECFD2DFE669689AF5E58E87776B0DE4A2DE552AD1EECA90783C76FC29DAD40B74DE17FB43CC23B4FDE60B7CA3320E9E830A2B0CDA3C07CC662BB88006718F6AD88EFA2BDBED3566F94DBEDF98739C37715D4BDC7CD13CB9538D5A7ECEA476B6EFCEE8E83E2BCBF6C4D2E48E49163795F01B8E8147E7C7F9E6BCFEF62643C903FD20907AF63FE15DB7C42BD6BD934FDDE5ED577DA54751C738ED9AE2F531B428FEECE7F91AAC3B7A5CE7C6C57B272F3FF2363C2EB16996CD76D1F98F7076805770007E1ED4547A5CDE5E8B6E9346BE5B166462C5738623AF7A2B1A94D4A4DB3BF0B514694524B6BFDFA9FAF5F1BBC453EB7F03F5EB1B892E2659ACD995A49777978DADC0000CF6C8C7D0D7C1FF001BE52DF0FF005B5ED25AC84FFDF078A28AFCFF002B8A8CD28FF32FCD1F579B6B177FE57FA9EFDFF048F319FD97B56F323DDFF152488FF36372982DF8FCC03F515EBDAA4ADAD5F5F457A567B7B0F9E18828555719C39EB9231F4A28AE5CE629626BCBADCEACADBFAAD15FDD5FA1C3FC45D4DAC3439A69545C1652BB1B841800F4F7CF7F4AEA3E0B78C351D7BC09359DFCEB75269B10314DB76E626CE2361FC417A024F4A28AF9CADEFD27296F73D25F1A5E470BFB44DD4DA97C2CF119B8612341A25D44871D008E423D7E95F1F78E5637D7AE34F8234B7861197651F33839C007B7EB9A28AFA5E1FD617F57FF00A49E7E37A1E5FAD69C96EF70D196558C8001E49CFBFE358975A9CD0DBF97BD9A3C1C03DB009FF1FCE8A2BF4AC27BC9731F039C549534E54DDBD3D458676B6B65E77330EA6AA5DCCC2E7AF39C64F39A28AE8A7F11E6E224FD9A5E86B7852356BC99CAF2226E8719E4565E947CCBA99BB890A8F6E4D14544779FC8EA97C34179CFF2896AF5CDC3E324051C7B52E8B29BBD42DA37EACEA030EDCD14538FC067393F6EBCDEA6EF8BC343776D133799852DBBD7A572DABB101BFD9B8FF1A28AAA3AC9139837EC5FF5D8E97C23ABC834586DDD639218C1650CBD0963FF00D7FCE8A28AF3B1114AA3B1DD8593F651D7A23FFFD9, NULL, 1, 1, 1, 1)
INSERT [dbo].[Producto] ([id], [descripcion], [imagen1], [imagen2], [idTipoProducto], [stock], [stockMinimo], [baja]) VALUES (4, N'Sillon', 0xFFD8FFE000104A46494600010101006000600000FFED003650686F746F73686F7020332E30003842494D04040000000000191C026700144B7566307A305650313472637741646B5A712D5800FFE20BF84943435F50524F46494C4500010100000BE800000000020000006D6E74725247422058595A2007D90003001B00150024001F61637370000000000000000000000000000000000000000100000000000000000000F6D6000100000000D32D0000000029F83DDEAFF255AE7842FAE4CA83390D00000000000000000000000000000000000000000000000000000000000000106465736300000144000000796258595A000001C00000001462545243000001D40000080C646D6464000009E0000000886758595A00000A680000001467545243000001D40000080C6C756D6900000A7C000000146D65617300000A9000000024626B707400000AB4000000147258595A00000AC80000001472545243000001D40000080C7465636800000ADC0000000C7675656400000AE8000000877774707400000B70000000146370727400000B84000000376368616400000BBC0000002C64657363000000000000001F735247422049454336313936362D322D3120626C61636B207363616C65640000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000058595A2000000000000024A000000F840000B6CF63757276000000000000040000000005000A000F00140019001E00230028002D00320037003B00400045004A004F00540059005E00630068006D00720077007C00810086008B00900095009A009F00A400A900AE00B200B700BC00C100C600CB00D000D500DB00E000E500EB00F000F600FB01010107010D01130119011F0125012B01320138013E0145014C0152015901600167016E0175017C0183018B0192019A01A101A901B101B901C101C901D101D901E101E901F201FA0203020C0214021D0226022F02380241024B0254025D02670271027A0284028E029802A202AC02B602C102CB02D502E002EB02F50300030B03160321032D03380343034F035A03660372037E038A039603A203AE03BA03C703D303E003EC03F9040604130420042D043B0448045504630471047E048C049A04A804B604C404D304E104F004FE050D051C052B053A05490558056705770586059605A605B505C505D505E505F6060606160627063706480659066A067B068C069D06AF06C006D106E306F507070719072B073D074F076107740786079907AC07BF07D207E507F8080B081F08320846085A086E0882089608AA08BE08D208E708FB09100925093A094F09640979098F09A409BA09CF09E509FB0A110A270A3D0A540A6A0A810A980AAE0AC50ADC0AF30B0B0B220B390B510B690B800B980BB00BC80BE10BF90C120C2A0C430C5C0C750C8E0CA70CC00CD90CF30D0D0D260D400D5A0D740D8E0DA90DC30DDE0DF80E130E2E0E490E640E7F0E9B0EB60ED20EEE0F090F250F410F5E0F7A0F960FB30FCF0FEC1009102610431061107E109B10B910D710F511131131114F116D118C11AA11C911E81207122612451264128412A312C312E31303132313431363138313A413C513E5140614271449146A148B14AD14CE14F01512153415561578159B15BD15E0160316261649166C168F16B216D616FA171D17411765178917AE17D217F7181B18401865188A18AF18D518FA19201945196B199119B719DD1A041A2A1A511A771A9E1AC51AEC1B141B3B1B631B8A1BB21BDA1C021C2A1C521C7B1CA31CCC1CF51D1E1D471D701D991DC31DEC1E161E401E6A1E941EBE1EE91F131F3E1F691F941FBF1FEA20152041206C209820C420F0211C2148217521A121CE21FB22272255228222AF22DD230A23382366239423C223F0241F244D247C24AB24DA250925382568259725C725F726272657268726B726E827182749277A27AB27DC280D283F287128A228D429062938296B299D29D02A022A352A682A9B2ACF2B022B362B692B9D2BD12C052C392C6E2CA22CD72D0C2D412D762DAB2DE12E162E4C2E822EB72EEE2F242F5A2F912FC72FFE3035306C30A430DB3112314A318231BA31F2322A3263329B32D4330D3346337F33B833F1342B3465349E34D83513354D358735C235FD3637367236AE36E937243760379C37D738143850388C38C839053942397F39BC39F93A363A743AB23AEF3B2D3B6B3BAA3BE83C273C653CA43CE33D223D613DA13DE03E203E603EA03EE03F213F613FA23FE24023406440A640E74129416A41AC41EE4230427242B542F7433A437D43C044034447448A44CE45124555459A45DE4622466746AB46F04735477B47C04805484B489148D7491D496349A949F04A374A7D4AC44B0C4B534B9A4BE24C2A4C724CBA4D024D4A4D934DDC4E254E6E4EB74F004F494F934FDD5027507150BB51065150519B51E65231527C52C75313535F53AA53F65442548F54DB5528557555C2560F565C56A956F75744579257E0582F587D58CB591A596959B85A075A565AA65AF55B455B955BE55C355C865CD65D275D785DC95E1A5E6C5EBD5F0F5F615FB36005605760AA60FC614F61A261F56249629C62F06343639763EB6440649464E9653D659265E7663D669266E8673D679367E9683F689668EC6943699A69F16A486A9F6AF76B4F6BA76BFF6C576CAF6D086D606DB96E126E6B6EC46F1E6F786FD1702B708670E0713A719571F0724B72A67301735D73B87414747074CC7528758575E1763E769B76F8775677B37811786E78CC792A798979E77A467AA57B047B637BC27C217C817CE17D417DA17E017E627EC27F237F847FE5804780A8810A816B81CD8230829282F4835783BA841D848084E3854785AB860E867286D7873B879F8804886988CE8933899989FE8A648ACA8B308B968BFC8C638CCA8D318D988DFF8E668ECE8F368F9E9006906E90D6913F91A89211927A92E3934D93B69420948A94F4955F95C99634969F970A977597E0984C98B89924999099FC9A689AD59B429BAF9C1C9C899CF79D649DD29E409EAE9F1D9F8B9FFAA069A0D8A147A1B6A226A296A306A376A3E6A456A4C7A538A5A9A61AA68BA6FDA76EA7E0A852A8C4A937A9A9AA1CAA8FAB02AB75ABE9AC5CACD0AD44ADB8AE2DAEA1AF16AF8BB000B075B0EAB160B1D6B24BB2C2B338B3AEB425B49CB513B58AB601B679B6F0B768B7E0B859B8D1B94AB9C2BA3BBAB5BB2EBBA7BC21BC9BBD15BD8FBE0ABE84BEFFBF7ABFF5C070C0ECC167C1E3C25FC2DBC358C3D4C451C4CEC54BC5C8C646C6C3C741C7BFC83DC8BCC93AC9B9CA38CAB7CB36CBB6CC35CCB5CD35CDB5CE36CEB6CF37CFB8D039D0BAD13CD1BED23FD2C1D344D3C6D449D4CBD54ED5D1D655D6D8D75CD7E0D864D8E8D96CD9F1DA76DAFBDB80DC05DC8ADD10DD96DE1CDEA2DF29DFAFE036E0BDE144E1CCE253E2DBE363E3EBE473E4FCE584E60DE696E71FE7A9E832E8BCE946E9D0EA5BEAE5EB70EBFBEC86ED11ED9CEE28EEB4EF40EFCCF058F0E5F172F1FFF28CF319F3A7F434F4C2F550F5DEF66DF6FBF78AF819F8A8F938F9C7FA57FAE7FB77FC07FC98FD29FDBAFE4BFEDCFF6DFFFF64657363000000000000002E4945432036313936362D322D312044656661756C742052474220436F6C6F7572205370616365202D20735247420000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000058595A2000000000000062990000B785000018DA58595A20000000000000000000500000000000006D656173000000000000000100000000000000000000000000000000000000000000000258595A20000000000000031600000333000002A458595A200000000000006FA2000038F50000039073696720000000004352542064657363000000000000002D5265666572656E63652056696577696E6720436F6E646974696F6E20696E204945432036313936362D322D31000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000058595A20000000000000F6D6000100000000D32D7465787400000000436F7079726967687420496E7465726E6174696F6E616C20436F6C6F7220436F6E736F727469756D2C20323030390000736633320000000000010C44000005DFFFFFF326000007940000FD8FFFFFFBA1FFFFFDA2000003DB0000C075FFDB0043000201010201010202020202020202030503030303030604040305070607070706070708090B0908080A0807070A0D0A0A0B0C0C0C0C07090E0F0D0C0E0B0C0C0CFFDB004301020202030303060303060C0807080C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0CFFC000110800C0008003012200021101031101FFC4001F0000010501010101010100000000000000000102030405060708090A0BFFC400B5100002010303020403050504040000017D01020300041105122131410613516107227114328191A1082342B1C11552D1F02433627282090A161718191A25262728292A3435363738393A434445464748494A535455565758595A636465666768696A737475767778797A838485868788898A92939495969798999AA2A3A4A5A6A7A8A9AAB2B3B4B5B6B7B8B9BAC2C3C4C5C6C7C8C9CAD2D3D4D5D6D7D8D9DAE1E2E3E4E5E6E7E8E9EAF1F2F3F4F5F6F7F8F9FAFFC4001F0100030101010101010101010000000000000102030405060708090A0BFFC400B51100020102040403040705040400010277000102031104052131061241510761711322328108144291A1B1C109233352F0156272D10A162434E125F11718191A262728292A35363738393A434445464748494A535455565758595A636465666768696A737475767778797A82838485868788898A92939495969798999AA2A3A4A5A6A7A8A9AAB2B3B4B5B6B7B8B9BAC2C3C4C5C6C7C8C9CAD2D3D4D5D6D7D8D9DAE2E3E4E5E6E7E8E9EAF2F3F4F5F6F7F8F9FAFFDA000C03010002110311003F00FDFCA28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28AF907FE0A01FF00059EF865FB0278E6DFC1D7BA4F8ABC75E38B883ED52E8DE1D86176D3A22032BDC492C88177290424625900642500910B7461B0B5B1153D9508B94BB214A492BB3EBEA2BF23355FF83A324D6A0B71A2FC1EB3D1E3BD964896F75FF14B47F64081CB3BC0B6A09E53017CD52772F7201F26F8C1FF0007007ED09E35B068BC2B7DE03F0C46CBBE2BCB2D04B4873F3019BAB89D7950707CA03247DEE87E8B0BC199AD7DA097AB5FA5CE4A9985087C523F7333547C49E28D33C1BA34DA96B1A8D8E93A7DB0DD35D5E4EB04310F56762147E26BF9D3F89FFF000504F8FDF16E5D346A5F19BE224B690DF4775AA5E68FABC9A014B7450D2478B03047F392E157682DE5800B31C579FF0089058F8EBC4CBAA5D6932788BC450E152F6FD06A57D197766DE679B74991F20CBB8F95989DD80A7D5C3F00D79DDD4AD1567676D6DDF7B6D626798538B4ACF5D8FE813C4DFF00053FFD9DFC2A76CDF1A3E1CDE4C09060D335B83539D48CE731DB348E3A1EA3B1F435DFFC0AFDA47C09FB4D78525D6BC05E29D27C4FA7DB4BE45CB59CBFBDB390A8711CD1301244E5195C2C8AA4ABAB0055813FCEC78E7E24C9A26A30DD5C5B5D2CF633859ADF724B0C4923E015018C6559636C285C945232C3207D1DFF000478F1FEA1E1CFDBE343B3F0BDD47A7DBF8D3C4D7967731ACC64B7D42CED748DB3AC80302583E9CED1861B94F96C78277AC5707D2A785AB56137CD0BBD568D2D7E5A6DAFE4694F14A4D2F25F27DBFE09FBA1451457C09D414514500145145001451450015FCC4FEDF7E35B9F8F3FF0518F8A5E33B9BEBA16DAA789B50D22C9ADC06DD6F6AED65693231202EF86D2060383B58636B9CD7F491F1FBE28C7F03FE04F8D7C6B34692C3E0FD06FB5B911CE15D6DADE498827D084AFE5D3C1D6115FFC3D169B6DE6D512D1654BC8C7173203B8B12003912AEE24919299393C57D570BD3A8AABC44768B8A7E69DF4FC115CB4E719427BB4EDEA72DACF84B5AD47C6BA4E8BA7DE5C7F64B6982F2F6FADEE1E28C461F6A5B24A234DC5D9159C804ED44200C807735445921D35B43B1B50EB713C76E65B9953CE4889899F7A9DE55773B292493B3BE4D727A87C5FD3EFFC6D7D0FDB24F3A47431DB2C0EEA91BA296DCC186D50C5C14073B9B18C7CA7B5F0278A2CF4536F796F35BC367BA282DF037247B373329DCC791BC12467066523908D5FA446B42379B7A7E5F79E2C29B6D422B5363E29E8379E13F08EA767A3D9E9BA8DD5ED9C856D9A5863855B1BD81DA8096E00192B96645EA576D9F0A7C3ED62CEC341B3D5B5247BBBF2EB7ED2642E63B6889C024161B5F76DC67E46F76AABE3DF8ADA7E85E17D4353BA320D323B6097A6398AF9B230FDC8049DC652022F5C00BC2F048C9F017C567F8BFF000FEC6FADAE97FE127B7BA8248247717060BCF9232F2AB02ED6F2C68A5D89727636E1865CF473B7072E77792BDBB2FBF5D6CEEFA5FCCD2128AA8972AF75FAB7F8597A2FBCF5CF167C2BBBD4ACB4F5D163D52F2CB518FC9B9D6675115B69A92EC590B87DA4B21DA495E7604DFB42955FB03FE0DF5F86DA4F8BBF681F0CEBD6CD0DC49A37852EF5E9A7876146BCBB64565F9400B85BEB8509F31554404A93B07CD165F12EF7E1978535CF10ADC58EA91E976B3DDCC6D5DA56B6961849C80EEFB903794002C5918A8219252ADF6FFF00C1B6BF06F4BF03F8C3E305ED843B63D36D347D26170728EC3ED293B2120128CD6D130CE4727079C0F0736AB5A8602BC6AA7A4524DEFEF3B6BF26F4F3F467A5563467CB5693B36F54AD6B2ED6F37BF97AA3F5628A28AFC8CA0A28A2800A28AC0F1EFC55F0BFC2AD37ED9E28F12683E1BB33FF002DF54D422B38FF00EFA919455462E4ED157606FD15F38F8EFF00E0AD9FB3DF80564F37E24697AC3463206876D71AB239F4125BC6F1FE2580F7AF15F1C7FC1C2DF09B42B2B86D1BC27E3ED6E684ED4324565630B9F4DD25CEF1FF007EEBD2A39263EA7C3465F356FCEC4F3C7B9EC5FF00058AF1549E0FFF008261FC6AB88E4F2BED9E1B974C763DD2EDD2D5C7E2B311F8D7F37BE08F1FDAF857C490C371229B79AD62965F324C2A132498600719DB1BAFA8127535FA55FB74FF00C17465FDAE3F677F197C333F0D745D0347F1869F269AF7D75E2496F2EAD19B98AE1228ED026F8E45470A59D58A8078CD7E50DDFC07D52E75337167AF4D7570907D95A19B45B80190382137021473BF92A38238C835F6D90E598AC2E1E50AD0B36EFBADADEA6339FBC9A1D7F7F637FE2F99A1B516D777174D732AA226D7BB9647266209DDB816E23FB8AA8ADE8ABEB9E14D47FB3F4A8235834F86391635579311890F97210246CFCB1C6CD33124118B5619024C1F1D83E046AFA7F89E695AF34BB89E473716EB1DCCA8AE5A3F2D580F2B738425FB805828E9927ADF1CFC3FF185F68171636DA1CD1B4D13A936D7306E884BE52C8EA19D7EF45130E39C39381935F45EC672769DDA5D12E8BA7CF5B9CFED945B925EF3DDBEEDEFF2D2C4BF1C17C25FB40784E1874FB9B4926FED08EF5554490F94F28937B5C2E76BB1DA88A06D2840C1209C9FB1A78663D1E0BCB85B1B886756FB45A4AD16230D811A90C4B11CC878D873B8738CE383B0F05F89BC13A4490CDE19D52C63B4CC9773CD0ACC6478DD990300A63DEA1980DC40DA79048507B4F829E339BC3DF10F509E34BFFECBBC8E096298DA4BB184484088BB1038604B2302097E704114F0B888CAA3724D38DB74D5D7CEDB5ADF326A51941435BDEFB6B67FD33D1AE2F7FB27E11DFDAC2BF63835AD36CF45B94760FB4DDDC4B66D26D2236251376D460B879182B0099AFD88FF00836BB40997F64CF1C6B9772C935E6A5E2B6B577740BBD62B3B697207601EE645C1FEED7E2BDC788EDF56F0B697636F2491C6FE20D1600606460BB2592E58A9F951BF783A8DA7E600ED55F97F7F3FE085BE1D3A37EC076379E5B44BAC788F5AB850CBB5888AFA4B4248EDCDB1C679C62BCBE2EA8A19638BDE528AFCDFE68DA8CB9E49ADB5FD3F4FCCFB128A28AFC98EC0A8EF2EE3B0B49269A458A1854BC8EC70A8A064927D8549515F5947A8D9CB6F3289219D1A3753D1948C11F91A3D40FE4D3E227FC1753F682F8EBACDE5F78D3C7DE29BCD26F034C96BA0EA1268F68A8D231456B68C842154050325880776E66CD65F82FF00684F0CFC4B7BA9E0D52DD35AB7DECF6DA84C23B8B938DB850479ACE782A1769DD9F997907E47D6ED25F00DFC9A6DC2A4973A499AC59F0AC1248D9A338CE47FCB427F01CD27842E3CE4BDD96F14926F066464591D81DCAD9EECC0B06C01FC4703238FD4B079C4B0D27414538DBB74F97639EB619548A9A6D3F276FF0081FD6E7E80C1777D3403C96F0F9F9413FE8774D248A4852C425CB39219D4723AE3F0DE5D5F49B6F0A2B6A5349A35F5BC3384496CD956FA6DD8489224DCC81B2D82CC7000DD81815F10F817C5BAB780BC616D79A3F892FB46D43ED125BD95C2C8268D3AB246C1B77EEC02B90B8E6453C741E85F0F3F6DAF187877519350F14786F4BD59AD9C238B39DA2B84936BA90232482401B986E5C6DEAAC41AF769E6D4B954EDBF7DBC9E9AF9F9A392A61A579454B6F2B3BF6EDE5AB5A9F4E787ADACDF5296F134C46B75F2D239A62636B95039323A8770CC194AA01B00CEECF51E9DADDEF87EE9E2B5D2FF007CBF6668A5874FB467F34146568D31B5B712546E3B461181201257C17E0F7ED65E0BF19DDC9652789A6F0BEA9F672A6C35991EC91C1DA13642CEB1CAC467F8C7200C30186F62D67C5161A2CD6F6B6DAA6916B7BA85A1BFB49EFAEC456D0A7DE5666551F78E0A0655F3036720282FDF4B074ABDEBC6A5D47B3D2FD6DFF013FD4BFAF4E8C7D8BA7BF5D3FAF95C7693F0FEF63D19EEA5B11A4A88E7B8B9B4826335B5A2AA318B6CB195CB6ECAB2464955C3336726BCEF5BD2FE2E78874E260D2F4AD07499118284BCB5B667CA893E666937860A0B90D8201C918C634D7E24F82F56820B5D0750D73C69AE490C4E2D740B7FB6C9685CC51896E0484C0ADB815F2EE1E220CF803E44CF2BA9F8BBE2358F809E6D264D134468EE62B5883EFD7752965CB484C67E5B787195C2462443943962335D12C44232E449B5D5AB5B5764ADD3FE1FAAB2CD509B8B94DA5E4EF7765F33B5F0B7C2FD7B40F01B5E6B091E936BA4CA669521B886F230C063ED13C8A709B4C9293939196386CE1B8FD0FE265FEA7E2CBA5F0EE876FE30D42C55BCAD4F499AD63D36EE44DAD985E548D64F9092CB1EFCB6701541C55B6F87371E3BB392FB59D4A7F1A788A469CA4DAD3294B670AB2466DED948B7879126D6450492FF007C1500F8D5E3DB3F0E5B4D0D88921D4BED6F7F0BA1522D268E4C481B9C156919C06192CD0E572856B96F4E5579F55A5DBF249595F6EB656BDF7368D49429BA69DEDB276EBABD37D2DBDD7C887C4163AE7C5D8EC6FB59BED0F43D723297F1C3A6591571324F8DAF2B6F0DF2F0E9B1546D8CE739C7F41DFF000461D0E5D03FE0983F086399E5924BAD2A5BE2F280B238B8BA9E70580006E22419C01CE7815FCF72DCC9AAF8FEDF5093F72A2EA79244471E59CC3247DB0A42B44472481B81CD7F48FF00F04E4D3E1D33FE09FBF0463B74F2E393C0BA2CFB4F63258C321F5EEC6BE378DAA5F0B04DDEF2FC93D7F134A117CD76BA7E67B4514515F9A9D4145145007F1A3FF0584F017FC2A4FF0082967ED09A0A42B6F6967E3FD4F50B78235D82182EA66BA08A07014C73803D8018C703CF7C7DFB3578F3F645F88771E1CF1FF87356F0A6BCC9FDA31417D16D17503345B668644DD1CF111BC2CB0B491B738270457D6DFF0007367827FE115FF82BDFC689161555D7D347D42003FDAD1ACE276E7D648A426BFA1AF067ECBDF0C3FE0A3FFF0004D9F84BA5FC55F0768FE33D135DF04E8DA943F6B42B716524B6103F9D6F3A112DBC9838DF13AB1048248241F6A8E653A36F69AAFC51D588A315184D7547F1D7ADF88EF34F3F66DE2386CE387C9F2D7E652AC77107D4B8F98F39D8BFDDE3A1D4BC6CD75A9CD731B1B765134E5923CED91D9DDA4DBD410141F979F957EA3F52BFE0A99FF06A4FC47FD9EE5BEF187C0DBBD4FE2C78221267B9D0DA156F1569B1A8766F2D176A5F8E08FDC88E626450209305EBF2B62D2AE2D64986A50CD6F756788AF2D9A32924054B24D1329C3232818C1E8DC1C102BE830F8CF6D17283BABFDDA7538BD9C55947B7EA77BA078CECF5AD2EEAF66B7B5BD8E631C537DA02C96F7460492624A019DAC649108CE4AB67208AF76F835E01F0CD9FC17D435C6D034E8DB4BD4ADDEE259944D6AB0FDAE143BED5DCC25586D46572C7F78DCA9C93F2D782ACE6B5F044D66AFF00BC46BC84491BF0CDE4B286F64DB20E7B87C0EB9AFADFF634B85F13FC30F155AAC702DB986E24965966291A80D15CB46854876CC69BB61057851900B67E932B968975D3B7F32F2EC72CB9AEED757BFF00E92DF7EFFF000D73D9239974BD274DB3D0ED469BE1392F5A3D64D9DBBC33E9CE6327C830F2CAD2299104824942A870A631BD4E1FC4FF00165A36AD78D66ADFD93A7C003C9023241A6B98DCED917690D20550EA0A943B8856042797CA7837C5FF00D897DE28D123BBB6BCD3AE3725B4E37C71C56D732C84464301B515882C40C203215CEF24F2DE31B3D57C6DA55AAC332DAB48D226A97D2CAC96C1624032EA79DEC4BB00319E7380091DD8EC3D555E9FBF2717CD7DAF75A5B45B5AE95AD6DD6B7BEF85C5535879FBAB9972DB7DBE6DF5B377BDFAE96B7A2FC31F18BEB9A14BA95BA347134B71768594912448D6D161C2FCC7813B70723CB5EA4E1AB782FE03F8D3F6B3FDA1A6F0CF80BC3DA9F88FC4F7D23CAD141087582369E42679DF3B21883480F992BAAE32BB8B9553F627FC13BBFE0885F12FF6A0D0347D43C69F6EF86FF0F56DE08DEE26465D5F5B8D4967FB2DBC83F7714923DC112CE0294921648E553F2FECD7ECBDFB247C3FFD8E3E1CA7863E1F7876CF43B16612DDCE3325E6A93779AE676CC9348738CB93B461542A8551E0E71C4F430FFB8C3A526ACADF655BFE0F45F7A269536E3CF27EF3BDDF5D7FE05CFE607F6FDF863E30FD953F6B0D4FE0CEB4FA4FDA3C2E2CD2FEEF4F69658F5037D676F78CB1BC8037951BCDE58F941628C4E03051FD447ECA3A9AEB5FB2DFC35BC53B96EFC2BA5CC0FA86B488FF005AFC19FF0083967C04BE13FF0082B05AEA2A36FF00C24DE15D1355918772973756A41FF80DA2F1EE2BF70BFE09E3AAAEB5FB037C13B856DFBBC09A2AB9CE7E75B1855BF260457C566788AB88846BD5777F86DD0F671118AC353E55FD591EC54514578C79C145145007F36BFF00077578163D13FE0A59E1CD51200B0EBBE01D3E695C8FF5B34777A942DF94690FE75FB7DFF047FF001047E26FF82537ECDF7319DC23F86BA05AB1CE7E7874F8217FFC790D7E4FFF00C1E6FE148F4AF893F017C418E756D2B5AD3DCFF745B4B64EBCFBFDB1F8FF0064D7E8D7FC1BB9E2BFF84CBFE08BFF00016EF76EF2746B9B0CFF00D7B5FDD5BFFED2AE9ADAC232F2FF0081FA1DD5B5C341F66D1F6957C7FF00F0522FF8223FC13FF82935B5D6ADAFE90DE13F88DE47956BE32D0E348B502542EC5BA423CBBC886C41B651BD54111C9113BABEC0A2B2A75274E5CD0766709FC96FFC1463FE08A5F1ABFE098377AA5F788F47FF0084A3E1BACC64D3FC65A246D258C6645F27174983259CA4BC2079C0C658954964C3563FEC0FAE34BAF78934DB8BA9ECC24F0006620C71C5296876AA64BE3614C649CEEC8603757F56DFB4778397E227ECF3E3CF0FBC2970BAE787750D3DA2750CB2096DA48F69041041DD8C106BF8DEF8037F75E09BEF334B9E4B33AC69E6DE5084FEEC06570C83F85815C023819381939AFAFC9F3DE5BCAB2D935A79A76FC7CCDA8E0E5886942DBADFD75FC0FAA7E107ECD9F12BF6E3F8EFFF00089FC21F0BEA3E2ABC2B60756BF92D8DA697A45AC71AC69E7DDBFC90C6EB1C87681E63E2458E3764C37EDEFF00C1387FE085BE05FD8F9ACFC57E3CB8B5F895F1316E53518EF27B7D9A5E8338550059DBB677BA6062E26CC85977A2C1B8A0F06FF83509161F82FF0019A355002788EC403FECFD94803E800C0F41C57EB4572673C4D8BC5B74A2F923D975F57F3DBEF30A997C30D55C376BAFDC1451457CB8CFC42FF83B0BC0D1693F1F7E0978A36FCFAC689A9E9B238EA16D2EAD2400FF00E073E3F1AFD2EFF8243EB3FDBBFF0004D7F83F37FCF3D096DC7FDB29648FFF0064AF907FE0EAFF008477BE26FD933E1F78D2CF4BD435087C1FE239ADF5196D6D249974DB3B9B491DEE26645222844B6B02191F0A1A4419C900FD35FF00043192F6E3FE094DF07E6BEB5BAB392EAC2F2E214B88DA3692DDF50BA78255040CA490B472230E191D58120835EAD69296062FADEDF9FE963BAA493C345766CFACE8A28AF28E10A28A2803C07F6F5FF82657C1DFF8296F877C33A5FC5EF0DDC6BF69E12BF37FA79B6D467B09977851342648595FCA94220750413B1082ACA08F54F825F03FC23FB377C2BD1BC0FE03F0EE93E13F09787E13069FA569B6E20B6B65676772147567777766396777666259893D5514EEC2FD028A28A40364459519595595860823208AFE2FFC29E1C6F0A78961D32463E669B2CB6C4B1F9B29F29FE55FDA1138AFE40FF69AF0737823F6D7F893A285F2C695E39D774F00AF4115F4F1E3FF001DE2BD1C0ABC26BD3F53D6CA656A9F71FB25FF0006A538FF00855BF1AD76B6E1AFE9EE49E841B6900FE5FA8AFD6AAFC94FF8354F09E08F8DCBCFFC857496E7D0DBDC1FF1AFD6BAE5C4AB546BD3F239F32FF7997CBF24145145607085360823B581238D1638E350A88A30AA070001D80A751400514514005145140051451400514514001E95FCA1FF00C14C7421E12FF82A27C6EB365DACBE3FD4AF06474FB54F24FF00AF9A2BFABCAFE5EFFE0BA1E1F1E1AFF82C6FC6285542ADC6A9A65D647ACBA658CA7F5727F1FA57A597BF8D797F5F99E865B2B55FEBBA3F413FE0D49B977FF85F519398D4F875C71DCA6A20FF00E822BF602BF1DFFE0D4198C977F1F9723E55F0D363B8CAEA83FA57EC4572E2BF8AFE5F922732FF007897CBF24145145739C2145145001451450014514500145145001451450015FCD27FC1C49A43691FF0582F1F4C4301A85AE8978181E302C2DA139E7FE991FF003CD7F4B75F8F7FF071CFFC1233C7DF1DBC6EBF1F3E195ADDF8B2EB4FD220D37C43E18B4B6336A3E540D2325E59AA82D390AFB5E000BE1159379CA8EECBE718D46A4ED756FC8EAC1D450A97653FF834EAE0CBADFED0699C2AC1E197098FBB96D6475FF808FCABF642BE05FF0082087FC132FC4DFB037C18F12F893C75726DFC6DF14058CD7BA121568BC3F6D6A6E5ADE0675CEFB83F6B94CA54EC53B11776C3249F7D5638A945D56E3B7FC00C65453AD2947FAD028A28AE739428A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A00FFD9, NULL, 1, 1, 1, 1)
INSERT [dbo].[Producto] ([id], [descripcion], [imagen1], [imagen2], [idTipoProducto], [stock], [stockMinimo], [baja]) VALUES (5, N'Tela Negra', NULL, NULL, 2, 2, 1, 0)
INSERT [dbo].[Producto] ([id], [descripcion], [imagen1], [imagen2], [idTipoProducto], [stock], [stockMinimo], [baja]) VALUES (6, N'Tela Amarilla', 0xFFD8FFE000104A46494600010100000100010000FFDB0084000906071413121514131416161417171A17181718191A1C18161C1818181A18151818182028201A1A251B1A1821312125292B2E2E2E1C1F3338332C37282D322B010A0A0A0E0D0E1A10101A2C241F242C2C2C2C2C2C2C2C2C2C2C2C2C2C2C2C2C2C2C2C2C2C2C2C2C2C2C2C2C2C2C2C2C2C2C2C2C2C2C2C2C2C2C2C2C2C2C2C2C2CFFC000110800E100E103012200021101031101FFC4001B00010101010101010100000000000000000100020706030405FFC40041100001010408040402070802020300000001F00011316102214151718191A112C1D1E10353B1F192D2040514154262E2132232527282A2C233930623B2D3F2FFC4001A010101010003010000000000000000000000010203050604FFC4002211010001030403010101000000000000000001021151141552A10391D1413121FFDA000C03010002110311003F00EE2D373B1FF907D23CD2FC28A4EC1A3FF9078FE75BF93A2DDBA8DE3C3C6AEBEBEAD2579874369B9FFDFDE3F9DFFC2EC160DAFBEFE90FFF0098E947E55A06BBC7878CF5F4D257987BE69BC0FDF9F4877FCDB51E43AF21A3F5DFD23CD32AA8FCAA710DE3C3C67AFA692BCC3DE34DE0FEFBFA47994B4A37FF004AC2B607D79E3D5FFB29683E55EADDFC5C67AFA9A5AF30F7AD3783FBEFC7F329683A3687D75E37994BE11D19BBF878CF5F4D2D7987BA69BC37DF7E3F9A7E1A296B1FAF3E91E61F868A591BBBF8713D7D34B5661EE5A6F0FF007DF8FF00CE74A37B97581F7DF8FE61FF001EEA0D378F0F19EBE9A5AB30F72D37873F5D78FE61FF001E8C9FAE7E91E61F868F2A3D73886EFE2E33D7D34B5661EDDA6F0E3EB8F1FCC3A01FEAB0ADB5F7C78FFCE5634568CDDFC3C67AFA696ACC3DB34DE2BEF7F1FCC3A0E614A2D1FAEBC7F30E9479AC2D6EFE2E33D7D34D5661ED5A6F143EBAF19F5F8874A21281A99FBE3C6F34FF008F45B1BBBF8B8CF5F534D5661ED1A6F15F7C78FE652D28FCAB668FD6DE3F994B41F2A9C04DE3C3C67AFA69AACC3DAB4DE2BEF8F1BCC3A0E8B6607D75E3799B51EBD73B1BC7878CF5F574B5E61ED9A6F13F7D78FE61D28F757B47EB8F1FCC3A51C7F94ABE226F1E1E33D7D34B5E61ED9A6F13F7CF8FE652D28F4699BCF878D5D7D5D2D5987F09D89CCF3176D2678602BBED560E7606F97ECF7C3A1B5130D8A3C82A8ABCD63CEBB06B87736BF9ACE13D3CF5C7DEB13A572873C2F6688807EF29058460D3D3E5FD4B5A4D3C39732A4220A453F985A36F5DDE9E9EDABA0148491C5681B40896CA29ED9A22E30C6ADD6ED70D4BA85708AE59A142B150DBA2945A1452A2B088E59FF572E41B6F557CCB1854344A416CC838AC03642A85C715268818E9760A7060FA0C3D52BAA61C9E7AA9D9F3146A82F84F3CECDD126C57FE15856D2E89E51FD4B7678A7E9D5A10FF00F5D306484F3D42BA2D451B2DE6956D700B86D79974CA24A83ABDFB8575A8B60B3528322443B6DFD2A503AE2C7D12836400E104940868470BB2B28E4B859323E84AAD2C8E453AC4166A7010551E8BD1E24E295AD2510A613AECD5E1957F22AF8038E6563494FF008842947B5D8ADD817A414E22271DD2188C82F1EDDD6AD5B05A2944E5A44C54ED2BFC987E7A4A6A5168974B5AB61CB2689488E595B246B84DDEBD1A6C65B7669A5CB3F192EB56AB0ADA70EB0EB772B1CFD138D6F4BA355D71DFAAC5B4D32FBF9735B3356F2BFAA7B2631DCDF23CFAB004C2FEE5215942B428A70E4BD5A754056B2E99088694FD3AA9540EA8F881F15ADE9EDA64D7718AFC382703AAEE863D162D9A24274D27B24075FED82D8820C2A4945B40D51F5EAB63F3013BAD15B368496CB56960DD59D7BA9C0344CFA7AADDA1815A589CC9157BF553B2A20E920D015AE8B76CD2386BDD7F93069A454AA60DF0A5456E6198D7A05741B2FAD257D6CF0482C94A0436A252B1B26A5DF2CF2397CF61F2A941B4155D96A1A05EB6BF24E10A41D66A27353832F55F5CBAC1B20C2BDCF52FDF3B2C8D385C34E4E96D6BAA45196833BB34F6C8A611174CADD923BFAF74F6928D3A1524AD6A6A7F8B3DFF0031C9A2EB97F6A944E80558E415CD04F4FEEA512BA4364ACB62157D45FED6E455E8AB52818A9D5400CB2B82BA062A3D968D70E1B4EE5649A0305929C04B8D70C97C2C34F9059B4D6F03F18A32F4CAA016B49A024B4521138C6A6FD627D7A067884B6E6562C691325A2B6C0C8A4E7F7F45AB554A1704B36CB97B2C0468D0A5729AEED57359A90A8E49C564A50641AE077E8B16BFA07CF7EEB66D71191CC3F72F57C279C356D714FD7AF2E8600530458B06D9727745A06C17CD7F775CCD40FDA4B71F32D4B6A125B346BC758E0A710055765B91F21A892D24D1386C966D51B14AAEC7A3374568E558B700270E9D3289402AAE4B660947BA940E8525EE56CD06082F8AD725C2D069EAA9A4E2B85CBE15B0C0C4AFEE2AF80D02FB8E8A08B4B96230590538B69E6DE6BD73B33C32D03F94A70B5CF0BA474ECB76068AAFF528BFF130FC13A6A56EC059DF52BA2D95173B752B52849D964A113392A3D328181C75EEA50696093A0721A20CF423905A30419AA9D150FCAD012190CBF9543F2B346B47A29C1A4CFE28785EEB605450EEAF805F5AEAA70171244ABDA5C1FB45C5FA99638E7BFEB658AFCA042B76A966C3A6B5E990884547A765A06DD6FC247A2C5AB4388575ACCA9541AE2AE3E8FF005BD3D9A271BD4397369C66EC7B8E5908EA10001DECBD2DC5A34456B95C9D532445FEBD6960AA6B885E35EFCF9B5FD4228CB6ECA70104805ABAAABED725510D1554A457C2D42048EA52C9A36753D57A64D1A8D5B762AF88D0551E9727450026DEBD56E63E24C6DCCAD1B41452CC2E99D7BF3D226A20630D7BADDB268C968B623D69F982BAA05AAF1B755AB40825FDBF4AD821F715905268EB925A30683EF58094F3FC281A2517E17F5CE00E29EFFAB15585D18E9DA0AB65F8ACD4DD52C2A349558DE59224157DD7130F5C52FEA51FCC5A2522D250F0A77E94FCCEDCA1D3964D872ABA4FB8894096C7A2941A5C43B461BF4CA057D71AF1CAFC93840A711D39722D6F585EBFC44500023DB93F04E6A8D085CA5D73803885E363CD4E0C8217B1E79C040F0A714ADB018AD54E20271580EB0B6CD3D258C40678C23FAD96BF6B3DC7CECB41F8E89857E9CB34F2630B741760A42A3F3E235D76F49AD9B60BD0EADA86ECD3E351B97EEDEAC65C9058B6408423D559931C2B9414A0D51B7A524E8BC58F5DD681B228AAFE558D40D774B504133BD56A65EEB8F0D47568855E0BD8340A7F75380B1FD0E9A0E8A7003901D8D6A6014B1DBAB6B873D3BAD05FF513943FD57AA12730EC15772BE349A1470D07CABD435D15A15D6E78E64596F5CA1D06DC6E5A2936404F4AA919FE9FE2A34BF30AE7C8965C0DCB2EB9C04294C6A7E65B078A60E62EC4ABD9FC10A38E43B1E70B6CD015DBA76536C80F57E479E76342FE57E5D738B4892492ABEA31DDFF00881C53AB177FB2DCE9D8FA7A2F50713AB7BB338DEBFC8A50829FDD4A2D393BB27D90302B4FCCA4CBA5D96D2B411465B3BFD56CC2E49060D05B7F2AFF0016784AF65B34208C57C49D9083922AF6D3D3FBA857FC2C07DFEBD4ABEC174048E0E7F23CF3B202B82D16ED0093D5F667871EBB29C5B2ADAFE21F334D87CDA6259F900C6F55A9448F3EFEEA5502AB6FC162D17DEB5134F2DA6C8C76EEB166EB72B9EBA45B21EBDC5986423133DFA95B351AA542AF6E95280A88E93B2F5A96350B4D4755BB4EC349617202A36C868BDCBB2DDBEB56DD21A7F4B6786B115FDAB61A4AA0C824999DFF0055E8D85122D72CCB2FAE2974BA8B5AEFF32F4A85E2F495A2E1557AB95F69B5CCFEA6AA5AA4403FB396DFA5550A815C9C55FDAD080F86DD94A34AE096CEFF0050AE8340BF1D7BABBF0B1C49FF00A94EB7421624A0769572DA4EA32465EFB5FA5D9ABE0CF0BD763CF9D1B3DFBA9B2E267BF22F86D2AAA1E196DD96E67E393E7318C67F9981453B3B97F933C2905BB4B8494F1F34D3DF494AB526B35A855CC8E4F73B7E993069D2F4E8B371AE5C96C222E725BEA0A02E032CBF9725C2D9910A4B6EC9CD7127F74EB6023442F65B34F5B3B943A08A819F3E679E6C1B2BDBB1BBDE2214D2255ED12095DF9E7627F807CDA6B8E636F99A69791F8411072D2E40450F17C5CAA0C81156BD2A41FD9C968B0ACEDAB9748A4F4F69F3DFBDC808C28A71E8DA325BA8CD827DEB75560C9A2FB146CCD3CB031DC5D8A908BA2CD7A5FF006C80D1170197657587403BB46382D8012D6E8EA9A2B6B94AA05036EA8452568F4F3D569458145DEDD97A233495ABA0A26A8EEFBFF32BED0D1305CD97E3AF796D2FDDC8225AF75BB3FA34E5BAF51169C9DD96C64976AB5D82DC86B8715906B3DF286CB8580138FCAA5068C3DF75D0A400A7CF153B1063DBBF3CE0D19FA8EAA1F958761AF7682093B14F234027765B9C8135A1BBDEC787156C146B8B02547AABED08A70AF7EE9F65A01073F7E8B70DBDDD3BE77CDE3F8885C56BFD2CCD498A9CB0B97F89043BCB19FB341C92D8E55A74968B661E905B3028A23B287E561D82C96CD2E589A417BA9C06389F5C79FAABDB471DD2BE0D54BDD4EC8A3F698AFEE698E29EE7AB4D2EB67E714D7B9C139A0705A957D61E2F4BFBE7D9E5A14955248372A3544A776BABE912B8BA0BE15549826B828A4469D20B25856604955A9EB32C130ACACC589D168D03E8A182736DC415D9665830F4FEEF5A2AC56FB564949F7859BAD55029C56ABD0274B6EDD2C902BAC71F4E4BD274F55356B4A88AD7FAF2F95AC4A272ECEC2C3E81ACF7EEA7111A29DD96ACBAB57ADA3017F50133DFF52DCEB8AF77ACEF5B8C28FEAC57EF0D3D3FBB413821D94A0602B81D3B0573000D12D6A89D51010ED52841A08970557A22E91A9524FEEB61412575B1A55AF47F2E8D3F8A78A6B757C1A2ADF409D6C454694D6A55ECD2D566AF80B740305F0A9C5805573C31D716973B94E2D185AB25B8975549278573EB03DF05AA9324CF7EF9A7929529EFDD499710A32DBB2940BC1250BB24E6CBD3D3942D02ABB649C629212D139A38F4F5CB2C8628D192D16CD522114B4114D5FCDBFEA69AE3C3E23FFD8CB11F0CED4ABCECABBECBFBADCC0E2B2836887DF5E295B66C40DEF4954D46F45F3579AC20C2BF5D639D5D4B65E2A7FAF755341B145549624E851482D1B0FDFA849E34F942431B96E68D92915A923EAD6DE4F0AE81C8C0EFD02BAC452F4E592BAB2648D0A582CD7A52E52C1484434AAB53A6AAAA019E24F9E2A516A8451376DD96C202AEDD94ED1F77A765B1417DEB25E92E5915AF6F775528F75B9804BA6B06415ACFADB3200724BD43C213BA27FC59727E136D69B29EB3265C0005ECA4D74C39A7CDD4A012A2A50652827CDEB80D24FEEB2704BABB566AF835C457BE5B7E568D2ABBF72AF645864894DF8E49D6D9AE192D14E2C3A4F581E7C80ED6353BA4BB9880499155DE31E7F886789233F6B746F494C666F5AE69E6DD41A4915268A4E4FB1FFBC9330B3526CD215AB32527D702F482D9B3B24139900D8F76195CA12608292D9A2AAFF98AFEE69AAAFDFB34C2EF801172DB1EF596D51B2E8A2E6CD10215DBBEAFAC4F33062FA9572519B6C6C5133D71E6AD13D658E2BF78E5CEB168DA0649226B10344A4568CADDF795A80524FC678F5B4D4A960B35A3546851482D1E8B6A943B5E9F01589664A021D32FE55708341B7E5ED8DD8651A53D662F2168D281ECB569E4555A193B6CBF151A56755ABE012056807D6F5EAA56242ABA15A1884514829B35D58CEF485594AA53B109394DA052FDE5B943EBDA0FF55B8C9A53DFBE68D26B8A7BF7C1A0690858A414AD862B4526291B924E89085D9CA4FAC344B97B7A742548E5FCCB2700D91D0F69AA8C6954B0BD42EA2D43515DCAD1A2E5EC6E9C2DFC25132DFBB5C4FBF4F7E79C02468096DD94D8B17656FE26CBE48E4A7160A8A5987E2914A1D7BA95A52A492C22C125CB9951ABF88962C6F5BB453907E15FA294084277B2D18A8FB7652B57496CAE8303C182FEC69B3C29C3E469A0FCEF4F4B4640C3D6DC253CC8AB0292459A4462804A8B73591B75B564074CF5996DD00EF6ECDF27AAEFCDF5E358B4FF00080C7A7653ACB4B0FB3FD7BAF5A9E35C73352BEEDB53F3AE0ED9DC968E4D3B79F4322637CE90587D78E7B8EABD01C92AB289C0A7842FCEF4F19B469ADEFAABEB312C3EA30DBB2954D3D56959593F24AA9FB03FBCBCD756DD82BAC23EAF48AAA40AF17EE2735AB7CC97397382A9FF00BDA14EB5D56C205D5D9EBCB2DBF2880B7976538B00A4BD0AE92D0ABFF0C1A56A527838AB5D56E72E4EED055B44CF7EF9EFF980269A454A2D3F05EE9EF328F75EB1BD5EBDCB040C942E5280A9524FF6B2ACF223821D94A05724E575B150A4B3C56C0E256735A3429084109A97F0B4692CF15EA092F5D8DDEF60555D9972DAECBAFF00081D25A29B002962B3CD71304947BADDAE18549639C45C59AC4ABE2C564843AA8D912A5507283052AD6A67B9760EDB28B05C325F030D7ED30DBA34C1F9C529AD6FAD5415A7441F5A0A7FBAD92669571BEB8D26E69402DEDD32764EFC2D3B52AE4EB6C0AABB5D8640FEF6A8E1B750B66042A8F45EBAC3DEB5A5A47EEE0195AAC5EBA36D4A172D28B2606A819EE3ACFBC495F8455AD814AD559C7AC2368D9F12CBA7DDA591A09779BED31A29DFA55506C1A496B1F986A884EEC9F64694B0D2505745B4291777CA0F50936067BF45288894ACAF7F8A587D019AD5AA19AAA6AC30187A456C21486B37CAF38200CB0FA520905BB1C38A5EF6044869D8A1F08F92C1CA6CB10D3D3FF52DC95734BA8853AA2AB9A746245C53DEF93D4D9613959E93F6FC5A0138F4526C3D2D79DA6093949A290ACB17681D7127F7526C9A572DC2B9EF312A10CD4A0D512B30BB2DBF2B1484968A6D3A09477B1EE21151AB6ECB668A3459F5CEC78A7CF997EF9B04ADAFCB6AE017E7DF33CF3832CACA8677155CC348A77B2D5820A1D94ECC97DEB642D73C07D323A8EAC3638C4FE2FD6D3034BE83E2F97E27C34BA2D8C7E83E2D5FFABC4F8297432EEEFDDEACD37A4D9A9E73E9D7EB270E5547EAFF001BCBF13E0A7D314FA4C0FABBC5F2BC4FFAE9FCAB63D59A66CD4F39F46B270E57F60F13CAF13FEBA43FD639F568FD03C5F2BC4F8297CB8F61552EA8D3366A79CFA3593872C1F40F17CAF13E0A7D16C11F42F17CAF13E0A5D57AF52699B353CFA3593872DFB1F89E5789F0D2E8F56D9AFB1F8BE5789F052BFF00A57F93750699B353CE7D1AC9C397FD8BC5F2A9FF00D74BE56D0FA1F8BE5789F0D2E5D73113D39A66CD4F39F46AE70E63F62F17CAF17E1A58287267EC7E2BFF00E3F13E0A49596F4D69A6CB4F3E8D5CE1CCBEC7E2795E27C14BE5C36C28C3E85E23BFE3F13E0A5F2A9DBD35A66CB4F39F46AE70E647E87E2D9E1789F0D24BE1D9FA1F8BE5F89F014AD6E94D34D929E73E8D64E1CCFEC7E2F974FE1A525CED0FD87C4F2FC4F82959FDADD2DA66C94739F46B270E69F62F17CBF13E1A5D97C4D0FA1F8BE5F883FB692F4C9BA5B4CD929E73E8D64E1CD7EC7E2797E27C14BA279846903E83E2F974FE0A53BE8857374B699B251CE7D1AC9C39A0FA0F8BE5789F0D2ED82E160FD0BC4F2E9FC14BA2D8F4C699B253CE7D1AC9C399FD87C4F2BC4F8297A1A2B663EC7E2F95E27C1492B6CE9AD3364A39CFA5D64E1CCBEC7E2FF2789F0D369BA6B4CD928E73E8D64E134D34DDE3E24D34D304D34D304D34D304D34D304D34D304D34D304D34D304D34D304D34D304D34D304D34D304D34D304D34D304D34D307FFFD9, NULL, 2, 2, 1, 0)
SET IDENTITY_INSERT [dbo].[Producto] OFF
SET IDENTITY_INSERT [dbo].[Proveedor] ON 

INSERT [dbo].[Proveedor] ([id], [cuil], [mail], [direccion], [razonSocial], [baja]) VALUES (1, N'300000001', N'javiermartingonzalez@gmail.com', N'Av Alberdi 3450', N'Mega Maderera', 0)
INSERT [dbo].[Proveedor] ([id], [cuil], [mail], [direccion], [razonSocial], [baja]) VALUES (2, N'300000002', N'javiermartingonzalez@gmail.com', N'Av. Juan b Justo 2345', N'TelasLocasSACICI', 0)
INSERT [dbo].[Proveedor] ([id], [cuil], [mail], [direccion], [razonSocial], [baja]) VALUES (3, N'2000000000', N'superfundas@gmail.com', N'Avenida Libertador 1000', N'SuperFund', 0)
SET IDENTITY_INSERT [dbo].[Proveedor] OFF
SET IDENTITY_INSERT [dbo].[Provincia] ON 

INSERT [dbo].[Provincia] ([id], [descripcion]) VALUES (1, N'CABA')
INSERT [dbo].[Provincia] ([id], [descripcion]) VALUES (2, N'Buenos Aires')
INSERT [dbo].[Provincia] ([id], [descripcion]) VALUES (3, N'Entre Rios')
INSERT [dbo].[Provincia] ([id], [descripcion]) VALUES (4, N'Santa Fe')
INSERT [dbo].[Provincia] ([id], [descripcion]) VALUES (5, N'Cordoba')
SET IDENTITY_INSERT [dbo].[Provincia] OFF
SET IDENTITY_INSERT [dbo].[Resguardo] ON 

INSERT [dbo].[Resguardo] ([id], [pathh], [descripcion], [fecha]) VALUES (1, N'C:\\Prueba\\Muebla1-9-2015-15-2-49.sql', N'pepe', NULL)
INSERT [dbo].[Resguardo] ([id], [pathh], [descripcion], [fecha]) VALUES (2, N'C:\\Prueba\\Muebla1-9-2015-15-6-0.sql', N'probando 2', NULL)
INSERT [dbo].[Resguardo] ([id], [pathh], [descripcion], [fecha]) VALUES (3, N'C:\\Prueba\\Muebla1-9-2015-15-11-38.sql', N'coco', NULL)
INSERT [dbo].[Resguardo] ([id], [pathh], [descripcion], [fecha]) VALUES (4, N'C:\\Prueba\\Muebla14-9-2015-0-2-29.sql', N'prueba con fecha', CAST(N'2015-09-14 00:02:30.603' AS DateTime))
SET IDENTITY_INSERT [dbo].[Resguardo] OFF
SET IDENTITY_INSERT [dbo].[Rol] ON 

INSERT [dbo].[Rol] ([id], [descripcion]) VALUES (1, N'Admin')
INSERT [dbo].[Rol] ([id], [descripcion]) VALUES (2, N'Usr')
INSERT [dbo].[Rol] ([id], [descripcion]) VALUES (3, N'Ventas')
INSERT [dbo].[Rol] ([id], [descripcion]) VALUES (4, N'Administrativo')
SET IDENTITY_INSERT [dbo].[Rol] OFF
INSERT [dbo].[RolComponente] ([idRol], [idComponente]) VALUES (1, 1)
INSERT [dbo].[RolComponente] ([idRol], [idComponente]) VALUES (1, 2)
INSERT [dbo].[RolComponente] ([idRol], [idComponente]) VALUES (1, 4)
INSERT [dbo].[RolComponente] ([idRol], [idComponente]) VALUES (1, 5)
INSERT [dbo].[RolComponente] ([idRol], [idComponente]) VALUES (1, 6)
INSERT [dbo].[RolComponente] ([idRol], [idComponente]) VALUES (1, 7)
INSERT [dbo].[RolComponente] ([idRol], [idComponente]) VALUES (1, 8)
INSERT [dbo].[RolComponente] ([idRol], [idComponente]) VALUES (1, 9)
INSERT [dbo].[RolComponente] ([idRol], [idComponente]) VALUES (1, 10)
INSERT [dbo].[RolComponente] ([idRol], [idComponente]) VALUES (1, 11)
INSERT [dbo].[RolComponente] ([idRol], [idComponente]) VALUES (1, 12)
INSERT [dbo].[RolComponente] ([idRol], [idComponente]) VALUES (1, 13)
INSERT [dbo].[RolComponente] ([idRol], [idComponente]) VALUES (1, 14)
INSERT [dbo].[RolComponente] ([idRol], [idComponente]) VALUES (1, 15)
INSERT [dbo].[RolComponente] ([idRol], [idComponente]) VALUES (1, 16)
INSERT [dbo].[RolComponente] ([idRol], [idComponente]) VALUES (1, 17)
INSERT [dbo].[RolComponente] ([idRol], [idComponente]) VALUES (1, 18)
INSERT [dbo].[RolComponente] ([idRol], [idComponente]) VALUES (1, 19)
INSERT [dbo].[RolComponente] ([idRol], [idComponente]) VALUES (1, 20)
INSERT [dbo].[RolComponente] ([idRol], [idComponente]) VALUES (1, 21)
INSERT [dbo].[RolComponente] ([idRol], [idComponente]) VALUES (1, 22)
INSERT [dbo].[RolComponente] ([idRol], [idComponente]) VALUES (1, 23)
INSERT [dbo].[RolComponente] ([idRol], [idComponente]) VALUES (1, 24)
INSERT [dbo].[RolComponente] ([idRol], [idComponente]) VALUES (1, 25)
INSERT [dbo].[RolComponente] ([idRol], [idComponente]) VALUES (2, 4)
INSERT [dbo].[RolComponente] ([idRol], [idComponente]) VALUES (2, 5)
INSERT [dbo].[RolComponente] ([idRol], [idComponente]) VALUES (2, 6)
INSERT [dbo].[RolComponente] ([idRol], [idComponente]) VALUES (2, 15)
INSERT [dbo].[RolComponente] ([idRol], [idComponente]) VALUES (2, 16)
INSERT [dbo].[RolComponente] ([idRol], [idComponente]) VALUES (2, 17)
INSERT [dbo].[RolComponente] ([idRol], [idComponente]) VALUES (2, 20)
INSERT [dbo].[RolComponente] ([idRol], [idComponente]) VALUES (3, 4)
INSERT [dbo].[RolComponente] ([idRol], [idComponente]) VALUES (3, 5)
INSERT [dbo].[RolComponente] ([idRol], [idComponente]) VALUES (3, 15)
INSERT [dbo].[RolComponente] ([idRol], [idComponente]) VALUES (3, 16)
INSERT [dbo].[RolComponente] ([idRol], [idComponente]) VALUES (3, 17)
INSERT [dbo].[RolComponente] ([idRol], [idComponente]) VALUES (4, 1)
INSERT [dbo].[RolComponente] ([idRol], [idComponente]) VALUES (4, 2)
INSERT [dbo].[RolComponente] ([idRol], [idComponente]) VALUES (4, 6)
INSERT [dbo].[RolComponente] ([idRol], [idComponente]) VALUES (4, 8)
INSERT [dbo].[RolComponente] ([idRol], [idComponente]) VALUES (4, 9)
INSERT [dbo].[RolComponente] ([idRol], [idComponente]) VALUES (4, 10)
INSERT [dbo].[RolComponente] ([idRol], [idComponente]) VALUES (4, 11)
INSERT [dbo].[RolComponente] ([idRol], [idComponente]) VALUES (4, 12)
INSERT [dbo].[RolComponente] ([idRol], [idComponente]) VALUES (4, 13)
INSERT [dbo].[RolComponente] ([idRol], [idComponente]) VALUES (4, 14)
INSERT [dbo].[RolComponente] ([idRol], [idComponente]) VALUES (4, 18)
INSERT [dbo].[RolComponente] ([idRol], [idComponente]) VALUES (4, 19)
INSERT [dbo].[RolComponente] ([idRol], [idComponente]) VALUES (4, 20)
SET IDENTITY_INSERT [dbo].[Telefono] ON 

INSERT [dbo].[Telefono] ([id], [idUsuario], [numero], [prefijo], [interno]) VALUES (2, 7, N'1535535353', N'1', N'1')
SET IDENTITY_INSERT [dbo].[Telefono] OFF
SET IDENTITY_INSERT [dbo].[TipoDocumento] ON 

INSERT [dbo].[TipoDocumento] ([id], [descripcion]) VALUES (1, N'DNI')
INSERT [dbo].[TipoDocumento] ([id], [descripcion]) VALUES (2, N'CI')
INSERT [dbo].[TipoDocumento] ([id], [descripcion]) VALUES (3, N'LE')
INSERT [dbo].[TipoDocumento] ([id], [descripcion]) VALUES (4, N'LC')
INSERT [dbo].[TipoDocumento] ([id], [descripcion]) VALUES (5, N'PAS')
SET IDENTITY_INSERT [dbo].[TipoDocumento] OFF
SET IDENTITY_INSERT [dbo].[TipoEvento] ON 

INSERT [dbo].[TipoEvento] ([id], [codigo]) VALUES (1, 1)
INSERT [dbo].[TipoEvento] ([id], [codigo]) VALUES (2, 2)
SET IDENTITY_INSERT [dbo].[TipoEvento] OFF
SET IDENTITY_INSERT [dbo].[TipoProducto] ON 

INSERT [dbo].[TipoProducto] ([id], [descripcion]) VALUES (1, N'Final')
INSERT [dbo].[TipoProducto] ([id], [descripcion]) VALUES (2, N'Materia Prima')
SET IDENTITY_INSERT [dbo].[TipoProducto] OFF
SET IDENTITY_INSERT [dbo].[TipoUsuario] ON 

INSERT [dbo].[TipoUsuario] ([id], [descripcion]) VALUES (1, N'Cliente')
INSERT [dbo].[TipoUsuario] ([id], [descripcion]) VALUES (2, N'Admin')
SET IDENTITY_INSERT [dbo].[TipoUsuario] OFF
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([id], [nombre], [apellido], [cuil], [dni], [mail], [idTipoUsuario], [baja], [usr], [pass], [idIdioma], [idTipoDocumento]) VALUES (2, N'jose', N'gonzalez', 0, 0, N'javiermartingonzalez@gmail.com', 1, 0, N'jose', N'pepe', 1, 1)
INSERT [dbo].[Usuario] ([id], [nombre], [apellido], [cuil], [dni], [mail], [idTipoUsuario], [baja], [usr], [pass], [idIdioma], [idTipoDocumento]) VALUES (3, N'admin', N'admin', 0, 0, N'javiermartingonzalez@gmail.com', 2, 0, N'admin', N'admin', 2, 1)
INSERT [dbo].[Usuario] ([id], [nombre], [apellido], [cuil], [dni], [mail], [idTipoUsuario], [baja], [usr], [pass], [idIdioma], [idTipoDocumento]) VALUES (7, N'Victoria', N'Di Giorgio', 20222222223, 2200000, N'victoriadigiorgio@gmail.com', 2, 0, N'bubia', N'bubia', 1, 1)
SET IDENTITY_INSERT [dbo].[Usuario] OFF
INSERT [dbo].[UsuarioRol] ([idUsuario], [idRol]) VALUES (2, 2)
INSERT [dbo].[UsuarioRol] ([idUsuario], [idRol]) VALUES (3, 1)
INSERT [dbo].[UsuarioRol] ([idUsuario], [idRol]) VALUES (7, 2)
ALTER TABLE [dbo].[AsistenciaShowroom]  WITH CHECK ADD  CONSTRAINT [FK_AsistenciaShowroom_Usuario] FOREIGN KEY([cliente])
REFERENCES [dbo].[Usuario] ([id])
GO
ALTER TABLE [dbo].[AsistenciaShowroom] CHECK CONSTRAINT [FK_AsistenciaShowroom_Usuario]
GO
ALTER TABLE [dbo].[Comentario]  WITH CHECK ADD  CONSTRAINT [FK_Comentario_Pedido] FOREIGN KEY([idPedido])
REFERENCES [dbo].[Pedido] ([id])
GO
ALTER TABLE [dbo].[Comentario] CHECK CONSTRAINT [FK_Comentario_Pedido]
GO
ALTER TABLE [dbo].[Componente]  WITH CHECK ADD  CONSTRAINT [FK_Componente_Componente] FOREIGN KEY([idComponente])
REFERENCES [dbo].[Componente] ([id])
GO
ALTER TABLE [dbo].[Componente] CHECK CONSTRAINT [FK_Componente_Componente]
GO
ALTER TABLE [dbo].[Comprobante]  WITH CHECK ADD  CONSTRAINT [FK_Comprobante_TipoComprobante] FOREIGN KEY([idTipoComprobante])
REFERENCES [dbo].[TipoComprobante] ([id])
GO
ALTER TABLE [dbo].[Comprobante] CHECK CONSTRAINT [FK_Comprobante_TipoComprobante]
GO
ALTER TABLE [dbo].[ComprobanteDetalle]  WITH CHECK ADD  CONSTRAINT [FK_ComprobanteDetalle_Comprobante] FOREIGN KEY([nroComprobante], [sucComprobante])
REFERENCES [dbo].[Comprobante] ([nroComprobante], [sucComprobante])
GO
ALTER TABLE [dbo].[ComprobanteDetalle] CHECK CONSTRAINT [FK_ComprobanteDetalle_Comprobante]
GO
ALTER TABLE [dbo].[ComprobanteDetalle]  WITH CHECK ADD  CONSTRAINT [FK_ComprobanteDetalle_ListaPrecioDetalle] FOREIGN KEY([idListaPrecio], [idListaPrecioDetalle])
REFERENCES [dbo].[ListaPrecioDetalle] ([idListaPrecio], [idListaPrecioDetalle])
GO
ALTER TABLE [dbo].[ComprobanteDetalle] CHECK CONSTRAINT [FK_ComprobanteDetalle_ListaPrecioDetalle]
GO
ALTER TABLE [dbo].[Domicilio]  WITH CHECK ADD  CONSTRAINT [FK_Domicilio_Localidad] FOREIGN KEY([idLocalidad])
REFERENCES [dbo].[Localidad] ([id])
GO
ALTER TABLE [dbo].[Domicilio] CHECK CONSTRAINT [FK_Domicilio_Localidad]
GO
ALTER TABLE [dbo].[Domicilio]  WITH CHECK ADD  CONSTRAINT [FK_Domicilio_Usuario] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuario] ([id])
GO
ALTER TABLE [dbo].[Domicilio] CHECK CONSTRAINT [FK_Domicilio_Usuario]
GO
ALTER TABLE [dbo].[IdiomaComponente]  WITH CHECK ADD  CONSTRAINT [FK_IdiomaComponente_Componente] FOREIGN KEY([idComponente])
REFERENCES [dbo].[Componente] ([id])
GO
ALTER TABLE [dbo].[IdiomaComponente] CHECK CONSTRAINT [FK_IdiomaComponente_Componente]
GO
ALTER TABLE [dbo].[IdiomaComponente]  WITH CHECK ADD  CONSTRAINT [FK_IdiomaComponente_Idioma] FOREIGN KEY([idIdioma])
REFERENCES [dbo].[Idioma] ([id])
GO
ALTER TABLE [dbo].[IdiomaComponente] CHECK CONSTRAINT [FK_IdiomaComponente_Idioma]
GO
ALTER TABLE [dbo].[ListaPrecioDetalle]  WITH CHECK ADD  CONSTRAINT [FK_ListaPrecioDetalle_ListaPrecio] FOREIGN KEY([idListaPrecio])
REFERENCES [dbo].[ListaPrecio] ([id])
GO
ALTER TABLE [dbo].[ListaPrecioDetalle] CHECK CONSTRAINT [FK_ListaPrecioDetalle_ListaPrecio]
GO
ALTER TABLE [dbo].[Localidad]  WITH CHECK ADD  CONSTRAINT [FK_Localidad_Provincia] FOREIGN KEY([idProvincia])
REFERENCES [dbo].[Provincia] ([id])
GO
ALTER TABLE [dbo].[Localidad] CHECK CONSTRAINT [FK_Localidad_Provincia]
GO
ALTER TABLE [dbo].[PedidoComprobante]  WITH CHECK ADD  CONSTRAINT [FK_PedidoComprobante_Pedido] FOREIGN KEY([idPedido])
REFERENCES [dbo].[Pedido] ([id])
GO
ALTER TABLE [dbo].[PedidoComprobante] CHECK CONSTRAINT [FK_PedidoComprobante_Pedido]
GO
ALTER TABLE [dbo].[PedidoListaPrecioDetalle]  WITH CHECK ADD  CONSTRAINT [FK_PedidoListaPrecioDetalle_Pedido] FOREIGN KEY([idPedido])
REFERENCES [dbo].[Pedido] ([id])
GO
ALTER TABLE [dbo].[PedidoListaPrecioDetalle] CHECK CONSTRAINT [FK_PedidoListaPrecioDetalle_Pedido]
GO
ALTER TABLE [dbo].[PedidoProducto]  WITH CHECK ADD  CONSTRAINT [FK_PedidoProducto_Pedido] FOREIGN KEY([idPedido])
REFERENCES [dbo].[Pedido] ([id])
GO
ALTER TABLE [dbo].[PedidoProducto] CHECK CONSTRAINT [FK_PedidoProducto_Pedido]
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_TipoProducto] FOREIGN KEY([idTipoProducto])
REFERENCES [dbo].[TipoProducto] ([id])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Producto_TipoProducto]
GO
ALTER TABLE [dbo].[ProveedorProducto]  WITH CHECK ADD  CONSTRAINT [FK_ProveedorProducto_Producto] FOREIGN KEY([idProducto])
REFERENCES [dbo].[Producto] ([id])
GO
ALTER TABLE [dbo].[ProveedorProducto] CHECK CONSTRAINT [FK_ProveedorProducto_Producto]
GO
ALTER TABLE [dbo].[ProveedorProducto]  WITH CHECK ADD  CONSTRAINT [FK_ProveedorProducto_Proveedor] FOREIGN KEY([idProveedor])
REFERENCES [dbo].[Proveedor] ([id])
GO
ALTER TABLE [dbo].[ProveedorProducto] CHECK CONSTRAINT [FK_ProveedorProducto_Proveedor]
GO
ALTER TABLE [dbo].[RolComponente]  WITH CHECK ADD  CONSTRAINT [FK_RolComponente_Componente] FOREIGN KEY([idComponente])
REFERENCES [dbo].[Componente] ([id])
GO
ALTER TABLE [dbo].[RolComponente] CHECK CONSTRAINT [FK_RolComponente_Componente]
GO
ALTER TABLE [dbo].[RolComponente]  WITH CHECK ADD  CONSTRAINT [FK_RolComponente_Rol] FOREIGN KEY([idRol])
REFERENCES [dbo].[Rol] ([id])
GO
ALTER TABLE [dbo].[RolComponente] CHECK CONSTRAINT [FK_RolComponente_Rol]
GO
ALTER TABLE [dbo].[Telefono]  WITH CHECK ADD  CONSTRAINT [FK_Telefono_Usuario] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuario] ([id])
GO
ALTER TABLE [dbo].[Telefono] CHECK CONSTRAINT [FK_Telefono_Usuario]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Idioma] FOREIGN KEY([idIdioma])
REFERENCES [dbo].[Idioma] ([id])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Idioma]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_TipoDocumento] FOREIGN KEY([idTipoDocumento])
REFERENCES [dbo].[TipoDocumento] ([id])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_TipoDocumento]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_TipoUsuario] FOREIGN KEY([idTipoUsuario])
REFERENCES [dbo].[TipoUsuario] ([id])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_TipoUsuario]
GO
ALTER TABLE [dbo].[UsuarioRol]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioRol_Usuario] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuario] ([id])
GO
ALTER TABLE [dbo].[UsuarioRol] CHECK CONSTRAINT [FK_UsuarioRol_Usuario]
GO
USE [master]
GO
ALTER DATABASE [Muebla] SET  READ_WRITE 
GO
