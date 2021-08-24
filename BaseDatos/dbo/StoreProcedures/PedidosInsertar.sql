CREATE PROCEDURE [dbo].[PedidosInsertar]
	@Codigo INT,
	@IdCliente INT,
	@FechaPedido DATE,
	@Producto VARCHAR (250),
	@Cantidad INT, 
	@Subtotal FLOAT,
	@Envio FLOAT,
	@IVA FLOAT,
	@Total FLOAT
AS
 BEGIN
   SET NOCOUNT ON
   BEGIN TRANSACTION TRASA

   BEGIN TRY 

   INSERT INTO Pedidos 
    (Codigo,
	IdCliente,
	FechaPedido,
	Producto,
	Cantidad, 
	Subtotal,
	Envio,
	IVA,
	Total)
	
   VALUES
   (
    @Codigo,
	@IdCliente,
	@FechaPedido,
	@Producto,
	@Cantidad, 
	@Subtotal,
	@Envio,
	@IVA,
	@Total
   )

   declare @Impuesto float = 0
   declare @Env float = 0
   declare @Cant int = 0
   declare @Subtot float = 0
   declare @TotalPag float = 0
   
   set @Impuesto = @Impuesto * 0.13
   select @Impuesto as [IVA]

   set @Env = @Env
   select @Env as [Envio]

   set @Cant = @Cant 
   select @Cant as [Cantidad]

   set @Subtot =@Subtot * @Cant
   select @Subtot as [Subtotal]

   set @TotalPag = @TotalPag * @Subtot * @Cantidad + @Impuesto
   select @TotalPag as [Total]



   COMMIT TRANSACTION TRASA

     SELECT 0 AS CodeError, '' AS MsgError

   END TRY

   BEGIN CATCH
     SELECT 
	     ERROR_NUMBER() AS CodeError
	   , ERROR_MESSAGE() AS MsgError

	   ROLLBACK TRANSACTION TRASA
   END CATCH

 END