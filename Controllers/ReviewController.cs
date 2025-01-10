using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using FlavorFusion.Data;  
using FlavorFusion.Models;  

public class ReviewController : Controller
{
    private readonly FlavorFusionContext _context;

    public ReviewController(FlavorFusionContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var reviews = await _context.Review
                                     .Include(r => r.User)
                                     .Include(r => r.Recipe) 
                                     .ToListAsync();

        return View(reviews);  
    }

    public IActionResult Create()
    {
        return View(); 
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("UserId,RecipeId,Comment,Rating")] Review review)
    {
        if (ModelState.IsValid)
        {
            _context.Add(review);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(review);
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var review = await _context.Review
                                    .Include(r => r.User)
                                    .Include(r => r.Recipe)
                                    .FirstOrDefaultAsync(m => m.Id == id);

        if (review == null)
        {
            return NotFound();
        }

        return View(review);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var review = await _context.Review.FindAsync(id);
        if (review == null)
        {
            return NotFound();
        }

        return View(review);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,RecipeId,Comment,Rating")] Review review)
    {
        if (id != review.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(review);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReviewExists(review.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(review);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var review = await _context.Review
                                    .Include(r => r.User)
                                    .Include(r => r.Recipe)
                                    .FirstOrDefaultAsync(m => m.Id == id);

        if (review == null)
        {
            return NotFound();
        }

        return View(review);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var review = await _context.Review.FindAsync(id);
        _context.Review.Remove(review);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ReviewExists(int id)
    {
        return _context.Review.Any(e => e.Id == id);
    }
}
