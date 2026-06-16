using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.DependencyInjection;

namespace Routine_SaaS.Data;

//Vérification de l'existance du rôle Admin
//Création du rôle avec RoleManager
//Cherche l'utilisateur admin
// Attribue le rôle

public static class SeedRoles //Static pour éviter les new()
{
    public static async Task InitializeAsync(IServiceProvider services)
    //Classe sans création d'objet, asynchrone, sans retour
    {
        using var scope = services.CreateScope();

        var roleManager = scope.ServiceProvider
        //Récupère le service RoleManager pour créer, chercher, supprimer ou vérifier l'existence d'un rôle
        .GetRequiredService<RoleManager<IdentityRole>>();

        //Bloc exécuté si le rôle n'existe pas 
        if (!await roleManager.RoleExistsAsync("Admin"))
        {
            //Créer un rôle Admin
            await roleManager.CreateAsync(new IdentityRole("Admin"));
        }

        var userManager = scope.ServiceProvider
        //Récupère le service UserManager pour rechercher, dans ce cas, le mail de l'utilisateur à mettre administrateur
            .GetRequiredService<UserManager<IdentityUser>>();
        
        //Recherche de l'utilisateur :
        var adminUser = await userManager.FindByEmailAsync("benjamin.magne@edu.igensia.com");

        //Regarde le résultat.
        if (adminUser != null)
        {
            //Donne le rôle administrateur pour l'utilisateur concerné.
            await userManager.AddToRoleAsync(adminUser, "Admin");
        }
    }
}