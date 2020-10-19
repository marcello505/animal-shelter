using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DomainServices;
using Microsoft.AspNetCore.Mvc;

namespace ManagementApplication.ViewComponents
{
    public class TotalAnimalsViewComponent : ViewComponent
    {
        private readonly IAnimalRepository _context;
        public TotalAnimalsViewComponent(IAnimalRepository context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var itemCount = await Task.Run(_context.GetAll().Count);
            return View(itemCount);
        }
    }
}
