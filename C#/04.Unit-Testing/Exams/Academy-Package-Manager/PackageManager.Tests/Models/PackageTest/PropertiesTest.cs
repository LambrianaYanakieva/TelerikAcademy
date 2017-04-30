namespace PackageManager.Tests.Models.PackageTest
{
    using Moq;
    using NUnit.Framework;
    using PackageManager.Models;
    using PackageManager.Models.Contracts;
    using System;

    [TestFixture]
    public class PropertiesTest
    {
        [Test]
        public void Property_ShouldSetNameCorrectly_WhenThePassedValueIsValid()
        {
            var versionMocked = new Mock<IVersion>();

            var package = new Package("UnitTest", versionMocked.Object);

            Assert.AreEqual("UnitTest", package.Name);
        }


        [Test]
        public void Property_ShouldSetVersionCorrectly_WhenThePassedValueIsValid()
        {
            var versionMocked = new Mock<IVersion>();

            var package = new Package("UnitTest", versionMocked.Object);

            Assert.IsInstanceOf(typeof(IVersion), package.Version);
        }

        

        [Test]
        public void Property_ShouldSetURLCorrectly_WhenThePassedValueIsValid()
        {
            var versionMocked = new Mock<IVersion>();

            var package = new Package("UnitTest", versionMocked.Object);

            Assert.IsNotEmpty(package.Url);
        }
    }
}
