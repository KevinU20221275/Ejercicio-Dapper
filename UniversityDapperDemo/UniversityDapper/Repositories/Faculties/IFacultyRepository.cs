﻿using UniversityDapper.Models;

namespace UniversityDapper.Repositories.Faculties
{
    public interface IFacultyRepository
    {
        void Add(Faculty faculty);
        void Delete(int id);
        void Edit(Faculty faculty);
        IEnumerable<Faculty> GetAll();
        IEnumerable<University> GetAllUniversities();
        Faculty? GetById(int id);
    }
}