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
    public class CageController : Controller
    {
        private readonly ILogger<CageController> _logger;
        private readonly ICageRepository _context;
        public CageController(ILogger<CageController> logger, ICageRepository context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.GetAll().ToViewModel());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(NewCageViewModel newCage)
        {
            _context.Add(newCage.ToDomainModel());
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_context.Get(id));
        }

        [HttpPost]
        public IActionResult Delete(Cage cage)
        {
            _context.Delete(cage);

            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            return View(_context.Get(id));
        }
    }
}
