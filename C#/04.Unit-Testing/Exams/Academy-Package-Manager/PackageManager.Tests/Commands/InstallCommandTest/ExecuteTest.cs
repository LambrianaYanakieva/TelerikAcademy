namespace PackageManager.Tests.Commands.InstallCommandTest
{

    using Moq;
    using NUnit.Framework;
    using PackageManager.Commands;
    using PackageManager.Core.Contracts;
    using PackageManager.Models.Contracts;
    using System;

    [TestFixture]
    public class ExecuteTest
    {
        [Test]
        public void Check_If_CallingThePerformOperationFromTheInstaller()
        {
            var installerMocked = new Mock<IInstaller<IPackage>>();
            var packageMocked = new Mock<IPackage>();

            var installCommand = new InstallCommand(
                installerMocked.Object,
                packageMocked.Object);

            installCommand.Execute();

            installerMocked.Verify(x => 
            x.PerformOperation(It.IsAny<IPackage>()), Times.Exactly(1));

        }
    }
}
