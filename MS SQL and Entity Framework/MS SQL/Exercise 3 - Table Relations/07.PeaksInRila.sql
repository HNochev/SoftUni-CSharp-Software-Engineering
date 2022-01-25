--Problem 7
USE Geography

SELECT MountainRange, PeakName, Elevation
FROM Peaks
INNER JOIN Mountains
ON Mountains.Id = Peaks.MountainId
WHERE MountainRange = 'Rila'
ORDER BY Elevation DESC

--От презентацията
SELECT m.MountainRange, p.PeakName, p.Elevation 
FROM Mountains AS m
JOIN Peaks As p ON p.MountainId = m.Id
WHERE m.MountainRange = 'Rila'
ORDER BY p.Elevation DESC
