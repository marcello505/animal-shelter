using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DomainServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnimalShelterApplication.Controllers
{
    public class AnimalController : Controller
    {
        private IAnimalRepository _context;
        public AnimalController(IAnimalRepository context)
        {
            _context = context;
        }

        // GET: AnimalController
        public ActionResult Index()
        {
            return View(_context.GetAll());
        }

        // GET: AnimalController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
    }
}
