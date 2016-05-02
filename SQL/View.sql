CREATE VIEW [Sklyar_A].[Good_Info] AS
SELECT result.[Unit Id] AS 'Unit Id', SUM(quantity) AS 'Unit Quantity'
FROM Sklyar_A.goods_moves AS goods_moves 
JOIN  
	(SELECT goods.Id_goods AS 'Unit Id', 
		goods.price AS 'Unit Price', 
		good_name AS 'Unit Name', 
		Name AS 'Book Name' 
	FROM Sklyar_A.goods as goods LEFT JOIN Sklyar_A.books as books 
	ON goods.Id_goods = books.Id_goods) AS result 
ON goods_moves.Id_goods = result.[Unit Id]
GROUP BY result.[Unit Id]
GO


