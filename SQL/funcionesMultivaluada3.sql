

--Genera una tabla virtual durante el tiempo que dura la función para eliminar, editar, etc...

CREATE FUNCTION ListaEmpleadosDani2()	--Multistatement table valued
RETURNS 
@miLista TABLE  --Lugar en el que crear la tabla virtual
(
	Nombre varchar(50),
	Apellido varchar(50)
)
AS
BEGIN
	--Quiero meter la tabla employees en la tabla @miLista

	INSERT INTO @miLista(Nombre, Apellido)
		SELECT first_name, last_name 
			FROM employees
			
	RETURN 
END
use AriEmployees

SELECT * FROM dbo.ListaEmpleadosDani2()



--lista con campos concretos (firstname, lastname ,email) x ejemplo


ALTER FUNCTION ListaEmpleadosDani3(
@first bit, @second bit, @mail bit
)	
RETURNS 
	@miLista TABLE  
	(
		valor1 varchar(50),
		valor2 varchar(50),
		valor3 varchar(50)
	)
AS
BEGIN
	BEGIN
		INSERT INTO @miLista SELECT NULL, NULL, NULL FROM employees;
	END


IF @first = 1
	BEGIN
		UPDATE ml
		SET ml.valor1 = e.first_name
		FROM @miLista ml
		CROSS JOIN employees e; 
	END
--ELSE PRINT('ERR');

IF @second = 1
	BEGIN
		UPDATE ml
		SET ml.valor2 = e.last_name
		FROM @miLista ml
		CROSS JOIN employees e; 
	END

IF @mail = 1
	BEGIN
		UPDATE ml
		SET ml.valor3 = e.email
		FROM @miLista ml
		CROSS JOIN employees e; 
	END
			
	RETURN 
	--Mas sencillo podria hacerse con un case then justo en el select para decidir si seleccionar un campo, etc... 
	--Sin break para que no salte
END

SELECT * FROM dbo.ListaEmpleadosDani3(1, 1, 0)
