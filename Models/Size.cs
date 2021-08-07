using System.Collections.Generic;

namespace Ollok.Models
{
    public class Size
    {
        public int Id { get; set; }
        public int SizeValue { get; set; }
        public List<Product> Products { get; set; }
    }
}
