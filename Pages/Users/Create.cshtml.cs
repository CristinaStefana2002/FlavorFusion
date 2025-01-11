using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FlavorFusion.Data;
using FlavorFusion.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Policy;

namespace FlavorFusion.Pages.Users
{
    public class CreateModel : PageModel
    {
        private readonly FlavorFusionContext _context;

        public CreateModel(FlavorFusionContext context)
        {
            _context = context;
        }

        [BindProperty]
        public User User { get; set; }  // Modelul User asociat formularului

        public IActionResult OnGet()
        {
            ViewData["UserID"] = new SelectList(_context.Set<User>(), "ID","UserName");
            return Page(); // Întoarce pagina Create
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                _context.User.Add(User); // Adaugă utilizatorul în baza de date
                await _context.SaveChangesAsync(); // Salvează modificările

                return RedirectToPage("./Index"); // Redirecționează la pagina Index
            }
            return Page(); // Dacă există erori, rămâne pe pagina curentă
        }
    }
}
