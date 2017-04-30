namespace Academy.Test.AcademyFactoryTest
{
    using Core.Factories;
    using Models.Utils.LectureResources;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CreateLectureResourceTest
    {
        [Test]
        public void ShouldThrow_ArgumentException_WhenPassedTypeIsInvalid()
        {
            var academyFactory = AcademyFactory.Instance;

            Assert.Throws<ArgumentException>(() => 
            academyFactory.CreateLectureResource(
            null, "Unit Testing", "www.unittesting.com"));
        }

        [Test]
        public void CreateLectureResource_ShouldReturn_CorrectInstances()
        {
            var academyFactory = AcademyFactory.Instance;

            var videoResource = academyFactory.CreateLectureResource(
            "video", "Unit Testing", "www.unittesting.com");

            Assert.IsInstanceOf(typeof(VideoResource), videoResource);
        }

        [Test]
        public void CreateLectureResource_ShouldReturn_WithCorrectlyAssignedName()
        {
            var academyFactory = AcademyFactory.Instance;

            var videoResource = academyFactory.CreateLectureResource(
            "video", "Unit Testing", "www.unittesting.com");

            Assert.AreEqual("Unit Testing", videoResource.Name);
            
        }

        [Test]
        public void CreateLectureResource_ShouldReturn_WithCorrectlyAssignedURL()
        {
            var academyFactory = AcademyFactory.Instance;

            var videoResource = academyFactory.CreateLectureResource(
            "video", "Unit Testing", "www.unittesting.com");

           
            Assert.AreEqual("www.unittesting.com", videoResource.Url);
        }
    }
}
