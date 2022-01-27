--Problem 18
SELECT TOP(5) k.CountryName, k.PeakName, k.HighestPeak, k.MountainRange
	FROM ( SELECT c.CountryName,
			ISNULL(p.PeakName, '(no highest peak)') AS PeakName,
			ISNULL(m.MountainRange, '(no mountain)') AS MountainRange,
			ISNULL(MAX(p.Elevation), 0) AS HighestPeak,
			DENSE_RANK() OVER (PARTITION BY c.CountryName ORDER BY MAX(p.Elevation) DESC) AS Ranked
				FROM Countries AS c
				LEFT JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
				LEFT JOIN Mountains AS m ON m.Id = mc.MountainId
				LEFT JOIN Peaks AS p ON p.MountainId = m.Id
				GROUP BY c.CountryName, p.PeakName, m.MountainRange) AS k
			WHERE Ranked = 1
			ORDER BY CountryName, PeakName