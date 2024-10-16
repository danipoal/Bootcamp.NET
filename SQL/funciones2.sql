
ALTER FUNCTION ListaDani()

RETURNS TABLE
AS
RETURN
(
	Select first_name, last_name from employees
)
	
GO

--Uso
SELECT * FROM dbo.ListaDani();


--lista emps de un dept

ALTER FUNCTION ListaDaniXdept(@dept varchar(50))
RETURNS TABLE
AS
RETURN
(
	SELECT e.first_name, e.last_name, d.department_name
	FROM employees e
	INNER JOIN departments d
		ON e.department_id = d.department_id
	WHERE d.department_name = @dept
)
	
--uso
SELECT * FROM dbo.ListaDaniXdept('IT')


--lista con campos concretos (firstname, lastname ,id) x ejemplo