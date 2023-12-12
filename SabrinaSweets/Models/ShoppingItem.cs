namespace SabrinaSweets.Models
{
    public class ShoppingItem
    {
        public string ShoppingItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Size { get; set; }
        public float price { get; set; }
        public string TagId { get; set; }
        public string Ingredients { get; set; }
        public string Nutritional_Values { get; set; }
        public string? Dietary { get; set; }
    }
}
