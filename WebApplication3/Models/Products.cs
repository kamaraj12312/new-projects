using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApplication3.Models
{
    public partial class Products
    {
        public int ProdId { get; set; }
        public string ProdName { get; set; }
        public string Price { get; set; }
        public string ModelId { get; set; }
    }
}
