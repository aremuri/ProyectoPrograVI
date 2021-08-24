CREATE PROCEDURE [dbo].[ListaClientes]
	AS
	BEGIN
		SET NOCOUNT ON



		SELECT 
		IdCliente,
		Cedula,
		Nombre,
		Apellidos,
		Direccion,
		FechaNacimiento,
		Telefono
		
		FROM	
			Clientes

			WHERE
					Estado=1






	END