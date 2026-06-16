using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Routine_SaaS.Data;
using Routine_SaaS.Models;

namespace Routine_SaaS.Controllers;

[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    // _context est notre porte d'entrée vers la base de données.
    private readonly ApplicationDbContext _context;

    public AdminController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> ListExoCat()
    {
        var categories = await _context.CategorieExercices
            .Include(categorie => categorie.Exercices)
            .OrderBy(categorie => categorie.CategorieName)
            .ToListAsync();

        return View(categories);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteExoCat(int id)
    {
        var categorie = await _context.CategorieExercices
            .Include(categorie => categorie.Exercices)
            .FirstOrDefaultAsync(categorie => categorie.Id == id);

        if (categorie != null)
        {
            // On supprime aussi les exercices de cette catégorie pour éviter des lignes orphelines.
            _context.Exercices.RemoveRange(categorie.Exercices);
            _context.CategorieExercices.Remove(categorie);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(ListExoCat));
    }

    [HttpGet]
    public IActionResult CreateExoCat()
    {
        return View(new CategorieExercice());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateExoCat(CategorieExercice categorie)
    {
        if (!ModelState.IsValid)
        {
            return View(categorie);
        }

        _context.CategorieExercices.Add(categorie);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(ListExoCat));
    }

    [HttpGet]
    public async Task<IActionResult> CreateExercice()
    {
        await FillCategoriesSelectListAsync();
        return View(new Exercice());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateExercice(Exercice exercice)
    {
        if (!ModelState.IsValid)
        {
            await FillCategoriesSelectListAsync();
            return View(exercice);
        }

        _context.Exercices.Add(exercice);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(ListExoCat));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteExercice(int id)
    {
        var exercice = await _context.Exercices.FindAsync(id);

        if (exercice != null)
        {
            _context.Exercices.Remove(exercice);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(ListExoCat));
    }

    private async Task FillCategoriesSelectListAsync()
    {
        // ViewBag est utilisé ici pour envoyer la liste des catégories à la vue du formulaire.
        ViewBag.Categories = new SelectList(
            await _context.CategorieExercices.OrderBy(categorie => categorie.CategorieName).ToListAsync(),
            nameof(CategorieExercice.Id),
            nameof(CategorieExercice.CategorieName));
    }
}
