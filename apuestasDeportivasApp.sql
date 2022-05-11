/***Nos ponemos en master para poder borrar la base de datos si se creo anteriormente***/
USE master
GO
DROP DATABASE apuestasDeportivasApp
GO
/***Creamos la base de datos***/
CREATE DATABASE apuestasDeportivasApp

/***Creamos el administrador***/
GO
create login [RocioSeoane] with password='AbCdEf84',
default_database=[apuestasDeportivasApp]
use[apuestasDeportivasApp]

GO
create user [RocioSeoane] for login[RocioSeoane]
use[apuestasDeportivasApp]
alter role[db_owner]add member[RocioSeoane]

/***Creamos las tablas necesarias con sus atributos y relaciones correspondientes***/
create table usuarios(
	id_usuario int identity(1,1) primary key,
	nombre varchar(255) not null,
	clave varchar(255) not null,
	saldo decimal(10,2) not null
)
--Identity significa que es autoincremental
--Primary key significa que es la clave primaria
--Not null significa que no puede estar vacío

create table tipoEventos(
	id_tipoEvento int identity(1,1) primary key,
	nombre varchar(255) not null,
	descripcion varchar(255)
)

create table eventos(
	id_evento int identity(1,1) primary key,
	nombre varchar(255) not null,
	fecha datetime not null,
	id_tipoEvento int not null references tipoEventos(id_tipoEvento)
)
--References significa que hace referencia a la clave primaria de otra tabla, clave foranea

create table tipoTransacciones(
	id_tipoTransaccion int identity(1,1) primary key,
	nombre varchar(255) not null unique,
	descripcion varchar(255)
)
--Unique significa que no puede haber mas de una igual

create table transacciones(
	id_transaccion int identity(1,1) primary key,
	fecha datetime not null,
	saldo_inicial decimal(10,2) not null,
	cantidad decimal(10,2) not null,
	id_usuario int not null references usuarios(id_usuario),
	id_tipoTransaccion int not null references tipoTransacciones(id_tipoTransaccion)
)

create table opciones(
	id_opcion int identity(1,1) primary key,
	nombre varchar(255) not null,
	multiplicador decimal(10,2) not null,
	ganador bit,
	id_evento int not null references eventos(id_evento)
)

create table apuestas(
	id_apuesta int identity(1,1) primary key,
	fecha datetime not null,
	cantidad decimal(10,2) not null,
	multiplicador decimal(10,2) not null,
	ganador bit,
	id_usuario int not null references usuarios(id_usuario),
	id_opcion int not null references opciones(id_opcion),
	id_TransaccionC int references transacciones(id_transaccion),
	id_TransaccionP int references transacciones(id_transaccion)
)

--Creamos una tabla para controlar los codigos de error que se puedan dar
CREATE TABLE codigos(
	codigo int not null,
	descripcion varchar(255) not null
)

/***Insertamos datos***/
--Dejamos los datos maestros, datos que son comunes
INSERT INTO tipoTransacciones(nombre, descripcion) VALUES ('Ingreso', 'Ingreso externo')
INSERT INTO tipoTransacciones(nombre, descripcion) VALUES ('Retirada', 'Retirada externa')
INSERT INTO tipoTransacciones(nombre, descripcion) VALUES ('Apuesta realizada', 'Retirada interna')
INSERT INTO tipoTransacciones(nombre, descripcion) VALUES ('Apuesta ganada', 'Ingreso interno')

select * from tipoTransacciones

INSERT INTO codigos(codigo, descripcion) VALUES (0, 'Correcto')
INSERT INTO codigos(codigo, descripcion) VALUES (1, 'Usuario ya registrado')
INSERT INTO codigos(codigo, descripcion) VALUES (2, 'Datos incorrectos')
INSERT INTO codigos(codigo, descripcion) VALUES (3, 'Error interno')

select * from codigos

