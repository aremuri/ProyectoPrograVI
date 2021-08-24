CREATE PROCEDURE dbo.CatalogoProductosLista
AS
	BEGIN
		SET NOCOUNT ON



		SELECT 
		CategoriaId,
		NombreCategoria

		FROM	
			dbo.CatalogoProductos

			WHERE
					Estado=1

	END
