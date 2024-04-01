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
                string storeProcedure = "dbo.spUniversity_GetAll";

                return connection.Query<University>(
                                        storeProcedure, 
                                        commandType: CommandType.StoredProcedure
                                        );
            }
        }

        public University? GetById(int id)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.spUniversity_GetById";

                return connection.QueryFirstOrDefault<University>(
                                    storeProcedure, 
                                    new { Id = id },
                                    commandType: CommandType.StoredProcedure
                                   );
            }
        }

        public void Add(University university)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.spUniversity_Insert";

                connection.Execute(
                    storeProcedure, 
                    new { university.UniversityName, university.Phone },
                    commandType: CommandType.StoredProcedure
                    );
            }
        }

        public void Edit(University university)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.spUniversity_Update";

                connection.Execute(storeProcedure, university, commandType: CommandType.StoredProcedure);
            }
        }

        public void Delete(int id)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.spUniversity_Delete";

                connection.Execute(
                    storeProcedure, 
                    new { id },
                    commandType: CommandType.StoredProcedure
                    );
            }
        }
    }
}
