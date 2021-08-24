﻿CREATE TABLE [dbo].[CatalogoProductos]
(
	  CategoriaId INT NOT NULL IDENTITY(1,1) CONSTRAINT PK_CatalogoProductos PRIMARY KEY CLUSTERED (CategoriaId)
	, NombreCategoria VARCHAR(250) NOT NULL
	, Estado BIT NOT NULL
)
WITH (DATA_COMPRESSION=PAGE)
GO
