-- Usar la base de datos correcta
USE GestionPedidos;
GO

-- Borrar tablas si existen (en orden inverso de relaciones)
DROP TABLE IF EXISTS DetallePedidos;
DROP TABLE IF EXISTS Pedidos;
DROP TABLE IF EXISTS Productos;
DROP TABLE IF EXISTS Clientes;
DROP TABLE IF EXISTS FormasDePago;
GO

-- Crear tabla Clientes
CREATE TABLE Clientes (
    IdCliente INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100),
    Email NVARCHAR(100),
    Telefono NVARCHAR(20)
);
GO

-- Crear tabla Formas de Pago
CREATE TABLE FormasDePago (
    IdFormaPago INT PRIMARY KEY IDENTITY(1,1),
    Descripcion NVARCHAR(50)
);
GO

-- Crear tabla Productos
CREATE TABLE Productos (
    IdProducto INT PRIMARY KEY IDENTITY(1,1),  -- ID autoincrementable
    Nombre NVARCHAR(100),                      -- Nombre del producto
    Precio DECIMAL(10,2),                      -- Precio del producto
    Stock INT DEFAULT 0                        -- Stock disponible del producto (valor por defecto 0)
);
GO

-- Crear tabla Pedidos (con relaciones a Clientes y Formas de Pago)
CREATE TABLE Pedidos (
    IdPedido INT PRIMARY KEY IDENTITY(1,1),
    Fecha DATE,
    IdCliente INT NOT NULL,
    IdFormaPago INT NOT NULL,

    CONSTRAINT FK_Pedidos_Clientes FOREIGN KEY (IdCliente) REFERENCES Clientes(IdCliente),
    CONSTRAINT FK_Pedidos_FormasDePago FOREIGN KEY (IdFormaPago) REFERENCES FormasDePago(IdFormaPago)
);
GO

-- Crear tabla DetallePedidos
CREATE TABLE DetallePedidos (
    IdDetalle INT PRIMARY KEY IDENTITY(1,1),
    IdPedido INT NOT NULL,
    IdProducto INT NOT NULL,
    Cantidad INT NOT NULL CHECK (Cantidad > 0),
    Subtotal DECIMAL(18, 2),

    CONSTRAINT FK_DetallePedidos_Pedidos FOREIGN KEY (IdPedido) REFERENCES Pedidos(IdPedido),
    CONSTRAINT FK_DetallePedidos_Productos FOREIGN KEY (IdProducto) REFERENCES Productos(IdProducto)
);
GO

-- Crear el trigger para calcular Subtotal automáticamente
GO
CREATE TRIGGER trg_CalcularSubtotal
ON DetallePedidos
AFTER INSERT, UPDATE
AS
BEGIN
    UPDATE dp
    SET Subtotal = dp.Cantidad * p.Precio
    FROM DetallePedidos dp
    INNER JOIN Productos p ON dp.IdProducto = p.IdProducto
    WHERE dp.IdDetalle IN (SELECT IdDetalle FROM inserted);
END;
GO

--Consulta detalle del pedido para visual
SELECT dp.IdDetalle, p.IdPedido, pr.Nombre AS NombreProducto, dp.Cantidad, dp.Subtotal
FROM DetallePedidos dp
INNER JOIN Pedidos p ON dp.IdPedido = p.IdPedido
INNER JOIN Productos pr ON dp.IdProducto = pr.IdProducto
WHERE p.IdCliente = @idCliente


