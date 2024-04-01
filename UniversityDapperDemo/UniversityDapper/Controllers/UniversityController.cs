using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityDapper.Models;
using UniversityDapper.Repositories.Universities;

namespace UniversityDapper.Controllers
{
    public class UniversityController : Controller
    {
        private readonly IUniversityRepository _universityRepository;

        public UniversityController(IUniversityRepository universityRepository)
        {
            _universityRepository = universityRepository;
        }

        public ActionResult Index()
        {
            return View(_universityRepository.GetAll());
        }

        // GET: UniverstiyController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UniverstiyController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UniverstiyController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(University university)
        {
            try
            {
                _universityRepository.Add(university);

                TempData["message"] = "Datos guardados exitosamente";

                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                TempData["message"] = ex.Message;

                return View(university);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var university = _universityRepository.GetById(id);

            if(university == null)
            {
                return NotFound();
            }

            return View(university);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(University university)
        {
            try
            {
                _universityRepository.Edit(university);

                TempData["message"] = "Datos editados correctamente";

                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return View(university);
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var university = _universityRepository.GetById(id);

            if(university == null)
            {
                return NotFound();
            }

            return View(university);
        }

        // POST: UniverstiyController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(University university)
        {
            try
            {
                _universityRepository.Delete(university.Id);

                TempData["message"] = "Dato eliminado exitosamente";

                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return View(university);
            }
        }
    }
}
