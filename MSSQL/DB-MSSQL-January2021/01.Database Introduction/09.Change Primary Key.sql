----- Problem 9.Change Primary Key
ALTER TABLE Users
DROP CONSTRAINT PK__Users__3214EC0762CA258E

ALTER TABLE Users
ADD CONSTRAINT PK_Id_Username PRIMARY KEY(Id,Username)