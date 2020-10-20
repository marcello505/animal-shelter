using Core.DomainServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelterApplication.ViewComponents
{
    public class SpotsLeftViewComponent : ViewComponent
    {
        private readonly ICageRepository _context;
        public SpotsLeftViewComponent(ICageRepository context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var result = _context.GetAll().CalculateFreeSpots();
            return View(result);
        }
    }
}
