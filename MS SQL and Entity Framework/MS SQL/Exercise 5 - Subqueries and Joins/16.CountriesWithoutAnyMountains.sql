--Problem 16
SELECT COUNT(*)
	FROM Countries AS c
	LEFT JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
	WHERE mc.MountainId IS NULL
	GROUP BY mc.MountainId