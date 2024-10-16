
CREATE PROCEDURE ListaEmpleadosSPdani

AS
BEGIN

	SET NOCOUNT ON;		--Para evitar que aparezca lo de x row affected

    -- Insert statements for procedure here
	UPDATE employees
		SET salary = salary + 0.01
END
GO

--uso exec

SELECT first_name, salary from employees;

exec ListaEmpleadosSPdani
SELECT first_name, salary from employees;

--Incrementar en x% a los emp de un dept o todos if null

CREATE PROCEDURE IncrementoPorcentajeDani @porcentaje decimal(4,2), @dept int
AS
BEGIN

	SET NOCOUNT ON;	

	UPDATE employees
		SET salary = salary + salary * @porcentaje
		WHERE @dept IS NULL OR department_id = @dept
END



SELECT first_name, salary, department_id from employees ORDER BY department_id;
exec IncrementoPorcentajeDani 0.02, 1
SELECT first_name, salary, department_id from employees ORDER BY department_id;



--Crear funcion que añada un job por param

CREATE PROCEDURE AñadirTrabajoDani @nombre varchar(50), @salarioMax decimal(8,2) , @salarioMin decimal(8,2) 
as
BEGIN
	SET NOCOUNT ON;	
	INSERT INTO dbo.jobs(job_title, max_salary, min_salary) VALUES(@nombre, @salarioMax, @salarioMin);

END
EXEC AñadirTrabajoDani 'paleto', 2.20,0.00;

--		* crea una tabla temporal (#miTabla) donde copia los empleados
--		* examina uno por uno estos emps, y elimina los que tiene salario >15000
-- 		* devolver la tabla final

ALTER PROCEDURE ExaminaTrabajoDani 
as
BEGIN
	DECLARE @count INT;

	SELECT * INTO #miTablaDan FROM dbo.jobs;
		SET @count = (SELECT COUNT(*) FROM #miTablaDan) ;

	WHILE @count > 0
	BEGIN
		DECLARE @salary DECIMAL(8,2)
		SET @salary = (
						SELECT max_salary FROM #miTablaDan 
						WHERE max_salary > 15000 and job_id = @count
						)
		IF @salary IS NOT NULL
			DELETE FROM #miTablaDan WHERE job_id = @count;

		SET @count = @count - 1
	END
	select * FROM #miTablaDan ORDER BY max_salary;
	DROP TABLE #miTablaDan

END

EXEC ExaminaTrabajoDani