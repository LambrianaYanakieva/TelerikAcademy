using Academy.Models;
using Academy.Models.Contracts;
using Academy.Models.Enums;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Test
{

    [TestFixture]
    public class ToString
    {
        [Test]
        public void Should_ReturnAListOfStudentsAndTrainers()
        {
            //ASSIGN
            var season = new Season(2016, 2017, Initiative.SoftwareAcademy);

            var trainerMocked = new Mock<ITrainer>();
            var studentMocked = new Mock<IStudent>();

            season.Trainers.Add(trainerMocked.Object);
            season.Students.Add(studentMocked.Object);
            //ACT
            season.ListUsers();

            trainerMocked.Verify(x => x.ToString(), Times.Exactly(1));
            studentMocked.Verify(x => x.ToString(), Times.Exactly(1));

        }

        [Test]
        public void ListUser_ShouldReturnMessageSayingThatThereAreNoUsersInThisSeason()
        {
            var season = new Season(2016, 2017, Initiative.SoftwareAcademy);

            var result = season.ListUsers();

            StringAssert.Contains("are no users", result);
            
        }
    }
}



