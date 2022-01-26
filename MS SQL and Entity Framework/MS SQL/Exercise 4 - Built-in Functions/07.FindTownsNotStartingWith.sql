--Problem 7
SELECT TownID, [Name]
FROM Towns
WHERE [Name] LIKE '[^RBD]%'
ORDER BY [Name]