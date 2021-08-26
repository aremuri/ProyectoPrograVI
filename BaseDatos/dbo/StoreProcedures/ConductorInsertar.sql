CREATE PROCEDURE [dbo].[ConductorInsertar]
		
	@CedulaConductor VARCHAR(50),
	@NombreConductor	VARCHAR(200),
	@TelefonoConductor	VARCHAR(50),
	@Estado BIT	
AS BEGIN
SET NOCOUNT ON

	BEGIN TRANSACTION TRASA

	BEGIN TRY
		
		INSERT INTO dbo.Conductores
		(
	    
	     CedulaConductor,
		 NombreConductor,
		 TelefonoConductor,
	     Estado 
		)
		VALUES
		(
		
	     @CedulaConductor ,
		 @NombreConductor,
		 @TelefonoConductor,
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