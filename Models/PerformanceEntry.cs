using System.ComponentModel.DataAnnotations;

namespace Routine_SaaS.Models;

public class PerformanceEntry
{
    // Id est la clé primaire de la performance.
    public int Id { get; set; }

    // UserId rattache la performance à l'utilisateur connecté.
    [Required]
    public string UserId { get; set; } = string.Empty;

    [Required(ErrorMessage = "L'exercice est obligatoire.")]
    [Display(Name = "Exercice")]
    public int ExerciceId { get; set; }

    // Navigation vers l'exercice, utile pour afficher son nom dans l'historique.
    public Exercice? Exercice { get; set; }

    [Display(Name = "Date")]
    public DateTime DatePerformance { get; set; } = DateTime.Today;

    [Range(0, 1000, ErrorMessage = "La charge doit être positive.")]
    [Display(Name = "Charge en kg")]
    public decimal ChargeKg { get; set; }

    [Range(0, 1000, ErrorMessage = "Le nombre de répétitions doit être positif.")]
    [Display(Name = "Répétitions")]
    public int Repetitions { get; set; }

    [Display(Name = "Commentaire")]
    public string? Commentaire { get; set; }
}
