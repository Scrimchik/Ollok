using System.Collections.Generic;

namespace Ollok.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LatinName { get; set; }
        public List<Product> Products { get; set; }
    }
}
