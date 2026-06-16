using Routine_SaaS.Models;

namespace Routine_SaaS.Data;

public static class SeedData
{
    public static async Task InitializeAsync(ApplicationDbContext context)
    {
        // On récupère ou on crée les catégories de base pour avoir une démo présentable.
        var jambes = GetOrCreateCategorie(context, "Jambes");
        var dos = GetOrCreateCategorie(context, "Dos");
        var pectoraux = GetOrCreateCategorie(context, "Pectoraux");

        AddExerciseIfMissing(context, "Squat", "Quadriceps", "Mouvement de base pour travailler les jambes.", 80, jambes);
        AddExerciseIfMissing(context, "Presse à cuisses", "Quadriceps", "Alternative guidée pour pousser lourd sur les jambes.", 120, jambes);
        AddExerciseIfMissing(context, "Soulevé de terre", "Chaîne postérieure", "Exercice complet pour le dos et les jambes.", 90, dos);
        AddExerciseIfMissing(context, "Tirage vertical", "Grand dorsal", "Tirage guidé pour construire le dos.", 55, dos);
        AddExerciseIfMissing(context, "Développé couché", "Pectoraux", "Exercice principal pour les pectoraux.", 60, pectoraux);
        AddExerciseIfMissing(context, "Écarté à la machine", "Pectoraux", "Mouvement d'isolation pour finir la séance.", 35, pectoraux);

        await context.SaveChangesAsync();
    }

    private static CategorieExercice GetOrCreateCategorie(ApplicationDbContext context, string name)
    {
        var categorie = context.CategorieExercices.FirstOrDefault(categorie => categorie.CategorieName == name);

        if (categorie != null)
        {
            return categorie;
        }

        categorie = new CategorieExercice { CategorieName = name };
        context.CategorieExercices.Add(categorie);
        return categorie;
    }

    private static void AddExerciseIfMissing(
        ApplicationDbContext context,
        string name,
        string muscle,
        string description,
        int maxPerf,
        CategorieExercice categorie)
    {
        // Any vérifie que l'exercice n'existe pas déjà avant de l'ajouter.
        if (context.Exercices.Any(exercice => exercice.ExerciceName == name))
        {
            return;
        }

        context.Exercices.Add(new Exercice
        {
            ExerciceName = name,
            MuscleTravaille = muscle,
            Description = description,
            MaxPerf = maxPerf,
            CategorieExercice = categorie
        });
    }
}
