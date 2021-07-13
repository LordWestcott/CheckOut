using System;
using System.Collections.Generic;
using CheckOutLogic;
using CheckOutLogic.Objects;
using Xunit;

namespace CheckOutTest
{
    public class Tests
    {
        #region init

        public readonly CheckOutLogic.Logic.Checkout checkout;

        public Tests()
        {
                checkout = new Logic.Checkout();
        }

        #endregion

        #region Tests
        
        #region Empty_Cart_Should_Total_Zero
            [Fact]
            public void Empty_Cart_Should_Total_Zero()
            {
                Assert.Equal(0m, checkout.Total());
            }
        #endregion

        #region Cart_Should_Not_Accept_Null_Items
        [Fact]
        public void Cart_Should_Not_Accept_Null_Items()
        {
            Assert.Throws<ArgumentException>(testCode: () =>
            {
                checkout.Scan(null);
            });
        }
        #endregion

        #region Cart_Should_Increment_On_Added_Item
        [Theory]
        [MemberData(nameof(DATA_CartShouldIncrement))]
        public void Cart_Should_Increment_On_Added_Item(int expected, Item[] items)
        {
            checkout.Cart.Clear();
            var PriorCartItems = checkout.Cart.Count;

            foreach (var item in items)
            {
                checkout.Scan(item);
            }

            var PostCartItems = checkout.Cart.Count;

            Assert.Equal(expected, PostCartItems);
        }

        public static IEnumerable<object[]> DATA_CartShouldIncrement()
        {
            var product = new ExampleProducts();

            yield return new object[] { 1, new Item[] { product.TestProductA } };
            yield return new object[] { 1, new Item[] { product.TestProductB } };
            yield return new object[] { 1, new Item[] { product.TestProductC } };
            yield return new object[] { 3, new Item[] { product.TestProductA, product.TestProductB, product.TestProductC } };
            yield return new object[] { 3, new Item[] { product.TestProductA, product.TestProductA, product.TestProductA } };
            yield return new object[] { 0, new Item[] { } };
        }
        #endregion

        #region Cart_Should_Contain_Scanned_Product
        [Theory]
        [MemberData(nameof(DATA_CartShouldContainScannedProduct))]
        public void Cart_Should_Contain_Scanned_Product(Item item)
        {
            checkout.Cart.Clear();
            checkout.Scan(item);
            var isItemInCart = checkout.Cart.Contains(item);
            Assert.True(isItemInCart);
        }

        public static IEnumerable<object[]> DATA_CartShouldContainScannedProduct()
        {
            foreach (var product in ProductList.Products)
            {
                yield return new object[] { product };
            }

        }
        #endregion

        #region Total_Should_Be_Accurate
        [Theory]
        [MemberData(nameof(DATA_TotalShouldBeAccurate))]
        public void Total_Should_Be_Accurate(decimal expected, Item[] items)
        {
            checkout.Cart.Clear();
            foreach (var item in items)
            {
                checkout.Scan(item);
            }

            Assert.Equal(expected, checkout.Total());
        }

        public static IEnumerable<object[]> DATA_TotalShouldBeAccurate()
        {
            yield return new object[] { 0.5m, new Item[] { new ExampleProducts().TestProductA } };
            yield return new object[] { 0.3m, new Item[] { new ExampleProducts().TestProductB } };
            yield return new object[] { 0.6m, new Item[] { new ExampleProducts().TestProductC } };
            yield return new object[] { 0.8m, new Item[] { new ExampleProducts().TestProductA, new ExampleProducts().TestProductB } };
            yield return new object[] { 1.4m, new Item[] { new ExampleProducts().TestProductA, new ExampleProducts().TestProductB, new ExampleProducts().TestProductC } };
            yield return new object[] { 0m, new Item[] { } };
        }
        #endregion
        #endregion

    }
}
