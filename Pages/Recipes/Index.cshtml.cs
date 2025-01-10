using FlavorFusion.Data;
using FlavorFusion.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
namespace FlavorFusion.Pages.Recipes;
public class IndexModel : PageModel
{
    private readonly FlavorFusionContext _context;

    public IndexModel(FlavorFusionContext context)
    {
        _context = context;
    }

    public IList<Recipe> Recipe { get; set; }

    public void OnGet()
    {
            Recipe = _context.Recipe
                        .Include(r => r.User)
                        .Include(r => r.Reviews)
                        .ToList();
    }
}
