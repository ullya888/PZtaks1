USE TradingCompany; 
GO

INSERT INTO Categories (Name) VALUES 
('Палетки тіней'), ('Тональні основи'), ('Консилери'), ('Пудри'), ('Рум''яна'), 
('Бронзери'), ('Хайлайтери'), ('Туші для вій'), ('Олівці для очей'), ('Підводки'), 
('Гелі для брів'), ('Олівці для брів'), ('Губні помади'), ('Блиски для губ'), ('Олівці для губ'), 
('Праймери'), ('Фіксатори макіяжу'), ('Пензлі для макіяжу'), ('Спонжі'), ('Засоби для демакіяжу');

INSERT INTO Products (CategoryId, Name, Price) VALUES 
(1, 'Natasha Denona Glam Palette (Cool-toned)', 3200.00), (2, 'Estee Lauder Double Wear', 2100.00), (3, 'Tarte Shape Tape Concealer', 1200.00), 
(4, 'Laura Mercier Translucent Powder', 1800.00), (5, 'Rare Beauty Soft Pinch Blush', 1100.00), 
(6, 'Physicians Formula Butter Bronzer', 650.00), (7, 'Dior Backstage Glow Face Palette', 2300.00), (8, 'Maybelline Lash Sensational', 350.00), 
(9, 'Urban Decay 24/7 Glide-On Eye Pencil', 950.00), (10, 'NYX Epic Ink Liner', 450.00), 
(11, 'Anastasia Beverly Hills Clear Brow Gel', 1050.00), (12, 'Vivienne Sabo Brow Arcade', 250.00), (13, 'MAC Matte Lipstick', 999.00), 
(14, 'Fenty Beauty Gloss Bomb', 1150.00), (15, 'Charlotte Tilbury Lip Cheat', 1100.00), 
(16, 'Smashbox Photo Finish Primer', 1600.00), (17, 'Urban Decay All Nighter Setting Spray', 1500.00), (18, 'Real Techniques Brush Set', 1200.00), 
(19, 'Beautyblender Original', 850.00), (20, 'Bioderma Sensibio H2O Micellar Water', 750.00);


INSERT INTO Users (Login, PasswordHash) VALUES 
('user1', 'x9K2mP5vL8'), ('user2', 'bR7qW3tY1c'), ('user3', 'gH4nJ8sD2f'), ('user4', 'wK9xM1bV6t'), ('user5', 'pL5cR2zN4j'), 
('user6', 'yT8qW6kF3d'), ('user7', 'vB1mX9cS7h'), ('user8', 'jD4fG5pL2r'), ('user9', 'nC2sV8bM9k'), ('user10', 'xZ7wQ1tY4p'), 
('user11', 'kF3jH6dG9s'), ('user12', 'mP8rL2cV5b'), ('user13', 'tY1wX7zN4q'), ('user14', 'cS9hV3mB6k'), ('user15', 'dG5fJ8pL1r'), 
('user16', 'bM2nC4xZ9v'), ('user17', 'qW8eR1tY5u'), ('user18', 'pA3sD7fG2h'), ('user19', 'jK6lZ9xN4m'), ('user20', 'vC4bM2nQ8w');

INSERT INTO CartItems (UserId, ProductId, Quantity) VALUES 
(1, 2, 1), (2, 5, 2), (3, 12, 1), (4, 1, 1), (5, 8, 2), 
(6, 15, 1), (7, 3, 1), (8, 19, 3), (9, 7, 1), (10, 10, 1), 
(11, 4, 1), (12, 6, 1), (13, 9, 2), (14, 11, 1), (15, 14, 1), 
(16, 17, 1), (17, 18, 2), (18, 20, 5), (19, 13, 1), (20, 16, 1);