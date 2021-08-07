using System.Collections.Generic;
using System.Linq;

namespace Ollok.Models.ViewsModel
{
    public class FiltrInfo
    {
        public List<string> Colors { get; set; }
        public List<int> Sizes { get; set; }
        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set; }
    }
}