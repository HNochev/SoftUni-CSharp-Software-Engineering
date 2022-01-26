--Problem 12
USE Geography
SELECT CountryName AS [Country Name], IsoCode AS [ISO Code]
FROM Countries
WHERE (LEN(CountryName) - LEN(REPLACE(CountryName, 'a', ''))) >= 3
ORDER BY [ISO Code] ASC