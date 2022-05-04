/***Creamos la base de datos***/
create database apuestasDeportivasApp
/***Nos ponemos en la base de datos que creamos***/
use apuestasDeportivasApp

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