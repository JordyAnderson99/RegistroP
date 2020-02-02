CREATE DATABASE PersonasDb
GO
USE PersonasDb

CREATE TABLE Persona
(
 Id int primary key identity,
 PersonaId varchar(30),
 Telefono varchar(13),
 Comentario varchar(13),
 Monto varchar(13),
 Balance varchar(13),

);