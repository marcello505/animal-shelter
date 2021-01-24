using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DomainServices;
using Microsoft.AspNetCore.Mvc;

namespace AnimalShelterApplication.ViewComponents
{
    public class AnimalNameById : ViewComponent
    {
        private readonly IAnimalRepository _context;
        public AnimalNameById(IAnimalRepository context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int animalId)
        {
            var animal = await Task.Run(() => _context.Get(animalId));
            if(animal != null)
            {
                return View("default", animal.Name);
            }
            else
            {
                return View("default", "");
            }
            
        }
    }
}
