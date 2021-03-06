CREATE PROCEDURE dbo.ProductosActualizar
    @ProductoId INT,
	@CategoriaId INT,
	@Nombre varchar(250),
	@Cantidad INT,
	@Caracteristicas varchar(250),
	@Precio INT,
	@Estado BIT

AS BEGIN
SET NOCOUNT ON

	BEGIN TRANSACTION TRASA

	BEGIN TRY
	-- AQUI VA EL CODIGO
		
	UPDATE dbo.Productos SET

		CategoriaId = @CategoriaId,
		Nombre= @Nombre,
		Cantidad=@Cantidad,
		Caracteristicas=@Caracteristicas,
	    Precio=@Precio,
		Estado=@Estado

	WHERE ProductoId= @ProductoId

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
