USE [Integra DB];
GO

-- Selects Basicos de todas las tablas
SELECT * FROM T_GRUPO_PROV
SELECT * FROM T_PROVEEDOR
SELECT * FROM T_ARTÍCULO

-- a. Listado de Artículos con stock mayor a cero
SELECT 
    AR.CodigoVenta AS 'Código de Venta',
    AR.Descripcion AS 'Descripción',
    AR.Precio,
    AR.Stock,
    PRO.Nombre AS 'Nombre de Proveedor'
FROM T_ARTÍCULO AS AR
INNER JOIN T_PROVEEDOR AS PRO ON AR.IDProveedor = PRO.ID
WHERE AR.Stock > 0;

-- b. Listado de Artículos y su proveedor
SELECT 
    AR.CodigoVenta AS 'Código de Venta',
    AR.Descripcion AS 'Descripción',
    AR.Stock,
    PRO.Nombre AS 'Nombre de Proveedor',
    GP.Descripcion AS 'Grupo de Proveedor'
FROM T_ARTÍCULO AS AR
INNER JOIN T_PROVEEDOR AS PRO ON AR.IDProveedor = PRO.ID
INNER JOIN T_GRUPO_PROV AS GP ON PRO.IDGrupoProv = GP.ID;

-- c. Listado de Proveedores que no tengan correo electrónico o teléfono
SELECT 
    PRO.Nombre AS 'Nombre de Proveedor',
    GP.Descripcion AS 'Nombre de Grupo',
    SUM(AR.Stock) AS 'Stock'
FROM T_PROVEEDOR AS PRO
LEFT JOIN T_GRUPO_PROV AS GP ON PRO.IDGrupoProv = GP.ID
LEFT JOIN T_ARTÍCULO AS AR ON PRO.ID = AR.IDProveedor
WHERE PRO.Correo IS NULL OR PRO.Telefono IS NULL
GROUP BY PRO.Nombre, GP.Descripcion;

-- d. Listado de Proveedores y la cantidad de artículos de los cuales son proveedores por defecto
SELECT 
    PRO.Nombre AS 'Nombre de Proveedor',
    GP.Descripcion AS 'Nombre de Grupo',
    COUNT(AR.ID) AS 'Cantidad de Artículos Asociados'
FROM T_PROVEEDOR AS PRO
LEFT JOIN T_GRUPO_PROV AS GP ON PRO.IDGrupoProv = GP.ID
LEFT JOIN T_ARTÍCULO AS AR ON PRO.ID = AR.IDProveedor
GROUP BY PRO.Nombre, GP.Descripcion;