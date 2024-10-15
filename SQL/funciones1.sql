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

	RETURN @NumEMps

END
GO

select dbo.NumEmpleadosDani('a');

