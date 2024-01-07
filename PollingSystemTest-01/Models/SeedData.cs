using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PollingSystemTest_01.Data;

namespace PollingSystemTest_01.Models
{
    public class SeedData
    {
        public async static Task Initialize(IServiceProvider serviceProvider)
        {
            var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>());

            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            string newRole = new string("Project Manager");
            await roleManager.CreateAsync(new IdentityRole(newRole));

            var passwordHasher = new PasswordHasher<ApplicationUser>();
            ApplicationUser firstProjectAdmin = new ApplicationUser
            {
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                UserName = "admin@gmail.com",
                EmailConfirmed = true,
            };

            var hashedPassword = passwordHasher.HashPassword(firstProjectAdmin, "P@ssword1");
            firstProjectAdmin.PasswordHash = hashedPassword;
            await userManager.CreateAsync(firstProjectAdmin);
            await userManager.AddToRoleAsync(firstProjectAdmin, "Admin");

            context.SaveChanges();
        }
    }
}

