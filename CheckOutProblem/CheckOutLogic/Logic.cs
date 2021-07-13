using System;
using System.Collections.Generic;
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
                return 0m;
            }

            public void Scan(Item item)
            {
                //Check to see if item is null.
                if (item == null)
                {
                    throw new ArgumentException("Item Scanned was null");
                }

                //todo - Check to see if item is valid Item.
                
                Cart.Add(item);

            }
        }
    }
}
