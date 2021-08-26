CREATE TABLE [dbo].[Conductores]
(
		ConductorId INT NOT NULL IDENTITY(1,1) CONSTRAINT PK_ConductorId PRIMARY KEY CLUSTERED (ConductorId)
	 ,  CedulaConductor VARCHAR(50) NOT NULL
	 ,  NombreConductor	VARCHAR(200) NOT NULL
	 ,  TelefonoConductor	VARCHAR(50) NOT NULL default('00000000')
	 ,  Estado BIT NOT NULL
)WITH (DATA_COMPRESSION=PAGE)
GO

CREATE UNIQUE NONCLUSTERED INDEX IDX_Conductor_Cedula
ON dbo.Conductores(CedulaConductor)
WITH (DATA_COMPRESSION=PAGE)
GO
