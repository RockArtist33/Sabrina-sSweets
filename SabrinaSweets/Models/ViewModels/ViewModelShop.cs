namespace SabrinaSweets.Models.ViewModels
{
    public class ViewModelShop
    {
        public int Id { get; set; }
        public IEnumerable<ShoppingItem> ShoppingItems { get; set; }
        public IEnumerable<ShoppingCategory> ShoppingCategories { get; set; }
    }
}
