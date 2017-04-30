namespace PackageManager.Tests.Commands.InstallCommandTest
{

    using Enums;
    using Moq;
    using NUnit.Framework;
    using PackageManager.Commands;
    using PackageManager.Core.Contracts;
    using PackageManager.Models.Contracts;
    using System;

    [TestFixture]
    public class PropertiesTest
    {
        [Test]
        public void Property_ShouldCorrectlySetOperation_WhenThePassedValueIsValid()
        {
            var installerMocked = new Mock<IInstaller<IPackage>>();
            var packageMocked = new Mock<IPackage>();

            var installCommand = new InstallCommand(
                installerMocked.Object,
                packageMocked.Object);

            Assert.AreEqual(InstallerOperation.Install, installCommand.Installer.Operation);
        }
    }
}
