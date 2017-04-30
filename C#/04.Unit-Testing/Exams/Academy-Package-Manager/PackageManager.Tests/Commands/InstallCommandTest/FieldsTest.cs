namespace PackageManager.Tests.Commands.InstallCommandTest
{

    using Moq;
    using NUnit.Framework;
    using PackageManager.Commands;
    using PackageManager.Core.Contracts;
    using PackageManager.Models.Contracts;
    using System;

    [TestFixture]
    public class FieldsTest
    {
        
        [Test]
        public void FieldInstaller_ShouldBeCorrectlyAssign_WhenPassedValueIsValid()
        {
            var installerMocked = new Mock<IInstaller<IPackage>>();
            var packageMocked = new Mock<IPackage>();

            var installCommand = new InstallCommand(
                installerMocked.Object,
                packageMocked.Object);

            Assert.IsInstanceOf(typeof(IInstaller<IPackage>), installCommand.Installer);
        }

        [Test]
        public void FieldPackage_ShouldBeCorrectlyAssign_WhenPassedValueIsValid()
        {
            var installerMocked = new Mock<IInstaller<IPackage>>();
            var packageMocked = new Mock<IPackage>();

            var installCommand = new InstallCommand(
                installerMocked.Object,
                packageMocked.Object);

            Assert.IsInstanceOf(typeof(IPackage), installCommand.Package);
        }
    }
}
