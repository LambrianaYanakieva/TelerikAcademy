
namespace PackageManager.Tests.Repositories.PackageRepositoryTest
{
    using Moq;
    using NUnit.Framework;
    using PackageManager.Models.Contracts;
    using PackageManager.Repositories;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class DeleteTest
    {
        [Test]
        public void ShouldThrow_ArgumentNullException_WhenThePassedPackageIsInvalid()
        {
           
            var loggerMocked = new Mock<Info.Contracts.ILogger>();
            var packagesMocked = new Mock<ICollection<IPackage>>();
            var packageMocked = new Mock<IPackage>();

            var packageRepository = new PackageRepository(loggerMocked.Object,
                packagesMocked.Object);

            Assert.Throws<ArgumentNullException>(() => packageRepository.Delete(null));
            
        }
        
    }
}
