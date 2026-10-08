using GestionProduits.Data;
using GestionProduits.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GestionProduits.Pages.Categories;

public class EditModel : PageModel
{
    private readonly AppDbContext _context;
    public EditModel(AppDbContext context) => _context = context;

    [BindProperty]
    public Categorie Categorie { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var categorie = await _context.Categories.FindAsync(id);
        if (categorie == null) return NotFound();

        Categorie = categorie;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        var categorie = await _context.Categories.FindAsync(Categorie.Id);
        if (categorie == null) return NotFound();

        categorie.Nom = Categorie.Nom;
        await _context.SaveChangesAsync();
        return RedirectToPage("Index");
    }
}