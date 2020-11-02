using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelterApplication.ViewComponents
{
    public class AddAnimalToCart : ViewComponent
    {
        public IViewComponentResult Invoke(int id)
        {
            var inCart = false;
            var session = HttpContext.Session;
            if (session.GetInt32("animal1").HasValue && session.GetInt32("animal1") == id) inCart = true;
            if (session.GetInt32("animal2").HasValue && session.GetInt32("animal2") == id) inCart = true;
            if (session.GetInt32("animal3").HasValue && session.GetInt32("animal3") == id) inCart = true;

            return View(inCart ? "Remove" : "Select", id);
        }
    }
}
