USE UniversityDB;

CREATE PROCEDURE dbo.spUniversity_GetAll
AS
BEGIN
	SELECT Id, UniversityName, Phone FROM University
END;

CREATE PROCEDURE dbo.spUniversity_GetById(@Id INT)
AS
BEGIN
	SELECT Id, UniversityName, Phone 
	FROM University
    WHERE Id = @Id
END;

CREATE PROCEDURE dbo.spUniversity_Insert
(
	@UniversityName nvarchar(50),
	@Phone nvarchar(20)
)
AS
BEGIN
	INSERT INTO University 
	VALUES(@UniversityName, @Phone)
END;

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

CREATE PROCEDURE dbo.spUniversity_Delete
(@Id int)
AS
BEGIN
	DELETE FROM University WHERE Id = @Id
END;
CREATE PROCEDURE dbo.spFaculty_GetAll
AS
BEGIN
	SELECT Faculty.Id, Faculty.FacultyName, University.UniversityName
	FROM Faculty 
	INNER JOIN University 
	ON Faculty.UniversityId = University.Id
END;

-- faculties procedures
CREATE PROCEDURE dbo.spFaculty_GetById(@Id INT)
AS
BEGIN
	SELECT Id, FacultyName, UniversityId 
	FROM Faculty
    WHERE Id = @Id
END;

CREATE PROCEDURE dbo.spGetAllUniversities
AS
BEGIN
	SELECT Id, UniversityName 
	FROM University
END;

CREATE PROCEDURE dbo.spFaculty_Insert
(
	@FacultyName nvarchar(50),
	@UniversityId int
)
AS
BEGIN
	INSERT INTO Faculty
	VALUES(@FacultyName, @UniversityId)
END;

CREATE PROCEDURE dbo.spFaculty_Update
(
	@FacultyName nvarchar(50),
	@UniversityId int,
	@Id int
)
AS
BEGIN
	UPDATE Faculty 
	SET FacultyName = @FacultyName,
	UniversityId = @UniversityId
    WHERE Id = @Id
END;

CREATE PROCEDURE dbo.spFaculty_Delete
(@Id int)
AS
BEGIN
	DELETE FROM Faculty WHERE Id = @Id
END;