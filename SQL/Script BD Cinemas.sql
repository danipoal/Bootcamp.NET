/*
1. Mostrar el nombre de todas las pel�culas,
2. Mostrar las distintas calificaciones de edad que existen,
3. Mostrar todas las pel�culas que no han sido calificadas,
4. Mostrar todas las salas que no proyectan pel�culas,
5. Mostrar la informaci�n de todas las salas, y si se proyecta alguna pel�cula en la
sala, mostrar tambi�n la informaci�n de la pel�cula,
6. Mostrar la informaci�n de todas las pel�culas, y si se proyecta en alguna sala,
mostrar tambi�n la informaci�n de la sala,
7. Mostrar los nombres de las pel�culas que no se proyectan en ninguna sala,
8. A�adir una nueva pel�cula �Uno, dos, tres� para mayores de 7 a�os,
9. Marcar todas las pel�culas no calificadas como calificadas �No recomendadas
para menores de 13 a�os�,
10.Eliminar todas las salas que proyectan pel�culas para todos los p�blicos.*/


--1
SELECT Nombre FROM PELICULAS;
--2
SELECT DISTINCT CalificacionEdad FROM PELICULAS;
--3
SELECT * FROM PELICULAS WHERE CalificacionEdad IS NULL;
--4
SELECT * FROM SALAS WHERE Pelicula IS NULL;
--5
SELECT S.*, P.* 
FROM SALAS S
LEFT OUTER JOIN PELICULAS P
ON S.Pelicula= P.Codigo;
--6
SELECT P.*,S.* 
FROM SALAS S
RIGHT JOIN PELICULAS P
ON S.Pelicula= P.Codigo;

--7 pELIS QUE NO SE PROYECTARON EN NINGUNA SALA

SELECT P.Nombre ,S.Pelicula 
FROM SALAS S
RIGHT JOIN PELICULAS P
ON S.Pelicula= P.Codigo
WHERE S.Pelicula IS NULL;
--8 

INSERT INTO PELICULAS(Nombre, CalificacionEdad) VALUES('Uno, dos, tres', 7);
--9

UPDATE PELICULAS 
SET CalificacionEdad = 13
FROM PELICULAS
WHERE CalificacionEdad IS NULL;
--10
/* TODO 
DELETE FROM SALAS
WHERE P.CalificacionEdad= 0
INNER JOIN PELICULAS P 
ON P.Codigo = SALAS.Pelicula; 

*/






--SCRIPT DE CREACI�N
CREATE TABLE PELICULAS
(
	Codigo int identity(1,1) CONSTRAINT CodigoPeli_PK PRIMARY KEY,
	Nombre nvarchar(100),
	CalificacionEdad int
)

CREATE TABLE SALAS
(
	Codigo int identity(1,1) CONSTRAINT Codigo_Salas_FK PRIMARY KEY,
	Nombre nvarchar(100),
	Pelicula int CONSTRAINT CodigoPeli_FK FOREIGN KEY REFERENCES PELICULAS (Codigo)
)

INSERT INTO PELICULAS VALUES
('Lobo de Wall Street',16),
('El Bueno, el feo y el malo', 7),
('Y se arm� la gorda', 7),
('Rambo', 16),
('Rambo II', 13),
('Rambo III', 16),
('Rocky I', 7),
('Rocky II', 7),
('Rocky III', 7),
('Rocky IV', 18),
('Rocky IV', null),
('Rocky V', 0)


INSERT INTO SALAS VALUES
('Yelmo Cast 1', 1),
('Yelmo Cast 2', 2),
('Yelmo Cast 3', 5),
('Yelmo Cast 4', 5),
('Yelmo Cast 5', 5),
('Yamagushi 1', 4),
('Yamagushi 2', 4),
('Yamagushi 3', 9),
('Yamagushi 4', 9),
('Yamagushi 5', 9),
('Yamagushi 6', 10),
('Yamagushi 7', null),
('Yelmo Gava 1', 12),
('Yelmo Gava 2', 12)
