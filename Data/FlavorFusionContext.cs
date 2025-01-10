using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FlavorFusion.Models;

namespace FlavorFusion.Data
{
    public class FlavorFusionContext : DbContext
    {
        public FlavorFusionContext(DbContextOptions<FlavorFusionContext> options)
            : base(options)
        {
        }

        public DbSet<FlavorFusion.Models.User> User { get; set; } = default!;
        public DbSet<FlavorFusion.Models.Recipe> Recipe { get; set; } = default!;
        public DbSet<FlavorFusion.Models.Category> Category { get; set; } = default!;
        public DbSet<FlavorFusion.Models.Review> Review { get; set; } = default!;
        public DbSet<FlavorFusion.Models.MealPlan> MealPlan { get; set; } = default!;


    }
}
