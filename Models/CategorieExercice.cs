
using System.ComponentModel.DataAnnotations;

namespace Routine_SaaS.Models;

public class CategorieExercice
{
    // Id est la clé primaire : Entity Framework l'utilise pour retrouver une catégorie en base.
    public int Id { get; set; }

    // Required empêche de créer une catégorie vide depuis le formulaire.
    [Required(ErrorMessage = "Le nom de la catégorie est obligatoire.")]
    [Display(Name = "Nom de la catégorie")]
    public string CategorieName { get; set; } = string.Empty;

    // Une catégorie peut contenir plusieurs exercices.
    public List<Exercice> Exercices { get; set; } = [];
}
