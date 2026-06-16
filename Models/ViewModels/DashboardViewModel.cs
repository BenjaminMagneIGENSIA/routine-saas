namespace Routine_SaaS.Models.ViewModels;

public class DashboardViewModel
{
    // Ces listes alimentent les tableaux et les formulaires du dashboard.
    public List<RoutineEntry> RoutineEntries { get; set; } = [];

    public List<PerformanceEntry> PerformanceEntries { get; set; } = [];

    public List<Exercice> Exercices { get; set; } = [];

    // Les jours sont centralisés ici pour que la vue n'invente pas ses propres valeurs.
    public List<string> JoursSemaine { get; set; } = [];
}
