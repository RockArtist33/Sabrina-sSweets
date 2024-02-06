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
    public class ShoppingCategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ShoppingCategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ShoppingCategories
        public async Task<IActionResult> Index()
        {
              return _context.ShoppingCategory != null ? 
                          View(await _context.ShoppingCategory.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.ShoppingCategory'  is null.");
        }

        // GET: ShoppingCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ShoppingCategory == null)
            {
                return NotFound();
            }

            var shoppingCategory = await _context.ShoppingCategory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shoppingCategory == null)
            {
                return NotFound();
            }

            return View(shoppingCategory);
        }

        // GET: ShoppingCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ShoppingCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Type")] ShoppingCategory shoppingCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shoppingCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shoppingCategory);
        }

        // GET: ShoppingCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ShoppingCategory == null)
            {
                return NotFound();
            }

            var shoppingCategory = await _context.ShoppingCategory.FindAsync(id);
            if (shoppingCategory == null)
            {
                return NotFound();
            }
            return View(shoppingCategory);
        }

        // POST: ShoppingCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Type")] ShoppingCategory shoppingCategory)
        {
            if (id != shoppingCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shoppingCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShoppingCategoryExists(shoppingCategory.Id))
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
            return View(shoppingCategory);
        }

        // GET: ShoppingCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ShoppingCategory == null)
            {
                return NotFound();
            }

            var shoppingCategory = await _context.ShoppingCategory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shoppingCategory == null)
            {
                return NotFound();
            }

            return View(shoppingCategory);
        }

        // POST: ShoppingCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ShoppingCategory == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ShoppingCategory'  is null.");
            }
            var shoppingCategory = await _context.ShoppingCategory.FindAsync(id);
            if (shoppingCategory != null)
            {
                _context.ShoppingCategory.Remove(shoppingCategory);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShoppingCategoryExists(int id)
        {
          return (_context.ShoppingCategory?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
