using System;
using System.Collections.Generic;

namespace Ollok.Models
{
    public class Cart
    {
        public string Id { get; set; }
        public List<CartLine> CartLines { get; set; } = new List<CartLine>();
    }
}
