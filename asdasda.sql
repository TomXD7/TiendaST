use northwind;

select a.ProductID, a.ProductName, round(sum((b.Quantity * b.UnitPrice)),2) as Total
from products a, orderdetails b 
where a.ProductID = b.ProductID 
group by a.ProductID order by Total desc limit 3;

SELECT ProductId, SUM(UnitPrice*Quantity) AS Monto FROM orderdetails GROUP BY ProductId ORDER BY Monto DESC LIMIT 3;

