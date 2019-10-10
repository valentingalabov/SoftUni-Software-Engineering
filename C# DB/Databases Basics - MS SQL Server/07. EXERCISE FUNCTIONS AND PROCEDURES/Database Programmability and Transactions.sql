--01. Employees with Salary Above 35000--

CREATE PROC usp_GetEmployeesSalaryAbove35000
AS
	SELECT FirstName, LastName
	FROM Employees
	WHERE Salary > 35000

EXEC usp_GetEmployeesSalaryAbove35000 

--02. Employees with Salary Above Number--

CREATE PROC usp_GetEmployeesSalaryAboveNumber(@valueAbove DECIMAL(18, 4))
AS
	SELECT FirstName, LastName
	FROM Employees
	WHERE Salary >= @valueAbove

EXEC usp_GetEmployeesSalaryAboveNumber 48100

--03. Town Names Starting With--

CREATE PROC usp_GetTownsStartingWith (@startingWith NVARCHAR(50))
AS
	SELECT [Name] AS [Town]
	FROM Towns
	WHERE [Name] LIKE @startingWith + '%'

EXEC usp_GetTownsStartingWith 'b'

--04. Employees from Town--

CREATE PROC usp_GetEmployeesFromTown(@townName NVARCHAR(50))
AS
	SELECT e.FirstName, e.LastName
	FROM Employees AS e
	JOIN Addresses AS a
	ON e.AddressID = a.AddressID
	JOIN Towns AS t
	ON t.TownID=a.TownID
	WHERE t.[Name] = @townName


EXEC usp_GetEmployeesFromTown 'Sofia'

--05. Salary Level Function--

CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS VARCHAR(7)
AS 
BEGIN
	DECLARE @salaryLevel VARCHAR(7) =  CASE
		WHEN @salary < 30000 THEN 'Low'
		WHEN @salary BETWEEN 30000 AND 50000 THEN  'Average'
		ELSE 'High'	
	END 
		RETURN @salaryLevel
END

SELECT Salary, dbo.ufn_GetSalaryLevel(Salary)  FROM Employees

--05. Salary Level Function - second solution --

CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS VARCHAR(7)
AS
BEGIN
	DECLARE @salaryLevel VARCHAR(7)
		
		IF(@salary < 30000)
		BEGIN
			SET @salaryLevel = 'Low'
		END

		ELSE IF(@salary <= 50000)
		BEGIN
			SET @salaryLevel = 'Average'
		END

		ELSE 
		BEGIN
			SET @salaryLevel = 'High'
		END

	RETURN @salaryLevel
END

--06. Employees by Salary Level--

CREATE PROC usp_EmployeesBySalaryLevel(@salaryLevel VARCHAR(7))
AS
BEGIN
	SELECT FirstName, LastName 
	FROM Employees AS e
	WHERE dbo.ufn_GetSalaryLevel(e.Salary) = @salaryLevel
END


EXEC dbo.usp_EmployeesBySalaryLevel'High'

--07. Define Function--


CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(MAX), @word VARCHAR(MAX))
RETURNS BIT
AS
BEGIN
	DECLARE @counter INT = 1
	DECLARE @currentLetter CHAR

	WHILE(@counter <= LEN(@word))
	BEGIN
		SET @currentLetter = SUBSTRING(@word , @counter, 1)
		DECLARE @charIndex INT = CHARINDEX(@currentLetter, @setOfLetters)
		IF(@charIndex <= 0)
		BEGIN
			RETURN 0
		END

		SET @counter +=1
	END

	RETURN 1
END

SELECT dbo.ufn_IsWordComprised('oistmiahf', 'halves')

--08. Delete Employees and Departments--

CREATE PROC usp_DeleteEmployeesFromDepartment (@departmentId INT)
AS
BEGIN
	DELETE FROM EmployeesProjects
	WHERE EmployeeID IN (
			SELECT EmployeeID 
			FROM Employees
			WHERE DepartmentID = @departmentId	
		)

	UPDATE Employees
	SET ManagerID = NULL
	WHERE ManagerID IN (SELECT EmployeeID 
			FROM Employees
			WHERE DepartmentID = @departmentId)

	ALTER TABLE Departments
	ALTER COLUMN ManagerId INT

	UPDATE Departments
	SET ManagerID = NULL
	WHERE DepartmentID = @departmentId

	DELETE FROM Employees
	WHERE DepartmentID = @departmentId

	DELETE FROM Departments
	WHERE DepartmentID = @departmentId

	SELECT COUNT(*) FROM Employees
	WHERE DepartmentID = @departmentId

