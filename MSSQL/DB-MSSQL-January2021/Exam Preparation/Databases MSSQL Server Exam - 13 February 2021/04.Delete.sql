--4.	Delete

DELETE FROM RepositoriesContributors
WHERE RepositoryId IN(SELECT Id FROM Repositories WHERE [Name] = 'Softuni-Teamwork')

DELETE FROM Issues
WHERE RepositoryId IN(SELECT Id FROM Repositories WHERE [Name] = 'Softuni-Teamwork')
