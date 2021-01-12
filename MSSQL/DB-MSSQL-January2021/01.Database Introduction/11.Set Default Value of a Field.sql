----- Problem 11.Set Default Value of a Field
ALTER TABLE Users
ADD CONSTRAINT df_LastLoginTime
DEFAULT GETDATE() FOR LastLoginTime