namespace ArmyOfCreatures.Test.BattleManagerWithThreeArmiesTest
{
    using Extended;
    using Logic;
    using Moq;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ConstructorTest
    {
        [Test]
        public void Constructor_ShouldCallBaseConstructorAndInstantiateTheObjectWithAllPropertiesSetUp()
        {

            var creaturesFactoryMocked = new Mock<ICreaturesFactory>();
            var loggerMocked = new Mock<ILogger>();

            var battleManager = new BattleManagerWithThreeArmies(creaturesFactoryMocked.Object, loggerMocked.Object);

            Assert.IsNotNull(battleManager.GetThirdArmyCreatures);
            Assert.IsNotNull(battleManager.GetFirstArmyCreatures);
            Assert.IsNotNull(battleManager.GetSecondArmyCreatures);
        }
    }
}
