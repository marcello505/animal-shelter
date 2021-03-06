using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DomainServices;
using Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagementApplication.Controllers
{
    public class AdoptionRequestController : Controller
    {
        private readonly IAdoptionRequestRepository _context;
        public AdoptionRequestController(IAdoptionRequestRepository context)
        {
            _context = context;
        }

        // GET: AdoptionRequestController
        [Authorize]
        public ActionResult Index()
        {
            return View(_context.GetAll());
        }

        // GET: AdoptionRequestController/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            return View(_context.Get(id));
        }

        // POST: AdoptionRequestController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Delete(AdoptionRequest adoptionRequest)
        {
            _context.Delete(adoptionRequest);
            return RedirectToAction("Index");
        }
    }
}