/*INSERT INTO usuarios(nombre, clave, saldo) VALUES ('Pepe', '142536pepe', 400.8)
INSERT INTO usuarios(nombre, clave, saldo) VALUES ('María', '875123maria', 30)

select * from usuarios

INSERT INTO tipoEventos(nombre, descripcion) VALUES ('Tenis', 'Semifinales')
INSERT INTO tipoEventos(nombre) VALUES ('F1')

select * from tipoEventos

INSERT INTO eventos(nombre, fecha, id_tipoEvento) VALUES ('Albert Park', '2022-04-10T07:00:00', 2)
INSERT INTO eventos(nombre, fecha, id_tipoEvento) VALUES ('Wimbledon Londres', '2022-07-21T18:00:00', 1)

select * from eventos

INSERT INTO transacciones(fecha, saldo_inicial, cantidad, id_usuario, id_tipoTransaccion) VALUES ('2022-04-05T19:51:36', 400.8, 25, 1, 2)
INSERT INTO transacciones(fecha, saldo_inicial, cantidad, id_usuario, id_tipoTransaccion) VALUES ('2022-04-09T00:05:36', 30, 25, 2, 3)
INSERT INTO transacciones(fecha, saldo_inicial, cantidad, id_usuario, id_tipoTransaccion) VALUES ('2022-04-10T18:00:32', 5, 300, 2, 4)

select * from transacciones

INSERT INTO opciones(nombre, multiplicador, id_evento) VALUES ('Leclerc', 2, 1)
INSERT INTO opciones(nombre, multiplicador, id_evento) VALUES ('Sainz', 3, 1)
INSERT INTO opciones(nombre, multiplicador, id_evento) VALUES ('Verstappen', 4, 1)
INSERT INTO opciones(nombre, multiplicador, id_evento) VALUES ('Russell', 5, 1)
INSERT INTO opciones(nombre, multiplicador, id_evento) VALUES ('Hamilton', 6, 1)
INSERT INTO opciones(nombre, multiplicador, id_evento) VALUES ('Ocon', 7, 1)
INSERT INTO opciones(nombre, multiplicador, id_evento) VALUES ('Magnussen', 8, 1)
INSERT INTO opciones(nombre, multiplicador, id_evento) VALUES ('Prez', 8, 1)
INSERT INTO opciones(nombre, multiplicador, id_evento) VALUES ('Bottas', 9, 1)
INSERT INTO opciones(nombre, multiplicador, id_evento) VALUES ('Norris', 10, 1)
INSERT INTO opciones(nombre, multiplicador, id_evento) VALUES ('Tsunoda', 11, 1)
INSERT INTO opciones(nombre, multiplicador, id_evento) VALUES ('Gasly', 11, 1)
INSERT INTO opciones(nombre, multiplicador, id_evento) VALUES ('Alonso', 12, 1)
INSERT INTO opciones(nombre, multiplicador, id_evento) VALUES ('Zhou', 13, 1)
INSERT INTO opciones(nombre, multiplicador, id_evento) VALUES ('Schumacher', 14, 1)
INSERT INTO opciones(nombre, multiplicador, id_evento) VALUES ('Stroll', 14, 1)
INSERT INTO opciones(nombre, multiplicador, id_evento) VALUES ('Albon', 14, 1)
INSERT INTO opciones(nombre, multiplicador, id_evento) VALUES ('Ricciardo', 14, 1)
INSERT INTO opciones(nombre, multiplicador, id_evento) VALUES ('Latifi', 14, 1)
INSERT INTO opciones(nombre, multiplicador, id_evento) VALUES ('Shulkenberg', 14, 1)
INSERT INTO opciones(nombre, multiplicador, id_evento) VALUES ('Nadal', 7, 2)
INSERT INTO opciones(nombre, multiplicador, id_evento) VALUES ('Swiatek', 2, 2)

select * from opciones

INSERT INTO apuestas(fecha, cantidad, multiplicador, id_usuario, id_opcion, id_TransaccionC, id_TransaccionP) VALUES ('2022-04-09T00:05:38', 25, 12, 2, 13, 2, 3)

select * from apuestas*/

/***Creamos los procedimientos***/
/**Todo tipo de usuarios**/
GO
CREATE PROCEDURE registrar
	@nombre varchar(255), @clave varchar(255)
as
	declare @usuario varchar(255)

	select @usuario = count(*) from usuarios where nombre = @nombre
	if @usuario > 0 --@usuario =1 para error de codigo 1
		select * from codigos where codigo=1

	else
		begin
			INSERT INTO usuarios(nombre, clave, saldo) values (@nombre, @clave, 0)--al registrarse tienen saldo = 0
			select * from codigos where codigo = 0
		end

