﻿
using MetroDigital.Domain.Enums;
using MetroDigital.Infraestructure.Identity.Entities;
using Microsoft.AspNetCore.Identity;

namespace MetroDigital.Infraestructure.Identity.Seeds
{
    public class IdentitySeeder
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var roles = Enum.GetValues(typeof(Roles))
                            .Cast<Roles>()
                            .Select(r => r.ToString());

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            // Usuarios de prueba
            var predefinedUsers = new List<(string Email, string Username, string Name, string Lastname, string Password, Roles Role)>
            {
                ("admin@gmail.com", "admin", "System", "Admin", "Admin123@", Roles.ADMIN),
                ("client@gmail.com", "client", "Test", "Client", "Client123@", Roles.CLIENT),
                ("secretary@gmail.com", "secretary", "Robert", "Brown", "Secretary123@", Roles.SECRETARY),
            };

            foreach (var (email, username, name, lastname, password, role) in predefinedUsers)
            {
                var existingUser = await userManager.FindByEmailAsync(email);
                if (existingUser == null)
                {
                    var user = new ApplicationUser
                    {
                        Email = email,
                        UserName = username,
                        Name = name,
                        LastName = lastname,
                        EmailConfirmed = true,
                        PhoneNumberConfirmed = true
                    };

                    var result = await userManager.CreateAsync(user, password);
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(user, role.ToString());
                    }
                }
            }
        }
    }
}
