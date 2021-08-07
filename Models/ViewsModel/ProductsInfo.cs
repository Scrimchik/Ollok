using System.Collections.Generic;

namespace Ollok.Models.ViewsModel
{
    public class ProductsInfo
    {
        public PagingInfo PagingInfo { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public FiltrInfo FiltrInfo { get; set; }
        public List<int> WishlistProductsId { get; set; }
    }
}
