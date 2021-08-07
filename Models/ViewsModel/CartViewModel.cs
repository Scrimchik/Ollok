using System.Linq;

namespace Ollok.Models.ViewsModel
{
    public class CartViewModel
    {
        public Cart Cart { get; set; }
        public int? cartSum => Cart?.CartLines?.Sum(t => t.productCost);
    }
}