END

--09. Find Full Name--

CREATE PROC usp_GetHoldersFullName AS
SELECT CONCAT(FirstName, ' ', LastName) AS [Full Name] FROM AccountHolders

EXEC usp_GetHoldersFullName


--10. People with Balance Higher Than--

CREATE PROC usp_GetHoldersWithBalanceHigherThan @minBalance MONEY
AS
BEGIN
	SELECT ah.FirstName, ah.LastName
	FROM Accounts AS a
	JOIN AccountHolders AS ah
	ON A.AccountHolderId = ah.Id
	GROUP BY ah.FirstName, ah.LastName
	HAVING SUM(a.Balance) > @minBalance
	ORDER BY ah.FirstName, ah.LastName

END

EXEC dbo.usp_GetHoldersWithBalanceHigherThan 1000

--11. Future Value Function--

CREATE FUNCTION ufn_CalculateFutureValue(@sum DECIMAL(16,2), @yearlyInterestRate FLOAT, @numberOfYear INT)
RETURNS DECIMAL(18,4)
AS
BEGIN
	DECLARE @result DECIMAL(18,4)
		SET @result = @sum * (POWER((1+ @yearlyInterestRate),@numberOfYear))
	RETURN @result
END

SELECT dbo.ufn_CalculateFutureValue(1000, 0.1, 5)


--12. Calculating Interest--

CREATE PROC usp_CalculateFutureValueForAccount(@AccountID INT, @InterestRate FLOAT) AS
SELECT 
	a.Id AS [Account Id], 
	ah.FirstName AS [First Name],
	ah.LastName AS [Last Name],
	a.Balance AS [Current Balance],
	dbo.ufn_CalculateFutureValue(a.Balance, @InterestRate, 5) AS [Balance in 5 years] 
	FROM Accounts AS a
JOIN AccountHolders AS ah
ON a.AccountHolderId = ah.Id AND a.Id = @AccountID

EXEC usp_CalculateFutureValueForAccount 1, 0.1

--13. *Cash in User Games Odd Rows--

CREATE FUNCTION ufn_CashInUsersGames(@gameName VARCHAR(MAX))
RETURNS @output TABLE (SumCash DECIMAL(18,4))
AS
BEGIN
	INSERT INTO @output SELECT( SELECT SUM(Cash) AS [SumCash] FROM (SELECT * , ROW_NUMBER() OVER(ORDER BY Cash DESC) AS [RowNum] FROM UsersGames
	WHERE GameId IN (
				SELECT Id FROM Games
				WHERE [Name] = @gameName
				)) AS [RowNumTable]
	WHERE [RowNum] % 2 <> 0 )
		
	RETURN
END

SELECT * FROM dbo.ufn_CashInUsersGames('Love in a mist')

--14. Create Table Logs--

CREATE TABLE Logs
(
	LogID INT PRIMARY KEY IDENTITY,
	AccountID INT FOREIGN KEY REFERENCES Accounts(Id),
	OldSum MONEY NOT NULL,
	NewSum MONEY NOT NULL
)


CREATE TRIGGER tr_AccountsUpdate ON Accounts FOR UPDATE
AS
  INSERT INTO Logs
  SELECT inserted.Id, deleted.Balance, inserted.Balance FROM inserted
  JOIN deleted
  ON inserted.Id = deleted.Id

UPDATE Accounts
SET Balance -= 10
WHERE Id = 1

SELECT * FROM Logs

--15. Create Table Emails--

CREATE TABLE NotificationEmails
(
	Id INT PRIMARY KEY IDENTITY,
	Recipient INT FOREIGN KEY REFERENCES Accounts(Id),
	Subject VARCHAR(100),
	Body VARCHAR(200)
)
GO

CREATE TRIGGER tr_LogsInsert ON Logs FOR INSERT
AS
	INSERT INTO NotificationEmails
	SELECT AccountId,  
		'Balance change for account: ' + CAST(AccountID AS varchar(20)),
		'On ' + CONVERT(VARCHAR(50), GETDATE(), 100) + ' your balance was changed from ' + 
		CAST(OldSum AS varchar(20)) + ' to ' + CAST(NewSum AS varchar(20))
		FROM inserted

