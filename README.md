# Routine_SaaS

Application ASP.NET Core MVC pour préparer et suivre une routine de musculation.

## MVP :
Un utilisateur authentifié peut programmer sa semaine de musculation avec des exercices classés par groupe musculaire et suivre ses performances actuelles.

## État actuel :
- Authentification ASP.NET Core Identity en place.
- Gestion du rôle administrateur.
- Début du catalogue d'exercices avec modèles `CategorieExercice` et `Exercice`.
- Espace administrateur protégé pour lister, créer et supprimer des catégories d'exercices.

## Fonctionnalité manquante :
- L'ajout d'un exercice depuis le dashboard ne s'affiche pas encore correctement dans les jours de la semaine.

## Découpage du projet :
### 1 - Authentification :
- Inscription
- Connexion
- Déconnexion
- Données liées à l'utilisateur
- Rôle utilisateur / administrateur

### 2 - Catalogues d'exercices :
- Création des groupes musculaires
- Création des exercices
- Association des exercices avec les groupes musculaires

Groupes et exercices pour la démo : Jambes, Dos, Pectoraux.

### 3 - Interfaces :
- Stylisation des champs, fonds et polices
- Page d'accueil
- Page dashboard
- Page (ou popup) sélection groupe et exercice
- Page (ou popup) renseignement des performances des exercices
- Page ajout, modification, suppression catégories (administrateur)
- Page ajout, modification, suppression exercices (administrateur)

### 4 - Métier :
- Association des exercices avec des jours de la semaines
- Dissociation
- Renseignement performances exercices à un profil utilisateur

## Lancer le projet :
```bash
dotnet restore
dotnet build
dotnet run
```

## Sources utilisées

### ASP.NET Core MVC / Razor

- [ASP.NET Core MVC — Overview](https://learn.microsoft.com/en-us/aspnet/core/mvc/overview)
- [Views MVC](https://learn.microsoft.com/en-us/aspnet/core/mvc/views/overview)
- [Razor syntax](https://learn.microsoft.com/en-us/aspnet/core/mvc/views/razor)
- [Working with forms / Tag Helpers](https://learn.microsoft.com/en-us/aspnet/core/mvc/views/working-with-forms)
- [Model Binding](https://learn.microsoft.com/en-us/aspnet/core/mvc/models/model-binding)

### Authentification / Autorisation

- [ASP.NET Core Identity](https://learn.microsoft.com/en-us/aspnet/core/security/authentication/identity)
- [Authentication overview](https://learn.microsoft.com/en-us/aspnet/core/security/authentication)
- [Simple authorization](https://learn.microsoft.com/en-us/aspnet/core/mvc/security/authorization/simple)
- [Role-based authorization](https://learn.microsoft.com/en-us/aspnet/core/security/authorization/roles)
- [MVC role authorization](https://learn.microsoft.com/en-us/aspnet/core/mvc/security/authorization/roles)
- [Secure user data](https://learn.microsoft.com/en-us/aspnet/core/security/authorization/secure-data)

### ASP.NET Core Identity API

- [RoleManager<T>](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.identity.rolemanager-1)
- [UserManager<T>](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.identity.usermanager-1)
- [AddRoles<TRole>()](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.identity.identitybuilder.addroles)
- [AddToRoleAsync()](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.identity.usermanager-1.addtoroleasync)
- [Customize Identity model](https://learn.microsoft.com/en-us/aspnet/core/security/authentication/customize-identity-model)

### Entity Framework Core

- [EF Core overview](https://learn.microsoft.com/en-us/ef/core)
- [MVC avec EF Core](https://learn.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro)
- [CRUD MVC + EF Core](https://learn.microsoft.com/en-us/aspnet/core/data/ef-mvc/crud)
- [dotnet ef CLI](https://learn.microsoft.com/en-us/ef/core/cli/dotnet)
- [Data seeding EF Core](https://learn.microsoft.com/en-us/ef/core/modeling/data-seeding)
- [Keyless entity types](https://learn.microsoft.com/en-us/ef/core/modeling/keyless-entity-types)

### C# / Asynchrone

- [Async / await](https://learn.microsoft.com/en-us/dotnet/csharp/asynchronous-programming/async-scenarios)

## Utilisation de l'IA

L'IA a été utilisée pour aider à la stylisation des pages de l'application, notamment pour créer une identité visuelle inspirée des couleurs Basic-Fit.

L'IA a également été utilisée pour générer le fichier `SeedData`, afin d'ajouter automatiquement des catégories et des exercices de démonstration au lancement de l'application.
