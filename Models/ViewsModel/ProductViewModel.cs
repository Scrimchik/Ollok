using System.Collections.Generic;

namespace Ollok.Models.ViewsModel
{
    public class ProductViewModel
    {
        public Product Product { get; set; }
        public List<Product> RecomendedProducts { get; set; } = new List<Product>();
    }
}
