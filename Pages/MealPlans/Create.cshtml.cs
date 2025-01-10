using FlavorFusion.Data;
using FlavorFusion.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace FlavorFusion.Pages.MealPlans
{
    public class CreateModel : PageModel
    {
        private readonly FlavorFusionContext _context;

        public CreateModel(FlavorFusionContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MealPlan MealPlan { get; set; }

        [BindProperty]
        public List<int> SelectedRecipeIds { get; set; }

        public List<Recipe> AvailableRecipes { get; set; }

        public IActionResult OnGet()
        {
            AvailableRecipes = _context.Recipe.ToList();
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                AvailableRecipes = _context.Recipe.ToList();
                return Page();
            }

            // Adăugăm MealPlan în baza de date
            _context.MealPlan.Add(MealPlan);
            _context.SaveChanges();

            _context.SaveChanges();

            return RedirectToPage("Index");
        }
    }
}
