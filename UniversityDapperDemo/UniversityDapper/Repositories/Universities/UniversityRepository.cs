using Dapper;
using System.Data;
using UniversityDapper.Data;
using UniversityDapper.Models;

namespace UniversityDapper.Repositories.Universities
{
    public class UniversityRepository : IUniversityRepository
    {
        private readonly ISqlDataAccess _dataAccess;

        public UniversityRepository(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public IEnumerable<University> GetAll()
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storedProcedure = "dbo.spUniversity_GetAll";

                return connection.Query<University>(
                                        storedProcedure, 
                                        commandType: CommandType.StoredProcedure
                                        );
            }
        }

        public University? GetById(int id)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storedProcedure = "dbo.spUniversity_GetById";

                return connection.QueryFirstOrDefault<University>(
                                    storedProcedure, 
                                    new { Id = id },
                                    commandType: CommandType.StoredProcedure
                                   );
            }
        }

        public void Add(University university)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storedProcedure = "dbo.spUniversity_Insert";

                connection.Execute(
                    storedProcedure, 
                    new { university.UniversityName, university.Phone },
                    commandType: CommandType.StoredProcedure
                    );
            }
        }

        public void Edit(University university)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storedProcedure = "dbo.spUniversity_Update";

                connection.Execute(storedProcedure, university, commandType: CommandType.StoredProcedure);
            }
        }

        public void Delete(int id)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storedProcedure = "dbo.spUniversity_Delete";

                connection.Execute(
                    storedProcedure, 
                    new { id },
                    commandType: CommandType.StoredProcedure
                    );
            }
        }
    }
}
