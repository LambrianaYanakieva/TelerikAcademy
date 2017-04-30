namespace ArmyOfCreatures.Test.CreatureIdentifierTest
{
    using Logic.Battles;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CallCreatureIdentifierTest
    {
        [Test]
        public void CallWithNullValueToParseShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            CreatureIdentifier.CreatureIdentifierFromString(null));
        }

        [Test]
        public void CallWithInvalidArmyNumber_ShouldThrowFormatExcepition()
        {
            Assert.Throws<FormatException>(() =>
            CreatureIdentifier.CreatureIdentifierFromString("Angel()"));
        }

        [Test]
        public void CallWithInvalidString_ShouldThrowIndexOutOfRangeException()
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            CreatureIdentifier.CreatureIdentifierFromString("Angel"));
        }

        [Test]
        public void ToString_ShouldOutputExpectedResult()
        {
            var result = CreatureIdentifier.CreatureIdentifierFromString("Angel(2)");

            StringAssert.Contains("Angel", result.ToString());
        }
    }
}
