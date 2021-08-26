CREATE PROCEDURE [dbo].[ConductorObtener]
		@ConductorId INT=NULL

AS BEGIN
	SET NOCOUNT ON

	SELECT
		   ConductorId
		,  CedulaConductor
		,  NombreConductor
		,  TelefonoConductor
		,  Estado

	FROM dbo.Conductores

	WHERE (@ConductorId IS NULL OR ConductorId=@ConductorId)

END