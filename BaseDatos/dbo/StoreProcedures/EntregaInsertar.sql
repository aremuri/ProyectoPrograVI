CREATE PROCEDURE [dbo].[EntregaInsertar]
	@FechaEntrega DATE,
	@PedidoId INT,
	@IdCatalogoProvincia INT,
	@IdCatalogoCanton INT,
	@IdCatalogoDistrito INT,
	@CamionId INT,
    @Estado BIT

	AS BEGIN
SET NOCOUNT ON

	BEGIN TRANSACTION TRASA

	BEGIN TRY

		
		INSERT INTO dbo.Entregas 
		(	       
	      FechaEntrega,
		  PedidoId,
		  IdCatalogoProvincia,
		  IdCatalogoCanton,
		  IdCatalogoDistrito,
		  CamionId,
		  Estado
		)
		VALUES
		(
		
			@FechaEntrega,
			@PedidoId,
			@IdCatalogoProvincia,
			@IdCatalogoCanton,
			@IdCatalogoDistrito,
			@CamionId,
			@Estado
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
