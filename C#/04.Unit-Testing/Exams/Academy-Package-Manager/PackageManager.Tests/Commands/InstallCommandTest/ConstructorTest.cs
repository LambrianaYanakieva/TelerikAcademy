namespace PackageManager.Tests.Commands.InstallCommandTest
{
    using Moq;
    using NUnit.Framework;
    using PackageManager.Commands;
    using PackageManager.Core.Contracts;
    using PackageManager.Models.Contracts;

    [TestFixture]
    public class ConstructorTest
    {
        //public InstallCommand(IInstaller<IPackage> installer, IPackage package)
        [Test]
        public void Constructor_ShouldCorrectlySetInstallerProperty_WhenPassedValueIsValid()
        {
            var installerMocked = new Mock<IInstaller<IPackage>>();
            var packageMocked = new Mock<IPackage>();

            var installCommand = new InstallCommand(
                installerMocked.Object, 
                packageMocked.Object);

            Assert.IsNotNull(installCommand.Installer);
            Assert.AreEqual(installerMocked.Object, installCommand.Installer);
        }

        [Test]
        public void Constructor_ShouldCorrectlySetPackageProperty_WhenPassedValueIsValid()
        {
            var installerMocked = new Mock<IInstaller<IPackage>>();
            var packageMocked = new Mock<IPackage>();

            var installCommand = new InstallCommand(
                installerMocked.Object,
                packageMocked.Object);

            Assert.IsNotNull(installCommand.Package);
        }
    }
}
