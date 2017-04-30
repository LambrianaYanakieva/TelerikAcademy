namespace ArmyOfCreatures.Test.CreaturesInBattleTest
{
    using Logic.Battles;
    using Logic.Creatures;
    using Moq;
    using NUnit.Framework;
    using Ploeh.AutoFixture;
    using Ploeh.AutoFixture.Kernel;
    using System;

    [TestFixture]
    public class DealDamageTest
    {
        [Test]
        public void DealDamageWithNullDefender_ShouldThrowArgumentNullException()
        {
            //ASSIGN
            var fixture = new Fixture();

            fixture.Customizations.Add(
                new TypeRelay(
                    typeof(Creature),
                    typeof(Angel)));

            //fixture.Customize<Angel>(c => c.With(x => x.Attack, 30));

            var creature = fixture.Create<Creature>();

            var creaturesInBattle = new CreaturesInBattle(creature, 1);
            //ACT & ASSERT
            Assert.Throws<ArgumentNullException>(() =>
            creaturesInBattle.DealDamage(null));
        }

        [Test]
        public void DealDamageShouldReturnExpectedResult()
        {
            //ASSIGN
            var creature = new Angel();
            var creaturesInBattle = new CreaturesInBattle(creature, 1);
            var defenderMocked = new Mock<ICreaturesInBattle>();

            defenderMocked.Setup(x => x.Creature).Returns(new Devil());
            //ACT
            creaturesInBattle.DealDamage(defenderMocked.Object);
            //ASSERT
            defenderMocked.VerifySet(x => x.TotalHitPoints = It.IsAny<int>());
        }
    }
}
