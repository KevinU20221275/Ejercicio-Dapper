using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using UniversityDapper.Data;
using UniversityDapper.Models;

namespace UniversityDapper.Repositories.Faculties
{
    public class FacultyRepository : IFacultyRepository
    {
        private readonly ISqlDataAccess _dataAccess;

        public FacultyRepository(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public IEnumerable<University> GetAllUniversities()
        {
            string query = "SELECT Id, UniversityName FROM University";

            using (var connection = _dataAccess.GetConnection())
            {
                return connection.Query<University>(query);
            }
        }

        public IEnumerable<Faculty> GetAll()
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storedProcedure = "dbo.spFaculty_GetAll";

                var faculties = connection.Query<Faculty, University, Faculty>
                    (storedProcedure, (faculty, university) =>
                    {
                        faculty.University = university;

                        return faculty;
                    }, splitOn: "UniversityName", commandType: CommandType.StoredProcedure);

                return faculties;
            }
        }

        public Faculty? GetById(int id)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storedProcedure = "dbo.spFaculty_GetById";

                return connection.QueryFirstOrDefault<Faculty>(
                                    storedProcedure,
                                    new { Id = id },
                                    commandType: CommandType.StoredProcedure
                                   );
            }
        }

        public void Add(Faculty faculty)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storedProcedure = "dbo.spFaculty_Insert";

                connection.Execute(
                    storedProcedure,
                    new { faculty.FacultyName, faculty.UniversityId },
                    commandType: CommandType.StoredProcedure
                    );
            }
        }

        
        public void Edit(Faculty faculty)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storedProcedure = "dbo.spFaculty_Update";

                connection.Execute(storedProcedure,
                    new { faculty.Id, faculty.FacultyName, faculty.UniversityId }, 
                    commandType: CommandType.StoredProcedure);
            }
        }

        public void Delete(int id)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storedProcedure = "dbo.spFaculty_Delete";

                connection.Execute(
                    storedProcedure,
                    new { Id = id },
                    commandType: CommandType.StoredProcedure
                    );
            }
        }
    }
}
