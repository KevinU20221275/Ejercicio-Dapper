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
                string storeProcedure = "dbo.spFaculty_GetById";

                return connection.QueryFirstOrDefault<Faculty>(
                                    storeProcedure,
                                    new { Id = id },
                                    commandType: CommandType.StoredProcedure
                                   );
            }
        }

        public void Add(Faculty faculty)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.spFaculty_Insert";

                connection.Execute(
                    storeProcedure,
                    new { faculty.FacultyName, faculty.UniversityId },
                    commandType: CommandType.StoredProcedure
                    );
            }
        }

        
        public void Edit(Faculty faculty)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.spFaculty_Update";

                connection.Execute(storeProcedure, faculty, commandType: CommandType.StoredProcedure);
            }
        }

        public void Delete(int id)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.spFaculty_Delete";

                connection.Execute(
                    storeProcedure,
                    new { id },
                    commandType: CommandType.StoredProcedure
                    );
            }
        }
    }
}
