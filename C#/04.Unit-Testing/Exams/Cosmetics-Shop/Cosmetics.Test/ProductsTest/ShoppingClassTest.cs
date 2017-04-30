namespace Cosmetics.Test.ProductsTest
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
    using Extensions;

    [TestClass]
    public class ShoppingClassTest
    {
        [TestMethod]
        public void AddProduct_ShouldAddThePassedProductToTheProductsList()
        {
            var shoppingCart = new ExtendedShoppingCart();
            var productMocked = new Mock<IProduct>();

            shoppingCart.AddProduct(productMocked.Object);

            Assert.AreEqual(1, shoppingCart.Products.Count);
        }

        [TestMethod]
        public void RemoveProduct_ShouldRemoveThePassedProductFromTheProductsList()
        {
            var shoppingCart = new ExtendedShoppingCart();
            var productMocked = new Mock<IProduct>();
            shoppingCart.Products.Add(productMocked.Object);

            shoppingCart.RemoveProduct(productMocked.Object);

            Assert.AreEqual(0, shoppingCart.Products.Count);
        }

        [TestMethod]
        public void ContainsProduct_ShouldReturnTrue_IfThePassedProductIsContainedWithinTheProductsList()
        {
            var shoppingCart = new ExtendedShoppingCart();
            var productMocked = new Mock<IProduct>();
            shoppingCart.Products.Add(productMocked.Object);

            Assert.IsTrue(shoppingCart.ContainsProduct(productMocked.Object));
        }

        [TestMethod]
        public void TotalPrice_ShouldReturnTheTotalSumOfThePricesOfAllProductsInTheProductsList()
        {
            var shoppingCart = new ExtendedShoppingCart();
            var productMocked = new Mock<IProduct>();
            productMocked.Setup(x => x.Price).Returns(22);
            shoppingCart.Products.Add(productMocked.Object);

            var totalSum = shoppingCart.TotalPrice();

            Assert.AreEqual(22, totalSum);
        }
    }
}
