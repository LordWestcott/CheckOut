using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckOutLogic.Objects
{
    public class Item
    {
        public string SKU { get; set; }
        public decimal UnitPrice { get; set; }
        public Offer ItemOffer { get; set; }
    }
}
