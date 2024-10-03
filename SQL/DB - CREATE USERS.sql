----------------------------------------------------------------
-- Copyright (c) 2024
-- Created by Mauricio Lopez
--
-- USER:
--      Name: C_Sharp
--      Pass: C_Sharp_Integra
-- DESCRIPTION:
--      Coneccion con la base de datos desde C#
-- ACCESS:
--      ALTER: Modificar estructura de tablas
--      CONTROL: Control total sobre la base de datos
--      DELETE: Eliminar registros
--      EXECUTE: Ejecutar procedimientos almacenados
--      INSERT: Insertar nuevos registros
--      REFERENCES: Crear claves foráneas
--      SELECT: Consultar datos
--      UPDATE: Actualizar registros existentes
--      CREATE TABLE: Crear nuevas tablas
----------------------------------------------------------------

USE master;
GO

IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'Integra DB')
BEGIN
    CREATE DATABASE [Integra DB];
    PRINT 'Database "Integra DB" created successfully.';
END
ELSE
BEGIN
    PRINT 'Database "Integra DB" already exists.';
END
GO

USE [Integra DB];
GO

IF NOT EXISTS (SELECT name FROM master.sys.server_principals WHERE name = 'C_Sharp')
BEGIN
    CREATE LOGIN C_Sharp WITH PASSWORD = 'C_Sharp_Integra';
    PRINT 'Login "C_Sharp" created successfully.';
END
ELSE
BEGIN
    PRINT 'Login "C_Sharp" already exists.';
END
GO

IF NOT EXISTS (SELECT name FROM sys.database_principals WHERE name = 'C_Sharp')
BEGIN
    CREATE USER C_Sharp FOR LOGIN C_Sharp;
    PRINT 'User "C_Sharp" created successfully.';
END
ELSE
BEGIN
    PRINT 'User "C_Sharp" already exists.';
END
GO

GRANT ALTER, CONTROL, DELETE, EXECUTE, INSERT, REFERENCES, SELECT, UPDATE TO C_Sharp;
PRINT 'Full permissions granted to user "C_Sharp".';
GO

GRANT CREATE TABLE TO C_Sharp;
PRINT 'Create table permission granted to user "C_Sharp".';
GO

PRINT 'Database setup completed with full permissions.';