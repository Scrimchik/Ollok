using System.Collections.Generic;

namespace Ollok.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LatinName { get; set; }
        public int Price { get; set; }
        public bool IsSeen { get; set; }
        public int Like { get; set; }
        public string Color { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<Size> Sizes { get; set; } = new List<Size>();
        public List<Photo> Photos { get; set; } = new List<Photo>();
        public List<Wishlist> Wishlists { get; set; } = new List<Wishlist>();
        public List<Cart> Carts { get; set; } = new List<Cart>();
    }
}
