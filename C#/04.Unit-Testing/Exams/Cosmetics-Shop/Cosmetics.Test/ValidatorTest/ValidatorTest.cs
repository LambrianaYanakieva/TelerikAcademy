using Cosmetics.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics.Test
{
    [TestClass]
    public class ValidatorTest
    {
        [TestMethod]
        public void CheckIfNull_ShouldThrowNullReferenceException_WhenThEParameterobjIsNull()
        {
            Assert.ThrowsException<NullReferenceException>(() => Validator.CheckIfNull(null, "ok"));
        }

        [TestMethod]
        public void CheckIfNull_ShouldNOTThrowAnyExceptions_WhenTheParameterobjIsNOTNull()
        {
            object obj = new object();

            Validator.CheckIfNull(obj, "ok");

            Assert.IsInstanceOfType(obj, typeof(object));
        }

        [TestMethod]
        public void CheckIfStringIsNullOrEmpty_ShouldThrowNullReferenceException_WhenTheParameterTextIsNullOrEmpty()
        {
            var obj = new object();
            Assert.ThrowsException<NullReferenceException>(() => Validator.CheckIfStringIsNullOrEmpty(null));

        }

        [TestMethod]
        public void CheckIfStringIsNullOrEmpty_ShouldNOTThrowAnyExceptions_WhenTheParameterTextIsNOTNullOrEmpty()
        {
            var text = "asdffghhj";
            Validator.CheckIfStringIsNullOrEmpty(text);
            Assert.AreEqual("asdffghhj", text);
        }

        [TestMethod]
        public void CheckIfStringLengthIsValid_ShouldThrowIndexOutOfRangeException_WhenParameterTextIsValid()
        {
            var text = "Castle Black";
            Assert.ThrowsException<IndexOutOfRangeException>(() => Validator.CheckIfStringLengthIsValid(text, 6, 0));

        }

        [TestMethod]
        [DataRow(20,0)]
        [DataRow(16, 4)]
        public void CheckIfStringLengthIsValid_ShouldNOTThrowAnyExceptions_WhenTheParameterTextIsValid(int max,int min)
        {
            var text = "Castle Black";
            Validator.CheckIfStringLengthIsValid(text, max, min);
            Assert.AreEqual("Castle Black", text);
        }


    }
}
