/***Nos ponemos en master para poder borrar la base de datos si se creo anteriormente***/
USE master
GO
DROP DATABASE apuestasDeportivasApp
GO
/***Creamos la base de datos***/
CREATE DATABASE apuestasDeportivas

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
