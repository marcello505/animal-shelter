using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DomainServices;
using Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagementApplication.Controllers
{
    public class AnimalSubmissionController : Controller
    {
        private readonly IAnimalSubmissionRepository _context;
        public AnimalSubmissionController(IAnimalSubmissionRepository context)
        {
            _context = context;
        }
        // GET: AnimalSubmissionController
        public ActionResult Index()
        {
            return View(_context.GetAll());
        }

        // GET: AnimalSubmissionController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_context.Get(id));
        }

        // POST: AnimalSubmissionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(AnimalSubmission animalSubmission)
        {
            _context.Delete(animalSubmission);
            return RedirectToAction("Index");
        }
    }
}
