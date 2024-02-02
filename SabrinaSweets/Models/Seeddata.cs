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
                if (context.CreatedSettings.Any())
                {
                    return;
                }
                context.CreatedSettings.AddRange(

                    new CreatedSettings
                    {
                        Name = "Test Checkbox",
                        Description = "",
                        Options = "",
                        Type = "checkbox"
                    },
                    new CreatedSettings
                    {
                        Name = "Test Dropdown",
                        Description = "",
                        Options = "",
                        Type = "dropdown"
                    },
                    new CreatedSettings
                    {
                        Name = "Test List",
                        Description = "",
                        Options = "",
                        Type = "checklist"
                    },
                    new CreatedSettings
                    {
                        Name = "Test Button List",
                        Description = "",
                        Options = "{{Option: 'Test Option 1'}, {Option: 'Test Option 2'}, {Option: 'Test Option 3'}, {Option: 'Test Option 4'}}",
                        Type = "radio"
                    }

                );
                context.Category.AddRange(
                    new Category
                    {
                        Name="General",
                        Description="",
                        IsActive=false
                    },
                    new Category
                    {
                        Name = "Appearance",
                        Description = "",
                        IsActive = false
                    },
                    new Category
                    {
                        Name = "Accessibility",
                        Description = "",
                        IsActive = false
                    },
                    new Category
                    {
                        Name = "Privacy and Security",
                        Description = "",
                        IsActive = false
                    },
                    new Category
                    {
                        Name = "Payment Methods",
                        Description = "",
                        IsActive = false
                    }
                );
                context.SettingsCategory.AddRange(
                    new SettingsCategory
                    {
                        CategoryId= 1,
                        Settings_Id= 1,
                    },
                    new SettingsCategory
                    {
                        CategoryId = 1,
                        Settings_Id = 2,
                    },
                    new SettingsCategory
                    {
                        CategoryId = 1,
                        Settings_Id = 3,
                    },
                    new SettingsCategory
                    {
                        CategoryId = 1,
                        Settings_Id = 4,
                    }
                );
                context.SaveChanges();

            }
        }

    }
}
