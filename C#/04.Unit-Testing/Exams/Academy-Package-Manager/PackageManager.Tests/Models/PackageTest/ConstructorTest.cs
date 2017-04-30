namespace PackageManager.Tests.Models.PackageTest
{
    using Moq;
    using NUnit.Framework;
    using PackageManager.Models;
    using PackageManager.Models.Contracts;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class ConstructorTest
    {
        
        [Test]
        public void Constructor_ShouldSetCorrectlyDependencies_WhenParameterIsOptional()
        {
            var versionMocked = new Mock<IVersion>();
            var package = new Package("Test", versionMocked.Object);
            
            Assert.IsInstanceOf(typeof(HashSet<IPackage>), package.Dependencies);
        }

        [Test]
        public void Constructor_ShouldSetCorrectlyDependencies_WhenParameterArePassed()
        {
            var versionMocked = new Mock<IVersion>();
            var dependenciesMocked = new Mock<ICollection<IPackage>>();

            var package = new Package("Test", versionMocked.Object,dependenciesMocked.Object );

            Assert.IsInstanceOf(typeof(ICollection<IPackage>), package.Dependencies);
        }
    }
}
