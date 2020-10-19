using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimalShelterApplication.Models;
using Core.DomainServices;
using Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnimalShelterApplication.Controllers
{
    public class AnimalController : Controller
    {
        private IAnimalRepository _context;
        public AnimalController(IAnimalRepository context)
        {
            _context = context;
        }

        // GET: AnimalController
        [HttpGet]
        public ActionResult Index([FromQuery]string dogOrCat, [FromQuery]string gender, [FromQuery]bool? safeForKids)
        {
            ViewBag.Filters = new AnimalFilterViewModel();
            //Haalt alle animals van de context die adopteerbaar zijn.
            var result = _context.GetAll();
            //Check of er query params zijn en filtreer op deze.
            if (dogOrCat != null) result = result.Where(a => a.DogOrCat == dogOrCat);
            if (gender != null) result = result.Where(a => a.Gender == gender);
            if (safeForKids.HasValue) result = result.Where(a => a.SafeForKids == safeForKids.Value);
            return View(result);
        }

        [HttpPost]
        public IActionResult Index(AnimalFilterViewModel animalFilterViewModel)
        {
            string DogOrCat = null;
            string Gender = null;
            bool? SafeForKids;
            if (animalFilterViewModel.DogOrCat != null) DogOrCat = animalFilterViewModel.DogOrCat;
            if (animalFilterViewModel.Gender != null) Gender = animalFilterViewModel.Gender;
            SafeForKids = animalFilterViewModel.SafeForKids;

            return RedirectToAction("Index", new { dogorcat = DogOrCat, gender = Gender, safeforkids = SafeForKids });
        }

        // GET: AnimalController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
    }
}
