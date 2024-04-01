using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityDapper.Models;
using UniversityDapper.Repositories.Faculties;

namespace UniversityDapper.Controllers
{
    public class FacultyController : Controller
    {
        private readonly IFacultyRepository _facultyRepository;

        public FacultyController(IFacultyRepository facultyRepository)
        {
            _facultyRepository = facultyRepository;
        }

        public ActionResult Index()
        {
            return View(_facultyRepository.GetAll());
        }

        

        // GET: FacultyController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FacultyController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Faculty faculty)
        {
            try
            {
                _facultyRepository.Add(faculty);

                TempData["message"] = "Datos guardados exitosamente";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;

                return View(faculty);
            }
        }

        // GET: FacultyController/Edit/5
        public ActionResult Edit(int id)
        {
            var faculty = _facultyRepository.GetById(id);

            if (faculty == null)
            {
                return NotFound();
            }

            return View(faculty);
        }

        // POST: FacultyController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Faculty faculty)
        {
            try
            {
                _facultyRepository.Edit(faculty);

                TempData["message"] = "Datos editados correctamente";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View(faculty);
            }
        }

        // GET: FacultyController/Delete/5
        public ActionResult Delete(int id)
        {
            var faculty = _facultyRepository.GetById(id);

            if (faculty == null)
            {
                return NotFound();
            }

            return View(faculty);
        }

        // POST: FacultyController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Faculty faculty)
        {
            try
            {
                _facultyRepository.Delete(faculty.Id);

                TempData["message"] = "Dato eliminado exitosamente";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View(faculty);
            }
        }
    }
}
