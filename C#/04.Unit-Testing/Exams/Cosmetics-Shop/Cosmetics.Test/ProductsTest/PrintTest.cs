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

    [TestClass]
    public class PrintTest
    {
        [TestMethod]
        public void ShampooPrint_ShouldReturnAStringWithTheShampooDetails_InTheRequiredFormat()
        {
            var shampoo = new Shampoo("Cool", "Nivea", 24, GenderType.Women, 240, UsageType.EveryDay);

            var result = shampoo.Print();

            StringAssert.Contains(result, "- Nivea - Cool:");
        }

        [TestMethod]
        public void ToothpastePrint_ShouldReturnAStringWithTheShampooDetails_InTheRequiredFormat()
        {
           
            var toothpaste = new Toothpaste(
                "Light", "Colgate", 2, GenderType.Unisex, 
                new List<string>() { "Laika", "Bosilek", "Parmezan" });
            var result = toothpaste.Print();
            StringAssert.Contains(result, "- Colgate - Light:");
        }

        [TestMethod]
        public void CategoryPrint_ShouldReturnAStringWithTheShampooDetails_InTheRequiredFormat()
        {
            
            var category = new Category("For Female");

            var result = category.Print();

            StringAssert.Contains(result, "For Female category");
        }
    }
}
