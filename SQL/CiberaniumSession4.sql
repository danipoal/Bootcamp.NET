--Sesion SQL Cibernarium 4


--Practica: CREAR UN STORE PROCEDURE QUE INCREMENTE EL VALOR
	--DEL IMPORTE DE LA TABLA FACTURAS SEGUN UNA VARIABLE,
	--Y QUE LO EJECUTE EN FUNCIÓN DE IDFact INDICADO Y DEL VALOR DEL IMP A INCREMENTAR

	--EXEC SPNOMBRE @IDFACT=5 @ID INCREMENTO = 15

	--VER EL REGISTRO QUE SE HA MODIFICADO

CREATE PROCEDURE IncrementoImporte @IdFactura INT, @Incremento DECIMAL(12,2)
AS
BEGIN
	UPDATE F
	SET F.Importe = F.Importe + @Incremento
	FROM Facturas F
	WHERE F.IdFactura = @IdFactura
END;

EXEC IncrementoImporte @IdFactura = 1, @Incremento = 20;

--Crear un store procedure que pasando un nombre de cliente e importe aleatorio INSERTE
	--Un registro en la tabla facturas y inserte en la tabla registro un nuevo registro 
	--cn descripcion 'la suma importe de todas las facturas = x SUM(F.importe)'

ALTER PROCEDURE InsertarFactura @NombreCliente VARCHAR(100), @Importe DECIMAL(12,2)
AS
BEGIN
	INSERT INTO Facturas(Cliente, Importe) VALUES(@NombreCliente, @Importe);
	DECLARE @in INT;
	SELECT @in = SUM(Facturas.Importe) FROM Facturas;

	INSERT INTO Registro(Fecha, Descripcion, Usuario) VALUES (GETDATE(),CONCAT('la suma importe de todas las facturas ES ', @in), USER);

	SELECT * FROM Registro WHERE Registro.IdRegistro = SCOPE_Identity();
END;

EXEC InsertarFactura juanito, 299;


--OTRO PROCEDURE QUE GUARDA UN VALOR EN EL MOMENTO(Guardar una variable dentro del procedure)
CREATE PROCEDURE GuardarAcumulado 
AS
BEGIN
	INSERT INTO Facturas(Cliente, Importe) VALUES ('Mengati', 23)

	DECLARE @acumulado DECIMAL(12,2);
	SET @acumulado = (SELECT SUM(Importe) FROM Facturas);
	
END;

--PRACTICA: Mediante las tablas pedidos y detalles de pedidos, crear un procedure
	--que genere una tabla llamada [resumen de ventas](id, pais, importes) y rellenar
	--con importes de pedidos= precio*cantidad agrupado por PAIS
ALTER PROCEDURE CrearTablaResumenVentas
AS
BEGIN
	IF OBJECT_ID('Resumen de ventas', 'U') IS NOT NULL
		drop table [Resumen de ventas]
	BEGIN
		CREATE TABLE [Resumen de ventas](
		IdResumen INT PRIMARY KEY IDENTITY(1,1),
		Pais VARCHAR(30),
		Importe DECIMAL(12,2)
		);
		PRINT('Tabla creada')
	DECLARE @pais VARCHAR(30);
	DECLARE @importes DECIMAL(12,2);

	INSERT INTO [Resumen de ventas](Pais, Importe) 
		SELECT  p.PaísDestinatario, SUM(dp.PrecioUnidad * dp.Cantidad)
		FROM [Detalles de pedidos] dp
		INNER JOIN Pedidos p
		ON	dp.IdPedido = p.IdPedido
		group by p.PaísDestinatario
	END;
END;

EXEC CrearTablaResumenVentas;
SELECT * FROM [Resumen de ventas];

--Generamos una vista
CREATE VIEW Pedidos_Alemania AS
SELECT
	p.Cargo
FROM
	Pedidos p