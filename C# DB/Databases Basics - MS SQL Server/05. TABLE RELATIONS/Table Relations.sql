--01. One-To-One Relationship--

CREATE TABLE Persons (
	PersonID INT IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	Salary DECIMAL(7,2),
	PassportID INT 
)


CREATE TABLE Passports (
	PassportID INT IDENTITY(101,1),
	PassportNumber NVARCHAR(50) NOT NULL
)

INSERT INTO Persons VALUES
('Roberto', 43300, 102) , 
('Tom', 56100, 103 ),
('Yana', 60200, 101)

INSERT INTO Passports VALUES
('N34FG21B'),
('K65LO4R7'), 
('K65LO4R7')

ALTER TABLE Persons
ADD PRIMARY KEY (PersonID)

ALTER TABLE Passports
ADD PRIMARY KEY (PassportID)

ALTER TABLE Persons
ADD FOREIGN KEY (PassportID) REFERENCES Passports(PassportID)

--02. One-To-Many Relationship--

CREATE TABLE Manufacturers (
	ManufacturerID INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL,
	EstablishedOn DATE
)

CREATE TABLE Models (
	ModelID INT PRIMARY KEY IDENTITY(101,1),
	[Name] NVARCHAR(50) NOT NULL,
	ManufacturerID INT FOREIGN KEY REFERENCES Manufacturers(ManufacturerID)
)


INSERT INTO Manufacturers VALUES
('BMW','07-03-1916'),
('Tesla', '01-01-2003'),
('Lada', '01-05-1966')



INSERT INTO Models VALUES 
('X1', 1),
('i6', 1),
('Model S',2),
('Model X',2),
('Model 3',2),
('Nova',3)

--03. Many-To-Many Relationship--

CREATE TABLE Students (
	StudentID INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Exams (
	ExamID INT PRIMARY KEY,
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE StudentsExams (
	StudentID INT FOREIGN KEY REFERENCES Students(StudentID),
	ExamID INT FOREIGN KEY REFERENCES Exams(ExamID),
	CONSTRAINT PK_CompositeStudentIDExamID
	PRIMARY KEY (StudentID, ExamID)
)

INSERT INTO Students ([Name]) VALUES
('Mila'), ('Toni'), ('Ron')

INSERT INTO Exams (ExamID, [Name]) VALUES
(101,'SpringMVC'),
(102,'Neo4j'),
(103, 'Oracle 11g')

INSERT INTO StudentsExams (StudentID, ExamID) VALUES
(1, 101),
(1, 102),
(2, 101),
(3,103),
(2,102),
(2,103)

--04. Self-Referencing--

CREATE TABLE Teachers (
	TeacherID INT PRIMARY KEY IDENTITY(101,1),
	[Name] NVARCHAR(30) NOT NULL,
	ManagerID INT FOREIGN KEY REFERENCES Teachers(TeacherID)
)

INSERT INTO Teachers ([Name], ManagerID) VALUES
('Joghn', NULL),
('Maya', 106),
('Silvia', 106),
('Ted', 105),
('Mark', 101),
('Greta', 101)

--05. Online Store Database--

CREATE DATABASE OnlineStore

USE OnlineStore

CREATE TABLE Cities (
	CityID INT PRIMARY KEY,
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Customers (
	CustomerID INT PRIMARY KEY,
	[Name] NVARCHAR(50) NOT NULL,
	Birthday DATE,
	CityID INT FOREIGN KEY REFERENCES Cities(CityID) NOT NULL
)

CREATE TABLE Orders (
	OrderID INT PRIMARY KEY,
	CustomerID INT FOREIGN KEY REFERENCES Customers(CustomerID) NOT NULL
)

CREATE TABLE ItemTypes (
	ItemTypeID INT PRIMARY KEY,
	[Name] NVARCHAR(50)
)

CREATE TABLE Items (
	ItemID INT PRIMARY KEY,
	[Name] NVARCHAR(50),
	ItemTypeID INT FOREIGN KEY REFERENCES ItemTypes(ItemTypeID) NOT NULL
)

CREATE TABLE OrderItems (
	OrderID INT FOREIGN KEY REFERENCES Orders(OrderID),
	ItemID INT FOREIGN KEY REFERENCES Items(ItemID),
	CONSTRAINT PK_CompositeOrderIDItemID
	PRIMARY KEY(OrderID,ItemID)
)

--06. University Database--

CREATE DATABASE University

USE University

CREATE TABLE Majors (
	MajorID INT PRIMARY KEY,
	[Name] NVARCHAR(30) NOT NULL
)

CREATE TABLE Students (
	StudentID INT PRIMARY KEY,
	StudentNumber NVARCHAR(30) NOT NULL,
	StudentName NVARCHAR(60) NOT NULL,
	MajorID INT FOREIGN KEY REFERENCES Majors(MajorID) NOT NULL
)

CREATE TABLE Payments (
	PaymentID INT PRIMARY KEY,
	PaymentDate SMALLDATETIME,
	PaymentAmount DECIMAL(10,2) NOT NULL,
	StudentID INT FOREIGN KEY REFERENCES Students(StudentID) NOT NULL
)

CREATE TABLE Subjects (
	SubjectID INT PRIMARY KEY,
	SubjectName NVARCHAR(30) NOT NULL
)

CREATE TABLE Agenda (
	StudentID INT FOREIGN KEY REFERENCES Students(StudentID),
	SubjectID INT FOREIGN KEY REFERENCES Subjects(SubjectID),
	CONSTRAINT PK_CompositeStudentIDSubjectID
	PRIMARY KEY(StudentID,SubjectID)
)

--09. *Peaks in Rila--

USE Geography

SELECT m.MountainRange, p.PeakName, p.Elevation
FROM Peaks AS p
JOIN Mountains AS m
ON P.MountainId = M.Id
WHERE MountainRange = 'Rila'
ORDER BY Elevation DESC
