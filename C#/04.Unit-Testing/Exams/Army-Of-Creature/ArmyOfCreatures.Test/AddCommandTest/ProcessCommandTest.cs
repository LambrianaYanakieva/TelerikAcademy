namespace ArmyOfCreatures.Test.AddCommandTest
{
    using Console.Commands;
    using Logic.Battles;
    using Moq;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ProcessCommandTest
    {
        [Test]
        public void ProcessCommand_ShouldThrowArgumentNullException_WhenTheIBattleManagerIsNull()
        {
            //ASSIGN
            var addCommand = new AddCommand();

            string[] arguments = { "argument" };
            //ACT & ASSERT
            Assert.Throws<ArgumentNullException>(() =>
            addCommand.ProcessCommand(null, arguments));
        }

        [Test]
        public void ProcessCommand_ShouldThrowArgumentNullException_WhenTheArgumentsIsNull()
        {
            //ASSIGN
            var addCommand = new AddCommand();

            var battleManagerMocked = new Mock<IBattleManager>();
            //ACT & ASSERT
            Assert.Throws<ArgumentNullException>(() =>
            addCommand.ProcessCommand(battleManagerMocked.Object, null));
        }

        [Test]
        public void ProcessCommand_ShouldThrowArgumentException_WhenTheNumberOfParamsIsInvalid()
        {
            //ASSIGN
            var addCommand = new AddCommand();

            var battleManagerMocked = new Mock<IBattleManager>();
            string[] arguments = { "argument" };

            //ACT & ASSERT
            Assert.Throws<ArgumentException>(() =>
            addCommand.ProcessCommand(battleManagerMocked.Object, arguments));
        }

        [Test]
        public void ProcessCommandShouldCallIBattleManagerAddCreatures_WhenTheCommandIsParsedSuccessfully()
        {
            //ASSIGN
            var addCommand = new AddCommand();

            var battleManagerMocked = new Mock<IBattleManager>();
            string[] arguments = { "1", "Angel(1)" };

            //ACT
            addCommand.ProcessCommand(battleManagerMocked.Object, arguments);

            //ASSERT
            battleManagerMocked.Verify(x => 
            x.AddCreatures(It.IsAny<CreatureIdentifier>(), It.IsAny<int>()));
        }
    }
}
