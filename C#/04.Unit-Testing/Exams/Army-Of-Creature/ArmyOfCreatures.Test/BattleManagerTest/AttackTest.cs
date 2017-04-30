namespace ArmyOfCreatures.Test.BattleManagerTest
{
    using Extended;
    using Extended.Creatures;
    using Logic;
    using Logic.Battles;
    using Logic.Creatures;
    using Moq;
    using NUnit.Framework;
    using Ploeh.AutoFixture;
    using System;

    [TestFixture]
    public class AttackTest
    {
        [Test]
        public void AttackingWithNullIdentifier_ShouldThrowArgumentNullException()
        {
            var creaturesfactoryMocked = new Mock<ICreaturesFactory>();
            var loggerMocked = new Mock<ILogger>();

            var battleManager = new BattleManagerWithThreeArmies(
                creaturesfactoryMocked.Object,
                loggerMocked.Object);

            Assert.Throws<ArgumentNullException>(() =>
            battleManager.Attack(null,
            CreatureIdentifier.CreatureIdentifierFromString(It.IsAny<string>())));
        }

        [Test]
        public void AttackingWithNullUnit_ShouldThrowArgumentException()
        {
            var creaturesfactoryMocked = new Mock<ICreaturesFactory>();
            var loggerMocked = new Mock<ILogger>();

            var battleManager = new BattleManagerWithThreeArmies(
                creaturesfactoryMocked.Object,
                loggerMocked.Object);

            Assert.Throws<ArgumentException>(() => battleManager.Attack(
                CreatureIdentifier.CreatureIdentifierFromString("Angel(1)"),
                CreatureIdentifier.CreatureIdentifierFromString("WolfRider(1)")));
        }

        [Test]
        public void AttackingSuccessful_ShouldCallWriteLineFromLoggerExactly4Times()
        {
            var creaturesfactoryMocked = new Mock<ICreaturesFactory>();
            var loggerMocked = new Mock<ILogger>();

            var battleManager = new BattleManagerWithThreeArmies(
                creaturesfactoryMocked.Object,
                loggerMocked.Object);

            var attackerMocked = new Mock<ICreaturesInBattle>();
            attackerMocked.Setup(x => x.Creature).Returns(new Angel());
            battleManager.GetFirstArmyCreatures.Add(attackerMocked.Object);

            var defenderMocked = new Mock<ICreaturesInBattle>();
            defenderMocked.Setup(x => x.Creature).Returns(new WolfRaider());
            battleManager.GetSecondArmyCreatures.Add(defenderMocked.Object);

            battleManager.Attack(
                CreatureIdentifier.CreatureIdentifierFromString("Angel(1)"),
                CreatureIdentifier.CreatureIdentifierFromString("WolfRaider(2)"));

            loggerMocked.Verify(x => x.WriteLine(It.IsAny<string>()), Times.Exactly(4));

        }
        //TO DO!
        [Test]
        public void AttackingWithTwoBehemoths_ShouldReturnRightResult()
        {
            var creaturesfactoryMocked = new Mock<ICreaturesFactory>();
            var loggerMocked = new Mock<ILogger>();

            var battleManager = new BattleManagerWithThreeArmies(
                creaturesfactoryMocked.Object,
                loggerMocked.Object);

            var fixture = new Fixture();

            var attackerBehemoth = fixture.Create<Behemoth>();
            var defenderBehemoth = fixture.Create<Behemoth>();

            var attackerMocked = new Mock<ICreaturesInBattle>();
            attackerMocked.Setup(x => x.Creature).Returns(attackerBehemoth);
            attackerMocked.Setup(x => x.Count).Returns(2);
            battleManager.GetSecondArmyCreatures.Add(attackerMocked.Object);

            var defenderMocked = new Mock<ICreaturesInBattle>();
            defenderMocked.SetupSet(x => x.TotalHitPoints = It.IsAny<int>());
            defenderMocked.Setup(x => x.Creature).Returns(defenderBehemoth);
            defenderMocked.Setup(x => x.Count).Returns(1);
            battleManager.GetFirstArmyCreatures.Add(defenderMocked.Object);

            battleManager.Attack(
                CreatureIdentifier.CreatureIdentifierFromString("Behemoth(2)"),
                CreatureIdentifier.CreatureIdentifierFromString("Behemoth(1)"));

            defenderMocked.VerifySet(x => x.TotalHitPoints = It.IsAny<int>(), Times.Exactly(0));
        }

        [Test]
        public void Attacking_WithTwoBehemoths_ShouldReturnTheRightResult()
        {
            var creaturesFactMocked = new Mock<ICreaturesFactory>();
            var loggerMocked = new Mock<ILogger>();

            creaturesFactMocked.Setup(
                m => m.CreateCreature("Behemoth")).
                Returns(new Behemoth());

            var battleManager = new BattleManager(creaturesFactMocked.Object,
                loggerMocked.Object);

            var creatureIdentifierAttacker = CreatureIdentifier.CreatureIdentifierFromString("Behemoth(1)");
            var creatureIdentifierDeffender = CreatureIdentifier.CreatureIdentifierFromString("Behemoth(2)");

            battleManager.AddCreatures(creatureIdentifierAttacker, 2);
            battleManager.AddCreatures(creatureIdentifierDeffender, 1);

            battleManager.Attack(creatureIdentifierAttacker, creatureIdentifierDeffender);
        }
    }
}
