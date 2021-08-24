CREATE TABLE [dbo].[Productos]
(
	ProductoId INT NOT NULL IDENTITY(1,1) CONSTRAINT PK_Productos PRIMARY KEY CLUSTERED(ProductoId)
 ,	CategoriaId INT NOT NULL CONSTRAINT FK_Productos_CatagoloProductos FOREIGN KEY(CategoriaId) REFERENCES dbo.CatalogoProductos(CategoriaId)
 ,  Nombre VARCHAR(250) NOT NULL
 ,  Cantidad INT NOT NULL
 ,  Caracteristicas VARCHAR(250) NOT NULL
 ,  Precio FLOAT NOT NULL
 ,  Estado BIT NOT NULL
)
WITH (DATA_COMPRESSION = PAGE)
GO