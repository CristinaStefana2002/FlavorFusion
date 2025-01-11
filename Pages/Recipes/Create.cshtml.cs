using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FlavorFusion.Data;
using FlavorFusion.Models;
using Microsoft.AspNetCore.Authorization;

namespace FlavorFusion.Pages.Recipes
{
    
    public class CreateModel : PageModel
    {
        private readonly FlavorFusion.Data.FlavorFusionContext _context;

        public CreateModel(FlavorFusion.Data.FlavorFusionContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["UserId"] = new SelectList(_context.User, "Id", "Id");
        ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Id");

            return Page();
        }

        [BindProperty]
        public Recipe Recipe { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Recipe.Add(Recipe);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
