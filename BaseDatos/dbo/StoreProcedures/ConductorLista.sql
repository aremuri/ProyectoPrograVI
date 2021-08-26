CREATE PROCEDURE [dbo].[ConductorLista]
	AS
	BEGIN
	SET NOCOUNT ON


	SELECT
	 ConductorId,
	 NombreConductor

	FROM Conductores
	WHERE Estado=1


	END
