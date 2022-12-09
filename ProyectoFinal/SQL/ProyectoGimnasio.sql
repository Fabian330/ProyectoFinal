
create database Gimnasio

use Gimnasio

create table Clientes
(
	CodigoCl int identity(1,1),
	Email nvarchar(100),
	Clave nvarchar(50),
	Tipo nvarchar (50),
	NombreCl nvarchar(50),
	Apellido nvarchar(50),
	Telefono int,
	constraint PK_CodigoCl primary key (CodigoCl)
)

create table Rutina
(
CodigoR int identity(1,1),
Rutina varchar(50),
constraint PK_CodigoR primary key (CodigoR)
)

create table RutinaA
(
Cod int identity(1,1),
CodigoRutina int,
CodigoCli int,
constraint PK_Cod primary key (Cod),
constraint FK_CodigoRutina foreign key (CodigoRutina) references Rutina (CodigoR),
constraint FK_CodigoCli foreign key (CodigoCli) references Clientes (CodigoCl)
)

create table Producto
(
	CodigoPr int identity(1,1),
	NombrePr nvarchar(100),
	Precio float,
	constraint PK_CodigoPr primary key (CodigoPr)
)

create table Mae_Factura
(
	Nfactura int identity(1000,1),
	Fecha date constraint def_fecha default getdate(),
	Codigo_Client int,
	Total float,
	IV_Total float,
	constraint PK_Nfactura primary key (Nfactura),
	constraint FK_Codigo_Client foreign key (Codigo_Client) references Clientes (CodigoCl)
)

create table Direcciones
(
	CodigoDirec int identity(1,1),
	Codigo_Cliente int,
	Provincia varchar(50),
	Canton varchar(50),
	Distrito varchar(50),
	constraint PK_CodigoDirec primary key (CodigoDirec),
	constraint FK_Codigo_Cliente foreign key (Codigo_Cliente) references Clientes (CodigoCl)
)

create table Det_Factura
(
	CodigoDF int identity (1,1),
	Nfactura int,
	Codigo_Producto int,
	Cantidad int,
	Precio_Unitario float,
	IV float,
	constraint PK_CodigoDF primary key (CodigoDF),
	constraint FK_Nfactura foreign key (Nfactura) references Mae_Factura (Nfactura),
	constraint FK_Codigo_Producto foreign key (Codigo_Producto) references Producto (CodigoPr)
)

-- Login

create procedure ValidarUsuario
@Email varchar(30),
@Clave varchar(30)
as
	begin
		select * from Clientes where Email = @Email and Clave = @Clave
	end

exec ValidarUsuario 'jose@uh.cr', '123'

-- Clientes

create procedure ConsultaUsuarios
as
	begin
		select c.CodigoCl, c.NombreCl, c.Apellido, c.Telefono, c.Email, c.Tipo from Clientes c
	end

exec ConsultaUsuarios

create procedure IngresarCliente
@Email varchar(30),
@Clave varchar(30),
@Tipo varchar(50),
@NombreCl varchar(50),
@Apellido varchar(50),
@Telefono varchar(30)
as
	begin
		insert into Clientes(Email, Clave, Tipo, NombreCl, Apellido, Telefono) values (@Email, @Clave, @Tipo, @NombreCl, @Apellido, @Telefono)
	end

exec IngresarCliente 'jose@uh.cr', '123', 'Administrador', 'Jose', 'Cruz', 82738472
exec IngresarCliente 'pedro@uh.cr', '222', 'Cliente', 'Pedro', 'Soto', 82934824
exec ConsultaUsuarios

create procedure BorrarCliente
@CodigoCl varchar(10)
as
	begin
		delete Clientes where CodigoCl = @CodigoCl
	end

exec BorrarCliente 2
exec ConsultaUsuarios

create procedure ActualizarUsuario
@CodigoCl varchar(10),
@Email varchar(30),
@Clave varchar(30),
@Tipo varchar(50),
@NombreCl varchar(50),
@Apellido varchar(50),
@Telefono varchar(30)
as
	begin
		update Clientes set Email = @Email, Clave = @Clave, Tipo = @Tipo, NombreCl = @NombreCl, Apellido = @Apellido, Telefono = @Telefono where CodigoCl = @CodigoCl
	end

exec ActualizarUsuario 3, 'Luis@uh.cr', '4321', 'Administrador', 'Adrian', 'Mora', 82838485
exec ConsultaUsuarios

-- Productos

create procedure ConsultaProducto
as
	begin
		select * from Producto
	end

exec ConsultaProducto

