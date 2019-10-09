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

--13. *Cash in User Games Odd Rows--

