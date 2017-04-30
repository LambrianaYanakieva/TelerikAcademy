namespace Academy.Test.UserTest
{
    using Extensions;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class UsernameTest
    {
        [Test]
        public void ShouldThrow_ArgumentException_WhenPassedValueIsInvalid()
        {
            Assert.Throws<ArgumentException>(() => new ExtendedUser(null));
        }

        [Test]
        public void Should_NotThrow_WhenThePassedValueIsValid()
        {
            Assert.DoesNotThrow(() => new ExtendedUser("Lambriana"));
        }

        [Test]
        public void Should_CorrectlyAssignPassedValue()
        {
            var user = new ExtendedUser("Gosho");

            Assert.AreEqual("Gosho", user.Username);
        }
    }
}
