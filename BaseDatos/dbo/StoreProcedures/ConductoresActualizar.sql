CREATE PROCEDURE [dbo].ConductoresActualizar
	@Nombre varchar(250),
	@Apellidos varchar(250),
	@Cedula INT,
	@Telefono varchar(250),
	@Estado BIT
AS
 BEGIN
   SET NOCOUNT ON
   BEGIN TRANSACTION TRASA

   BEGIN TRY 

   UPDATE Conductores SET
   Nombre = @Nombre, Apellidos = @Apellidos, Telefono = @Telefono, Estado = @Estado
	
  WHERE Cedula=@Cedula

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