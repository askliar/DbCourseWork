USE [CarDb] GO /****** Object:  View [Romanovska_S].[GoodInfo]    Script Date: 08.06.2016 20:12:51 ******/
SET ANSI_NULLS ON GO
SET QUOTED_IDENTIFIER ON GO
ALTER VIEW [Romanovska_S].[GoodInfo] AS
SELECT god.IdGoods,
       SUM(QUANTITY) AS Quantity,
       Price,
       GoodName,
       ContrName,
       Phone,
       Address
FROM
    (SELECT IdMove,
            IdGoods,
            Quantity,
            ContrName,
            Phone,
            Address
     FROM
         (SELECT IdMove,
                 IdGoods,
                 Quantity,
                 IdContr
          FROM Romanovska_S.GoodsMoves AS g
          JOIN Romanovska_S.Documentation AS d ON g.IdDoc = d.IdDoc
          WHERE quantity < 0
              AND docdate <= cast(getdate() AS date)
              AND docdate >= cast(dateadd(MONTH, -1, getdate()) AS date)) AS r
     JOIN Romanovska_S.Contractors AS c ON r.IdContr = c.IdContr) AS cm
JOIN
    (SELECT goom.IdGoods,
            goom.Price,
            goom.GoodName,
            IdDoc,
            IdMove
     FROM
         (SELECT g.IdGoods,
                 g.Price,
                 g.GoodName,
                 IdDoc,
                 IdMove
          FROM Romanovska_S.Goods AS g
          JOIN Romanovska_S.GoodsMoves AS gom ON g.IdGoods = gom.IdGoods) AS goom) AS god ON cm.IdMove = god.IdMove
GROUP BY god.IdGoods,
         Price,
         GoodName,
         ContrName,
         Phone,
         Address GO
