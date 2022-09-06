using BaltaLearn.Data;
using BaltaLearn.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BaltaLearn.Controllers
{
    public class ModuleController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ModuleController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Module/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Module/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Description,Order,Title,Id")] Module @module)
        {
            if (ModelState.IsValid)
            {
                _context.Add(@module);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(@module);
        }

        // GET: Module/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null || _context.Module is null)
            {
                return NotFound();
            }

            var @module = await _context.Module
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@module is null)
            {
                return NotFound();
            }

            return View(@module);
        }

        // POST: Module/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Module is null)
            {
                return Problem("Entity set 'ApplicationDbContext.Module' is null.");
            }
            var @module = await _context.Module.FindAsync(id);
            if (@module is not null)
            {
                _context.Module.Remove(@module);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Module/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id is null || _context.Module is null)
            {
                return NotFound();
            }

            var @module = await _context.Module
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@module is null)
            {
                return NotFound();
            }

            return View(@module);
        }

        // GET: Module/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null || _context.Module is null)
            {
                return NotFound();
            }

            var @module = await _context.Module.FindAsync(id);
            if (@module is null)
            {
                return NotFound();
            }
            return View(@module);
        }

        // POST: Module/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Description,Order,Title,Id")] Module @module)
        {
            if (id != @module.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@module);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModuleExists(@module.Id))
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
            return View(@module);
        }

        // GET: Module
        public async Task<IActionResult> Index()
            => _context.Module is not null ?
                        View(await _context.Module.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Module' is null.");

        private bool ModuleExists(int id)
            => (_context.Module?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}