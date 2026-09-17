CREATE TABLE [Sch_Pedido].[Cliente]
(
    [Id] INT NOT NULL PRIMARY KEY,
    [RazonSocial] VARCHAR(150) NOT NULL,
    [TipoDocumento] VARCHAR(200) NOT NULL,
    [NumeroDocumento] VARCHAR(15) NULL,
    [Contacto] VARCHAR(100) NOT NULL,
    [Direcccion] VARCHAR(200) NOT NULL,
    [CorreoElectronico] VARCHAR(200) NOT NULL,
    [Celular] CHAR(9) NULL,
    [IdRubroMae] INT NOT NULL,
    [Estado] BIT NOT NULL,
    [FechaCreacion] DATETIME NOT NULL DEFAULT getdate(),
    [UsuarioCreacion] NCHAR(10) NOT NULL DEFAULT 'sql',
    [FechaModificacion] DATETIME NOT NULL,
    [UsuarioModificacion] VARCHAR(100) NOT NULL,
    CONSTRAINT [FK_Cliente_Rubro] FOREIGN KEY ([IdRubroMae]) REFERENCES Sch_Configuracion.MaestroDetalle(Id)
)