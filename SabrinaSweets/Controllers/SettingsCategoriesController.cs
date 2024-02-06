using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SabrinaSweets.Data;
using SabrinaSweets.Models;

namespace SabrinaSweets.Controllers
{
    public class SettingsCategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SettingsCategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SettingsCategories
        public async Task<IActionResult> Index()
        {
              return _context.SettingsCategory != null ? 
                          View(await _context.SettingsCategory.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.SettingsCategory'  is null.");
        }

        // GET: SettingsCategories/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null || _context.SettingsCategory == null)
            {
                return NotFound();
            }

            var SettingsCategory = await _context.SettingsCategory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (SettingsCategory == null)
            {
                return NotFound();
            }

            return View(SettingsCategory);
        }

        // GET: SettingsCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SettingsCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Settings_Id,CategoryId")] SettingsCategory SettingsCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(SettingsCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(SettingsCategory);
        }

        // GET: SettingsCategories/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null || _context.SettingsCategory == null)
            {
                return NotFound();
            }

            var SettingsCategory = await _context.SettingsCategory.FindAsync(id);
            if (SettingsCategory == null)
            {
                return NotFound();
            }
            return View(SettingsCategory);
        }

        // POST: SettingsCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Settings_Id,CategoryId")] SettingsCategory SettingsCategory)
        {
            if (id != SettingsCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(SettingsCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SettingsCategoryExists(SettingsCategory.Id))
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
            return View(SettingsCategory);
        }

        // GET: SettingsCategories/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || _context.SettingsCategory == null)
            {
                return NotFound();
            }

            var SettingsCategory = await _context.SettingsCategory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (SettingsCategory == null)
            {
                return NotFound();
            }

            return View(SettingsCategory);
        }

        // POST: SettingsCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SettingsCategory == null)
            {
                return Problem("Entity set 'ApplicationDbContext.SettingsCategory'  is null.");
            }
            var SettingsCategory = await _context.SettingsCategory.FindAsync(id);
            if (SettingsCategory != null)
            {
                _context.SettingsCategory.Remove(SettingsCategory);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SettingsCategoryExists(int id)
        {
          return (_context.SettingsCategory?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