exec registrar 'Rocio', 'abcde1'
select * from usuarios

GO
CREATE PROCEDURE logear
	@nombre varchar(255), @clave varchar(255)
as
	declare @usuario varchar(255)

	select @usuario = count(*) from usuarios where nombre=@nombre and clave=@clave
	--if @usuario>1 or @usuario<1
	--	select * from codigos where codigo=2
	--else
	--	begin
	--		select * from codigos where codigo=0
			select id_usuario, nombre from usuarios where nombre=@nombre and clave=@clave
	--	end

exec logear 'Rocio', 'abcde1'
exec logear 'pepe', 'abcdee'

/**Usuarios normales**/
GO
CREATE PROCEDURE ingresarTransaccion
	@cantidad decimal(10,2), @id_usuario int
as
	declare @saldoInicial decimal(10,2)
	declare @saldo decimal(10,2)
	set @saldo=0
	begin tran
		select @saldoInicial = saldo from usuarios where id_usuario = @id_usuario
		insert into transacciones(fecha, saldo_inicial, cantidad, id_usuario, id_tipoTransaccion) values (GETDATE(), @saldoInicial, @cantidad, @id_usuario, 1)
		set @saldo=@saldoInicial+@cantidad
		update usuarios set saldo=@saldo where id_usuario=@id_usuario

	if @@ERROR=0
		begin
			commit
			select * from codigos where codigo=0
		end
	else
		begin
			rollback
			select * from codigos where codigo=3
		end

exec ingresarTransaccion 50, 1
select * from transacciones
select * from usuarios

GO
CREATE PROCEDURE retirarTransaccion
	@cantidad decimal(10,2), @id_usuario int
as
	declare @saldoInicial decimal(10,2)
	declare @saldo decimal(10,2)
	set @saldo=0
	begin tran
		select @saldoInicial=saldo from usuarios where id_usuario=@id_usuario
		if @saldoInicial<@cantidad
			begin
				rollback
				select * from codigos where codigo=2
			end
		else
			begin
				insert into transacciones(fecha, saldo_inicial, cantidad, id_usuario, id_tipoTransaccion) values (GETDATE(), @saldoInicial, @cantidad, @id_usuario, 2)
				set @saldo=@saldoInicial-@cantidad
				update usuarios set saldo=@saldo where id_usuario=@id_usuario
				if @@ERROR=0
					begin
						commit
						select * from codigos where codigo=0
					end
				else
					begin
						rollback
						select * from codigos where codigo=3
					end
			end

exec retirarTransaccion 10, 1
select * from transacciones
select * from usuarios

GO
CREATE PROCEDURE hacerApuesta
	@cantidad decimal(10,2), @id_usuario int, @id_evento int, @id_opcion int
as
	declare @saldoInicial decimal(10,2)
	declare @saldo decimal(10,2)
	declare @fecha datetime
	declare @fecha_evento datetime
	declare @multiplicador decimal(10,2)
	declare @id_transaccion int
	set @saldo=0
	set @fecha=GETDATE()
	begin tran
		select @saldoInicial=saldo from usuarios where id_usuario=@id_usuario
		select @fecha_evento=fecha from eventos where id_evento = @id_evento
		if @saldoInicial<@cantidad or @fecha_evento<@fecha
			begin
				rollback
				select * from codigos where codigo=2
			end
		else
			begin
				select @multiplicador=multiplicador from opciones where id_opcion=@id_opcion
				insert into transacciones(fecha, saldo_inicial, cantidad, id_usuario, id_tipoTransaccion) values (@fecha, @saldoInicial, @cantidad, @id_usuario, 4)
				select @id_transaccion=@id_transaccion from transacciones where id_usuario=@id_usuario
				insert into apuestas(fecha, cantidad, multiplicador, id_usuario, id_opcion, id_TransaccionP) values (@fecha, @cantidad, @multiplicador, @id_usuario, @id_opcion, @id_transaccion)
				set @saldo=@saldoInicial-@cantidad
				update usuarios set saldo=@saldo where id_usuario=@id_usuario

				if @@ERROR=0
					begin
						commit
						select * from codigos where codigo=0
					end
				else
					begin
						rollback
						select * from codigos where codigo=3
					end
			end

exec hacerApuesta 30, 1, 2, 1
select * from apuestas
select * from transacciones
select * from usuarios

