CREATE PROCEDURE [dbo].[EntregaObtener]

@EntregaId INT=NULL

	AS BEGIN
	SET NOCOUNT ON

	SELECT
			E.EntregaId
		,   E.FechaEntrega
		,   E.PedidoId
		,   E.CamionId
		,   E.Estado

		,   CP.IdCatalogoProvincia
		,	CP.NombreCatalogoProvincia

		,   CC.IdCatalogoCanton
		,	CC.NombreCatalogoCanton

		,   CD.IdCatalogoDistrito
		,	CD.NombreCatalogoDistrito
				

	FROM dbo.Entregas E
	 INNER JOIN dbo.CatalogoProvincia CP
         ON E.IdCatalogoProvincia = CP.IdCatalogoProvincia
     INNER JOIN dbo.CatalogoCanton CC
         ON E.IdCatalogoCanton = CC.IdCatalogoCanton
	 INNER JOIN dbo.CatalogoDistrito CD
         ON E.IdCatalogoDistrito = CD.IdCatalogoDistrito
	WHERE
	     (@EntregaId IS NULL OR EntregaId=@EntregaId)

END