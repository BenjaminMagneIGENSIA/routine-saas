using System.ComponentModel.DataAnnotations;

namespace Routine_SaaS.Models;

public class Exercice
{
    // Id est la clé primaire de l'exercice dans la base de données.
    public int Id { get; set; }

    // Le nom est obligatoire car un exercice sans nom ne serait pas affichable proprement.
    [Required(ErrorMessage = "Le nom de l'exercice est obligatoire.")]
    [Display(Name = "Nom de l'exercice")]
    public string ExerciceName { get; set; } = string.Empty;

    [Display(Name = "Muscle travaillé")]
    public string? MuscleTravaille { get; set; }

    [Display(Name = "Description")]
    public string? Description { get; set; }

    [Display(Name = "Performance de référence")]
    public int MaxPerf { get; set; }

    // Cette propriété stocke l'id de la catégorie liée à l'exercice.
    [Display(Name = "Catégorie")]
    public int? CategorieExerciceId { get; set; }

    // Cette propriété permet de naviguer de l'exercice vers sa catégorie.
    public CategorieExercice? CategorieExercice { get; set; }

    // Ces listes permettent de retrouver où l'exercice est utilisé dans le MVP.
    public List<RoutineEntry> RoutineEntries { get; set; } = [];

    public List<PerformanceEntry> PerformanceEntries { get; set; } = [];
}
