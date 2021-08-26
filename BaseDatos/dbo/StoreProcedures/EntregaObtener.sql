CREATE PROCEDURE [dbo].[EntregaObtener]

@EntregaId INT=NULL

	AS BEGIN
	SET NOCOUNT ON

	SELECT
			E.EntregaId
		,   E.FechaEntrega
		,   E.PedidoId
		,   E.Estado

		,   CP.IdCatalogoProvincia
		,	CP.NombreCatalogoProvincia

		,   CC.IdCatalogoCanton
		,	CC.NombreCatalogoCanton

		,   CD.IdCatalogoDistrito
		,	CD.NombreCatalogoDistrito

		,   C.CamionId
		,   C.Cualidad

		,   D.ConductorId
		,   D.NombreConductor

			

	FROM dbo.Entregas E
	 INNER JOIN dbo.CatalogoProvincia CP
         ON E.IdCatalogoProvincia = CP.IdCatalogoProvincia
     INNER JOIN dbo.CatalogoCanton CC
         ON E.IdCatalogoCanton = CC.IdCatalogoCanton
	 INNER JOIN dbo.CatalogoDistrito CD
         ON E.IdCatalogoDistrito = CD.IdCatalogoDistrito
	 INNER JOIN dbo.Camiones C
         ON E.IdCamion = C.CamionId
	INNER JOIN dbo.Conductores D
		 ON E.IdConductor = D.ConductorId
	

	
	WHERE
	     (@EntregaId IS NULL OR EntregaId=@EntregaId)

END