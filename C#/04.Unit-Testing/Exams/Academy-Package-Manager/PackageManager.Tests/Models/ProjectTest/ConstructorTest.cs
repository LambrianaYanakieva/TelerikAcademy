namespace PackageManager.Tests.Models.ProjectTest
{
    using Moq;
    using NUnit.Framework;
    using PackageManager.Models;
    using PackageManager.Models.Contracts;
    using PackageManager.Repositories;
    using PackageManager.Repositories.Contracts;

    [TestFixture]
    public class ConstructorTest
    {
        [Test]
        public void Constructor_ShouldSetPackageRepositoryCorrectly_WhenParameterAreOptional()
        {
            //ASSIGN & ACT
            var project = new Project("Project X", "Burgas");
            //ASSERT
            Assert.IsInstanceOf(typeof(PackageRepository), project.PackageRepository);
        }

        [Test]
        public void Constructor_ShouldSetPackageRepositoryCorrectly_WhenParameterArePassed()
        {
            //ASSIGN
            var packagesMocked = new Mock<IRepository<IPackage>>();
            //ACT
            var project = new Project(
                "Project X",
                "Burgas",
                packagesMocked.Object);
            //ASSERT
            Assert.IsInstanceOf(typeof(IRepository<IPackage>), project.PackageRepository);
        }
    }
}
