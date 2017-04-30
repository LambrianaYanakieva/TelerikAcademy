namespace ArmyOfCreatures.Test.BattleManagerTest
{
    using Extended;
    using Logic;
    using Logic.Battles;
    using Logic.Creatures;
    using Moq;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class AddCreaturesTest
    {
        [Test]
        public void AddCreaturesShouldThrowArgumentNullException_WhenIdentifierIsNull()
        {
            var creaturesFactoryMocked = new Mock<ICreaturesFactory>();
            var loggerMocked = new Mock<ILogger>();

            var battleManager = new BattleManagerWithThreeArmies(creaturesFactoryMocked.Object, loggerMocked.Object);

            Assert.Throws<ArgumentNullException>(() => battleManager.AddCreatures(null, 3));

        }
        //TO DO WITH FIXTURE
        [Test]
        public void AddCreatures_ShouldCallCreteCreatureFromFactory()
        {
            var creaturesFactoryMocked = new Mock<ICreaturesFactory>();
            var loggerMocked = new Mock<ILogger>();

            var battleManager = new BattleManagerWithThreeArmies(
                creaturesFactoryMocked.Object, 
                loggerMocked.Object);

            creaturesFactoryMocked.Setup(x => x.CreateCreature(It.IsAny<string>())).Returns(new Angel());

            battleManager.AddCreatures(CreatureIdentifier.CreatureIdentifierFromString("Angel(1)"), 1);

            creaturesFactoryMocked.Verify(x => 
            x.CreateCreature(It.IsAny<string>()), Times.Exactly(1));

        }
        //TO DO WITH FIXTURE
        [Test]
        public void AddCreatures_ShouldCallWriteLineFromLogger()
        {
            var creaturesFactoryMocked = new Mock<ICreaturesFactory>();
            var loggerMocked = new Mock<ILogger>();

            var battleManager = new BattleManagerWithThreeArmies(
                creaturesFactoryMocked.Object,
                loggerMocked.Object);

            creaturesFactoryMocked.Setup(x => x.CreateCreature(It.IsAny<string>())).Returns(new Angel());

            battleManager.AddCreatures(CreatureIdentifier.CreatureIdentifierFromString("Angel(1)"), 1);

            loggerMocked.Verify(x =>
            x.WriteLine(It.IsAny<string>()), Times.Exactly(1));
        }
        [Test]
        public void AddingCreatureToArmy3_ShouldThrowArgumentException_IfNotExisting()
        {
            var creaturesfactoryMocked = new Mock<ICreaturesFactory>();
            var loggerMocked = new Mock<ILogger>();

            creaturesfactoryMocked.Setup(x =>
            x.CreateCreature("Angel")).Returns(new Angel());

            var battleManager = new BattleManager(
                creaturesfactoryMocked.Object,
                loggerMocked.Object);


            Assert.Throws<ArgumentException>(() =>
            battleManager.AddCreatures(
            CreatureIdentifier.CreatureIdentifierFromString("Angel(3)"), 3));
        }
    }
}
