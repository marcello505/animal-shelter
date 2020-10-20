using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelterApplication.ViewComponents
{
    public class AnimalCartViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var cartCount = 0;
            if (HttpContext.Session.GetInt32("animal1").HasValue) cartCount += 1;
            if (HttpContext.Session.GetInt32("animal2").HasValue) cartCount += 1;
            if (HttpContext.Session.GetInt32("animal3").HasValue) cartCount += 1;
            if (cartCount > 0) return View("Default", cartCount);
            return View("Empty");
        }
    }
}
