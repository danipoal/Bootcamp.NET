-- Lista de vuelos con nombre de co/piloto, ordenados por fecha

SELECT v.*, p.Nombre as 'Piloto', cp.Nombre as 'Copiloto'
FROM Vuelo v
INNER JOIN Piloto p
ON v.FkIdPiloto = p.IdPiloto
INNER JOIN Piloto cp
ON v.FkIdCopiloto = cp.IdPiloto
ORDER BY v.Fecha

-- Num. de pasajeros en un vuelo concreto

SELECT r.FkIdVuelo as 'IdVuelo' , COUNT(*) as 'Num. Pasajeros'
FROM Vuelo v
INNER JOIN Reserva r
ON v.IdVuelo = r.FkIdVuelo
GROUP BY r.FkIdVuelo;

-- Lista de co/pilotos que no vuelan
SELECT * 
FROM Piloto p
LEFT JOIN Vuelo v
ON p.IdPiloto = v.FkIdPiloto  
WHERE v.FkIdPiloto IS NULL
	OR v.FkIdCopiloto IS NULL;

-- Nombres de co/pilotos que hayan volado a Sevilla (Es que a madrid no tenia ninguno)

SELECT p.*, a.Lugar as 'Destino'
FROM Piloto p
INNER JOIN Vuelo v
ON p.IdPiloto = v.FkIdPiloto
INNER JOIN Trayecto t
ON t.IdTrayecto = v.FkIdTrayecto
INNER JOIN Aeropuerto a
ON t.FkIdDestino = a.IdAeropuerto
WHERE a.Lugar = 'Sevilla';


-- Nombres de co/pilotos que no hayan volado a BCN

SELECT p.*, a.Lugar as 'Destino'
FROM Piloto p
	LEFT JOIN Vuelo v
		ON p.IdPiloto = v.FkIdPiloto
	LEFT JOIN Trayecto t
		ON t.IdTrayecto = v.FkIdTrayecto
	LEFT JOIN Aeropuerto a
		ON t.FkIdDestino = a.IdAeropuerto
	WHERE a.Lugar <> 'Barcelona';

-- Num. de vuelos pilotados por co/pilotos intercontinentales (no hay....)

SELECT * 
FROM Piloto p
INNER JOIN Vuelo v
ON p.IdPiloto = v.FkIdPiloto
INNER JOIN TipoServicio ts
ON p.FkIdTipoServicio = ts.IdTipoServicio
WHERE ts.IsInterContinental = 1;

-- Num. de vuelos con destino a BCN

SELECT COUNT(*) as 'Num. Vuelos a BCN' 
FROM Vuelo v 
INNER JOIN Trayecto t
ON t.IdTrayecto = v.FkIdTrayecto
INNER JOIN Aeropuerto a
ON t.FkIdDestino = a.IdAeropuerto
WHERE a.Lugar = 'Barcelona';






USE AriEmployees;
--Nombre apellido categoria EMployees
SELECT CONCAT(first_name, ' ', last_name) as 'Nombre', 'Employee' as 'Type'
FROM employees
	UNION
SELECT CONCAT(first_name,' ', last_name) as 'Nombre', 'Dependant'
FROM dependents