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
        private const string adminEmail = "Admin@gmail.com";
        private const string adminPassword = "Welcome123!";


        public static async Task EnsurePopulated(UserManager<IdentityUser> userManager)
        {
            IdentityUser user = await userManager.FindByNameAsync(adminEmail);
            if (user == null)
            {
                user = new IdentityUser(adminEmail);
                user.Email = adminEmail;
                user.EmailConfirmed = true;
                user.NormalizedEmail = adminEmail.ToUpper();
                await userManager.CreateAsync(user, adminPassword);
                await userManager.AddClaimAsync(user, new Claim("Volunteer", "true"));
            }

        }

    }
}
