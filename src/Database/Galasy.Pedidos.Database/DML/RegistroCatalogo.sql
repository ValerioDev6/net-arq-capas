-- This file contains SQL statements that will be executed after the build script.
CREATE TABLE Sch_Configuracion.Maestro
(
    Id                   INT NOT NULL PRIMARY KEY,
    Codigo               VARCHAR(20) NOT NULL UNIQUE,
    Nombre               VARCHAR(50) NOT NULL,
    Descripcion          VARCHAR(200) NULL,
    Estado               BIT NOT NULL,
    FechaCreacion        DATETIME NOT NULL DEFAULT GETDATE(),
    UsuarioCreacion      VARCHAR(50) NOT NULL DEFAULT 'sql',
    FechaModificacion    DATETIME NULL,
    UsuarioModificacion  VARCHAR(100) NULL
)
GO

CREATE TABLE Sch_Configuracion.MaestroDetalle
(
    Id                   INT NOT NULL PRIMARY KEY,
    IdMaestro            INT NOT NULL,
    Codigo               VARCHAR(20) NOT NULL UNIQUE,
    Valor                VARCHAR(50) NOT NULL,
    Estado               BIT NOT NULL,
    FechaCreacion        DATETIME NOT NULL DEFAULT GETDATE(),
    UsuarioCreacion      VARCHAR(50) NOT NULL DEFAULT 'sql',
    FechaModificacion    DATETIME NULL,
    UsuarioModificacion  VARCHAR(100) NULL,
    CONSTRAINT FK_MaestroDetalle_Maestro FOREIGN KEY (IdMaestro) REFERENCES Sch_Configuracion.Maestro(Id)
)
GO

CREATE TABLE Sch_Pedido.Cliente
(
    Id                   INT NOT NULL PRIMARY KEY,
    RazonSocial          VARCHAR(150) NOT NULL,
    TipoDocumento        VARCHAR(200) NOT NULL,
    NumeroDocumento      VARCHAR(15) NULL,
    Contacto             VARCHAR(100) NOT NULL,
    Direccion            VARCHAR(250) NULL,
    CorreoElectronico    VARCHAR(200) NOT NULL,
    Celular              CHAR(9) NULL,
    IdRubroMae           INT NOT NULL,
    Estado               BIT NOT NULL,
    FechaCreacion        DATETIME NOT NULL DEFAULT GETDATE(),
    UsuarioCreacion      VARCHAR(50) NOT NULL DEFAULT 'sql',
    FechaModificacion    DATETIME NULL,
    UsuarioModificacion  VARCHAR(100) NULL,
    CONSTRAINT FK_Cliente_Rubro FOREIGN KEY (IdRubroMae) REFERENCES Sch_Configuracion.MaestroDetalle(Id)
)
GO

CREATE TABLE Sch_Pedido.Producto
(
    Id                   INT NOT NULL PRIMARY KEY,
    Nombre               VARCHAR(100) NOT NULL,
    Descripcion          VARCHAR(200) NULL,
    IdMarcaMae           INT NOT NULL,
    IdCategoriaMae       INT NOT NULL,
    PrecioUnitario       DECIMAL(18,2) NOT NULL,
    Stock                INT NOT NULL,
    Estado               BIT NOT NULL,
    FechaCreacion        DATETIME NOT NULL DEFAULT GETDATE(),
    UsuarioCreacion      VARCHAR(50) NOT NULL DEFAULT 'sql',
    FechaModificacion    DATETIME NULL,
    UsuarioModificacion  VARCHAR(100) NULL,
    CONSTRAINT FK_Producto_Marca FOREIGN KEY (IdMarcaMae) REFERENCES Sch_Configuracion.MaestroDetalle(Id),
    CONSTRAINT FK_Producto_Categoria FOREIGN KEY (IdCategoriaMae) REFERENCES Sch_Configuracion.MaestroDetalle(Id)
)
GO

CREATE TABLE Sch_Pedido.Pedido
(
    Id                   INT NOT NULL PRIMARY KEY,
    IdCliente            INT NOT NULL,
    TotalBruto           DECIMAL(18,2) NOT NULL,
    TotalNeto            DECIMAL(18,2) NOT NULL,
    Adelanto             DECIMAL(18,2) NOT NULL DEFAULT 0,
    Estado               BIT NOT NULL,
    FechaCreacion        DATETIME NOT NULL DEFAULT GETDATE(),
    UsuarioCreacion      VARCHAR(50) NOT NULL DEFAULT 'sql',
    FechaModificacion    DATETIME NULL,
    UsuarioModificacion  VARCHAR(100) NULL,
    CONSTRAINT FK_Pedido_Cliente FOREIGN KEY (IdCliente) REFERENCES Sch_Pedido.Cliente(Id)
)
GO

CREATE TABLE Sch_Pedido.PedidoDetalle
(
    Id                   INT NOT NULL PRIMARY KEY,
    IdPedido             INT NOT NULL,
    IdProducto           INT NOT NULL,
    Cantidad             DECIMAL(18,2) NOT NULL,
    PrecioUnitario       DECIMAL(18,2) NOT NULL,
    TotalBruto           DECIMAL(18,2) NOT NULL,
    TotalNeto            DECIMAL(18,2) NOT NULL,
    CONSTRAINT FK_PedidoDetalle_Pedido FOREIGN KEY (IdPedido) REFERENCES Sch_Pedido.Pedido(Id),
    CONSTRAINT FK_PedidoDetalle_Producto FOREIGN KEY (IdProducto) REFERENCES Sch_Pedido.Producto(Id)
)
GO
