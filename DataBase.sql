-- ====== DATA BASE ===========
CREATE DATABASE UniversityDB;

USE UniversityDB;

CREATE TABLE University
(
 Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
 UniversityName NVARCHAR(50) NOT NULL,
 Phone NVARCHAR(20) NOT NULL
);

CREATE TABLE Faculty
(
	Id INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	FacultyName NVARCHAR(50) NOT NULL,
	UniversityId INT NOT NULL,
    CONSTRAINT fk_university FOREIGN KEY (UniversityId) 
    REFERENCES University(Id)
);

CREATE TABLE Student
(
	Id INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	FirstName NVARCHAR(75) NOT NULL,
	LastName NVARCHAR(75) NOT NULL,
	Email NVARCHAR(75) NOT NULL,
	Carnet NVARCHAR(10) NOT NULL,
	PhoneNumber NVARCHAR(20)
)O

-- =========== UNIVERSITIES PROCEDURES =========
-- GET ALL
CREATE PROCEDURE dbo.spUniversity_GetAll
AS
BEGIN
	SELECT Id, UniversityName, Phone FROM University
END;
GO

-- GET BY ID
CREATE PROCEDURE dbo.spUniversity_GetById(@Id INT)
AS
BEGIN
	SELECT Id, UniversityName, Phone 
	FROM University
    WHERE Id = @Id
END;
GO

-- INSERT 
CREATE PROCEDURE dbo.spUniversity_Insert
(
	@UniversityName NVARCHAR(50),
	@Phone NVARCHAR(20)
)
AS
BEGIN
	INSERT INTO University 
	VALUES(@UniversityName, @Phone)
END;
GO

-- UPDATE
CREATE PROCEDURE dbo.spUniversity_Update
(
	@UniversityName nvarchar(50),
	@Phone nvarchar(20),
	@Id int
)
AS
BEGIN
	UPDATE University 
	SET UniversityName = @UniversityName,
	Phone = @Phone
    WHERE Id = @Id
END;
GO

-- DELETE
CREATE PROCEDURE dbo.spUniversity_Delete
(@Id int)
AS
BEGIN
	DELETE FROM University WHERE Id = @Id
END;
GO

-- ======== FACULTIES PROCEDURES =======
-- GET ALL
CREATE PROCEDURE dbo.spFaculty_GetAll
AS
BEGIN
	SELECT Faculty.Id, Faculty.FacultyName, University.UniversityName
	FROM Faculty 
	INNER JOIN University 
	ON Faculty.UniversityId = University.Id
END;
GO

-- GET BY ID
CREATE PROCEDURE dbo.spFaculty_GetById(@Id INT)
AS
BEGIN
	SELECT Id, FacultyName, UniversityId 
	FROM Faculty
    WHERE Id = @Id
END;
GO

-- INSERT
CREATE PROCEDURE dbo.spFaculty_Insert
(
	@FacultyName NVARCHAR(50),
	@UniversityId INT
)
AS
BEGIN
	INSERT INTO Faculty
	VALUES(@FacultyName, @UniversityId)
END;
GO

-- UPDATE
CREATE PROCEDURE dbo.spFaculty_Update
(
	@Id INT,
	@FacultyName NVARCHAR(50),
	@UniversityId INT
)
AS
BEGIN
	UPDATE Faculty 
	SET FacultyName = @FacultyName,
	UniversityId = @UniversityId
    WHERE Id = @Id
END;
GO

-- DELETE
CREATE PROCEDURE dbo.spFaculty_Delete
(@Id INT)
AS
BEGIN
	DELETE FROM Faculty WHERE Id = @Id
END;