INSERT INTO Clientes (Nombre, Email, Telefono) VALUES
('Cliente_1', 'cliente1@example.com', '555-0001'),
('Cliente_2', 'cliente2@example.com', '555-0002'),
('Cliente_3', 'cliente3@example.com', '555-0003'),
('Cliente_4', 'cliente4@example.com', '555-0004'),
('Cliente_5', 'cliente5@example.com', '555-0005'),
('Cliente_6', 'cliente6@example.com', '555-0006'),
('Cliente_7', 'cliente7@example.com', '555-0007'),
('Cliente_8', 'cliente8@example.com', '555-0008'),
('Cliente_9', 'cliente9@example.com', '555-0009'),
('Cliente_10', 'cliente10@example.com', '555-0010'),
('Cliente_11', 'cliente11@example.com', '555-0011'),
('Cliente_12', 'cliente12@example.com', '555-0012'),
('Cliente_13', 'cliente13@example.com', '555-0013'),
('Cliente_14', 'cliente14@example.com', '555-0014'),
('Cliente_15', 'cliente15@example.com', '555-0015'),
('Cliente_16', 'cliente16@example.com', '555-0016'),
('Cliente_17', 'cliente17@example.com', '555-0017'),
('Cliente_18', 'cliente18@example.com', '555-0018'),
('Cliente_19', 'cliente19@example.com', '555-0019'),
('Cliente_20', 'cliente20@example.com', '555-0020'),
('Cliente_21', 'cliente21@example.com', '555-0021'),
('Cliente_22', 'cliente22@example.com', '555-0022'),
('Cliente_23', 'cliente23@example.com', '555-0023'),
('Cliente_24', 'cliente24@example.com', '555-0024'),
('Cliente_25', 'cliente25@example.com', '555-0025'),
('Cliente_26', 'cliente26@example.com', '555-0026'),
('Cliente_27', 'cliente27@example.com', '555-0027'),
('Cliente_28', 'cliente28@example.com', '555-0028'),
('Cliente_29', 'cliente29@example.com', '555-0029'),
('Cliente_30', 'cliente30@example.com', '555-0030'),
('Cliente_31', 'cliente31@example.com', '555-0031'),
('Cliente_32', 'cliente32@example.com', '555-0032'),
('Cliente_33', 'cliente33@example.com', '555-0033'),
('Cliente_34', 'cliente34@example.com', '555-0034'),
('Cliente_35', 'cliente35@example.com', '555-0035'),
('Cliente_36', 'cliente36@example.com', '555-0036'),
('Cliente_37', 'cliente37@example.com', '555-0037'),
('Cliente_38', 'cliente38@example.com', '555-0038'),
('Cliente_39', 'cliente39@example.com', '555-0039'),
('Cliente_40', 'cliente40@example.com', '555-0040');
GO
-- Insertar Formas de Pago
INSERT INTO FormasDePago (Descripcion) VALUES
('Efectivo'),
('Tarjeta de Crédito'),
('Tarjeta de Débito'),
('Transferencia Bancaria'),
('Pago Contra Entrega');
GO
-- Insertar Productos
-- Insertar productos con stock disponible
INSERT INTO Productos (Nombre, Precio, Stock) VALUES
('Producto A', 100.00, 50),
('Producto B', 150.00, 30),
('Producto C', 200.00, 75),
('Producto D', 250.00, 40),
('Producto E', 300.00, 20),
('Producto F', 350.00, 10),
('Producto G', 400.00, 5),
('Producto H', 450.00, 15),
('Producto I', 500.00, 100),
('Producto J', 550.00, 80),
('Producto K', 600.00, 150),
('Producto L', 650.00, 70),
('Producto M', 700.00, 25),
('Producto N', 750.00, 60),
('Producto O', 800.00, 90),
('Producto P', 850.00, 40),
('Producto Q', 900.00, 10),
('Producto R', 950.00, 35),
('Producto S', 1000.00, 55),
('Producto T', 1100.00, 45),
('Producto U', 1200.00, 30),
('Producto V', 1300.00, 65),
('Producto W', 1400.00, 20),
('Producto X', 1500.00, 75),
('Producto Y', 1600.00, 50),
('Producto Z', 1700.00, 60);
GO
-- Insertar Pedidos
INSERT INTO Pedidos (Fecha, IdCliente, IdFormaPago) VALUES
('2025-05-01', 1, 2),
('2025-05-02', 2, 3),
('2025-05-03', 3, 1),
('2025-05-04', 4, 4),
('2025-05-05', 5, 5),
('2025-05-06', 6, 2),
('2025-05-07', 7, 3),
('2025-05-08', 8, 1),
('2025-05-09', 9, 4),
('2025-05-10', 10, 5),
('2025-05-11', 11, 2),
('2025-05-12', 12, 3),
('2025-05-13', 13, 1),
('2025-05-14', 14, 4),
('2025-05-15', 15, 5),
('2025-05-16', 16, 2),
('2025-05-17', 17, 3),
('2025-05-18', 18, 1),
('2025-05-19', 19, 4),
('2025-05-20', 20, 5),
('2025-05-21', 21, 2),
('2025-05-22', 22, 3),
('2025-05-23', 23, 1),
('2025-05-24', 24, 4),
('2025-05-25', 25, 5);
GO
-- Insertar Detalle de Pedidos
INSERT INTO DetallePedidos (IdPedido, IdProducto, Cantidad) VALUES
(1, 1, 2),
(1, 2, 1),
(2, 3, 3),
(2, 4, 2),
(3, 5, 1),
(3, 6, 1),
(4, 7, 2),
(4, 8, 1),
(5, 9, 3),
(5, 10, 2),
(6, 11, 1),
(6, 12, 2),
(7, 13, 3),
(7, 14, 1),
(8, 15, 2),
(8, 16, 1),
(9, 17, 2),
(9, 18, 1),
(10, 19, 1),
(10, 20, 2),
(11, 21, 3),
(11, 22, 1),
(12, 23, 2),
(12, 24, 3),
(13, 25, 2),
(13, 26, 1);
GO


