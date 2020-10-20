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
    public class CartController : Controller
    {
        private readonly IAnimalRepository _animalRepository;
        private readonly IAdoptionRequestRepository _context;
        public CartController(IAdoptionRequestRepository context, IAnimalRepository animalRepository)
        {
            _context = context;
            _animalRepository = animalRepository;
        }

        // GET: CartController
        [Authorize]
        public ActionResult Index()
        {
            var result = new AdoptionRequestViewModel();
            var animalsList = _animalRepository.GetAll();
            result.Email = User.Identity.Name;
            var animal1 = HttpContext.Session.GetInt32("animal1");
            var animal2 = HttpContext.Session.GetInt32("animal2");
            var animal3 = HttpContext.Session.GetInt32("animal3");
            if (animal1.HasValue && animalsList.Any(a => a.Id == animal1.Value)) { result.AnimalId1 = animal1.Value; result.AnimalsView.Add(animalsList.SingleOrDefault(a => a.Id == animal1.Value)); }
            if (animal2.HasValue && animalsList.Any(a => a.Id == animal2.Value)) { result.AnimalId2 = animal2.Value; result.AnimalsView.Add(animalsList.SingleOrDefault(a => a.Id == animal2.Value)); }
            if (animal3.HasValue && animalsList.Any(a => a.Id == animal3.Value)) { result.AnimalId3 = animal3.Value; result.AnimalsView.Add(animalsList.SingleOrDefault(a => a.Id == animal3.Value)); }
            return View(result);
        }


        // GET: CartController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(AdoptionRequestViewModel adoptionRequestViewModel)
        {
            var animals = _animalRepository.GetAll();
            var result = new AdoptionRequest()
            {
                Email = adoptionRequestViewModel.Email,
                Telephone = adoptionRequestViewModel.Telephone,
                Animal1 = adoptionRequestViewModel.AnimalId1,
                Animal2 = adoptionRequestViewModel.AnimalId2,
                Animal3 = adoptionRequestViewModel.AnimalId3
            };

            _context.Add(result);
            HttpContext.Session.Remove("animal1");
            HttpContext.Session.Remove("animal2");
            HttpContext.Session.Remove("animal3");

            return View("Complete");
        }

        [Authorize]
        public IActionResult Clear()
        {
            HttpContext.Session.Remove("animal1");
            HttpContext.Session.Remove("animal2");
            HttpContext.Session.Remove("animal3");

            return RedirectToAction("Index", "Home");
        }

        // GET: CartController/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            var animal1 = HttpContext.Session.GetInt32("animal1");
            var animal2 = HttpContext.Session.GetInt32("animal2");
            var animal3 = HttpContext.Session.GetInt32("animal3");
            if (animal1.HasValue && animal1.Value == id) HttpContext.Session.Remove("animal1");
            if (animal2.HasValue && animal2.Value == id) HttpContext.Session.Remove("animal2");
            if (animal3.HasValue && animal3.Value == id) HttpContext.Session.Remove("animal3");

            return RedirectToAction("Index");
        }

    }
}
