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
    public class CreateCategoryTest
    {
        [TestMethod]
        public void CreateCategory_ShouldThrowNullReferenceException_WhenNameIsNullOrEmpty()
        {
            var cosmeticsFactory = new CosmeticsFactory();

            Assert.ThrowsException<NullReferenceException>(() => cosmeticsFactory.CreateCategory(null));
        }

        [TestMethod]
        public void CreateCategoryShouldThrowIndexOutOfRangeException_WhenNameIsInInvalidFormat()
        {
            var cosmeticsFactory = new CosmeticsFactory();

            Assert.ThrowsException<IndexOutOfRangeException>(() => cosmeticsFactory.CreateCategory("For Dry And Damaged Hair"));
        }

        [TestMethod]
        public void CreateCategory_ShouldReturnANewCategory_WhenThePassedParametersAreAllValid()
        {
            var cosmeticsFactory = new CosmeticsFactory();

            var newCategory = new Category("For Female");

            Assert.IsInstanceOfType(newCategory, typeof(Category));
        }
    }
}
