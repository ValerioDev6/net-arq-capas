CREATE TABLE [Sch_Pedido].[Pedido]
(
    [Id] INT NOT NULL PRIMARY KEY,
    [IdCliente] INT NOT NULL,
    [TotalBruto] DECIMAL(18,2) NOT NULL,
    [TotalNeto] DECIMAL(18,2) NOT NULL,
    [Adelanto] DECIMAL(18,2) NOT NULL DEFAULT 0,
    [Estado] BIT NOT NULL,
    [FechaCreacion] DATETIME NOT NULL DEFAULT getdate(),
    [UsuarioCreacion] NCHAR(10) NOT NULL DEFAULT 'sql',
    [FechaModificacion] DATETIME NOT NULL,
    [UsuarioModificacion] VARCHAR(100) NOT NULL,
    CONSTRAINT [Fk_Pedido_Cliente] FOREIGN KEY ([IdCliente]) REFERENCES Sch_Pedido.Cliente(Id)
)