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
	   IF NOT EXISTS( SELECT * FROM Clientes WHERE @Cedula = Cedula) BEGIN

	   INSERT INTO Clientes 
	   (Cedula, Nombre, Apellidos, Direccion, FechaNacimiento, Telefono, Estado)
	
	   VALUES
	   (
		 @Cedula, @Nombre, @Apellidos, @Direccion, @FechaNacimiento, @Telefono, @Estado
	   )

		SELECT 0 AS CodeError, '' AS MsgError

	   END 
	   ELSE BEGIN 

	   SELECT -1 AS CodeError, 'Este Numero de Cedula ya existe en la Base de Datos' AS MsgError

	   END

	   COMMIT TRANSACTION TRASA

   END TRY

   BEGIN CATCH
		 SELECT 
			 ERROR_NUMBER() AS CodeError
		   , ERROR_MESSAGE() AS MsgError

	   ROLLBACK TRANSACTION TRASA
   END CATCH

 END