using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Connections;
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
            IEnumerable<SettingsCategory> CategorisedSettings;
            IEnumerable<Setting> AvailableSettings;
            IEnumerable<Category> AllCategories;
            IEnumerable<Setting> AllSettings;
            IEnumerable<SettingsCategory> AllSetCats;
            Category Category_;
            Category_ = _context.Category.Where(Category => Category.Id == id).FirstOrDefault();
            if (Category_ == null)
            {
                Category_ = _context.Category.Where(Category => Category.Id == 1).FirstOrDefault();
            }
            AllCategories = _context.Category.Where(item => item.Id >= 0).ToList();
            AllSettings = _context.Setting.Where(item => item.SettingId >= 0);
            AllSetCats = _context.SettingsCategory.Where(item => item.Id >= 0);
            CategorisedSettings = _context.SettingsCategory.Where(item => item.CategoryId == id).ToList();
            AvailableSettings = _context.Setting.Where(item => CategorisedSettings.Any(c => item.SettingId == c.Setting_Id) == true);
            

            ViewModelSettings_.Category = Category_;
            ViewModelSettings_.EnumCategories = AllCategories;
            ViewModelSettings_.Setting = AvailableSettings;
            ViewModelSettings_.EnumSettings = AllSettings;
            ViewModelSettings_.EnumSetCat = AllSetCats;
            
            ViewBag.CategoryName = Category_.Name;
            //ViewBag.ViewModelSettings_ = ViewModelSettings_;

            return View(ViewModelSettings_);

        }
    }
}