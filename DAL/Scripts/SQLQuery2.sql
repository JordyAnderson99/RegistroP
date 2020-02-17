CREATE DATABASE PersonasDb
GO
USE PersonasDb
go

CREATE TABLE Persona
(
 Id int primary key identity,
 Nombre varchar(30),
 Fecha Date default GetDate(),
 Comentario varchar(13),
 Monto decimal,
 Pago decimal,
 Balance decimal,
);

drop table Persona