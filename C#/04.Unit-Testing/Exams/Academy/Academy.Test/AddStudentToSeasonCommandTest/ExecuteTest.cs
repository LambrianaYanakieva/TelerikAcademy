namespace Academy.Test.AddStudentToSeasonCommandTest
{
    using Commands.Adding;
    using Core.Contracts;
    using Models.Contracts;
    using Moq;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class ExecuteTest
    {
        [Test]
        public void ShouldThrow_ArgumentException_WhenThePassedStudentIsAlreadyAPartOfThatSeason()
        {
            var factoryMocked = new Mock<IAcademyFactory>();
            var engineMocked = new Mock<IEngine>();
            var student = new Mock<IStudent>();
            var season = new Mock<ISeason>();

            student.Setup(
              m => m.Username).Returns("LambrianaTriaaDaSpie");

            season.Setup(
                m => m.Students).Returns(new List<IStudent> { student.Object });

            var listOfSeasons = new List<ISeason> { season.Object };

            engineMocked.Setup(
               m => m.Seasons).Returns(listOfSeasons);

            engineMocked.Setup(
                m => m.Students).Returns(new List<IStudent> { student.Object});
            
            var addStudentIstance = new AddStudentToSeasonCommand(
                factoryMocked.Object, engineMocked.Object);

         
            //Act And Assert
            var ex = Assert.Throws<ArgumentException>
               (() =>
              addStudentIstance.Execute(new List<string>
              {  "LambrianaTriaaDaSpie","0" }));

            StringAssert.Contains("LambrianaTriaaDaSpie", ex.Message);
            StringAssert.Contains("0", ex.Message);
        }
    }
}
