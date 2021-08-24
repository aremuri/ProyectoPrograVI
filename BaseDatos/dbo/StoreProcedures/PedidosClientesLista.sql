CREATE PROCEDURE [dbo].[PedidosClientesLista]
AS
	BEGIN
		SET NOCOUNT ON



		SELECT 
		IdCliente
		Nombre
		

		FROM	
			dbo.Clientes

			WHERE
					Estado=1

	END