UPDATE Accounts
SET Balance -= 10
WHERE Id = 1

SELECT * FROM NotificationEmails

--16. Deposit Money--

CREATE PROC usp_DepositMoney (@AccountId INT, @MoneyAmount MONEY) AS
BEGIN
	BEGIN TRAN
		IF (@MoneyAmount > 0)
		BEGIN
			UPDATE Accounts
			SET Balance += @MoneyAmount
			WHERE Id = @AccountId

			IF @@ROWCOUNT != 1
			BEGIN
				ROLLBACK
				RAISERROR('Invalid account!', 16, 1)
				RETURN
			END
		END
	COMMIT
END 

EXEC usp_DepositMoney 1, 10
SELECT * FROM Accounts

--17. Withdraw Money Procedure--

CREATE PROC usp_WithdrawMoney (@AccountId INT, @MoneyAmount MONEY) AS
BEGIN
	BEGIN TRAN
		IF (@MoneyAmount > 0)
		BEGIN
			UPDATE Accounts
			SET Balance -= @MoneyAmount
			WHERE Id = @AccountId

			IF @@ROWCOUNT != 1
			BEGIN
				ROLLBACK
				RAISERROR('Invalid account!', 16, 1)
				RETURN
			END
		END
	COMMIT
END

EXEC usp_WithdrawMoney 5, 25
SELECT * FROM Accounts

--18. Money Transfer--

CREATE PROC usp_TransferMoney(@SenderId INT, @ReceiverId INT, @Amount money) AS
BEGIN 
	BEGIN TRAN
		IF(@Amount > 0)
		BEGIN
			EXEC usp_WithdrawMoney @SenderId, @Amount
			EXEC usp_DepositMoney @ReceiverId, @Amount
		END
	COMMIT
END

EXEC usp_TransferMoney 5, 1, 5000

SELECT * FROM Accounts

--19. Trigger--

USE Diablo
GO

CREATE TRIGGER tr_UserGameItems ON UserGameItems INSTEAD OF INSERT AS
BEGIN 
	INSERT INTO UserGameItems
	SELECT i.Id, ug.Id FROM inserted
	JOIN UsersGames AS ug
	ON UserGameId = ug.Id
	JOIN Items AS i
	ON ItemId = i.Id
	WHERE ug.Level >= i.MinLevel
END
GO

UPDATE UsersGames
SET Cash += 50000
FROM UsersGames AS ug
JOIN Users AS u
ON ug.UserId = u.Id
JOIN Games AS g
ON ug.GameId = g.Id
WHERE g.Name = 'Bali' AND u.Username IN('baleremuda', 'loosenoise', 'inguinalself', 'buildingdeltoid', 'monoxidecos')
GO

CREATE PROC usp_BuyItems(@Username VARCHAR(100)) AS
BEGIN
	DECLARE @UserId INT = (SELECT Id FROM Users WHERE Username = @Username)
	DECLARE @GameId INT = (SELECT Id FROM Games WHERE Name = 'Bali')
	DECLARE @UserGameId INT = (SELECT Id FROM UsersGames WHERE UserId = @UserId AND GameId = @GameId)
	DECLARE @UserGameLevel INT = (SELECT Level FROM UsersGames WHERE Id = @UserGameId)

	DECLARE @counter INT = 251

	WHILE(@counter <= 539)
	BEGIN
		DECLARE @ItemId INT = @counter
		DECLARE @ItemPrice MONEY = (SELECT Price FROM Items WHERE Id = @ItemId)
		DECLARE @ItemLevel INT = (SELECT MinLevel FROM Items WHERE Id = @ItemId)
		DECLARE @UserGameCash MONEY = (SELECT Cash FROM UsersGames WHERE Id = @UserGameId)

		IF(@UserGameCash >= @ItemPrice AND @UserGameLevel >= @ItemLevel)
		BEGIN
			UPDATE UsersGames
			SET Cash -= @ItemPrice
			WHERE Id = @UserGameId

			INSERT INTO UserGameItems VALUES
			(@ItemId, @UserGameId)
		END

		SET @counter += 1
		
		IF(@counter = 300)
		BEGIN
			SET @counter = 501
		END
	END
END

