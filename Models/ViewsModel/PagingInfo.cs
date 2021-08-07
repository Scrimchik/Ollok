using System;

namespace Ollok.Models.ViewsModel
{
    public class PagingInfo
    {
        public int CurrentPage { get; set; }
        public int SumProduct { get; set; }
        public int ProductPerPage { get; set; }

        public int TotalPages => (int)Math.Ceiling((decimal)SumProduct / ProductPerPage);
    }
}
