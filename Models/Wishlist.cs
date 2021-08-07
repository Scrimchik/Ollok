using System.Collections.Generic;

namespace Ollok.Models
{
    public class Wishlist
    {
        public string Id { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
