using System.Collections.Generic;

namespace Ollok.Models.ViewsModel
{
    public class AddProductViewModel
    {
        public List<Size> Sizes { get; set; }
        public List<Category> Categories { get; set; }
        public Product Product { get; set; }
    }
}
