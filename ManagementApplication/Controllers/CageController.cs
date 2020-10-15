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
    }
}
