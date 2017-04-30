namespace PackageManager.Tests.Models.ProjectTest
{
    using NUnit.Framework;
    using PackageManager.Models;
    using System;

    [TestFixture]
    public class PropertiesTest
    {
        [Test]
        public void Property_ShouldCorrectlyAssignName_WhenPassedValueIsInValidFormat()
        {
            //ASSIGN & ACT
            var project = new Project("Project X", "Burgas");
            //ASSERT
            Assert.AreEqual("Project X", project.Name);
        }
        [Test]
        public void Property_ShouldCorrectlyAssignLocation_WhenPassedValueIsInValidFormat()
        {

            //ASSIGN & ACT
            var project = new Project("Project X", "Burgas");
            //ASSERT
            Assert.AreEqual("Burgas", project.Location);
        }
    }
}
