using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DomainServices;
using Core.Models;
using ManagementApplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ManagementApplication.Controllers
{
    public class TreatmentController : Controller
    {
        private readonly ILogger<TreatmentController> _logger;
        private readonly ITreatmentRepository _context;
        private readonly IAnimalRepository _animalRepository;
        public TreatmentController(ILogger<TreatmentController> logger, ITreatmentRepository context, IAnimalRepository animalRepository)
        {
            _logger = logger;
            _context = context;
            _animalRepository = animalRepository;
        }

        [Authorize]
        public IActionResult Index()
        {
            var result = _context.GetAll().ToViewModel();
            //Voor elke treatment vind de bijhorende diernaam.
            //Misschien beter om dit alleen te doen voor detail view van Treatments.
            foreach(var item in result)
            {
                item.Animal = _animalRepository.GetAll().SingleOrDefault(a => a.Id == item.AnimalId)?.Name ?? "";
            }

            return View(result);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Create(int? animalId)
        {
            if (animalId.HasValue)
            {
                return View(new Treatment() { AnimalId = animalId});
            }
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(Treatment treatment)
        {
            if(!treatment.IsValid()) ModelState.AddModelError("Description", "For this type of treatment there needs to be description filled out. For chippings put in the GUID of the chip, for Euthanasia put in the reason for it.");

            //Kijk of de Animal oud genoeg is voor de treatment.
            if (treatment.AnimalId.HasValue)
            {
                var animalTest = _animalRepository.Get(treatment.AnimalId.Value);
                if(!treatment.CanAssignAnimal(animalTest)) ModelState.AddModelError("AnimalId", "Animal is too young for this operation.");
            }

            if (ModelState.IsValid)
            {
                _context.Add(treatment);
            }

            return ModelState.IsValid ? (IActionResult)RedirectToAction("Index") : View(treatment);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Edit(int id)
        {
            return View(_context.Get(id));
        }

        [HttpPost]
        [Authorize]
        public IActionResult Edit(Treatment treatment)
        {
            if(!treatment.IsValid()) ModelState.AddModelError("Description", "For this type of treatment there needs to be description filled out. For chippings put in the GUID of the chip, for Euthanasia put in the reason for it.");

            //Kijk of de Animal oud genoeg is voor de treatment.
            if (treatment.AnimalId.HasValue)
            {
                var animalTest = _animalRepository.Get(treatment.AnimalId.Value);
                if(!treatment.CanAssignAnimal(animalTest)) ModelState.AddModelError("AnimalId", "Animal is too young for this operation.");
            }

            if (ModelState.IsValid)
            {
                _context.Update(treatment);
            }

            return ModelState.IsValid ? (IActionResult)RedirectToAction("Index") : View(treatment);
        }

        [Authorize]
        public IActionResult Details(int id)
        {
            return View(_context.Get(id)?.ToViewModel()?? new TreatmentViewModel { Id = id});
        }

        [HttpGet]
        [Authorize]
        public IActionResult Delete(int id)
        {
            return View(_context.Get(id) ?? new Treatment { Id = id });
        }

        [HttpPost]
        [Authorize]
        public IActionResult Delete(Treatment treatment)
        {
            _context.Delete(treatment);
            return RedirectToAction("Index");
        }
    }
}
