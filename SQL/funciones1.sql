-- ================================================
-- Template generated from Template Explorer using:
-- Create Scalar Function (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the function.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
ALTER FUNCTION NumEmpleadosDani(@dept varchar(50))
RETURNS INT
AS
BEGIN
	DECLARE @NumEmps INT

	--Si coge null que devuelva todos
	IF @dept IS NOT NULL
		SELECT @NumEmps= COUNT(*) FROM employees e
			INNER JOIN departments d
				ON d.department_id = e.department_id
		WHERE d.department_name LIKE '%' + @dept + '%'
	ELSE
		SELECT @NumEmps= COUNT(*) FROM employees e
			INNER JOIN departments d
				ON d.department_id = e.department_id
	
	--Set @NumEmps = (SELECT COUNT(*) FROM employees)

	--Segunda manera 
	SELECT COUNT(*) FROM employees e
		INNER JOIN departments d
			ON d.department_id = e.department_id
	WHERE @dept IS NULL OR d.department_name LIKE '%' + @dept + '%' ; --Comprueba que no sea null y devuelve todo, sino aplica el like
																	  --Un where es un if, si se cumple el filtro, devuelve lo que se cumple, else no

	--Tercera subquery [Con subquerry]
		SELECT COUNT(*) FROM employees e
	WHERE (@dept IS NULL 
		OR e.department_id IN 
								(
								SELECT d.department_id 
								FROM departments d 
								WHERE d.department_name = @dept
								);
							
	--Cuarta manera [CASE WHEN]

		SELECT COUNT(*) FROM employees e
		INNER JOIN departments d
			ON d.department_id = e.department_id
		WHERE @dept = CASE 
						WHEN @dept IS NOT NULL
						THEN d.department_name
						ELSE NULL
					END
	--Quinta manera [case de primeras (subconsultas)]

	SET @NumEmps = CASE
						WHEN @dept IS NULL
							THEN	(SELECT COUNT(*) FROM employees)
							ELSE	(SELECT COUNT(*) FROM employees e
										INNER JOIN departments d
											ON d.department_id = e.department_id
									WHERE d.department_name LIKE '%' + @dept + '%' )
							END;

	RETURN @NumEMps

END
GO

select dbo.NumEmpleadosDani('a');

