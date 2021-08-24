CREATE PROCEDURE [dbo].[ProductosObtener]
	@ProductoId INT=NULL

AS BEGIN
	SET NOCOUNT ON

	SELECT
			P.ProductoId
		,   P.Nombre
		,   P.Cantidad
		,   P.Caracteristicas
		,   P.Precio
		,   P.Estado
		,   CP.CategoriaId
		,	CP.NombreCategoria
	
	FROM dbo.Productos P
	 INNER JOIN dbo.CatalogoProductos CP
         ON P.CategoriaId = CP.CategoriaId
	WHERE
	     (@ProductoId IS NULL OR ProductoId=@ProductoId)

END