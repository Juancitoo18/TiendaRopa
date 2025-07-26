-- Crear base de datos
CREATE DATABASE bdsistemaventas;
GO
USE bdsistemaventas;
GO

-- Tabla de usuarios
CREATE TABLE usuarios (
    id_usuario INT IDENTITY(1,1) PRIMARY KEY,
    nombre_usuario VARCHAR(100) NOT NULL UNIQUE,
    email_usuario VARCHAR(100) NOT NULL UNIQUE,
    contraseña_usuario VARCHAR(100) NOT NULL,
	restablecer_usuario VARCHAR(100) NOT NULL,
    rol_usuario VARCHAR(20) NOT NULL DEFAULT 'cliente',
    Estado BIT
);
GO

-- Tabla de provincias
CREATE TABLE provincias (
    id INT IDENTITY(1,1) PRIMARY KEY,
    provincia VARCHAR(255) NOT NULL,
    Estado BIT
);
GO

-- Tabla de localidades
CREATE TABLE localidades (
    id INT IDENTITY(1,1) PRIMARY KEY,
    id_provincia INT NOT NULL,
    localidad VARCHAR(255) NOT NULL,
    Estado BIT,
    FOREIGN KEY (id_provincia) REFERENCES provincias(id)
);
GO

-- Tabla de clientes
CREATE TABLE clientes (
    id_cliente INT IDENTITY(1,1) PRIMARY KEY,
    nombre_cliente VARCHAR(100),
    dni_cliente VARCHAR(45),
    apellido_cliente VARCHAR(45),
    sexo_cliente VARCHAR(45),
    fechaNacimiento_cliente DATE,
    telefono_cliente VARCHAR(20),
    direccion_cliente TEXT,
    id_usuario_cliente INT UNIQUE NULL,
    id_provincia_cliente INT NULL,
    id_localidad_cliente INT NULL,
    Estado BIT,
    FOREIGN KEY (id_usuario_cliente) REFERENCES usuarios(id_usuario) ON DELETE SET NULL,
    FOREIGN KEY (id_provincia_cliente) REFERENCES provincias(id) ON DELETE SET NULL,
    FOREIGN KEY (id_localidad_cliente) REFERENCES localidades(id) ON DELETE SET NULL
);
GO

-- Tabla de categorías
CREATE TABLE categorias (
    id_categoria INT IDENTITY(1,1) PRIMARY KEY,
    nombre_categoria VARCHAR(500) NOT NULL UNIQUE,
    Estado BIT
);
GO

-- Tabla de productos
CREATE TABLE productos (
    id_producto INT IDENTITY(1,1) PRIMARY KEY,
    nombre_producto VARCHAR(100) NOT NULL,
    descripcion_producto TEXT,
    precio_producto DECIMAL(10,2) NOT NULL,
    stock_producto INT NOT NULL,
    id_categoria_producto INT,
    id_temporada_producto INT,
    imagen_producto VARCHAR(255) NULL,
    Estado BIT,
    FOREIGN KEY (id_categoria_producto) REFERENCES categorias(id_categoria),
);
GO

-- Tabla de ventas
CREATE TABLE ventas (
    id_venta INT IDENTITY(1,1) PRIMARY KEY,
    id_cliente_vt INT,
    fecha_vt DATETIME DEFAULT GETDATE(),
    metodo_envio INT,
    total_vt DECIMAL(10,2) NOT NULL,
    Estado BIT,
    FOREIGN KEY (id_cliente_vt) REFERENCES clientes(id_cliente)
);
GO

-- Tabla de detalle_ventas
CREATE TABLE detalle_ventas (
    id_detalle INT IDENTITY(1,1) PRIMARY KEY,
    id_venta_dt INT,
    id_producto_dt INT,
    cantidad_dt INT NOT NULL,
    precio_unitario_dt DECIMAL(10,2) NOT NULL,
    subtotal_dt DECIMAL(10,2) NOT NULL,
    Estado BIT,
    FOREIGN KEY (id_venta_dt) REFERENCES ventas(id_venta),
    FOREIGN KEY (id_producto_dt) REFERENCES productos(id_producto)
);
GO

-- Tabla de pagos
CREATE TABLE pagos (
    id_pago INT IDENTITY(1,1) PRIMARY KEY,
    id_venta INT,
    metodo_pago INT NOT NULL,  -- 1=Tarjeta Crédito, 2=Débito, etc.
    estado VARCHAR(20) NOT NULL DEFAULT 'pendiente',
    fecha_pago DATETIME DEFAULT GETDATE(),
    total_pagado DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (id_venta) REFERENCES ventas(id_venta)
);
GO

-- Insertar provincias
INSERT INTO provincias (provincia, Estado) VALUES
('Buenos Aires', 1),
('Buenos Aires-GBA', 1),
('Capital Federal', 1),
('Catamarca', 1),
('Chaco', 1),
('Chubut', 1),
('Córdoba', 1),
('Corrientes', 1),
('Entre Ríos', 1);
GO

INSERT INTO usuarios (nombre_usuario, email_usuario, contraseña_usuario, restablecer_usuario, rol_usuario, Estado)
VALUES 
('juanperez', 'juan@example.com', 'clave123', 'respuesta1', 'admin', 1),
('mariagomez', 'maria@example.com', 'pass456', 'respuesta2', 'cliente', 1),
('carloslopez', 'carlos@example.com', 'abc789', 'respuesta3', 'cliente', 0),
('lauradiaz', 'laura@example.com', 'laura2024', 'respuesta4', 'cliente', 1),
('adminuser', 'admin@example.com', 'adminsecure', 'adminresp', 'admin', 1);
