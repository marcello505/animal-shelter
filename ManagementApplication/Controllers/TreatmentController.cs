using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DomainServices;
using ManagementApplication.Models;
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
    }
}
