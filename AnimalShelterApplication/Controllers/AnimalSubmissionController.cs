using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DomainServices;
using Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnimalShelterApplication.Controllers
{
    public class AnimalSubmissionController : Controller
    {
        private IAnimalSubmissionRepository _context;
        public AnimalSubmissionController(IAnimalSubmissionRepository context)
        {
            _context = context;
        }

        // GET: AnimalSubmissionController
        [Authorize]
        public ActionResult Index()
        {
            return View(_context.GetAll().Where(a => a.OwnerName == User.Identity.Name));
        }

        // GET: AnimalSubmissionController/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: AnimalSubmissionController/Create
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AnimalSubmission animalSubmission)
        {
            if (ModelState.IsValid)
            {
                animalSubmission.OwnerName = User.Identity.Name;
                _context.Add(animalSubmission);
                return RedirectToAction("Index");
            }
            return View(animalSubmission);
        }

        // GET: AnimalSubmissionController/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            var result = _context.Get(id);
            if(result.OwnerName == User.Identity.Name)
            {
                return View(_context.Get(id));
            }
            return RedirectToAction("Index");
        }

        // POST: AnimalSubmissionController/Edit/5
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AnimalSubmission animalSubmission)
        {
            if (ModelState.IsValid)
            {
                animalSubmission.OwnerName = User.Identity.Name;
                _context.Update(animalSubmission);
                return RedirectToAction("Index");
            }
            return View(animalSubmission);
        }

    }
}
