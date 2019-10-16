--01. DDL--

CREATE DATABASE Bitbucket

USE Bitbucket

CREATE TABLE Users(
	Id INT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) NOT NULL,
	[Password] VARCHAR(30) NOT NULL,
	Email VARCHAR(50) NOT NULL
)

CREATE TABLE Repositories(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
)

CREATE TABLE RepositoriesContributors(
	RepositoryId INT FOREIGN KEY REFERENCES Repositories(Id) NOT NULL,
	ContributorId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL
	CONSTRAINT PK_CompositeRepositoryIdContributorId
	PRIMARY KEY(RepositoryId, ContributorId)
)

CREATE TABLE Issues(
	Id INT PRIMARY KEY IDENTITY,
	Title VARCHAR(255) NOT NULL,
	IssueStatus CHAR(6) NOT NULL,
	RepositoryId INT FOREIGN KEY REFERENCES Repositories(Id) NOT NULL,
	AssigneeId INT FOREIGN KEY REFERENCES Users(Id)
	)

CREATE TABLE Commits(
	Id INT PRIMARY KEY IDENTITY,
	[Message] VARCHAR(255) NOT NULL,
	IssueId INT FOREIGN KEY REFERENCES Issues(Id),
	RepositoryId INT FOREIGN KEY REFERENCES Repositories(Id) NOT NULL,
	ContributorId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL
)

CREATE TABLE Files(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(100) NOT NULL,
	Size DECIMAL(18,2) NOT NULL,
	ParentId INT FOREIGN KEY REFERENCES Files(Id),
	CommitId INT FOREIGN KEY REFERENCES Commits(Id) NOT NULL
)

--02. Insert--

INSERT INTO Files([Name], Size, CommitId) VALUES
('Trade.idk', 2598.0, 1),
('menu.net', 9238.31, 2),
('Administrate.soshy', 1246.93, 3),
('Controller.php', 7353.15, 4),
('Find.java', 9957.86, 5),
('Controller.json', 14034.87, 6),
('Operate.xix', 7662.92, 7)

INSERT INTO Issues(Title, IssueStatus,RepositoryId, AssigneeId) VALUES
('Critical Problem with HomeController.cs file', 'open', 1, 4),
('Typo fix in Judge.html', 'open', 4, 3),
('Implement documentation for UsersService.cs', 'closed', 8, 2),
('Unreachable code in Index.cs', 'open', 9, 8)

--03. Update--

UPDATE Issues
SET IssueStatus = 'closed'
WHERE AssigneeId = 6


--04. Delete--

DELETE FROM RepositoriesContributors
WHERE RepositoryId IN(SELECT Id 
						FROM Repositories
						WHERE [Name] = 'Softuni-Teamwork')

DELETE FROM Issues
WHERE RepositoryId IN(SELECT Id 
						FROM Repositories
						WHERE [Name] = 'Softuni-Teamwork')


--05. Commits--

SELECT Id, [Message], RepositoryId, ContributorId 
FROM Commits
ORDER BY Id, [Message], RepositoryId, ContributorId

--06. Heavy HTML--

SELECT Id, [Name], Size
FROM Files
WHERE SIZE > 1000 AND [Name] LIKE '%html%'
ORDER BY Size DESC, Id, [Name]
 
--07. Issues and Users--

SELECT i.Id, CONCAT(u.Username, ' : ', i.Title) AS [IssueAssignee]
FROM Users AS u
JOIN Issues AS i
ON i.AssigneeId = u.Id
ORDER BY i.Id DESC, [IssueAssignee]

--08. Non-Directory Files--

SELECT f.Id, 
       f.[Name], 
       CONCAT(f.Size, 'KB') AS [Size]
FROM Files AS f
LEFT JOIN Files AS fi ON fi.ParentId = f.Id
WHERE fi.Id IS NULL
ORDER BY f.Id, 
         f.[Name], 
         f.Size DESC

--09. Most Contributed Repositories--

SELECT TOP (5) r.Id, 
       r.[Name], 
       COUNT(c.Id) AS [Commits]
FROM Repositories AS r
     JOIN Commits AS c ON r.Id = c.RepositoryId
     JOIN RepositoriesContributors AS rc ON r.Id = rc.RepositoryId
GROUP BY r.Id, 
         r.[Name]
ORDER BY COUNT(c.Id) DESC, 
         r.Id, 
         r.[Name]

--10. User and Files--

SELECT u.Username, AVG(f.Size) AS [Size]
FROM Users AS u
JOIN Commits AS c
ON U.Id = C.ContributorId
JOIN Files AS f
ON f.CommitId = c.Id
GROUP BY U.Username
ORDER BY [Size] DESC, u.Username

--11. User Total Commits--
GO
CREATE FUNCTION udf_UserTotalCommits(@username VARCHAR(50))
RETURNS INT
AS
BEGIN
	DECLARE @count INT = (SELECT COUNT(c.Id) 
							FROM Users AS u
							JOIN Commits AS c
							ON c.ContributorId = u.Id
							WHERE U.Username = @username
							)

	RETURN @count
END

SELECT dbo.udf_UserTotalCommits('UnderSinduxrein')

--12. Find by Extensions--

CREATE PROCEDURE usp_FindByExtension(@extension VARCHAR(10))
AS
BEGIN
	SELECT Id, [Name], CONCAT(Size, 'KB') AS [Size]
	FROM Files
	WHERE [Name] LIKE CONCAT('%.', @extension)
	ORDER BY Id, [Name], Size DESC
END

EXEC usp_FindByExtension 'txt'