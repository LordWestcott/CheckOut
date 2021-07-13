using System;
using System.Collections.Generic;
using System.Linq;
using CheckOutLogic.Objects;

namespace CheckOutLogic
{
    public class Logic
    {
        public class Checkout
        {
            public List<Item> Cart = new List<Item>();

            public decimal Total()
            {
                return Cart.Sum(o => o.UnitPrice);
            }

            public void Scan(Item item)
            {
                //Check to see if item is null.
                if (item == null)
                {
                    throw new ArgumentException("Item Scanned was null");
                }

                //Check to see if item is on product list.
                if (ProductList.Products.Exists(o => o.SKU == item.SKU))
                {
                    Cart.Add(item);
                }
                
                

            }
        }
    }
}
