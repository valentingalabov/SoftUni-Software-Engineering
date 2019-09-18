
--01.Create Database--

CREATE DATABASE Minions

--02.Create Tables--

GO

USE Minions

GO

CREATE TABLE Minions (
	Id INT NOT NULL,
	[Name] NVARCHAR(50) NOT NULL,
	Age INT NOT NULL
)

CREATE TABLE Towns (
	Id INT NOT NULL,
	[Name] NVARCHAR(50) NOT NULL
)


ALTER TABLE Minions
ADD CONSTRAINT PK_Id
PRIMARY KEY(Id)

ALTER TABLE Towns
ADD CONSTRAINT PK_TownId
PRIMARY KEY(Id)

--03.Alter Minions Table--

ALTER TABLE Minions
ADD TownId INT

ALTER TABLE Minions
ADD CONSTRAINT FK_MinionTownId
FOREIGN KEY (TownID) REFERENCES Towns(Id)

--04.Insert Records in Both Tables--

GO

INSERT INTO Towns(iD,[Name]) VALUES
	(1,'Sofia'),
	(2,'Plovdiv'),
	(3,'Varna')



INSERT INTO Minions(Id,[Name],Age,TownId) VALUES
	(1,'Kevin',22,1),
	(2,'Bob',15,3),
	(3,'Steward',NULL,2)

--05.Truncate Table Minions--

TRUNCATE TABLE Minions


--06.Drop All Tables--

DROP TABLE Minions
DROP TABLE Towns

--07.Create Table People--

CREATE TABLE People (
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(200) NOT NULL,
	Picture VARBINARY(MAX) CHECK (DATALENGTH(Picture) > 1024 * 1024 * 2),
	Height DECIMAL(3,2),
	[Weight] DECIMAL(5,2),
	Gender CHAR(1) CHECK(Gender='m' OR Gender='f') NOT NULL,
	Birthdata DATE NOT NULL,
	Biography NVARCHAR(MAX)
)

INSERT INTO People (Name, Picture, Height, [Weight], Gender, Birthdata, Biography) VALUES
('Pesho Marinov', NULL, 1.80, 55.23, 'm', Convert(DateTime,'19820626',112), 'Skilled worker'),
('Ivan Dimov', NULL, 1.75, 75.55, 'm', Convert(DateTime,'19850608',112), 'Basketball player'),
('Todorka Peneva', NULL, 1.66, 48.55, 'f', Convert(DateTime,'19900606',112), 'Model'),
('Dilyana Ivanova', NULL, 1.77, 52.22, 'f', Convert(DateTime,'19920705',112), 'Fashion guru'),
('Todor Stamatov', NULL, 1.88, 98.25, 'm', Convert(DateTime,'19870706',112), 'Master')


--08.Create Table Users--

CREATE TABLE Users (
Id BIGINT PRIMARY KEY IDENTITY,
Username VARCHAR(30) UNIQUE NOT NULL,
[Password] VARCHAR(26) NOT NULL,
ProfilePicture VARBINARY(MAX),
CHECK(DATALENGTH(ProfilePicture) <= 921600),
LastLoginTime DATETIME2,
IsDeleted BIT NOT NULL
)



INSERT INTO Users
(Username,[Password],ProfilePicture,LastLoginTime,IsDeleted) VALUES
('Ivo','12345',	NULL,NULL,0),
('Gosho','123',	NULL,NULL,0),
('Pesho','12345',NULL,NULL,0),
('Test','12345',NULL,NULL,1),
('Ivan','12345',NULL,NULL,1)

--09.Change Primary Key--

ALTER TABLE Users
DROP CONSTRAINT PK__Users__3214EC076FA24CBB

ALTER TABLE Users
ADD CONSTRAINT PK_CompositeIdUsername
PRIMARY KEY(Id,Username)

--10.Add Check Constraint--

ALTER TABLE Users
ADD CONSTRAINT PasswordLength CHECK (LEN(Password) >= 5)

--11.Set Default Value of a Field--

ALTER TABLE Users
ADD CONSTRAINT DF_LastLoginTime
DEFAULT GETDATE() FOR LastLoginTime

INSERT INTO Users
(Username,[Password],ProfilePicture,IsDeleted) VALUES
('TestttttTT', '123',NULL,1)

--12.Set Unique Field--

ALTER TABLE Users
DROP CONSTRAINT PK_CompositeIdUsername

ALTER TABLE Users
ADD CONSTRAINT PK_Id
PRIMARY KEY (Id)

ALTER TABLE Users
ADD CONSTRAINT uq_Username
UNIQUE(Username)

ALTER TABLE Users
DROP CONSTRAINT UsernameLength

ALTER TABLE Users
ADD CONSTRAINT UsernameLength CHECK (LEN(Username) >= 3)

--13.Movies Database--

