using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementApplication.Models
{
    public class AddAuthorizeFiltersControllerConvention : IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            if (!controller.ControllerName.Contains("Home"))
            {
                controller.Filters.Add(new AuthorizeFilter("defaultpolicy"));
            }
        }
    }
}
