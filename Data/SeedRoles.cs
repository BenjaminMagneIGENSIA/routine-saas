using Microsoft.AspNetCore.Identity;

namespace Routine_SaaS.Data;

public static class SeedRoles
{
    public static async Task InitializeAsync(IServiceProvider services)
    {
        using var scope = services.CreateScope();

        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        if (!await roleManager.RoleExistsAsync("Admin"))
        {
            await roleManager.CreateAsync(new IdentityRole("Admin"));
        }

        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
        var adminUser = await userManager.FindByEmailAsync("benjamin.magne@edu.igensia.com");

        if (adminUser != null && !await userManager.IsInRoleAsync(adminUser, "Admin"))
        {
            await userManager.AddToRoleAsync(adminUser, "Admin");
        }
    }
}
