using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SabrinaSweets.Data;
using SabrinaSweets.Models;
using SabrinaSweets.Models.ViewModels;

namespace SabrinaSweets.Controllers
{
    public class SettingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SettingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Settings
        [Authorize]
        public async Task<IActionResult> Index(int id)
        {
            var ViewModelSettings_ = new ViewModelSettings();
            Category Category_;
            if (id != null)
            {
                try 
                { 
                    Category_ = _context.Category.Where(Category => Category.Id == id).FirstOrDefault();
                    ViewBag["CategoryName"] = Category_.Name;
                    ViewBag["ViewModelSettings_"] = ViewModelSettings_;
                    return View();
                }

                catch
                {
                    Category_ = _context.Category.Where(Category => Category.Id == 0).FirstOrDefault();
                    ViewBag["CategoryName"] = Category_.Name;
                    ViewBag["ViewModelSettings_"] = ViewModelSettings_;
                    return View();
                }

            }
            
        }
    }
}