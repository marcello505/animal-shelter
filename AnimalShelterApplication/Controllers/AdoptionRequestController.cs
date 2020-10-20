using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimalShelterApplication.Models;
using Core.DomainServices;
using Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnimalShelterApplication.Controllers
{
    public class AdoptionRequestController : Controller
    {
        private readonly IAdoptionRequestRepository _context;
        public AdoptionRequestController(IAdoptionRequestRepository context, IAnimalRepository animalRepository)
        {
            _context = context;
        }

        // GET: AdoptionRequestController
        [Authorize]
        public ActionResult Index()
        {
            return View(_context.GetAll().Where(a => a.Email == User.Identity.Name));
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var result = _context.Get(id);
            if(result.Email == User.Identity.Name)
            {
                return View(result);
            }
            return RedirectToAction("Index");
        }

        // POST: AnimalSubmissionController/Edit/5
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AdoptionRequest adoptionRequest)
        {
            if (ModelState.IsValid)
            {
                adoptionRequest.Email = User.Identity.Name;
                _context.Update(adoptionRequest);
                return RedirectToAction("Index");
            }
            return View(adoptionRequest);
        }
    }
}
