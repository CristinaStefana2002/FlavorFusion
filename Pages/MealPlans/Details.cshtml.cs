using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FlavorFusion.Data;
using FlavorFusion.Models;

namespace FlavorFusion.Pages.MealPlans
{
    public class DetailsModel : PageModel
    {
        private readonly FlavorFusion.Data.FlavorFusionContext _context;

        public DetailsModel(FlavorFusion.Data.FlavorFusionContext context)
        {
            _context = context;
        }

        public MealPlan MealPlan { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mealplan = await _context.MealPlan.FirstOrDefaultAsync(m => m.Id == id);
            if (mealplan == null)
            {
                return NotFound();
            }
            else
            {
                MealPlan = mealplan;
            }
            return Page();
        }
    }
}
