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

        [Authorize]
        public IActionResult Index()
        {
            return View(_context.GetAll().ToViewModel());
        }

        [Authorize]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_context.Get(id));
        }

        [Authorize]
        [HttpPost]
        public IActionResult Edit(Animal animal)
        {
            if (!animal.Age.HasValue) ModelState.AddModelError("Age", "Either EstimatedAge or DateOfBirth need to be filled in. But not both.");
            //Dit kijkt of de animal aan de kooi kan worden toegevoegd. Het kijkt ook of de kooi uberhaupt bestaat.
            if (animal.CageId.HasValue && !(_cageRepository.Get(animal.CageId.Value)?.CanAddAnimalToCage(animal) ?? false)) ModelState.AddModelError("CageId", "Can't assign Animal to cage. It's either full, doesn't exist or the Animals can't be paired because they're a different type of animal or they differ in gender without being Sterilized/Castrated.");

            if (!ModelState.IsValid) return View(animal);

            _context.Update(animal);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(NewAnimalViewModel animal)
        {
            var result = animal.ToDomainModel();
            if (!result.Age.HasValue) ModelState.AddModelError("Age", "Either EstimatedAge or DateOfBirth need to be filled in. But not both.");
            //Dit kijkt of de animal aan de kooi kan worden toegevoegd. Het kijkt ook of de kooi uberhaupt bestaat.
            if (animal.CageId.HasValue && !(_cageRepository.Get(animal.CageId.Value)?.CanAddAnimalToCage(animal.ToDomainModel()) ?? false)) ModelState.AddModelError("CageId", "Can't assign Animal to cage. It's either full, doesn't exist or the Animals can't be paired because they're a different type of animal or they differ in gender without being Sterilized/Castrated.");

            if (!ModelState.IsValid) return View(animal);

            _context.Add(result);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize]
        public IActionResult Delete(int id)
        {
            return View(_context.Get(id));
        }

        [HttpPost]
        [Authorize]
        public IActionResult Delete(Animal animal)
        {
            _context.Delete(animal);
            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult Details(int id)
        {
            return View(_context.Get(id));
        }
    }
}
