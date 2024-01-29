using SabrinaSweets.Models;
namespace SabrinaSweets.Models.ViewModels
{
    public class ViewModelSettings
    {
        public IEnumerable<Setting> Setting { get; set; }
        public Category? Category { get; set; }
        public IEnumerable<SettingsCategory> SettingsCategory { get; set; }
    }
}
