CREATE PROCEDURE [dbo].[EntregaActualizar]
	@EntregaId INT,
	@FechaEntrega DATE,
	@PedidoId INT,
	@IdCatalogoProvincia INT,
	@IdCatalogoCanton INT,
	@IdCatalogoDistrito INT,
	@IdCamion INT,
	@IdConductor INT,
    @Estado BIT

	AS BEGIN
	SET NOCOUNT ON

	BEGIN TRANSACTION TRASA

	BEGIN TRY
	-- AQUI VA EL CODIGO
		
	UPDATE dbo.Entregas SET
	    FechaEntrega = @FechaEntrega,
		PedidoId = @PedidoId,
		IdCatalogoProvincia=@IdCatalogoProvincia,
		IdCatalogoCanton=@IdCatalogoCanton,
		IdCatalogoDistrito=@IdCatalogoDistrito,
		IdCamion= @IdCamion,
		IdConductor = @IdConductor,
		Estado=@Estado

	WHERE EntregaId=@EntregaId

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


