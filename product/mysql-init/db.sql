CREATE DATABASE IF NOT EXISTS ecommerceproductsdatabase;
USE ecommerceproductsdatabase;

-- إنشاء الجدول (إذا مش بتستخدم migrations)
CREATE TABLE IF NOT EXISTS Products (
    ProductId CHAR(36) PRIMARY KEY,
    ProductName VARCHAR(255) NOT NULL,
    Category VARCHAR(100) NOT NULL,
    UnitPrice DOUBLE,
    QuantityInStock INT
);


INSERT INTO ecommerceproductsdatabase.Products (ProductId, ProductName, Category, UnitPrice, QuantityInStock) VALUES
('3fa85f64-5717-4562-b3fc-2c963f66afa6', 'iPhone 15 Pro', 'Electronics', 999.99, 50),
('12345678-1234-1234-1234-123456789012', 'Samsung Galaxy S24', 'Electronics', 899.99, 75),
('a1b2c3d4-e5f6-7890-abcd-ef1234567890', 'MacBook Pro M3', 'Electronics', 2499.99, 30),
('b2c3d4e5-f6a7-8901-bcde-f12345678901', 'AirPods Pro', 'Electronics', 249.99, 100),
('c3d4e5f6-a7b8-9012-cdef-123456789012', 'iPad Air', 'Electronics', 599.99, 60),
('d4e5f6a7-b8c9-0123-def0-234567890123', 'Sony WH-1000XM5', 'Electronics', 399.99, 85),
('e5f6a7b8-c9d0-1234-ef01-345678901234', 'Dell XPS 15', 'Electronics', 1799.99, 40),
('f6a7b8c9-d0e1-2345-f012-456789012345', 'Apple Watch Series 9', 'Electronics', 429.99, 90),
('a7b8c9d0-e1f2-3456-0123-567890123456', 'Lenovo ThinkPad X1', 'Electronics', 1599.99, 45),
('b8c9d0e1-f2a3-4567-1234-678901234567', 'Google Pixel 8 Pro', 'Electronics', 999.00, 55),
('c9d0e1f2-a3b4-5678-2345-789012345678', 'Microsoft Surface Pro 9', 'Electronics', 1299.99, 35),
('d0e1f2a3-b4c5-6789-3456-890123456789', 'Canon EOS R6', 'Cameras', 2499.00, 20),
('e1f2a3b4-c5d6-7890-4567-901234567890', 'Nintendo Switch OLED', 'Gaming', 349.99, 120),
('f2a3b4c5-d6e7-8901-5678-012345678901', 'PlayStation 5', 'Gaming', 499.99, 25),
('a3b4c5d6-e7f8-9012-6789-123456789012', 'Xbox Series X', 'Gaming', 499.99, 30),
('b4c5d6e7-f8a9-0123-7890-234567890123', 'Bose QuietComfort 45', 'Electronics', 329.99, 70),
('c5d6e7f8-a9b0-1234-8901-345678901234', 'Kindle Paperwhite', 'Electronics', 139.99, 150),
('d6e7f8a9-b0c1-2345-9012-456789012345', 'GoPro Hero 12', 'Cameras', 399.99, 50),
('e7f8a9b0-c1d2-3456-0123-567890123456', 'Fitbit Charge 6', 'Wearables', 159.99, 110),
('f8a9b0c1-d2e3-4567-1234-678901234567', 'Razer DeathAdder V3', 'Gaming', 69.99, 200);