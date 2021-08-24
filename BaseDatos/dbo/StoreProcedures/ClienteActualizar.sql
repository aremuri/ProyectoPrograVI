CREATE PROCEDURE [dbo].[ClienteActualizar]
	@IdCliente INT,
	@Cedula INT,
	@Nombre VARCHAR(250),
	@Apellidos VARCHAR(250),
	@Direccion VARCHAR(500),
	@FechaNacimiento DATE,
	@Telefono VARCHAR(250),
	@Estado BIT
AS
 BEGIN
   SET NOCOUNT ON
   BEGIN TRANSACTION TRASA

   BEGIN TRY 

   UPDATE Clientes SET
   Cedula = @Cedula, Nombre = @Nombre, Apellidos = @Apellidos, Direccion = @Direccion, FechaNacimiento = @FechaNacimiento, Telefono = @Telefono, Estado = @Estado
	
  WHERE IdCliente=@IdCliente

   COMMIT TRANSACTION TRASA

     SELECT 0 AS CodeError, '' AS MsgError

   END TRY

   BEGIN CATCH
     SELECT 
	     ERROR_NUMBER() AS CodeError
	   , ERROR_MESSAGE() AS MsgError

	   ROLLBACK TRANSACTION TRASA
   END CATCH

 END