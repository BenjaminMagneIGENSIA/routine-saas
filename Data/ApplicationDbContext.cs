using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Routine_SaaS.Models;

namespace Routine_SaaS.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
{
    // DbSet représente une table que Entity Framework doit gérer.
    public DbSet<Exercice> Exercices { get; set; }

    public DbSet<CategorieExercice> CategorieExercices { get; set; }

    public DbSet<RoutineEntry> RoutineEntries { get; set; }

    public DbSet<PerformanceEntry> PerformanceEntries { get; set; }
}
