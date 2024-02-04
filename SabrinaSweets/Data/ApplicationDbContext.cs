using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SabrinaSweets.Models;

namespace SabrinaSweets.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<SabrinaSweets.Models.CreatedSettings>? CreatedSettings { get; set; }
        public DbSet<SabrinaSweets.Models.UserSettings>? UserSettings { get; set; }
        public DbSet<SabrinaSweets.Models.Category>? Category { get; set; }
        public DbSet<SabrinaSweets.Models.SettingsCategory>? SettingsCategory { get; set; }
        public DbSet<SabrinaSweets.Models.ShoppingItem>? ShoppingItems { get; set; }
    }
}