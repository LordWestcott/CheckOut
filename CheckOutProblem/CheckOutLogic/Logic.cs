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
                decimal total = 0;
                
                //Group items by SKU.
                var DistinctItemGroups = Cart.GroupBy(o => o.SKU).ToList();


                foreach (var group in DistinctItemGroups)
                {
                    //Retrieve Item details.
                    var item = group.First(); 
                    
                    if (item.ItemOffer == null)
                    {
                        //If no offer, increase total by price of units.
                        total += item.UnitPrice * group.Count();
                        continue;
                    }

                    //Find total for items eligible for discount.
                    var OfferCount = @group.Count() / item.ItemOffer.OfferQuant;
                    var TotalOfferPrice = OfferCount * item.ItemOffer.OfferPrice;

                    //Find total for extra items.
                    var ItemsNotIncluded = @group.Count() % item.ItemOffer.OfferQuant;
                    var TotalNotIncludedPrice = ItemsNotIncluded * item.UnitPrice;

                    //increase total.
                    total += TotalOfferPrice + TotalNotIncludedPrice;
                }

                return total;
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
