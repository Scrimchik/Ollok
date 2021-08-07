
namespace Ollok.Models
{
    public class CartLine
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string CartId { get; set; }
        public Cart Cart { get; set; }
        public int SizeValue { get; set; }
        public int ProductSum { get; set; } = 1;
        public int? productCost => Product?.Price * ProductSum;
    }
}
