namespace PackageManager.Tests.Core.PackageInstallerTest
{
    using Enums;
    using Moq;
    using NUnit.Framework;
    using PackageManager.Core;
    using PackageManager.Core.Contracts;
    using PackageManager.Models.Contracts;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class ConstructorTest
    {
        [Test]
        public void ShouldCall_RestoringPackagesWhenTheObjectIsConstructed()
        {
            var downloaderMocked = new Mock<IDownloader>();
            var projectMocked = new Mock<IProject>();

            projectMocked.Setup(
                m => m.PackageRepository.GetAll()).Returns(new List<IPackage>());

            var packageInstaller = new PackageInstaller(
                downloaderMocked.Object, 
                projectMocked.Object);          
        }
    }
}
