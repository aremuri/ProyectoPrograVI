CREATE PROCEDURE [dbo].[CamionObtener]
	@CamionId INT=NULL

AS BEGIN
	SET NOCOUNT ON

	SELECT
		   CamionId
		,  Cualidad
		,  Estado

	FROM dbo.Camiones

	WHERE (@CamionId IS NULL OR CamionId=@CamionId)

END