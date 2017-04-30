namespace Academy.Test.AddStudentToSeasonCommandTest
{
    using Commands.Adding;
    using Core.Contracts;
    using Models.Contracts;
    using Moq;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ConstructorTest
    {
        [Test]
        public void ShouldThrow_ArgumentNullException_WhenAPassedFactoryIsNull()
        {
            var engineMocked = new Mock<IEngine>();

            Assert.Throws<ArgumentNullException>(() => 
            new AddStudentToSeasonCommand(null, engineMocked.Object));
        }

        [Test]
        public void ShouldThrow_ArgumentNullException_WhenAPassedEngineIsNull()
        {
            var factoryMocked = new Mock<IAcademyFactory>();

            Assert.Throws<ArgumentNullException>(() =>
            new AddStudentToSeasonCommand(factoryMocked.Object, null));
            
        }

        [Test]
        public void Should_CorrectlyAssignPassedFactory()
        {
            var factoryMocked = new Mock<IAcademyFactory>();
            var engineMocked = new Mock<IEngine>();

            var addStudent = new AddStudentToSeasonCommand(
                factoryMocked.Object, 
                engineMocked.Object);

            Assert.IsInstanceOf(typeof(IAcademyFactory), addStudent.Factory);
        }

        [Test]
        public void Should_CorrectlyAssignPassedEngine()
        {
            var factoryMocked = new Mock<IAcademyFactory>();
            var engineMocked = new Mock<IEngine>();

            var addStudent = new AddStudentToSeasonCommand(
                factoryMocked.Object,
                engineMocked.Object);

            Assert.IsInstanceOf(typeof(IEngine), addStudent.Engine);
        }
    }
}
