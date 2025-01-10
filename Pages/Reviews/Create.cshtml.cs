using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FlavorFusion.Data;
using FlavorFusion.Models;

namespace FlavorFusion.Pages.Reviews
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
        ViewData["RecipeId"] = new SelectList(_context.Recipe, "Id", "Id");
        ViewData["UserId"] = new SelectList(_context.User, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Review Review { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Review.Add(Review);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
