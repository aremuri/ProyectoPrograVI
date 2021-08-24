CREATE PROCEDURE [dbo].ConductoresObtener
@Cedula INT = NULL	
AS
	BEGIN
		SET NOCOUNT ON
		SELECT 
		Nombre, Apellidos, Cedula, Telefono, Estado
		
		FROM	
			Conductores
			WHERE (@Cedula IS NULL OR Cedula = @Cedula)
	END
