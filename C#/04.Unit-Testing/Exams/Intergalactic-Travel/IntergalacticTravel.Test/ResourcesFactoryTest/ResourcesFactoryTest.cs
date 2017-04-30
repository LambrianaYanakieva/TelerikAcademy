

namespace IntergalacticTravel.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using IntergalacticTravel;
    using Exceptions;
    using System;

    [TestClass]
    public class ResourcesFactoryTest
    {
        [TestMethod]
        [DataRow("gold(20)", "silver(30)", "bronze(40)")]
        [DataRow("gold(20)", "bronze(40)", "silver(30)")]
        [DataRow("silver(30)", "bronze(40)", "gold(20)")]
        [DataRow("silver(30)", "gold(20)", "bronze(40)")]
        [DataRow("bronze(40)", "gold(20)", "silver(30)")]
        [DataRow("bronze(40)", "silver(30)", "gold(20)")]
        public void GetResources_ShouldReturnANewlyCreatedResourcesObject_WithCorrectlySetUpProperties
            (string first, string second, string third)
        {
            var resFactory = new ResourcesFactory();

            var unit = resFactory.GetResources($"create resources {first} {second} {third}");


            Assert.IsInstanceOfType(unit, typeof(Resources));
        }
        [TestMethod]
        [DataRow("create resources x y z")]
        [DataRow("tansta resources a b")]
        public void GetResources_ShouldThrowInvalidOperationException_WhichContainsTheStringCommand_WhenTheInputStringRepresentsAnInvalidCommand(string command)
        {
            var resFactory = new ResourcesFactory();

            Assert.ThrowsException<InvalidOperationException>(() => resFactory.GetResources($"{command}"), "Invalid command!");
        }

        [TestMethod]
        [DataRow("create resources silver(10) gold(97853252356623523532) bronze(20)")]
        [DataRow("create resources silver(555555555555555555555555555555555) gold(97853252356623523532999999999) bronze(20)")]
        public void GetResources_ShouldThrowOverflowException_WhenTheInputStringCommandIsInTheCorrectFormatButAnyOfTheValuesThatRepresentTheResourceAmountIsLargerThanUintMaxValue(string command)
        {
            var resFactory = new ResourcesFactory();

            Assert.ThrowsException<OverflowException>(() => resFactory.GetResources($"{command}"));
        }
    }
}
