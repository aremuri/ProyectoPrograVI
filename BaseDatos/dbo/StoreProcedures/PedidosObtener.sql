CREATE PROCEDURE [dbo].[PedidosObtener]
@Codigo INT = NULL	
AS
	BEGIN
		SET NOCOUNT ON
		SELECT 
		Codigo,
		IdCliente,
		FechaPedido,
		Producto,
		Cantidad, 
		Subtotal,
		Envio,
		IVA,
		Total
		
		FROM	
			Pedidos
			WHERE (@Codigo IS NULL OR Codigo = @Codigo)
	END
