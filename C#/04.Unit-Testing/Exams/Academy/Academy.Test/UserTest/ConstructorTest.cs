namespace Academy.Test.UserTest
{
    using Extensions;
    using NUnit.Framework;

    [TestFixture]
    public class ConstructorTest
    {
        [Test]
        public void Should_CorrectlyAssignPassedValues()
        {
            var user = new ExtendedUser("Lambriana");

            Assert.AreEqual("Lambriana", user.Username);
        }

        
    }
}
