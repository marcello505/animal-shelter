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

        public IActionResult Edit(int id)
        {
            return View(_context.Get(id));
        }
    }
}
