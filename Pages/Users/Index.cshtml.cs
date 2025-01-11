using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FlavorFusion.Data;
using FlavorFusion.Models;
using FlavorFusion.Models.ViewModels;

namespace FlavorFusion.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly FlavorFusion.Data.FlavorFusionContext _context;

        public IndexModel(FlavorFusion.Data.FlavorFusionContext context)
        {
            _context = context;
        }
        public UserIndexData UserData { get; set; }
        public int UserID { get; set; }
        public int RecipeID { get; set; }

        public IList<User> User { get; set; } = default!;

        public async Task OnGetAsync(int? id, int? recipeID)
        {
            UserData = new UserIndexData();
            UserData.Users = await _context.User
                .Include(u => u.Recipes)
                .OrderBy(u => u.UserName)
                .ToListAsync();

            if (id != null)
            {
                UserID = id.Value;
                var user = UserData.Users
                    .Where(u => u.Id == id.Value).SingleOrDefault();
                UserData.Recipes = user?.Recipes;
            }
        }
    }
}