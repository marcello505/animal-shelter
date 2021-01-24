using AnimalShelterApplication.Models;
using Core.DomainServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelterApplication.ViewComponents
{
    public class AnimalSelectList :ViewComponent
    {
        private readonly IAnimalRepository _context;
        public AnimalSelectList(IAnimalRepository context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var animalSelectViewModel = new AnimalSelectViewModel();
            animalSelectViewModel.selectedId = id;
            animalSelectViewModel.animals = await Task.Run(() => _context.GetAll());
            return View("default", animalSelectViewModel);
        }
    }
}
