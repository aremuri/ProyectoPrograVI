CREATE PROCEDURE [dbo].[PedidosProductosLista]
AS
	BEGIN
		SET NOCOUNT ON



		SELECT 
		ProductoId
		Nombre
		

		FROM	
			dbo.Productos

			WHERE
					Estado=1

	END
