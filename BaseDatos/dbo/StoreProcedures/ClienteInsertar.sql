CREATE PROCEDURE [dbo].[ClienteInsertar]
	@Cedula INT,
	@Nombre varchar(250),
	@Apellidos varchar(250),
	@Direccion varchar(500),
	@FechaNacimiento DATE,
	@Telefono varchar(250),
	@Estado BIT
AS
 BEGIN
  SET NOCOUNT ON

	BEGIN TRANSACTION TRASA

	BEGIN TRY

	   INSERT INTO Clientes 
	   (Cedula, Nombre, Apellidos, Direccion, FechaNacimiento, Telefono, Estado)
	
	   VALUES
	   (
		 @Cedula, @Nombre, @Apellidos, @Direccion, @FechaNacimiento, @Telefono, @Estado
	   )

		COMMIT TRANSACTION TRASA
		
		SELECT 0 AS CodeError, '' AS MsgError

	END TRY

	BEGIN CATCH
		SELECT 
				ERROR_NUMBER() AS CodeError
			,	ERROR_MESSAGE() AS MsgError

			ROLLBACK TRANSACTION TRASA
	END CATCH
END