using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Routine_SaaS.Data;
using Routine_SaaS.Models;
using Routine_SaaS.Models.ViewModels;

namespace Routine_SaaS.Controllers;

[Authorize]
public class DashboardController : Controller
{
    // _context permet de lire et écrire les exercices, le planning et les performances.
    private readonly ApplicationDbContext _context;

    private static readonly List<string> JoursSemaine =
    [
        "Lundi",
        "Mardi",
        "Mercredi",
        "Jeudi",
        "Vendredi",
        "Samedi",
        "Dimanche"
    ];

    public DashboardController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var userId = GetCurrentUserId();

        var viewModel = new DashboardViewModel
        {
            JoursSemaine = JoursSemaine,
            Exercices = await GetExercicesAsync(),
            RoutineEntries = await GetRoutineEntriesAsync(userId),
            PerformanceEntries = await GetPerformanceEntriesAsync(userId)
        };

        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddRoutineEntry(RoutineEntry entry)
    {
        var userId = GetCurrentUserId();

        // On force le UserId côté serveur pour éviter qu'un utilisateur modifie celui d'un autre.
        entry.UserId = userId;

        if (ModelState.IsValid)
        {
            _context.RoutineEntries.Add(entry);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteRoutineEntry(int id)
    {
        var userId = GetCurrentUserId();
        var entry = await _context.RoutineEntries.FirstOrDefaultAsync(item => item.Id == id && item.UserId == userId);

        if (entry != null)
        {
            _context.RoutineEntries.Remove(entry);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddPerformance(PerformanceEntry performance)
    {
        var userId = GetCurrentUserId();
        performance.UserId = userId;

        if (performance.DatePerformance == default)
        {
            performance.DatePerformance = DateTime.Today;
        }

        if (ModelState.IsValid)
        {
            _context.PerformanceEntries.Add(performance);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }

    private string GetCurrentUserId()
    {
        // Le claim NameIdentifier contient l'identifiant technique de l'utilisateur connecté.
        return User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty;
    }

    private async Task<List<Exercice>> GetExercicesAsync()
    {
        return await _context.Exercices
            .Include(exercice => exercice.CategorieExercice)
            .OrderBy(exercice => exercice.CategorieExercice!.CategorieName)
            .ThenBy(exercice => exercice.ExerciceName)
            .ToListAsync();
    }

    private async Task<List<RoutineEntry>> GetRoutineEntriesAsync(string userId)
    {
        return await _context.RoutineEntries
            .Include(entry => entry.Exercice)
            .ThenInclude(exercice => exercice!.CategorieExercice)
            .Where(entry => entry.UserId == userId)
            .ToListAsync();
    }

    private async Task<List<PerformanceEntry>> GetPerformanceEntriesAsync(string userId)
    {
        return await _context.PerformanceEntries
            .Include(performance => performance.Exercice)
            .Where(performance => performance.UserId == userId)
            .OrderByDescending(performance => performance.DatePerformance)
            .Take(8)
            .ToListAsync();
    }
}
