CREATE PROCEDURE dbo.CatalogoProductosInsertar
	@NombreCategoria VARCHAR(250),
	@Estado BIT
AS
 BEGIN
   SET NOCOUNT ON
   BEGIN TRANSACTION TRASA

   BEGIN TRY 

   INSERT INTO CatalogoProductos 
   (
      NombreCategoria
	, Estado)
   VALUES
   (
     @NombreCategoria
	,@Estado
   )

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

