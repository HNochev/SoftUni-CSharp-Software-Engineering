--Problem 15
SELECT k.ContinentCode, k.CurrencyCode, k.Total
	FROM
		(SELECT ContinentCode, CurrencyCode, COUNT(CurrencyCode) AS Total, 
			DENSE_RANK() OVER (PARTITION BY ContinentCode ORDER BY COUNT(CurrencyCode) DESC) AS Ranked
			FROM Countries
		GROUP BY ContinentCode, CurrencyCode) AS k
	WHERE Ranked = 1 AND Total > 1
	ORDER BY ContinentCode