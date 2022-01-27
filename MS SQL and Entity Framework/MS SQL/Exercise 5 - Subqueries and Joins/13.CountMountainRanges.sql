--Problem 13
SELECT c.CountryCode, COUNT(*)
	FROM Countries AS c
	JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
	JOIN Mountains AS m ON m.Id = mc.MountainId
	WHERE c.CountryCode IN('US', 'RU', 'BG')
	GROUP BY c.CountryCode

SELECT c.CountryCode, 
	(SELECT COUNT(*) AS Total
		FROM MountainsCountries AS mc
		WHERE mc.CountryCode = c.CountryCode)
	FROM Countries AS c
	WHERE c.CountryCode IN('US', 'RU', 'BG')