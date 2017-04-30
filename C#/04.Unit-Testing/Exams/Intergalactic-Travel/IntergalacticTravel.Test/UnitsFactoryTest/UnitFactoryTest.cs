namespace IntergalacticTravel.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using IntergalacticTravel;
    using Exceptions;

    [TestClass]
    public class UnitFactoryTest
    {
        [TestMethod]
        public void GeTUnit_ShouldReturnNeProcyonUnit_WhenAValidCorrespondingCommandIsPassed()
        {
            //ASSERT
            var factory = new UnitsFactory();

            //ACT
            var unit = factory.GetUnit("create unit Procyon Gosho 1");

            Assert.IsInstanceOfType(unit, typeof(Procyon));

        }

        [TestMethod]
        public void GeTUnit_ShouldReturnNeLuytenUnit_WhenAValidCorrespondingCommandIsPassed()
        {
            //ASSERT
            var factory = new UnitsFactory();

            //ACT
            var unit = factory.GetUnit("create unit Luyten Pesho 2");
            //ASSERT
            Assert.IsInstanceOfType(unit, typeof(Luyten));

        }

        [TestMethod]
        public void GeTUnit_ShouldReturnNeLacailleUnit_WhenAValidCorrespondingCommandIsPassed()
        {
            //ASSIGN
            var factory = new UnitsFactory();

            //ACT
            var unit = factory.GetUnit("create unit Lacaille Tosho 3");
            //ASSERT
            Assert.IsInstanceOfType(unit, typeof(Lacaille));

        }

        [TestMethod]
        public void GetUnit_ShouldThrowInvalidUnitCreationCommandException_WhenTheCommandPassedIsNotInTheValidFormat()
        {
            var factory = new UnitsFactory();
            Assert.ThrowsException<InvalidUnitCreationCommandException>(() => factory.GetUnit("asdfghjkl"));
        }
    }
}


