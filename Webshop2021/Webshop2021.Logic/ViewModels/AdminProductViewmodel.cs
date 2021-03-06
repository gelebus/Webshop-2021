using System;
using System.Collections.Generic;
using System.Text;

namespace Webshop2021.Logic.ViewModels
{
    public class AdminProductViewmodel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public IEnumerable<StockViewModel> Stock { get; set; }
    }
}
