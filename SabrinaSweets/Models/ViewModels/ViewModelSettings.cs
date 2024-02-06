using SabrinaSweets.Models;
namespace SabrinaSweets.Models.ViewModels
{
    public class ViewModelSettings
    {
        public IEnumerable<CreatedSettings> Settings { get; set; }
        public Category? Category { get; set; }
        public IEnumerable<Category> EnumCategories { get; set; }
        public IEnumerable<CreatedSettings> EnumSettings { get; set; }
        public IEnumerable<SettingsCategory> EnumSetCat { get; set; }
        public UserSettings userSettings { get; set; }
        public IEnumerable<UserSettings> EnumuserSettings { get; set; }

    }
}
