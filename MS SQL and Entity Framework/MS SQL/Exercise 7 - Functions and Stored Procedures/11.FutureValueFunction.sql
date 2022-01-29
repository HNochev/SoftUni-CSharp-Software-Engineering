--Problem 11
CREATE FUNCTION ufn_CalculateFutureValue (@i DECIMAL(18, 4), @r FLOAT, @t INT)
RETURNS DECIMAL(18, 4)
BEGIN
	DECLARE @result DECIMAL(18, 4)

	SET @result = (@i * (POWER((1 + @r), @t)))

	RETURN @result
END

SELECT dbo.ufn_CalculateFutureValue(1000, 0.1, 5)