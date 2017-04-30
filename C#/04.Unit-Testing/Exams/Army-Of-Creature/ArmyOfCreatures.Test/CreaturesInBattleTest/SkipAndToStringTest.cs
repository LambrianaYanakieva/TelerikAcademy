namespace ArmyOfCreatures.Test.CreaturesInBattleTest
{
    using Logic.Battles;
    using Logic.Creatures;
    using NUnit.Framework;

    [TestFixture]
    public class SkipAndToStringTest
    {
        [Test]
        public void Skip_ShouldCallApplyOnSkipTheCountOfTheSpecialtiesTimes()
        {
            var creature = new Angel();
            var creaturesInBattle = new CreaturesInBattle(creature, 1);

            creaturesInBattle.Skip();

            
        }

        [Test]
        public void ToString_ShouldOutputExpectedResult()
        {

        }
    }
}
