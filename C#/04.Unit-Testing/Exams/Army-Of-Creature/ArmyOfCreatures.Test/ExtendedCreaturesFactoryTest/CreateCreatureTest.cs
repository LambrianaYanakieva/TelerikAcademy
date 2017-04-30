namespace ArmyOfCreatures.Test.ExtendedCreaturesFactoryTest
{
    using Extended;
    using Logic.Creatures;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CreateCreatureTest
    {
        [Test]
        public void CreateCreature_ShouldThrowArgumentExceptionWithMessageThatContainsTheStringInvalidcreatureType_WhenAStringIsInvalid()
        {
            var creaturesFactory = new ExtendedCreaturesFactory();

           Assert.Throws<ArgumentException>(() => 
           creaturesFactory.CreateCreature("Lambriana"));
 
        }

        [Test]
        public void CreateCreature_ShouldReturnTheCorrespondingCreatureTypeBasedOnTheStringThatIsPassedAsAMethodArgument()
        {
            var creaturesFactory = new ExtendedCreaturesFactory();

            var creature = creaturesFactory.CreateCreature("Angel");

            Assert.IsInstanceOf(typeof(Angel), creature);
        }
    }
}
