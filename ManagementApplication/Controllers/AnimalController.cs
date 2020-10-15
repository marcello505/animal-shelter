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
        public AnimalController(ILogger<AnimalController> logger, IAnimalRepository context)
        {
            _logger = logger;
            _context = context;
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
