using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DomainServices;
using Core.Models;
using ManagementApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ManagementApplication.Controllers
{
    public class AnimalController : Controller
    {
        private readonly ILogger<AnimalController> _logger;
        private readonly IAnimalRepository _context;
        private readonly ICageRepository _cageRepository;
        public AnimalController(ILogger<AnimalController> logger, IAnimalRepository context, ICageRepository cageRepository)
        {
            _logger = logger;
            _context = context;
            _cageRepository = cageRepository;
        }
        public IActionResult Index()
        {
            return View(_context.GetAll().ToViewModel());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_context.Get(id));
        }

        [HttpPost]
        public IActionResult Edit(Animal animal)
        {
            if (!animal.Age.HasValue) ModelState.AddModelError("Age", "Either EstimatedAge or DateOfBirth need to be filled in. But not both.");
            //Dit kijkt of de animal aan de kooi kan worden toegevoegd.
            if (animal.CageId.HasValue && !_cageRepository.Get(animal.CageId.Value).CanAddAnimalToCage(animal)) ModelState.AddModelError("CageId", "Can't assign Animal to cage. Animals can't be paired if they're a different type of animal or if they differ in gender without being Sterilized/Castrated.");

            if (!ModelState.IsValid) return View(animal);

            _context.Update(animal);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(NewAnimalViewModel animal)
        {
            var result = animal.ToDomainModel();
            if (!result.Age.HasValue) ModelState.AddModelError("Age", "Either EstimatedAge or DateOfBirth need to be filled in. But not both.");
            //Dit kijkt of de animal aan de kooi kan worden toegevoegd.
            if (animal.CageId.HasValue && !_cageRepository.Get(animal.CageId.Value).CanAddAnimalToCage(animal.ToDomainModel())) ModelState.AddModelError("CageId", "Can't assign Animal to cage. Animals can't be paired if they're a different type of animal or if they differ in gender without being Sterilized/Castrated.");

            if (!ModelState.IsValid) return View(animal);

            _context.Add(result);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_context.Get(id));
        }

        [HttpPost]
        public IActionResult Delete(Animal animal)
        {
            _context.Delete(animal);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            return View(_context.Get(id));
        }
    }
}
