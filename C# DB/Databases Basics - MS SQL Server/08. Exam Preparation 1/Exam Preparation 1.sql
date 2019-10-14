--01. DDL--

CREATE DATABASE Airport

USE Airport

CREATE TABLE Planes (
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) NOT NULL,
	Seats INT NOT NULL,
	[Range] INT NOT NULL
)

CREATE TABLE Flights(
	Id INT PRIMARY KEY IDENTITY,
	DepartureTime DATETIME2,
	ArrivalTime DATETIME2,
	Origin VARCHAR(50) NOT NULL,
	Destination VARCHAR(50) NOT NULL,
	PlaneId INT FOREIGN KEY REFERENCES Planes(Id) NOT NULL
)

CREATE TABLE Passengers(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(30) NOT NULL,
	LastName VARCHAR(30) NOT NULL,
	Age INT NOT NULL,
	[Address] VARCHAR(30) NOT NULL,
	PassportId CHAR(11) NOT NULL
)

CREATE TABLE LuggageTypes(
	Id INT PRIMARY KEY IDENTITY,
	[Type] VARCHAR(30) NOT NULL
)

CREATE TABLE Luggages(
	Id INT PRIMARY KEY IDENTITY,
	LuggageTypeId INT FOREIGN KEY REFERENCES LuggageTypes(Id) NOT NULL,
	PassengerId INT FOREIGN KEY REFERENCES Passengers(Id) NOT NULL
)

CREATE TABLE Tickets(
	Id INT PRIMARY KEY IDENTITY,
	PassengerId INT FOREIGN KEY REFERENCES Passengers(Id) NOT NULL,
	FlightId INT FOREIGN KEY REFERENCES Flights(Id) NOT NULL,
	LuggageId INT FOREIGN KEY REFERENCES Luggages(Id) NOT NULL,
	Price DECIMAL(18,2) NOT NULL
)

--02. Insert--

INSERT INTO Planes([Name], Seats, [Range]) VALUES
('Airbus 336', 112,5132),
('Airbus 330', 432, 5325),
('Boeing 369', 231, 2355),
('Stelt 297', 254, 2143),
('Boeing 338', 165, 5111),
('Airbus 558', 387, 1342),
('Boeing 128', 345, 5541)

INSERT INTO LuggageTypes([Type]) VALUES
('Crossbody Bag'),
('School Backpack'),
('Shoulder Bag')

--03. Update--

UPDATE Tickets
SET Price += Price * 0.13 
WHERE FlightId IN(SELECT Id FROM Flights
				  WHERE Destination = 'Carlsbad'
)

--04. Delete--

DELETE FROM Tickets
WHERE FlightId IN (SELECT Id FROM Flights
				   WHERE Destination = 'Ayn Halagim'			
)

DELETE FROM Flights
WHERE Destination = 'Ayn Halagim'

--05. The "Tr" Planes--

SELECT *
FROM Planes
WHERE [Name] LIKE '%tr%'
ORDER BY Id, [Name], Seats, [Range]

--BUILD-IN FUNCTIONS--

SELECT *
FROM Planes
WHERE CHARINDEX('tr', [Name]) > 0
ORDER BY Id, [Name], Seats, [Range]

--06. Flight Profits--

SELECT f.Id AS [FlightId], SUM(t.Price) AS [Price]
FROM Flights AS f
JOIN Tickets AS t
ON t.FlightId = f.Id
GROUP BY f.Id
ORDER BY [Price] DESC, [FlightId]

--07. Passenger Trips--

SELECT CONCAT(p.FirstName,' ', p.LastName) AS [Full Name], f.Origin, f.Destination
FROM Passengers AS p
JOIN Tickets AS t
ON t.PassengerId=p.Id
JOIN Flights AS f
ON t.FlightId = f.Id
ORDER BY [Full Name], f.Origin, f.Destination

--08. Non Adventures People--

SELECT p.FirstName AS [First Name], p.LastName AS [Last Name] , p.Age
FROM Passengers AS p
LEFT OUTER JOIN Tickets AS t
ON t.PassengerId = p.Id
WHERE t.id IS NULL
ORDER BY Age DESC, FirstName,LastName

--09. Full Info--

SELECT 
	CONCAT(p.FirstName, ' ', p.LastName) AS [Full Name],
	pl.[Name] AS [Plane Name],
	CONCAT(f.Origin, ' - ', f.Destination) AS [Trip],
	lt.[Type] AS [Luggage Type]
FROM Passengers AS p
JOIN Tickets AS t
ON t.PassengerId = p.Id
JOIN Flights AS f
ON t.FlightId = f.Id
JOIN Planes AS pl
ON f.PlaneId = pl.Id
JOIN Luggages AS l
ON t.LuggageId = l.Id
JOIN LuggageTypes lt
ON l.LuggageTypeId = lt.Id
ORDER BY [Full Name], [Plane Name], f.Origin, f.Destination, [Luggage Type]

--10. PSP--

SELECT p.[Name], p.Seats, COUNT(t.Id) AS [Passengers Count]
FROM Planes as p
LEFT OUTER JOIN Flights AS f
ON f.PlaneId = p.Id
LEFT OUTER JOIN Tickets AS t
ON t.FlightId = f.Id
GROUP BY p.[Name], p.Seats
ORDER BY [Passengers Count] DESC, p.[Name], p.Seats

--11. Vacation--

CREATE FUNCTION udf_CalculateTickets(@origin varchar(50), @destination varchar(50), @peopleCount int)
RETURNS VARCHAR(100)
AS
BEGIN

IF (@peopleCount <= 0)
BEGIN
	RETURN 'Invalid people count!'
END

DECLARE @tripId INT = (SELECT f.Id FROM Flights AS f
											  JOIN Tickets AS t ON t.FlightId = f.Id 
											  WHERE Destination = @destination AND Origin = @origin)
IF (@tripId IS NULL)
BEGIN
	RETURN 'Invalid flight!'
END

DECLARE @ticketPrice DECIMAL(15,2) = (SELECT t.Price FROM Flights AS f
											  JOIN Tickets AS t ON t.FlightId = f.Id 
											  WHERE Destination = @destination AND Origin = @origin)

DECLARE @totalPrice DECIMAL(15, 2) = @ticketPrice * @peoplecount;

RETURN 'Total price ' + CAST(@totalPrice as VARCHAR(30));
END

SELECT dbo.udf_CalculateTickets('Kolyshley','Rancabolang', 33)

SELECT dbo.udf_CalculateTickets('Kolyshley','Rancabolang', -1)

SELECT dbo.udf_CalculateTickets('Invalid','Rancabolang', 33)

--12. Wrong Data--

CREATE PROC usp_CancelFlights
AS
BEGIN
	UPDATE Flights
	SET DepartureTime = NULL , ArrivalTime = NULL
	WHERE DATEDIFF(SECOND, DepartureTime, ArrivalTime) > 0
END

EXEC usp_CancelFlights