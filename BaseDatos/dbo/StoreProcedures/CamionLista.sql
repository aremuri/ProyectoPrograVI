CREATE PROCEDURE [dbo].[CamionLista]
	AS
	BEGIN
	SET NOCOUNT ON


	SELECT
	 CamionId,
	 Cualidad

	FROM Camiones
	WHERE Estado=1


	END