GO
CREATE PROCEDURE apuestaGanada
	@id_evento int, @id_opcion int
as
	declare @saldoInicial decimal(10,2)
	declare @saldo decimal(10,2)
	declare @saldoFinal decimal(10,2)
	declare @multiplicador decimal(10,2)
	declare @id_transaccion int
	declare @id_usuario int
	declare @ganado bit
	declare @cantidad decimal(10,2)

	select @multiplicador=multiplicador from apuestas where id_opcion=@id_opcion
	select @id_usuario=id_usuario from apuestas where id_opcion=@id_opcion
	select @saldoInicial=saldo from usuarios where id_usuario=@id_usuario
	select @cantidad=cantidad from apuestas where id_usuario=@id_usuario and id_opcion=@id_opcion

	begin tran
		if @multiplicador>0
			begin
				set @saldo=@saldoInicial*@multiplicador
				set @saldoFinal=@cantidad*@multiplicador
				insert into transacciones (fecha, saldo_inicial, cantidad, id_usuario, id_tipoTransaccion) values (GETDATE(), @saldoInicial, @saldoFinal, @id_usuario, 3)
				select @id_transaccion=id_transaccion from transacciones where id_usuario=@id_usuario
				update apuestas set ganador=1, id_TransaccionC=@id_transaccion where id_usuario=@id_usuario and id_opcion=@id_opcion
				update opciones set ganador=1 where id_evento=@id_opcion
				update opciones set ganador=0 where id_opcion!=@id_opcion
				update usuarios set saldo=@saldoInicial+@cantidad where id_usuario=@id_usuario
				commit
				select * from codigos where codigo=0
			end
		else
			select * from codigos where codigo=2

exec apuestaGanada 1, 2
select * from apuestas
select * from usuarios
select * from opciones
select * from transacciones

/**Administradores**/
GO
CREATE PROCEDURE insertarTipoEventos
	@nombre varchar(255), @descripcion varchar(255)
as
	begin tran
		insert into tipoEventos(nombre, descripcion) values (@nombre, @descripcion)
		if @@ERROR=0
			begin
				commit
				select * from codigos where codigo=0
			end
		else
			begin
				rollback
				select * from codigos where codigo=3
			end

exec insertarTipoEventos 'Futbol', 'Clasico'
select * from tipoEventos

GO
CREATE PROCEDURE insertarEventos
	@nombre varchar(255), @fecha datetime, @id_tipoEvento int
as
	begin tran
		insert into eventos(nombre, fecha, id_tipoEvento) values (@nombre, @fecha, @id_tipoEvento)
		if @@ERROR=0
			begin
				commit
				select * from codigos where codigo=0
			end
		else
			begin
				rollback
				select * from codigos where codigo=3
			end

exec insertarEventos 'Futbol', '2022-05-27T21:02:00', 1
select * from eventos
select * from tipoEventos

GO
CREATE PROCEDURE insertarOpciones
	@nombre varchar(255), @multiplicador decimal(10,2), @id_evento int
as
	begin tran
		insert into opciones(nombre, multiplicador, id_evento) values (@nombre, @multiplicador, @id_evento)
		if @@ERROR=0
			begin
				commit
				select * from codigos where codigo=0
			end
		else
			begin
				rollback
				select * from codigos where codigo=3
			end

exec insertarOpciones 'Madrid', 3, 1
exec insertarOpciones 'Barça', 2, 1
select * from eventos
select * from opciones

/**Procedimientos para mostrar datos**/
GO
CREATE PROCEDURE mostrarEventos
as
	select * from eventos

exec mostrarEventos

GO
CREATE PROCEDURE mostrarTransacciones
	@id_usuario int
as
	select * from transacciones where id_usuario=@id_usuario

exec mostrarTransacciones 1

GO
CREATE PROCEDURE mostrarApuestas
	@id_usuario int
as
	select * from apuestas where id_usuario=@id_usuario

exec mostrarApuestas 1

GO
CREATE PROCEDURE mostrarOpcionesEvento
	@id_evento int
as
	select * from opciones where id_evento=@id_evento

exec mostrarOpcionesEvento 1

GO
CREATE PROCEDURE mostrarTipoEventos
as
	select * from tipoEventos

exec mostrarTipoEventos
