CREATE TABLE [Sch_Configuracion].[Maestro]
(
    [Id] INT NOT NULL PRIMARY KEY,
    [Codigo]  VARCHAR(20) NOT NULL UNIQUE,
    [Nombre]  VARCHAR(50) NOT NULL,
    [Descripcion]  VARCHAR(200) NULL,
    [Estado] BIT NOT NUll,
    [FechaCreacion] DATETIME NOT NULL DEFAULT getdate(),
    [UsuarioCreacion] NCHAR(10)  NOT NULL DEFAULT  'sql',
    [FechaModificacion] DATETIME NOT NULl,
    [UsuarioModificacion] VARCHAR(100) NOT NULl

)
