--SESION 3 Ciberanium Clase de SQL Avanzado


CREATE TABLE Facturas(
	IdFactura INT PRIMARY KEY IDENTITY(1,1),    --Identity(n,m) Indica que empezara x el valor n con incremento m
	Cliente VARCHAR(100),
	Importe DECIMAL(12,2)
);
PRINT('Tabla Facturas creada con exito');


CREATE TABLE Registro (
	IdRegistro INT PRIMARY KEY IDENTITY(1,1),
	Fecha DATE,
	Descripcion VARCHAR(100),
	Usario VARCHAR(50)
);
PRINT('Tabla Registro creada con exito');



INSERT INTO Facturas(Cliente, Importe)
VALUES ('Cliente 4', 1278);

--Creando un trigger
USE Cibernarium;
CREATE TRIGGER TFacturas
ON Facturas FOR INSERT		--Cuando haya un insert, el trigger se ejecutará
AS
BEGIN
	--Acción a realizar
	UPDATE F							--Actualizara la tabla F Sumandole 100 al importe
	SET F.Importe = F.Importe + 100
	FROM Facturas F					--El inserted objeto que se guarda de lo que se insertó
	INNER JOIN inserted I ON F.IdFactura = I.IdFactura; --Hay que juntar la tabla temporal inserted con la normal
	--Para saber que ID usar tiene que recoger el dato del objeto inserted
END;

--Trigger
CREATE TRIGGER TFacturasI
ON Facturas FOR INSERT
AS
BEGIN
	INSERT INTO Registro(Fecha, Descripcion, Usuario)
	--Introducimos la fecha del sistema	y el Usuario que hemos iniciado en sql
	VALUES(GETDATE(), 'Alta de factura', USER_NAME)
END;

	

--EJERCICIO PRACTICO
--En la tabla fact crear 1 campo numero factura
	--varchar(10)NUll

ALTER TABLE Facturas
ADD NumeroFactura VARCHAR(10) DEFAULT NULL;

--CREAR Trigger Numero_Factura, activar despues de insertar 
	--poner el nº fact que = idFact + / + año fecha actual
	--Si idFact es 4 -> Nfact = 4/2024

CREATE TRIGGER NUMERO_FACTURA
ON Facturas FOR INSERT
AS
BEGIN
	UPDATE F
	SET F.NumeroFactura = CAST(F.IdFactura as varchar(3)) + '/' + CAST(YEAR(GETDATE()) as VARCHAR(4))  
		--Si haces CONCAT te ahorras los 2 cast
	FROM Facturas F
	INNER JOIN inserted I ON F.IdFactura = I.IdFactura
END;
	
--Uso de Update
UPDATE Clientes
SET CódPostal = 'Ale',
	Región = 'Ale'	--Actualizar multiples campos
WHERE País = 'Alemania';

---------------
---------------
--Alter Trigger:
ALTER TRIGGER NUMERO_FACTURA
ON Facturas FOR INSERT
AS
BEGIN
	UPDATE F
	SET F.NumeroFactura = CONCAT(F.IdFactura , '/' , YEAR(GETDATE() ) ),
	F.Cliente = 'CLI' + F.Cliente --Modificacion añadida que introducimos:
	FROM Facturas F
	INNER JOIN inserted I ON F.IdFactura = I.IdFactura
END;

--Eliminar trigger
DROP TRIGGER TFacturas;

--Creando un trigger cuando se hace un UPDATE

CREATE TRIGGER MFacturas
ON Facturas AFTER UPDATE   --Se podria hacer FOR, pero lo queremos despues
AS BEGIN
	UPDATE F							
	SET F.Importe = F.Importe - 20
	FROM Facturas F					
	INNER JOIN inserted I ON F.IdFactura = I.IdFactura; --Inserted sirve para Update tambien
END;

--Modificar + mostrar
UPDATE Facturas
SET Importe = Importe + 5
WHERE IdFactura = 1;

SELECT * FROM Facturas;
----------------
---------------
--Trigger para ELIMINAR un registro

CREATE TRIGGER REGISTRO_ELIMINADO
ON Facturas FOR DELETE
AS BEGIN
	INSERT INTO Registro(Fecha, Descripcion, Usuario)
	--Introducimos la fecha del sistema	y el Usuario que hemos iniciado en sql
	VALUES(GETDATE(), 'Factura eliminada', USER)
END;

--Eliminar registro cn ID=3
DELETE FROM Facturas WHERE IdFactura = 2;
