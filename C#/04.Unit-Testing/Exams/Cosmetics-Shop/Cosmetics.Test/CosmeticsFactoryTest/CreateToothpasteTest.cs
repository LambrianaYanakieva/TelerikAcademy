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
    public class CreateToothpasteTest
    {
        [TestMethod]
        public void CreateToothpaste_ShouldThrowNullReferenceException_WhenNameIsNullOrEmpty()
        {
            var cosmeticsFactory = new CosmeticsFactory();

            Assert.ThrowsException<NullReferenceException>(() =>
            cosmeticsFactory.CreateToothpaste(
            null, "Colgate", 2, GenderType.Unisex,
            new List<string>() { "Laika", "Bosilek", "Parmezan" }));
        }

        [TestMethod]
        public void CreateToothpaste_ShouldThrowIndexOutOfRangeException_WhenNameIsNotInTheCorrectFormat()
        {
            var cosmeticsFactory = new CosmeticsFactory();

            Assert.ThrowsException<IndexOutOfRangeException>(() =>
            cosmeticsFactory.CreateToothpaste(
            "Toothpaste For Yellow And Damaged Teeth With A Breath Of Ciggaretes And Flowers",
            "Colgate", 2, GenderType.Unisex,
            new List<string>() { "Laika", "Bosilek", "Parmezan" }));
        }

        [TestMethod]
        public void CreateToothpaste_ShouldThrowNullReferenceException_WhenBrandIsNullOrEmpty()
        {
            var cosmeticsFactory = new CosmeticsFactory();

            Assert.ThrowsException<NullReferenceException>(() =>
            cosmeticsFactory.CreateToothpaste(
            "Light", null, 2, GenderType.Unisex,
            new List<string>() { "Laika", "Bosilek", "Parmezan" }));
        }

        [TestMethod]
        public void CreateToothpaste_ShouldThrowIndexOutOfRangeException_WhenBrandIsNotInTheCorrectFormat()
        {
            var cosmeticsFactory = new CosmeticsFactory();

            Assert.ThrowsException<IndexOutOfRangeException>(() =>
            cosmeticsFactory.CreateToothpaste(
            "Light", "For Asian People Only", 2, GenderType.Unisex,
            new List<string>() { "Laika", "Bosilek", "Parmezan" }));
        }

        [TestMethod]
        public void CreateToothpaste_ShouldThrowIndexOutOfRangeException_WhenTheNameOfAnyItemIsNotInTheCorrectFormat()
        {
            var cosmeticsFactory = new CosmeticsFactory();

            Assert.ThrowsException<IndexOutOfRangeException>(() =>
            cosmeticsFactory.CreateToothpaste(
            "Light", "Colgate", 2, GenderType.Unisex,
            new List<string>() { "Laika", "Bosilek", "Parmezan", "ne" }));
        }
    }
}
