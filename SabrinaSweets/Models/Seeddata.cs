using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SabrinaSweets.Data;
using System;
using System.Linq;


namespace SabrinaSweets.Models
{
    public static class Seeddata
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.Setting.Any())
                {
                    return;
                }

            }
        }

    }
}
