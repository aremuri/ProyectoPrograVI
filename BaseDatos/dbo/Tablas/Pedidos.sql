CREATE TABLE [dbo].[Pedidos]
(
     Codigo INT NOT NULL IDENTITY(1,1) CONSTRAINT PK_Pedidos PRIMARY KEY CLUSTERED (Codigo)
   , IdCliente INT NOT NULL CONSTRAINT FK_Pedidos_Clientes FOREIGN KEY(IdCliente) REFERENCES dbo.Clientes(IdCliente)
   , FechaPedido DATE NOT NULL CONSTRAINT DF_Pedidos_FechaPedido default('2021-01-01')
   , Producto	VARCHAR(250) NOT NULL
   , Cantidad	INT NOT NULL
   , Subtotal  FLOAT NOT NULL
   , Envio   FLOAT NOT NULL
   , IVA    FLOAT NOT NULL
   , Total   FLOAT NOT NULL
  
)

WITH (DATA_COMPRESSION = PAGE)
GO

