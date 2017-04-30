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
    public class CategoryTest
    {
        [TestMethod]
        public void AddCosmetics_ShouldAddThePassedCosmeticToTheProductList()
        {
            var category = new ExtendedCategory("For Female");
            var productMocked = new Mock<IProduct>();

            category.AddProduct(productMocked.Object);

            Assert.AreEqual(1, category.Products.Count);
        }

        [TestMethod]
        public void RemoveCosmetics_ShouldRemoveThePassedCosmeticToTheProductList()
        {
            var category = new ExtendedCategory("For Female");
            var productMocked = new Mock<IProduct>();
            category.Products.Add(productMocked.Object);
            category.RemoveProduct(productMocked.Object);

            Assert.AreEqual(0, category.Products.Count);
        }

    }
}
