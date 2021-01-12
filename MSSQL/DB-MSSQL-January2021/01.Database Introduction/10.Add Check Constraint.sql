----- Problem 10.Add Check Constraint
ALTER TABLE Users
ADD CONSTRAINT CHK_Password CHECK (LEN([Password])>5)