CREATE TABLE [Sch_Pedido].[Producto]
(
    [Id] INT NOT NULL PRIMARY KEY,
    [Nombre] VARCHAR(100) NOT NULL,
    [Descripcion] VARCHAR(200) NULL,
    [IdMarcaMae] INT NOT NULL,
    [IdCategoriaMae] INT NOT NULL,
    [PrecioUnitario] DECIMAL(18,2) NOT NULL,
    [Stock] INT NOT NULL,
    [Estado] BIT NOT NULL,
    [FechaCreacion] DATETIME NOT NULL DEFAULT getdate(),
    [UsuarioCreacion] NCHAR(10) NOT NULL DEFAULT 'sql',
    [FechaModificacion] DATETIME NOT NULL,
    [UsuarioModificacion] VARCHAR(100) NOT NULL,
    CONSTRAINT [FK_Producto_Marca] FOREIGN KEY ([IdMarcaMae]) REFERENCES Sch_Configuracion.MaestroDetalle(Id),
    CONSTRAINT [FK_Producto_Categoria] FOREIGN KEY ([IdCategoriaMae]) REFERENCES Sch_Configuracion.MaestroDetalle(Id)
)