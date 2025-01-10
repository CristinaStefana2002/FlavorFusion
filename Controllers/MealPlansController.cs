using FlavorFusion.Data;
using FlavorFusion.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlavorFusion.Controllers
{
    public class MealPlansController : Controller
    {
        private readonly FlavorFusionContext _context;

        public MealPlansController(FlavorFusionContext context)
        {
            _context = context;
        }

        // Index - List Meal Plans
        public async Task<IActionResult> Index()
        {
            var mealPlans = await _context.MealPlan.ToListAsync();
            return View(mealPlans);
        }

        // Create - GET
        public IActionResult Create()
        {
            return View();
        }

        // Create - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, Name, Description")] MealPlan mealPlan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mealPlan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mealPlan);
        }

        // Edit - GET
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mealPlan = await _context.MealPlan.FindAsync(id);
            if (mealPlan == null)
            {
                return NotFound();
            }
            return View(mealPlan);
        }

        // Edit - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Name, Description")] MealPlan mealPlan)
        {
            if (id != mealPlan.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mealPlan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MealPlanExists(mealPlan.Id))
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
            return View(mealPlan);
        }

        // Delete - GET
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mealPlan = await _context.MealPlan
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mealPlan == null)
            {
                return NotFound();
            }

            return View(mealPlan);
        }

        // Delete - POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mealPlan = await _context.MealPlan.FindAsync(id);
            _context.MealPlan.Remove(mealPlan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MealPlanExists(int id)
        {
            return _context.MealPlan.Any(e => e.Id == id);
        }
    }
}
