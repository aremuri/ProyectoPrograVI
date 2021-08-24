CREATE PROCEDURE dbo.CatalogoProductosObtener
	@CategoriaId INT= NULL

AS
	BEGIN 
	SET NOCOUNT ON

	SELECT 
	    CategoriaId
	  , NombreCategoria
	  , Estado
	FROM CatalogoProductos
	WHERE (@CategoriaId IS NULL OR CategoriaId=@CategoriaId)

	END
