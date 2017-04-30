namespace PackageManager.Tests.Models
{
    using Enums;
    using NUnit.Framework;
    using PackageManager.Models;
    using System;

    [TestFixture]
    public class PropertiesTest
    {
        [Test]
        public void PropertyOfMajor_ShouldCorrectlyAssignPassedValue()
        {
            //ASSIGN & ACT
            var packageVersion = new PackageVersion(2, 3, 4, VersionType.beta);
            //ASSERT
            Assert.AreEqual(2, packageVersion.Major);
        }

        [Test]
        public void PropertyOfMajor_ShouldThrowArgumentException_WhenThePassedValueIsNotCorrectlyAssign()
        {
            //ASSIGN & ACT & ASSERT
            Assert.Throws<ArgumentException>(() => new PackageVersion(-2, 3, 4, VersionType.alpha));
        }

        [Test]
        public void PropertyOfMinor_ShouldCorrectlyAssignPassedValue()
        {
            //ASSIGN & ACT
            var packageVersion = new PackageVersion(2, 3, 4, VersionType.final);
            //ASSERT
            Assert.AreEqual(3, packageVersion.Minor);
        }

        [Test]
        public void PropertyOfMinor_ShouldThrowArgumentException_WhenThePassedValueIsNotCorrectlyAssign()
        {
            //ASSIGN & ACT & ASSERT
            Assert.Throws<ArgumentException>(() => new PackageVersion(2, -3, 4, VersionType.alpha));
        }
        [Test]
        public void PropertyOfPatch_ShouldCorrectlyAssignPassedValue()
        {
            //ASSIGN & ACT
            var packageVersion = new PackageVersion(2, 3, 4, VersionType.beta);
            //ASSERT
            Assert.AreEqual(4, packageVersion.Patch);
        }

        [Test]
        public void PropertyOfPatch_ShouldThrowArgumentException_WhenThePassedValueIsNotCorrectlyAssign()
        {
            //ASSIGN & ACT & ASSERT
            Assert.Throws<ArgumentException>(() => new PackageVersion(2, 3, -4, VersionType.alpha));
        }

        [Test]
        public void PropertyOfVersionType_ShouldCorrectlyAssignPassedValue()
        {
            //ASSIGN & ACT
            var packageVersion = new PackageVersion(2, 3, 4, VersionType.beta);
            //ASSERT
            Assert.AreEqual(VersionType.beta, packageVersion.VersionType);
        }

        [Test]
        public void PropertyOfVersionType_ShouldThrowArgumentException_WhenThePassedValueIsNotCorrectlyAssign()
        {
            //ASSIGN & ACT & ASSERT
            Assert.Throws<ArgumentException>(() => new PackageVersion(2, 3, 4, (VersionType)8));
        }
    }
}
