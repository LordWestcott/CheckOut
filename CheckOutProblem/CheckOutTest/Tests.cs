using System;
using CheckOutLogic;
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
        [Fact]
        public void Empty_Cart_Should_Total_Zero()
        {
            //Confirm unit tests are working correctly are able to call relevant methods.
            Assert.Equal(0m, checkout.Total());
        }
        #endregion

    }
}
