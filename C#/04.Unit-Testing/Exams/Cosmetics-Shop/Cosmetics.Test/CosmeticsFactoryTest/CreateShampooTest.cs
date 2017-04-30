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
    public class CreateShampooTest
    {
        [TestMethod]
        public void CreateShampoo_ShouldThrowNullReferenceException_WhenThePassedNameFormatIsNullOrEmpty()
        {
            var cosmeticsFactory = new CosmeticsFactory();

            Assert.ThrowsException<NullReferenceException>(() => 
            cosmeticsFactory.CreateShampoo(
            null, "Nivea", 22 , GenderType.Women, 200, UsageType.EveryDay));
        }

        [TestMethod]
        public void CreateShampoo_ShouldThrowIndexOutOfRangeException_WhenNameIsInInvalidFormat()
        {
            var cosmeticsFactory = new CosmeticsFactory();

            Assert.ThrowsException<IndexOutOfRangeException>(() =>
            cosmeticsFactory.CreateShampoo(
            "Om", "Nivea", 22, GenderType.Women, 200, UsageType.EveryDay));
        }

        [TestMethod]
        public void CreateShampoo_ShouldThrowNullReferenceException_WhenThePassedBrandIsNullOrEmpty()
        {
            var cosmeticsFactory = new CosmeticsFactory();

            Assert.ThrowsException<NullReferenceException>(() =>
            cosmeticsFactory.CreateShampoo(
            "Cool", null, 22, GenderType.Women, 200, UsageType.EveryDay));
        }

        [TestMethod]
        public void CreateShampoo_ShouldThrowIndexOutOfRangeException_WhenBrandIsInInvalidFormat()
        {
            var cosmeticsFactory = new CosmeticsFactory();

            Assert.ThrowsException<IndexOutOfRangeException>(() =>
            cosmeticsFactory.CreateShampoo(
            "Cool", "Niveaaaaaaaaaaaaaaaaaaaaaaaaaa", 22, GenderType.Women, 200, UsageType.EveryDay));
        }

        [TestMethod]
        public void CreateShampoo_ShouldReturnANewShampoo_WhenThePassedParametersAreAllValid()
        {
            var cosmeticsFactory = new CosmeticsFactory();

            var newShampoo = cosmeticsFactory.CreateShampoo("Cool", "Nivea", 24, GenderType.Women, 240, UsageType.EveryDay);

            Assert.IsInstanceOfType(newShampoo, typeof(Shampoo));
        }
    }
}
