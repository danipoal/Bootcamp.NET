
--Introducir en una nueva tabla todos los valores seleccionados de otras tablas
	--Para crear la tabla SELECT INTO(Se introducen valores de la tabla referenciada) y luego INSERT INTO
USE AriEmployees;

SELECT CONCAT(first_name, ' ', last_name) as 'Nombre', 'Employee' as 'Type'  INTO personsDani
	FROM employees


INSERT INTO personsDani 
	SELECT CONCAT(first_name,' ', last_name) as 'Nombre', 'Dependant' as 'Type'
		FROM dependents

------------------------------------------

--Para modificar valores de columnas
UPDATE Tabla 
	SET columna = 'a' + columna    --Se le añade a a todas las filas
								   --Añadimos un where para filtrar

	--Modificar multiples valores (Separar por comas, pero el SET solo 1 vez)
UPDATE Tabla 
	SET columna = 'a' + columna,
		columna2= 'j' + columna2
WHERE columna2 LIKE 'T*'
-------------------------------------------------------------------

--Actualizar en tabla employees todos los empleados que su departamento empiece por T
--Hay dos maneras, con subquerry o con JOIN

UPDATE employees
	SET first_name = '*' + first_name
	WHERE department_id = (SELECT department_id
	FROM departments d
	WHERE d.department_name LIKE  'M%')

--Es lo mismo
UPDATE employees
	SET first_name = '*' + first_name
	FROM employees INNER JOIN departments
ON employees.department_id = departments.department_id
WHERE department_name LIKE 'T%'
-------------------------------------
--Eliminar personas que empiecen por T (como ahora empiezan por * pues buscamos eso)
DELETE FROM Personas
WHERE first_name LIKE '*%'


DELETE e 
	FROM employees e INNER JOIN departments d
ON e.department_id = d.department_id
WHERE department_name LIKE 'T%'

---------------------------------------------------------

--Num emp un dept
SELECT COUNT(*) FROM employees
WHERE department_id = 6;

--num emp por dept
SELECT department_name, COUNT(*)FROM employees e
	INNER JOIN departments d
	ON e.department_id = d.department_id
GROUP BY d.department_name;
	--PROBLEMA: Aqui si agrupas por nombres en vez id, puede haber problemas de duplicado por si hay dos dept
	-- que se llamen igual pero son diferentes en verdad, los va a tratar como iguales
	--SOLUCION: AÑADIR en el GROUP BY tambien la regla mas fuerte, 
	--  [GROUP BY department_name, department_id] por 2 valores


-- Hacer emps por location

SELECT l.city, COUNT(*) FROM employees e
	INNER JOIN departments d
		ON e.department_id = d.department_id
	INNER JOIN locations l
		ON d.location_id = l.location_id
GROUP BY l.location_id, l.city
-----------------------------
--PRACTICA
--nombre dept +3 empleados

SELECT d.department_name, COUNT(*) AS 'S' 
FROM employees e
	INNER JOIN departments d
		ON e.department_id = d.department_id
GROUP BY d.department_id, d.department_name
HAVING COUNT(*) > 3

	--Con subquerrys




--n empleados en depts que empiecen por S
SELECT d.department_name, COUNT(*) AS 'S' 
FROM employees e
	INNER JOIN departments d
		ON e.department_id = d.department_id
		WHERE d.department_name LIKE 'S%'
GROUP BY d.department_id, d.department_name



--De la bd vuelos
USE DaniVuelos;

--Total asientos ocupados en cada clase para un vuelo     ERROR, no es correcto
SELECT ta.NombreTipo, COUNT(*) AS 'Asientos ocupados'
FROM Reserva r
	INNER JOIN Vuelo v
		ON r.FkIdVuelo = v.IdVuelo
	INNER JOIN Vuelo_TipoAsiento vta
		ON v.IdVuelo = vta.FkIdVuelo
	INNER JOIN TipoAsiento ta
		ON vta.FkIdTipoAsiento = ta.IdTipoAsiento
WHERE v.IdVuelo = 6
GROUP BY vta.FkIdTipoAsiento, ta.NombreTipo


--Num de vuelos por destino
SELECT a.Lugar, COUNT(*) as 'Nº vuelos'
FROM Vuelo v
	INNER JOIN Trayecto t
		ON v.FkIdTrayecto = t.IdTrayecto
	INNER JOIN Aeropuerto a
		ON t.FkIdDestino = a.IdAeropuerto
GROUP BY t.FkIdDestino, a.Lugar


--num pilotos que han sido copilotos

SELECT COUNT(*) AS NumeroPilotos
FROM (
	SELECT p.Nombre
	FROM Piloto p
	INNER JOIN Vuelo v
	ON p.IdPiloto = v.FkIdPiloto
INTERSECT
	SELECT p.Nombre
	FROM Piloto p
	INNER JOIN Vuelo v
		ON p.IdPiloto = v.FkIdCopiloto
) as Numeropilotos
	
	--Otra manera:
SELECT COUNT(DISTINCT p.IdPiloto)
	FROM Piloto p
		INNER JOIN Vuelo v
	ON p.IdPiloto = v.FkIdPiloto
		INNER JOIN Vuelo v2
		ON p.IdPiloto = v2.FkIdCopiloto;
	--Otra manera

-- FUNCIONES Y PROCEDIMIENTOS
CREATE FUNCTION FechaHoy()
RETURNS DATE
BEGIN 
	
	RETURN GETDATE();

END

SELECT dbo.FechaHoy();

