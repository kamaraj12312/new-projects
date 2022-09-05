using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApplication3.Models
{
    public partial class Market
    {
        public int? MarketId { get; set; }
        public string Marketname { get; set; }
        public string MarketAddress { get; set; }
    }
}
