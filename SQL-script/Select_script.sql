SELECT p.Name,
c.Name
FROM Products p
LEFT JOIN Categories c on p.Category_id = c.Category_id;