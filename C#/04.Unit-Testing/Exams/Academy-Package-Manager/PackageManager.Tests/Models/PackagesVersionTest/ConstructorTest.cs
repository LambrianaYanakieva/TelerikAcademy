namespace PackageManager.Tests.Models
{
    using Enums;
    using NUnit.Framework;
    using PackageManager.Models;
    using System;

    [TestFixture]
    public class ConstructorTest
    {
        [Test]
        public void Constructor_ShouldSetTheAppropriatePassedValueOfMajor()
        {
            //ASSIGN & ACT
            var packageVersion = new PackageVersion(6, 3, 4, VersionType.alpha);

            //ASSERT
            Assert.AreEqual(6, packageVersion.Major);
            
        }

        [Test]
        public void Constructor_ShouldSetTheAppropriatePassedValueOfMinior()
        {
            //ASSIGN & ACT
            var packageVersion = new PackageVersion(6, 3, 4, VersionType.alpha);
            //ASSERT
            Assert.AreEqual(3, packageVersion.Minor);

        }

        [Test]
        public void Constructor_ShouldSetTheAppropriatePassedValueOfPatch()
        {
            //ASSIGN & ACT
            var packageVersion = new PackageVersion(6, 3, 4, VersionType.alpha);
            //ASSERT
            Assert.AreEqual(4, packageVersion.Patch);
            
        }

        [Test]
        public void Constructor_ShouldSetTheAppropriatePassedValueOfVersionType()
        {
            //ASSIGN & ACT
            var packageVersion = new PackageVersion(6, 3, 4, VersionType.alpha);
            //ASSERT
            Assert.AreEqual(VersionType.alpha, packageVersion.VersionType);
            
        }

    }
}
