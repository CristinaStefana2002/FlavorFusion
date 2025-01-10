﻿using System;
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
    public class IndexModel : PageModel
    {
        private readonly FlavorFusion.Data.FlavorFusionContext _context;

        public IndexModel(FlavorFusion.Data.FlavorFusionContext context)
        {
            _context = context;
        }

        public IList<MealPlan> MealPlan { get; set; } = default!;

        public async Task OnGetAsync()
        {
            MealPlan = await _context.MealPlan
                .Include(m => m.Recipes)  
                .ToListAsync();
        }
    }
}