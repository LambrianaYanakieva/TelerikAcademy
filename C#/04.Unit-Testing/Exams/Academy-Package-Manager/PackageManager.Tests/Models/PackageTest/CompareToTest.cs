namespace PackageManager.Tests.Models.PackageTest
{
    using Enums;
    using Moq;
    using NUnit.Framework;
    using PackageManager.Models;
    using PackageManager.Models.Contracts;
    using System;

    [TestFixture]
    public class CompareToTest
    {
        [Test]
        public void CompareTo_ShouldNotThrow_WhenPassedValueIsValid()
        {
            var versionMocked = new Mock<IVersion>();
            var otherMocked = new Mock<IPackage>();

            otherMocked.Setup(x => x.Name).Returns("UnitTesting");

            otherMocked.Setup(
                m => m.Version).Returns(versionMocked.Object);

            var package = new Package("UnitTesting", versionMocked.Object);

            Assert.DoesNotThrow(() => package.CompareTo(otherMocked.Object));
        }

        [Test]
        public void CompareTo_ShouldThrowArgumentException_WhenPassedValueIsNotValid()
        {
            var versionMocked = new Mock<IVersion>();
            var otherMocked = new Mock<IPackage>();
            otherMocked.Setup(x => x.Name).Returns("Other Name");

            var package = new Package("UnitTesting", versionMocked.Object);
            Assert.Throws<ArgumentException>(() => package.CompareTo(otherMocked.Object));
        }

        [Test]
        public void CompareTo_ShouldCheck_IfPassedPackageIsHigherVersion()
        {
            var versionMocked = new Mock<IVersion>();
            var otherMocked = new Mock<IPackage>();
            otherMocked.Setup(x => x.Name).Returns("Unit Testing");
            otherMocked.Setup(x => x.Version.VersionType).Returns(VersionType.alpha);
            otherMocked.Setup(x => x.Version.Major).Returns(20);
            otherMocked.Setup(x => x.Version.Minor).Returns(20);
            otherMocked.Setup(x => x.Version.Patch).Returns(20);

            var package = new Package("Unit Testing", versionMocked.Object);

            var result = package.CompareTo(otherMocked.Object);

            Assert.AreEqual(-1, result);
        }

        [Test]
        public void CompareTo_ShouldCheck_IfPassedPackageIsLowerVersion()
        {
            var versionMocked = new Mock<IVersion>();
            var otherMocked = new Mock<IPackage>();

            otherMocked.Setup(x => x.Name).Returns("Unit Testing");
            otherMocked.Setup(x => x.Version.VersionType).Returns(VersionType.alpha);
            otherMocked.Setup(x => x.Version.Major).Returns(2);
            otherMocked.Setup(x => x.Version.Minor).Returns(2);
            otherMocked.Setup(x => x.Version.Patch).Returns(2);

            versionMocked.Setup(x => x.VersionType).Returns(VersionType.beta);
            versionMocked.Setup(x => x.Major).Returns(3);
            versionMocked.Setup(x => x.Minor).Returns(3);
            versionMocked.Setup(x => x.Patch).Returns(3);

            var package = new Package("Unit Testing", versionMocked.Object);

            var result = package.CompareTo(otherMocked.Object);

            Assert.AreEqual(1, result);
        }
        [Test]
        public void CompareTo_ShouldCheck_IfPassedPackageIsTheSameVersion()
        {
            var versionMocked = new Mock<IVersion>();
            var otherMocked = new Mock<IPackage>();

            otherMocked.Setup(x => x.Name).Returns("Unit Testing");
            otherMocked.Setup(x => x.Version.VersionType).Returns(VersionType.alpha);
            otherMocked.Setup(x => x.Version.Major).Returns(2);
            otherMocked.Setup(x => x.Version.Minor).Returns(2);
            otherMocked.Setup(x => x.Version.Patch).Returns(2);

            versionMocked.Setup(x => x.VersionType).Returns(VersionType.alpha);
            versionMocked.Setup(x => x.Major).Returns(2);
            versionMocked.Setup(x => x.Minor).Returns(2);
            versionMocked.Setup(x => x.Patch).Returns(2);

            var package = new Package("Unit Testing", versionMocked.Object);

            var result = package.CompareTo(otherMocked.Object);

            Assert.AreEqual(0, result);
        }


    }
}
