using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimalShelterApplication.Models;
using Core.DomainServices;
using Core.Models;
using Microsoft.AspNetCore.Authorization;
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
            var result = _context.Get(id);
            if(result.ImageURL != null && result.ImageURL.Length > 0)
            {
                string imageBase64Data = Convert.ToBase64String(result.ImageURL);
                string imgDataURL = string.Format("data:image/png;base64,{0}", imageBase64Data);
                ViewBag.ImageData = imgDataURL;
            }
            return View(result);
         }

        [Authorize]
        public ActionResult Select(int id)
        {
            if(_context.Get(id) != null)
            {
                string key = null;
                if (!HttpContext.Session.GetInt32("animal1").HasValue)
                {
                    key = "animal1";
                }
                else if (!HttpContext.Session.GetInt32("animal2").HasValue)
                {
                    key = "animal2";
                }
                else
                {
                    key = "animal3";
                }
                HttpContext.Session.SetInt32(key, id);
            }

            return RedirectToAction("Index");
        }
        
        [Authorize]
        public ActionResult Remove(int id)
        {
            //Delete item from cart.
            var session = HttpContext.Session;
            if (session.GetInt32("animal1").HasValue && session.GetInt32("animal1") == id) session.Remove("animal1");
            if (session.GetInt32("animal2").HasValue && session.GetInt32("animal2") == id) session.Remove("animal2");
            if (session.GetInt32("animal3").HasValue && session.GetInt32("animal3") == id) session.Remove("animal3");

            return RedirectToAction("Index");
        }
    }
}
