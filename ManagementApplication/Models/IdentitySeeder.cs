using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ManagementApplication.Models
{
    public class IdentitySeeder
    {
        private const string adminUser = "Admin";
        private const string adminPassword = "Secret123$";


        public static async Task EnsurePopulated(UserManager<IdentityUser> userManager)
        {
            IdentityUser user = await userManager.FindByIdAsync(adminUser);
            if (user == null)
            {
                user = new IdentityUser("Admin");
                await userManager.CreateAsync(user, adminPassword);
                await userManager.AddClaimAsync(user, new Claim("Volunteer", "true"));
            }

        }

    }
}