EXEC usp_BuyItems 'baleremuda'
EXEC usp_BuyItems 'loosenoise'
EXEC usp_BuyItems 'inguinalself'
EXEC usp_BuyItems 'buildingdeltoid'
EXEC usp_BuyItems 'monoxidecos'
GO

SELECT * FROM Users AS u
JOIN UsersGames AS ug
ON u.Id = ug.UserId
JOIN Games AS g
ON ug.GameId = g.Id
JOIN UserGameItems AS ugi
ON ug.Id = ugi.UserGameId
JOIN Items AS i
ON ugi.ItemId = i.Id
WHERE g.Name = 'Bali'
ORDER BY u.Username, i.Name

--20. Massive Shopping--


DECLARE @UserId INT = (SELECT Id FROM Users WHERE Username = 'Stamat')
DECLARE @GameId INT = (SELECT Id FROM Games WHERE Name = 'Safflower')
DECLARE @UserGameId INT = (SELECT Id FROM UsersGames WHERE UserId = @UserId AND GameId = @GameId)
DECLARE @UserGameLevel INT = (SELECT Level FROM UsersGames WHERE Id = @UserGameId)
DECLARE @ItemStartLevel INT = 11
DECLARE @ItemEndLevel INT = 12
DECLARE @AllItemsPrice MONEY = (SELECT SUM(Price) FROM Items WHERE (MinLevel BETWEEN @ItemStartLevel AND @ItemEndLevel)) 
DECLARE @StamatCash MONEY = (SELECT Cash FROM UsersGames WHERE Id = @UserGameId)

IF(@StamatCash >= @AllItemsPrice)
BEGIN
	BEGIN TRAN	
		UPDATE UsersGames
		SET Cash -= @AllItemsPrice
		WHERE Id = @UserGameId
	
		INSERT INTO UserGameItems
		SELECT i.Id, @UserGameId  FROM Items AS i
		WHERE (i.MinLevel BETWEEN @ItemStartLevel AND @ItemEndLevel)
	COMMIT
END

SET @ItemStartLevel = 19
SET @ItemEndLevel = 21
SET @AllItemsPrice = (SELECT SUM(Price) FROM Items WHERE (MinLevel BETWEEN @ItemStartLevel AND @ItemEndLevel)) 
SET @StamatCash = (SELECT Cash FROM UsersGames WHERE Id = @UserGameId)

IF(@StamatCash >= @AllItemsPrice)
BEGIN
	BEGIN TRAN
		UPDATE UsersGames
		SET Cash -= @AllItemsPrice
		WHERE Id = @UserGameId
	
		INSERT INTO UserGameItems
		SELECT i.Id, @UserGameId  FROM Items AS i
		WHERE (i.MinLevel BETWEEN @ItemStartLevel AND @ItemEndLevel)
	COMMIT
END

SELECT i.Name AS [Item Name] FROM Users AS u
JOIN UsersGames AS ug
ON u.Id = ug.UserId
JOIN Games AS g
ON ug.GameId = g.Id
JOIN UserGameItems AS ugi
ON ug.Id = ugi.UserGameId
JOIN Items AS i
ON ugi.ItemId = i.Id
WHERE u.Username = 'Stamat' AND g.Name = 'Safflower'
ORDER BY i.Name


--21. Employees with Three Projects--

CREATE PROC usp_AssignProject(@employeeId INT, @projectID INT) AS
BEGIN
	BEGIN TRAN
		INSERT INTO EmployeesProjects VALUES
		(@employeeId, @projectID)
		DECLARE @EmployeeProjectsCount INT = (SELECT COUNT(*) FROM EmployeesProjects WHERE EmployeeId = @employeeId)
		IF(@EmployeeProjectsCount > 3)
		BEGIN
			ROLLBACK
			RAISERROR('The employee has too many projects!', 16, 1)
			RETURN
		END
	COMMIT
END 

--22. Delete Employees--

CREATE TABLE Deleted_Employees
(
	EmployeeId INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	MiddleName VARCHAR(50),
	JobTitle VARCHAR(50) NOT NULL,
	DepartmentID INT NOT NULL,
	Salary MONEY NOT NULL
)
GO

CREATE TRIGGER tr_DeleteEmployees ON Employees AFTER DELETE AS
	INSERT INTO Deleted_Employees
	SELECT FirstName, LastName, MiddleName, JobTitle, DepartmentID, Salary FROM deleted