create procedure IngresarProducto
@NombrePr varchar(30),
@Precio int
as
	begin
		insert into Producto(NombrePr, Precio) values (@NombrePr, @Precio)
	end

exec IngresarProducto'Proteina', 5000
exec IngresarProducto'Camisa', 3000
exec ConsultaProducto

create procedure BorrarProducto
@CodigoPr varchar(10)
as
	begin
		delete Producto where CodigoPr = @CodigoPr
	end

exec BorrarProducto 2
exec ConsultaProducto

create procedure ActualizarProducto
@CodigoPr varchar(10),
@NombrePr varchar(30),
@Precio int
as
	begin
		update Producto set NombrePr = @NombrePr, Precio = @Precio where CodigoPr = @CodigoPr
	end

exec ActualizarProducto 3, 'Zapatos', 10000 
exec ConsultaProducto

-- Factura

create procedure MaeFactura
 
  @CodigoClient varchar(10),
  @Total money
  as 

  begin
  DECLARE @FECHA datetime
  SET @fecha = GETDATE()
    insert into Mae_Factura(Fecha,Codigo_Client,Total) values (@FECHA,@CodigoClient,@Total)
  end

create procedure DetFactura
@CodigoDF int,
@Codigo_Producto int,
@Cantidad int,
@Precio_Unitario money
as 
  
begin
    Declare @Nfactura int
	set @Nfactura = (select top 1 Nfactura from Mae_factura order by Nfactura desc)
    insert into Det_Factura(CodigoDF, Nfactura,Codigo_Producto,Cantidad,Precio_Unitario) values (@CodigoDF, @Nfactura,@Codigo_Producto,@Cantidad,@Precio_Unitario)
end

create procedure selecproducto
@NombrePr varchar(50),
@CodigoPr int
as 
 begin 
 select CodigoPr,NombrePr, precio from producto where CodigoPr = @CodigoPr
end

-- Rutinas

create procedure ConsultaRutina
as
	begin
		select * from Rutina
	end
exec ConsultaRutina

create procedure IngresarRutina
@NombreR varchar(50)
as
	begin
		insert into Rutina(Rutina) values (@NombreR)
	end

create procedure BorrarRutina
@CodigoR varchar(10)
as
	begin
		delete Rutina where CodigoR = @CodigoR
	end

create procedure ActualizarRutina
@NombreR varchar(50),
@CodigoR varchar(10)
as
	begin
		update Rutina set Rutina = @NombreR where CodigoR = @CodigoR
	end

create procedure RutinaAsignada
as
	begin
		select ra.Cod, c.NombreCl, c.Apellido, r.Rutina 
		from RutinaA ra
		inner join Rutina r on r.CodigoR = ra.CodigoRutina
		inner join Clientes c on c.CodigoCl = ra.CodigoCli
	end
exec RutinaAsignada

create procedure AsignarRutina
@CodigoRutina varchar(10),
@CodigoCli varchar(10)
as
	begin
		insert into RutinaA (CodigoRutina, CodigoCli ) values (@CodigoRutina, @CodigoCli)
	end

exec AsignarRutina 1, 1

create procedure QuitarRutina
@Cod varchar(10)
as
	begin
		delete RutinaA where Cod = @Cod
	end
exec QuitarRutina 1

-- Direcciones

create procedure ConsultaDireccion
as
	begin
		select d.CodigoDirec, c.CodigoCl, c.NombreCl, c.Apellido, d.Provincia, d.Canton, d.Distrito 
		from Direcciones d
		inner join Clientes c on c.CodigoCl = d.Codigo_Cliente
	end
exec ConsultaDireccion

create procedure IngresarDireccion
@Codigo_Cliente varchar(10),
@Provincia varchar(50),
@Canton varchar(50),
@Distrito varchar(50)
as
	begin
		insert into Direcciones(Codigo_Cliente,Provincia,Canton,Distrito) values (@Codigo_Cliente,@Provincia,@Canton,@Distrito)
	end

create procedure BorrarDireccion
@CodigoDirec varchar(10)
as
	begin
		delete Direcciones where CodigoDirec = @CodigoDirec
	end

create procedure ActualizarDireccion
@CodigoDirec varchar(10),
@Codigo_Cliente varchar(10),
@Provincia varchar(50),
@Canton varchar(50),
@Distrito varchar(50)
as
	begin
		update Direcciones set Codigo_Cliente = @Codigo_Cliente, Provincia = @Provincia, Canton = @Canton, Distrito = @Distrito where CodigoDirec = @CodigoDirec
	end