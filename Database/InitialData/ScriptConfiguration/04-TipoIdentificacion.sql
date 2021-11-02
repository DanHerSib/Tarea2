DROP TABLE IF EXISTS #TipoIdentificacionTemp

SELECT 
    IdTipoIdentificacion, Descripcion INTO #TipoIdentificacionTemp FROM 
    (VALUES (1, 'Cedula'), (2, 'Pasaporte'), (3, 'Cedula Juridica')) 
    AS TEMP(IdTipoIdentificacion, Descripcion)

----ACTUALIZAR DATOS---
UPDATE TI SET TI.Descripcion = TM.Descripcion
    FROM Dbo.TipoIdentificacion TI
        INNER JOIN #TipoIdentificacionTemp TM
        ON TI.IdTipoIdentificacion = TM.IdTipoIdentificacion

----INSERTAR DATOS---
SET IDENTITY_INSERT dbo.TipoIdentificacion ON
INSERT INTO dbo.TipoIdentificacion(IdTipoIdentificacion, Descripcion)
    SELECT
        IdTipoIdentificacion, Descripcion
    FROM #TipoIdentificacionTemp
EXCEPT
    SELECT
        IdTipoIdentificacion, Descripcion
        FROM dbo.TipoIdentificacion
SET IDENTITY_INSERT dbo.TipoIdentificacion OFF
Go