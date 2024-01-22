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
    public class UserSettingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserSettingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UserSettings
        public async Task<IActionResult> Index()
        {
              return _context.UserSettings != null ? 
                          View(await _context.UserSettings.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.UserSettings'  is null.");
        }

        // GET: UserSettings/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.UserSettings == null)
            {
                return NotFound();
            }

            var userSettings = await _context.UserSettings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userSettings == null)
            {
                return NotFound();
            }

            return View(userSettings);
        }

        // GET: UserSettings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserSettings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,SettingId,Value")] UserSettings userSettings)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userSettings);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userSettings);
        }

        // GET: UserSettings/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.UserSettings == null)
            {
                return NotFound();
            }

            var userSettings = await _context.UserSettings.FindAsync(id);
            if (userSettings == null)
            {
                return NotFound();
            }
            return View(userSettings);
        }

        // POST: UserSettings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,UserId,SettingId,Value")] UserSettings userSettings)
        {
            if (id != userSettings.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userSettings);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserSettingsExists(userSettings.Id))
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
            return View(userSettings);
        }

        // GET: UserSettings/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.UserSettings == null)
            {
                return NotFound();
            }

            var userSettings = await _context.UserSettings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userSettings == null)
            {
                return NotFound();
            }

            return View(userSettings);
        }

        // POST: UserSettings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.UserSettings == null)
            {
                return Problem("Entity set 'ApplicationDbContext.UserSettings'  is null.");
            }
            var userSettings = await _context.UserSettings.FindAsync(id);
            if (userSettings != null)
            {
                _context.UserSettings.Remove(userSettings);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserSettingsExists(string id)
        {
          return (_context.UserSettings?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
