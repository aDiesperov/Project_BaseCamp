using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using RealEstateAgency.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateAgency
{
    public static class DbInitializer
    {

        public static async void Initialize(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var _roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var _userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();


                if (_roleManager.Roles.Count() > 0 || _userManager.Users.Count() > 0) return;

                await _roleManager.CreateAsync(new IdentityRole("Administrator"));
                await _roleManager.CreateAsync(new IdentityRole("Moderator"));
                await _roleManager.CreateAsync(new IdentityRole("Agent"));

                var user = new IdentityUser("Admin") { Email = "Admin@mail.ru"};
                await _userManager.CreateAsync(user, "123456q");
                await _userManager.AddToRoleAsync(user, "Administrator");

                user = new IdentityUser("Moderator") { Email = "Moderator@mail.ru" };
                await _userManager.CreateAsync(user, "123456q");
                await _userManager.AddToRoleAsync(user, "Moderator");

                user = new IdentityUser("UserAgent") { Email = "UserAgent@mail.ru" };
                await _userManager.CreateAsync(user, "123456q");
                await _userManager.AddToRoleAsync(user, "Agent");

                await _userManager.CreateAsync(new IdentityUser("User1") { Email = "User1@mail.ru" }, "123456q");
            }
        }
    }
}
