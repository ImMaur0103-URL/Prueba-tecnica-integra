----------------------------------------------------------------
-- Copyright (c) 2024
-- Created by Mauricio Lopez
--
-- Tables:
--  T_PROVEEDOR:
--      ID (autoincremental) [int] PK
--      Nombre [string] NOT NULL
--      Telefono [string] NULL
--      Correo [string] NULL
--      NIT [string] NOT NULL, Default CF
--      Direccion [string] NOT NULL
--      IDGrupoProv [int] FK T_GRUPO_PROV
--  T_GRUPO_PROV:
--      ID (autoincremental) [int] PK
--      Descripcion [string] NOT NULL
--  T_ARTÍCULO:
--      ID (autoincremental) [int] PK
--      CodigoVenta [string] NOT NULL
--      Descripcion [string] NOT NULL
--      Precio [decimal] Default 0.00
--      Stock [decimal] Default 0.00
--      IDProveedor [int] FK T_PROVEEDOR
----------------------------------------------------------------
USE [Integra DB];
GO


CREATE TABLE T_GRUPO_PROV (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion NVARCHAR(255) NOT NULL
);

CREATE TABLE T_PROVEEDOR (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(255) NOT NULL,
    Telefono NVARCHAR(50) NULL,
    Correo NVARCHAR(255) NULL,
    NIT NVARCHAR(50) NOT NULL DEFAULT 'CF',
    Direccion NVARCHAR(255) NOT NULL,
    IDGrupoProv INT,
    FOREIGN KEY (IDGrupoProv) REFERENCES T_GRUPO_PROV(ID)
);

CREATE TABLE T_ARTÍCULO (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    CodigoVenta NVARCHAR(50) NOT NULL,
    Descripcion NVARCHAR(255) NOT NULL,
    Precio DECIMAL(18, 2) DEFAULT 0.00,
    Stock DECIMAL(18, 2) DEFAULT 0.00,
    IDProveedor INT,
    FOREIGN KEY (IDProveedor) REFERENCES T_PROVEEDOR(ID)
);