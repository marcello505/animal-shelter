using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Core.DomainServices;
using Core.Models;
using ManagementApplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        public async Task<IActionResult> Edit(Animal animal, List<IFormFile> ImageURL)
        {
            if (!animal.Age.HasValue) ModelState.AddModelError("Age", "Either EstimatedAge or DateOfBirth need to be filled in. But not both.");
            //Dit kijkt of de animal aan de kooi kan worden toegevoegd. Het kijkt ook of de kooi uberhaupt bestaat.
            if (animal.CageId.HasValue && !(_cageRepository.Get(animal.CageId.Value)?.CanAddAnimalToCage(animal) ?? false)) ModelState.AddModelError("CageId", "Can't assign Animal to cage. It's either full, doesn't exist or the Animals can't be paired because they're a different type of animal or they differ in gender without being Sterilized/Castrated.");

            if (!ModelState.IsValid) return View(animal);

            foreach(var item in ImageURL)
            {
                if(item.Length > 0)
                {

                    using(var stream = new MemoryStream())
                    {
                        await item.CopyToAsync(stream);
                        animal.ImageURL = stream.ToArray();
                    }
                }
            }

            await _context.Update(animal);
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
        public async Task<IActionResult> Create(NewAnimalViewModel animal, List<IFormFile> ImageURL)
        {
            foreach(var item in ImageURL)
            {
                if(item.Length > 0)
                {

                    using(var stream = new MemoryStream())
                    {
                        await item.CopyToAsync(stream);
                        animal.ImageURL = stream.ToArray();
                    }
                }
            }
            var result = animal.ToDomainModel();
            if (!result.Age.HasValue) ModelState.AddModelError("Age", "Either EstimatedAge or DateOfBirth need to be filled in. But not both.");
            //Dit kijkt of de animal aan de kooi kan worden toegevoegd. Het kijkt ook of de kooi uberhaupt bestaat.
            if (animal.CageId.HasValue && !(_cageRepository.Get(animal.CageId.Value)?.CanAddAnimalToCage(animal.ToDomainModel()) ?? false)) ModelState.AddModelError("CageId", "Can't assign Animal to cage. It's either full, doesn't exist or the Animals can't be paired because they're a different type of animal or they differ in gender without being Sterilized/Castrated.");

            if (!ModelState.IsValid) return View(animal);

            await _context.Add(result);
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
            var result = _context.Get(id);

            if(result.ImageURL != null && result.ImageURL.Length > 0)
            {
                string imageBase64Data = Convert.ToBase64String(result.ImageURL);
                string imgDataURL = string.Format("data:image/png;base64,{0}", imageBase64Data);
                ViewBag.ImageData = imgDataURL;
            }

            return View(result);
        }
    }
}
