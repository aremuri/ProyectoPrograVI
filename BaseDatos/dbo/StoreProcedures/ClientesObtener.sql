CREATE PROCEDURE [dbo].[ClientesObtener]
@IdCliente INT = NULL	
AS
	BEGIN
		SET NOCOUNT ON
		SELECT 
		IdCliente, Cedula, Nombre, Apellidos, Direccion, FechaNacimiento, Telefono, Estado
		
		FROM	
			Clientes
			WHERE (@IdCliente IS NULL OR IdCliente = @IdCliente)
	END
