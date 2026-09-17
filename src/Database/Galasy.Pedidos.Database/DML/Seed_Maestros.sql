-- This file contains SQL statements that will be executed after the build script.

-- 1) Maestros (tipos de catálogo)
IF NOT EXISTS (SELECT 1 FROM Sch_Configuracion.Maestro WHERE Id = 1)
    INSERT INTO Sch_Configuracion.Maestro (Id, Codigo, Nombre, Descripcion, Estado)
    VALUES (1, 'RUBRO', 'Rubro', 'Rubros de clientes', 1);

IF NOT EXISTS (SELECT 1 FROM Sch_Configuracion.Maestro WHERE Id = 2)
    INSERT INTO Sch_Configuracion.Maestro (Id, Codigo, Nombre, Descripcion, Estado)
    VALUES (2, 'MARCA', 'Marca', 'Marcas de productos', 1);

IF NOT EXISTS (SELECT 1 FROM Sch_Configuracion.Maestro WHERE Id = 3)
    INSERT INTO Sch_Configuracion.Maestro (Id, Codigo, Nombre, Descripcion, Estado)
    VALUES (3, 'CATEGORIA', 'Categoría', 'Categorías de productos', 1);
GO

-- 2) MaestroDetalle (valores de cada catálogo)

-- Detalle de RUBRO (IdMaestro = 1)
IF NOT EXISTS (SELECT 1 FROM Sch_Configuracion.MaestroDetalle WHERE Id = 1)
    INSERT INTO Sch_Configuracion.MaestroDetalle (Id, IdMaestro, Codigo, Valor, Estado)
    VALUES (1, 1, 'RUBRO_01', 'Comercio', 1);

IF NOT EXISTS (SELECT 1 FROM Sch_Configuracion.MaestroDetalle WHERE Id = 2)
    INSERT INTO Sch_Configuracion.MaestroDetalle (Id, IdMaestro, Codigo, Valor, Estado)
    VALUES (2, 1, 'RUBRO_02', 'Servicios', 1);

-- Detalle de MARCA (IdMaestro = 2)
IF NOT EXISTS (SELECT 1 FROM Sch_Configuracion.MaestroDetalle WHERE Id = 3)
    INSERT INTO Sch_Configuracion.MaestroDetalle (Id, IdMaestro, Codigo, Valor, Estado)
    VALUES (3, 2, 'MARCA_01', 'Genérica', 1);

-- Detalle de CATEGORIA (IdMaestro = 3)
IF NOT EXISTS (SELECT 1 FROM Sch_Configuracion.MaestroDetalle WHERE Id = 4)
    INSERT INTO Sch_Configuracion.MaestroDetalle (Id, IdMaestro, Codigo, Valor, Estado)
    VALUES (4, 3, 'CATEGORIA_01', 'General', 1);
GO