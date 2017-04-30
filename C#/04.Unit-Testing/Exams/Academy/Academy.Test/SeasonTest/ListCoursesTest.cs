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

namespace Academy.Test.SeasonTest
{
    [TestFixture]
    public class ListCoursesTest
    {
        [Test]
        public void ListCourses_ShouldReturnAListOfCourses()
        {
            var season = new Season(2016, 2017, Initiative.SoftwareAcademy);

            var courseMocked = new Mock<ICourse>();

            courseMocked.Setup(
                m => m.ToString()).Returns("course");

            season.Courses.Add(courseMocked.Object);

            season.ListCourses();

            courseMocked.Verify(x => x.ToString(), Times.Exactly(1));
        }

        [Test]
        public void ShouldReturnMessageSayingThatThereAreNoCoursesInThisSeason()
        {
            var season = new Season(2016, 2017, Initiative.SoftwareAcademy);

            var result = season.ListCourses();

            Assert.AreEqual(result, "There are no courses in this season!");
        }
    }
}
