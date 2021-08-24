﻿CREATE TABLE [dbo].[Entregas]
(
	  EntregaId INT NOT NULL IDENTITY(1,1) CONSTRAINT Entrega PRIMARY KEY CLUSTERED(EntregaId)
	, FechaEntrega DATE NOT NULL CONSTRAINT DF_Entregas_FechaEntrega default('01-01-2020')
	, PedidoId INT NOT NULL
	, IdCatalogoProvincia INT NOT NULL
		CONSTRAINT FK_Agencia_Provincia FOREIGN KEY(IdCatalogoProvincia) REFERENCES dbo.CatalogoProvincia(IdCatalogoProvincia)
	, IdCatalogoCanton INT NOT NULL 
		CONSTRAINT Fk_Agencia_Canton FOREIGN KEY(IdCatalogoCanton) REFERENCES dbo.CatalogoCanton(IdCatalogoCanton)
	, IdCatalogoDistrito INT NOT NULL
		CONSTRAINT Fk_Agencia_Distrito FOREIGN KEY(IdCatalogoDistrito) REFERENCES dbo.CatalogoDistrito(IdCatalogoDistrito)
	, CamionId INT NOT NULL
	, Estado BIT NOT NULL
)

WITH (DATA_COMPRESSION = PAGE)
GO
