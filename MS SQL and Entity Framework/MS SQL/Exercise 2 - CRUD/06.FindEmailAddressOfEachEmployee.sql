--Problem 6
SELECT CONCAT(FirstName,'.',LastName,'@softuni.bg') AS Email
	FROM Employees

SELECT FirstName + '.' + LastName + '@softuni.bg' AS Email
	FROM Employees