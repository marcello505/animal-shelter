using Core.DomainServices;
using ManagementApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementApplication.ViewComponents
{
    public class CageSelectList : ViewComponent
    {
        private readonly ICageRepository _context;
        public CageSelectList(ICageRepository context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int? id)
        {
            var cageSelectViewModel = new CageSelectViewModel();
            cageSelectViewModel.selectedId = id.GetValueOrDefault();
            cageSelectViewModel.cages = await Task.Run(() => _context.GetAll());
            return View("default", cageSelectViewModel);

        }
    }
}
