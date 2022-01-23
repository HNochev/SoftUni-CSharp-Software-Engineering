--Problem 10
ALTER TABLE Users
	ADD CONSTRAINT CH_PasswordIsAtLeastFiveSymbols
	CHECK (LEN(Password) > 5)
