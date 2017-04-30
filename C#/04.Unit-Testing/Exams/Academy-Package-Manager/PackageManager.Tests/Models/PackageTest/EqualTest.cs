namespace PackageManager.Tests.Models.PackageTest
{
    using Enums;
    using Moq;
    using NUnit.Framework;
    using PackageManager.Models;
    using PackageManager.Models.Contracts;
    using System;

    [TestFixture]
    public class EqualTest
    {
        
        [Test]
        public void Equal_ShouldNotThrow_WhenThePassedValueIsValid()
        {
            var versionMocked = new Mock<IVersion>();
            var objectMocked = new Mock<IPackage>();

            var package = new Package(
                "Unit Testing", 
                versionMocked.Object);

           

            Assert.DoesNotThrow(() => package.Equals(objectMocked.Object));
        }

        [Test]
        public void Equals_ShouldThrowArgumentNullException_WhenThePassedValueIsInvalid()
        {
            var versionMocked = new Mock<IVersion>();
            

            var package = new Package(
                "Unit Testing",
                versionMocked.Object);

            Assert.Throws<ArgumentNullException>(() => package.Equals(null));
        }

        [Test]
        public void Check_IfPassedValueIsTypeOfIPackage()
        {
            var versionMocked = new Mock<IVersion>();
            var objectMocked = new Mock<IPackage>();

            var package = new Package(
                "Unit Testing",
                versionMocked.Object);

            package.Equals(objectMocked.Object);

            Assert.IsInstanceOf(typeof(IPackage), objectMocked.Object);
        }

        [Test]
        public void Check_IfPassedPackageIsEqualToCurrentPackage()
        {
            var versionMocked = new Mock<IVersion>();
            var objectMocked = new Mock<IPackage>();

            versionMocked.Setup(x => x.Major).Returns(2);
            versionMocked.Setup(x => x.Minor).Returns(2);
            versionMocked.Setup(x => x.Patch).Returns(2);
            versionMocked.Setup(x => x.VersionType).Returns(VersionType.alpha);

            objectMocked.Setup(x => x.Name).Returns("Unit Testing");
            objectMocked.Setup(x => x.Version.Major).Returns(2);
            objectMocked.Setup(x => x.Version.Minor).Returns(2);
            objectMocked.Setup(x => x.Version.Patch).Returns(2);
            objectMocked.Setup(x => x.Version.VersionType).Returns(VersionType.alpha);

            var package = new Package(
                "Unit Testing",
                versionMocked.Object);

            Assert.IsTrue(package.Equals(objectMocked.Object));
        }

        [Test]
        public void Check_IfPassedPackageIsNotEqualToCurrentPackage()
        {
            var versionMocked = new Mock<IVersion>();
            var objectMocked = new Mock<IPackage>();

            versionMocked.Setup(x => x.Major).Returns(3);
            versionMocked.Setup(x => x.Minor).Returns(3);
            versionMocked.Setup(x => x.Patch).Returns(3);
            versionMocked.Setup(x => x.VersionType).Returns(VersionType.beta);

            objectMocked.Setup(x => x.Name).Returns("Unit Testing");
            objectMocked.Setup(x => x.Version.Major).Returns(2);
            objectMocked.Setup(x => x.Version.Minor).Returns(2);
            objectMocked.Setup(x => x.Version.Patch).Returns(2);
            objectMocked.Setup(x => x.Version.VersionType).Returns(VersionType.alpha);

            var package = new Package(
                "Unit Testing",
                versionMocked.Object);

            Assert.IsFalse(package.Equals(objectMocked.Object));
        }
    }
}
