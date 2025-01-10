using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using FlavorFusion.Data; 
using FlavorFusion.Models; 

public class UserController : Controller
{
    private readonly FlavorFusionContext _context;

    public UserController(FlavorFusionContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> DeleteUser(int userId)
    {
        var user = await _context.User
                                  .Include(u => u.Reviews)  
                                  .FirstOrDefaultAsync(u => u.Id == userId);

        if (user != null)
        {
            _context.Review.RemoveRange(user.Reviews);

            _context.User.Remove(user);

            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }
}
