using UniversityDapper.Models;

namespace UniversityDapper.Repositories.Universities
{
    public interface IUniversityRepository
    {
        void Add(University university);
        void Delete(int id);
        void Edit(University university);
        IEnumerable<University> GetAll();
        University? GetById(int id);
    }
}