using Moq;
using NUnit.Framework;
using PackageManager.Core;
using PackageManager.Core.Contracts;
using PackageManager.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Tests.Core.PackageInstallerTest
{
    [TestFixture]
    public class PerformOperationTests
    {
        [Test]
        public void PerformOperation_ShouldCallDownload2timesAndRemove1time()
        {
            var downloadMocked = new Mock<IDownloader>();
            var projectMocked = new Mock<IProject>();
            var packageMocked = new Mock<IPackage>();

            projectMocked.Setup(
                m => m.PackageRepository.GetAll()).Returns(
                new List<IPackage>() { packageMocked.Object});

            packageMocked.Setup(
                m => m.Dependencies).Returns(new List<IPackage>() { });

            var installer = new PackageInstaller(downloadMocked.Object,
                projectMocked.Object);

            downloadMocked.Verify(
                m => m.Remove(It.IsAny<string>()),
                Times.Exactly(1));

            downloadMocked.Verify(
                m => m.Download(It.IsAny<string>()),
                Times.Exactly(2));

    }

        [Test]
        public void PerformOperation_ShouldCallDownloadAndRemoveMultiplieByEachPackage()
        {
            var downloadMocked = new Mock<IDownloader>();
            var projectMocked = new Mock<IProject>();
            var packageMocked = new Mock<IPackage>();
            var otherPackage = new Mock<IPackage>();

            otherPackage.Setup(
                m => m.Dependencies).Returns(new List<IPackage>());

            projectMocked.Setup(
                m => m.PackageRepository.GetAll()).Returns(
                new List<IPackage>() { packageMocked.Object });

            packageMocked.Setup(
                m => m.Dependencies).Returns(new List<IPackage>() {otherPackage.Object });

            var installer = new PackageInstaller(downloadMocked.Object,
                projectMocked.Object);


            downloadMocked.Verify(
                m => m.Remove(It.IsAny<string>()),
                Times.Exactly(2));

            downloadMocked.Verify(
                m => m.Download(It.IsAny<string>()),
                Times.Exactly(4));
        }
    }
}
