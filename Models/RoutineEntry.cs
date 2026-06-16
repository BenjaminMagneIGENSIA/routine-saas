using System.ComponentModel.DataAnnotations;

namespace Routine_SaaS.Models;

public class RoutineEntry
{
    // Id est la clé primaire de la ligne de programme.
    public int Id { get; set; }

    // UserId permet de savoir à quel utilisateur appartient cette ligne.
    [Required]
    public string UserId { get; set; } = string.Empty;

    // Le jour est stocké en texte pour rester simple à comprendre et à afficher.
    [Required(ErrorMessage = "Le jour est obligatoire.")]
    [Display(Name = "Jour de la semaine")]
    public string JourSemaine { get; set; } = string.Empty;

    // ExerciceId est la clé étrangère vers l'exercice choisi.
    [Required(ErrorMessage = "L'exercice est obligatoire.")]
    [Display(Name = "Exercice")]
    public int ExerciceId { get; set; }

    // Cette propriété permet d'afficher les détails de l'exercice dans le planning.
    public Exercice? Exercice { get; set; }

    [Display(Name = "Notes")]
    public string? Notes { get; set; }
}
