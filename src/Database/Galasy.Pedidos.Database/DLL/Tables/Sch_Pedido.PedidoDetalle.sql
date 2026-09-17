CREATE TABLE [Sch_Pedido].[PedidoDetalle]
(
    [Id] INT NOT NULL PRIMARY KEY,
    [IdPedido] INT NOT NULL,
    [IdProducto] INT NOT NUll,
    [Cantidad] DECIMAL(18,2) NOT NUll,
    [PrecioUnitario] DECIMAL(18,2) NOT NUll,
    [TotalBruto] DECIMAL(18,2) NOT NUll,
    [TotalNeto] DECIMAL(18,2) NOT NUll,
    CONSTRAINT [FK_PedidoDetalle_Pedido] FOREIGN KEY ([IdPedido]) REFERENCES Sch_Pedido.Pedido(Id),
    CONSTRAINT [FK_PedidoDetalle_Producto] FOREIGN KEY ([IdProducto]) REFERENCES Sch_Pedido.Producto(Id)
)