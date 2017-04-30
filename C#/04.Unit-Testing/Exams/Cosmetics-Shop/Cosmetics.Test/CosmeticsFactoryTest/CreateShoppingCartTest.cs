namespace Cosmetics.Test.CosmeticsFactoryTest
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using Moq;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Cosmetics.Contracts;
    using Cosmetics.Engine;
    using Cosmetics.Products;
    using Common;

    [TestClass]
    public class CreateShoppingCartTest
    {
        [TestMethod]
        public void CreateShoppingCart_ShouldAlwaysReturnANewShoppingCart()
        {
            var cosmeticsFactory = new CosmeticsFactory();

            var shoppingCart = cosmeticsFactory.CreateShoppingCart();

            Assert.IsInstanceOfType(shoppingCart, typeof(ShoppingCart));
        }
    }
}
