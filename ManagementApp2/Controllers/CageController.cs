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
    public class CageController : Controller
    {
        private readonly ILogger<CageController> _logger;
        private readonly ICageRepository _context;
        public CageController(ILogger<CageController> logger, ICageRepository context)
        {
            _logger = logger;
            _context = context;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View(_context.GetAll().ToViewModel());
        }

        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(NewCageViewModel newCage)
        {
            _context.Add(newCage.ToDomainModel());
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize]
        public IActionResult Delete(int id)
        {
            return View(_context.Get(id));
        }

        [Authorize]
        [HttpPost]
        public IActionResult Delete(Cage cage)
        {
            _context.Delete(cage);

            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult Details(int id)
        {
            return View(_context.Get(id));
        }
    }
}
