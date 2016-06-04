ALTER FUNCTION sklyar_a.gettotalearnings ()
returns @TOTALEARNINGS TABLE 
                             ( 
                                                          [Назва товару]	varchar(50), 
                                                          [Загальні покупки] int, 
                                                          [Назва книги]       varchar(50), 
                                                          [Автор] varchar(50), 
                                                          ISBN       varchar(50), 
                                                          [Рік видання] int, 
                                                          [Ім`я контрагента] varchar(50), 
                                                          [Телефон контрагента] varchar(20), 
                                                          [Адреса контрагента] varchar(100) 
                             ) 
                             AS BEGIN 
INSERT @TOTALEARNINGS
SELECT   goodname, 
         sum(quantity) * price AS 'Total Price', 
         NAME, 
         author, 
         isbn, 
         year, 
         contrname, 
         phone, 
         address 
FROM     ( 
                SELECT idmove, 
                       idgoods, 
                       quantity, 
                       contrname, 
                       phone, 
                       address 
                FROM   ( 
                              SELECT idmove, 
                                     idgoods, 
                                     abs(quantity) AS quantity, 
                                     idcontr 
                              FROM   ( 
                                            SELECT idmove, 
                                                   idgoods, 
                                                   abs(quantity) AS quantity, 
                                                   idcontr, 
                                                   iddoctype, 
                                                   docdate 
                                            FROM   sklyar_a.goodsmoves    AS g 
                                            JOIN   sklyar_a.documentation AS d 
                                            ON     g.iddoc = d.iddoc 
                                            WHERE  quantity < 0 
                                            AND    docdate <= cast(getdate() AS                     date)
                                            AND    docdate >= cast(dateadd(month, -1, getdate()) AS date)) AS dm
                              JOIN   sklyar_a.doctypes                                                     AS dt
                              ON     dm.iddoctype = dt.iddoctype 
                              WHERE  doctype = 'Sell') AS r 
                JOIN   sklyar_a.contractors            AS c 
                ON     r.idcontr = c.idcontr) AS cm 
JOIN 
         ( 
                SELECT gm.idgoods, 
                       gm.price, 
                       goodname, 
                       NAME, 
                       author, 
                       isbn, 
                       year, 
                       iddoc, 
                       idmove 
                FROM   ( 
                                 SELECT    g.idgoods, 
                                           g.price, 
                                           goodname, 
                                           NAME, 
                                           b.isbn, 
                                           b.author, 
                                           b.year 
                                 FROM      sklyar_a.goods AS g 
                                 LEFT JOIN sklyar_a.books AS b 
                                 ON        g.idgoods = b.idgoods) AS gm 
                JOIN   sklyar_a.goodsmoves                        AS gom 
                ON     gm.idgoods = gom.idgoods) AS goom 
ON       cm.idmove = goom.idmove 
GROUP BY goom.idgoods, 
         price, 
         goodname, 
         NAME, 
         author, 
         isbn, 
         year, 
         contrname, 
         phone, 
         address 
RETURN 
END