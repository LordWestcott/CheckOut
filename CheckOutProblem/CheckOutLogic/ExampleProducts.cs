using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckOutLogic.Objects;

namespace CheckOutLogic
{
    public class ExampleProducts
    {
        public readonly Item TestProductA = new Item()
        {
            SKU = "A99",
            UnitPrice = 0.5m,
            ItemOffer = new Offer()
            {
                OfferQuant = 3,
                OfferPrice = 1.3m
            }
        };

        public readonly Item TestProductB = new Item()
        {
            SKU = "B15",
            UnitPrice = 0.3m,
            ItemOffer = new Offer()
            {
                OfferQuant = 2,
                OfferPrice = 0.45m
            }
        };

        public readonly Item TestProductC = new Item()
        {
            SKU = "C40",
            UnitPrice = 0.6m,
        };
    }

    public static class ProductList
    {
        public static List<Item> Products { get; set; } = new List<Item>()
        {
            new ExampleProducts().TestProductA,
            new ExampleProducts().TestProductB,
            new ExampleProducts().TestProductC
        };
    }
}
