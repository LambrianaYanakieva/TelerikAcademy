namespace Cosmetics.Test.CommandTest
{
    using Cosmetics.Common;
    using Engine;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.ComponentModel.Design;

    [TestClass]
    public class ParseTest
    {

        [TestMethod]
        public void Parse_ShouldReturnNewCommand_WhenTheInputStringIsInTheRequiredValidFormat()
        {
            var input = "ShowCategory ForMale";
            var result = Command.Parse(input);
            Assert.IsInstanceOfType(result, typeof(Command));
            
        }

        [TestMethod]
        public void Parse_ShouldSetCorrectValuesToTheNewlyReturnedCommandObjectsProperties_WhenTheInpuStringIsInTheValidRequiredFormat()
        {
            var input = "ShowCategory ForMale";
            var result = Command.Parse(input);
            Assert.AreEqual("ShowCategory", result.Name);
            Assert.AreEqual("ForMale", result.Parameters[0]);

        }

        [TestMethod]
        public void Parse_ShouldThrowNullReferenceExceptionWhenTheInputStringIsNull()
        {
            Assert.ThrowsException<NullReferenceException>(() => Command.Parse(null));
        }

        [TestMethod]
        public void Parse_ShouldThrowArgumentNullExceptionWithAMessageThatContainsTheStringName_WhenTheInputStringIsEmpty()
        {
            var ex = Assert.ThrowsException<ArgumentNullException>(() => Command.Parse(" Formale"));

            StringAssert.Contains(ex.Message, "Name");
        }

        [TestMethod]
        public void Parse_ShouldThrowArgumentNullExeptionThatContainsTheWord_List_WhenEmptyOrNUllParametersAreEntered()
        {
            var ex = Assert.ThrowsException<ArgumentNullException>(() => Command.Parse("ShowCategory "));

            StringAssert.Contains(ex.Message, "List");
        }     
    }
}
