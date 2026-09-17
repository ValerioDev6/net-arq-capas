CREATE TABLE [Sch_Configuracion].[MaestroDetalle]
(
    [Id] INT NOT NULL PRIMARY KEY,
    [IdMaestro]  INT NOT NULL,
    [Codigo]  VARCHAR(20) NOT NULL UNIQUE,
    [Valor] VARCHAR(50)  NOT NULL,
    CONSTRAINT [FK_MaestroDetalle_Maestro] FOREIGN KEY ([IdMaestro]) REFERENCES Sch_Configuracion.Maestro(Id),
    [Estado] BIT NOT NUll,
    [FechaCreacion] DATETIME NOT NULL DEFAULT getdate(),
    [UsuarioCreacion] NCHAR(10)  NOT NULL DEFAULT  'sql',
    [FechaModificacion] DATETIME NOT NULl,
    [UsuarioModificacion] VARCHAR(100) NOT NULl
)
