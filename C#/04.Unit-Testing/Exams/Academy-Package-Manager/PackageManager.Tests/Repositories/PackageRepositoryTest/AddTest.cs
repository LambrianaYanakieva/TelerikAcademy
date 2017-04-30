namespace PackageManager.Tests.Repositories.PackageRepositoryTest
{
    using Extended;
    using Info.Contracts;
    using Moq;
    using NUnit.Framework;
    using PackageManager.Models.Contracts;
    using PackageManager.Repositories;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class AddTest
    {             
        [Test]
        public void ShouldThrow_ArgumentNullException_WhenThePassedPackageIsInvalid()
        {
            
            var loggerMocked = new Mock<ILogger>();
            var packagesMocked = new Mock<ICollection<IPackage>>();
            var packageMocked = new Mock<IPackage>();

            var packageRepository = new PackageRepository(loggerMocked.Object,
                packagesMocked.Object );

            Assert.Throws<ArgumentNullException>(() => packageRepository.Add(null));          
        }

        [Test]
        public void Add_ShouldUpdate()
        {
            var loggerMocked = new Mock<ILogger>();
            var packageMocked = new Mock<IPackage>();
            var packages = new List<IPackage>() { packageMocked.Object };

            packageMocked.Setup(
                m => m.CompareTo(It.IsAny<IPackage>())).Returns(1);
           
            var packageRepository = new PackageRepositoryExtended(loggerMocked.Object,
                packages);

            Assert.Throws<MyCustomExeption_Shtoto_Si_MoGa_Update_Da_Se_Znae>(
                ()=>packageRepository.Add(packageMocked.Object));
        }

    }
}
