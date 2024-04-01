using System.Data;

namespace UniversityDapper.Data
{
    public interface ISqlDataAccess
    {
        IDbConnection GetConnection();
    }
}