namespace ArmyOfCreatures.Test.DoubleDefenseWhenDefendingTest
{
    using Logic.Battles;
    using Logic.Specialties;
    using Moq;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ApplyWhenDefending
    {
        [Test]
        public void ApplyWhenDefendingShouldThrowArgumentNullException_WhenTheDefenderIsNull()
        {
            //ASSIGN
            var doubleDefenseWhenDefending = new DoubleDefenseWhenDefending(2);

            var attackerMocked = new Mock<ICreaturesInBattle>();
            //ACT & ASSERT
            Assert.Throws<ArgumentNullException>(() =>
            doubleDefenseWhenDefending.ApplyWhenDefending(null, attackerMocked.Object));
        }

        [Test]
        public void ApplyWhenDefendingShouldThrowArgumentNullException_WhenTheAttackerIsNull()
        {
            //ASSIGN
            var doubleDefenseWhenDefending = new DoubleDefenseWhenDefending(2);

            var defenderMocked = new Mock<ICreaturesInBattle>();
            //ACT & ASSERT
            Assert.Throws<ArgumentNullException>(() =>
            doubleDefenseWhenDefending.ApplyWhenDefending(defenderMocked.Object, null));
        }

        [Test]
        public void ApplyWhenDefending_ShouldReturnAndNotChangeTheCurrentDefenseProperty_WhenTheEffectIsExpired()
        {
            //ASSIGN
            var doubleDefenseWhenDefending = new DoubleDefenseWhenDefending(1);

            var attackerMocked = new Mock<ICreaturesInBattle>();
            var defenderMocked = new Mock<ICreaturesInBattle>();

            //ACT
            doubleDefenseWhenDefending.ApplyWhenDefending(defenderMocked.Object, attackerMocked.Object);
            doubleDefenseWhenDefending.ApplyWhenDefending(defenderMocked.Object, attackerMocked.Object);

            //ASSERT
            defenderMocked.VerifySet(x => x.CurrentDefense = It.IsAny<int>(), Times.Exactly(1));
        }

        [Test]
        public void ApplyWhenDefending_ShouldMultiplyBy2TheCurrentDefense_WhenTheEffectHasNotExpired()
        {
            //ASSIGN
            var doubleDefenseWhenDefending = new DoubleDefenseWhenDefending(2);

            var attackerMocked = new Mock<ICreaturesInBattle>();
            var defenderMocked = new Mock<ICreaturesInBattle>();

            //ACT
            doubleDefenseWhenDefending.ApplyWhenDefending(defenderMocked.Object, attackerMocked.Object);
            doubleDefenseWhenDefending.ApplyWhenDefending(defenderMocked.Object, attackerMocked.Object);
            doubleDefenseWhenDefending.ApplyWhenDefending(defenderMocked.Object, attackerMocked.Object);

            //ASSERT
            defenderMocked.VerifySet(x => x.CurrentDefense = It.IsAny<int>(), Times.Exactly(2));
        }
    }
}
