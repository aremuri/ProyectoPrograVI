CREATE PROCEDURE [dbo].[ConductorActualizar]
@ConductorId INT,
@CedulaConductor VARCHAR(50),
@NombreConductor	VARCHAR(200),
@TelefonoConductor	VARCHAR(50),
@Estado BIT	

AS BEGIN
SET NOCOUNT ON

BEGIN TRANSACTION TRASA

	BEGIN TRY
		
	UPDATE dbo.Conductores SET
		   CedulaConductor=@CedulaConductor,
		   NombreConductor=@NombreConductor,
		   TelefonoConductor=@TelefonoConductor,
		   Estado=@Estado

	WHERE ConductorId=@ConductorId

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