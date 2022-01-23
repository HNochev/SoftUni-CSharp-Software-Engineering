--Problem 9
ALTER TABLE Users
DROP CONSTRAINT PK__Users__3214EC07D8634093
-- Намира се в Keys на дадена таблица.

ALTER TABLE Users
  ADD CONSTRAINT IdUsername_PK
    PRIMARY KEY (Id, Username)
