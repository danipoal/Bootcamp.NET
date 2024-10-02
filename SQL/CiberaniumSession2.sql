USE Cibernarium;

--Ordenar por mas de un filtro
SELECT * FROM Pedidos ORDER BY FechaPedido DESC, IdCliente ASC;

--20 ultimos pedidos por fecha
--Usar Top
Select TOP(20) * FROM Pedidos ORDER BY FechaPedido DESC;

--Concatenar campos txt manualmente y alias
SELECT (CódPostalDestinatario+ ' ' + CiudadDestinatario) as Codigo FROM Pedidos;

--Concatenar int con comillas convierte no lo convierte en texto
SELECT (FormaEnvío+ ' a' + IdEmpleado) as Codigo FROM Pedidos;

--Op arit sujeto [Si tiene espacio en blanco ENTRE CORCHETES]
SELECT PrecioUnidad, Cantidad, (PrecioUnidad*Cantidad) as importe FROM [Detalles de pedidos];


--Where Sirve para dos cosas
--JOIN Implicito -> Where [Solo se puede poner una vez y condiciones se añaden con AND/OR]
SELECT * FROM Pedidos WHERE PaísDestinatario = 'Alemania';

--Funcion de agregado
SELECT COUNT(*) AS total FROM Pedidos WHERE PaísDestinatario = 'Alemania';

--Like palabras parecidas
SELECT * FROM Pedidos WHERE PaísDestinatario LIKE 'A%';


--Funciones en el sujeto
SELECT 'Mes: '+ CAST(MONTH(FechaPedido)as varchar(2)) AS NOMBRE_COLUMNA FROM Pedidos;

--Lower y mayus
SELECT UPPER(PaísDestinatario) AS Pais, LOWER(PaísDestinatario) AS 'P 2' FROM Pedidos;


--vER CANTIDAD REGISTROS DE TABLA PEDIDOS QUE NOMBRE TENGA LA S
--NOMBRE DE DESTINATARIO, WHERE FORMA ENVIO = 1 OR 3
--VER CAMPO CALCULADO IMPORTE solo si cantidad es mayor que 20
--ver un campo calculado -> dia y mes fecha pedido separado por - + campo destinatario where nombre acabe en 'a'
--y forma envio=1
SELECT COUNT(*) as TotalPedidos FROM Pedidos WHERE CiudadDestinatario LIKE '%s%'

SELECT *, UPPER(Destinatario) FROM Pedidos WHERE FormaEnvío = 1 OR FormaEnvío = 3;

SELECT (PrecioUnidad*Cantidad)as Importe FROM [Detalles de pedidos] WHERE Cantidad > 20;

SELECT 'FECHA: ' + CAST(DAY(FechaPedido) as varchar(2)) + '/' + CAST(MONTH(FechaPedido) as varchar(2)) as FechaPedido FROM
Pedidos WHERE Destinatario LIKE '%a' AND FormaEnvío = 1;

--VINCULACION DE TABLAS CON JOINT
SELECT * FROM Pedidos, [Detalles de pedidos] WHERE Pedidos.IdPedido = [Detalles de pedidos].IdPedido;


--Inner join
SELECT
	p.Destinatario,
	p.PaísDestinatario,
	(dp.Cantidad*dp.PrecioUnidad) AS Importe
FROM
	Pedidos p
INNER JOIN
	[Detalles de Pedidos] dp
ON p.IdPedido = dp.IdPedido

--Crear la tabla Maestro y la tabla Detalle

SELECT
	*
FROM
	Maestro M
INNER JOIN
	Detalle D
	ON
	M.IdMaestro = D.IdMaestro;


	
SELECT
	*
FROM
	Maestro M
FULL OUTER JOIN
	Detalle D
	ON
	M.IdMaestro = D.IdMaestro;


--INSERTANDO VALORES EN LAS TABLAS
--Insertar 1 valor
INSERT INTO Maestro (IdMaestro, Valor1) Values(8, 'Lleno');
--Varios valores
INSERT INTO MaestroBis (IdMaestro, Valor1) 
Values	(9, 'Lleno'),
		(11,'Lleno'),
		(12, 'Lleno');

INSERT INTO MaestroBis (IdMaestro, Valor1) 
SELECT IdMaestro, Valor1 FROM Maestro
WHERE IdMaestro >4;

DELETE FROM MaestroBis;

--Funciones de resumen o agregado (Cuenta filas)
--SUM -> Suma valores de una columna
--AVERAGE()

SELECT 
	p.PaísDestinatario,
	SUM(dp.PrecioUnidad * dp.Cantidad) as Importe
FROM
	Pedidos p
INNER JOIN 
	[Detalles de pedidos] dp
ON
	p.IdPedido = dp.IdPedido
GROUP BY p.PaísDestinatario
HAVING P.PaísDestinatario <> 'Alemania'
ORDER BY p.PaísDestinatario ASC;

--Practica
	--Ver promedio importe (precio*cantidad) por ciudadDestino where la SUM de la cantidad -30 
	--
SELECT
	AVG(dp.PrecioUnidad*dp.Cantidad) as Importe
FROM
	Pedidos p
INNER JOIN
	[Detalles de pedidos] dp
ON
	p.IdPedido = dp.IdPedido

GROUP BY
	p.CiudadDestinatario
HAVING
	SUM(dp.Cantidad) < 30
