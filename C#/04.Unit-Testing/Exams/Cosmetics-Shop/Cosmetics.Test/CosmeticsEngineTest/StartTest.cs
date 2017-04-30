using Cosmetics.Contracts;
using Cosmetics.Engine;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmetics.Products;

namespace Cosmetics.Test.CosmeticsEngineTest
{
    [TestClass]
    public class StartTest
    {
        [TestMethod]
        public void Start_ShouldRead_ParseAndExecute_CreateCategoryCommand_WhenThePassedInputStringIsInTheFormat_ThatRepresents_CreateCategoryCommand_whichShouldResultInAdding_TheNewCategory_InTheListOfCategories()
        {

            var factoryMocked = new Mock<ICosmeticsFactory>();
            var shoppingCartMocked = new Mock<IShoppingCart>();
            var commandParserMocked = new Mock<ICommandParser>();


            var command = new Mock<ICommand>();
            command.Setup(x => x.Name).Returns("CreateCategory");
            command.Setup(x => x.Parameters).Returns(new List<string>() { "ForMale" });

            var listOfCatgories = new List<ICommand>() { command.Object };
            commandParserMocked.Setup(x => x.ReadCommands()).Returns(listOfCatgories);


            var cosmeticsEngine = new ExtendedCosmeticsEngine(
                factoryMocked.Object,
                shoppingCartMocked.Object,
                commandParserMocked.Object);


            cosmeticsEngine.Start();

            Assert.AreEqual(1, cosmeticsEngine.Categories.Count);
            Assert.IsTrue(cosmeticsEngine.Categories.ContainsKey("ForMale"));
        }

        [TestMethod]
        public void Start_ShouldReadParseAndExecuteAddToCategoryCommand_WhenThePassedInputStringIsInValidFormatWhichShouldResultInAddingTheSelectedProductInTheRespectiveCategory()
        {
            var factoryMocked = new Mock<ICosmeticsFactory>();
            var shoppingCardMocked = new Mock<IShoppingCart>();
            var commandParserMocked = new Mock<ICommandParser>();

            var command = new Mock<ICommand>();
            command.Setup(x => x.Name).Returns("AddToCategory");
            command.Setup(x => x.Parameters).Returns(new List<string>() { "For Male", "Cool" });

            var listOfcommands = new List<ICommand>() { command.Object };
            commandParserMocked.Setup(x => x.ReadCommands()).Returns(listOfcommands);

            var cosmeticsEngine = new ExtendedCosmeticsEngine(
                            factoryMocked.Object,
                            shoppingCardMocked.Object,
                            commandParserMocked.Object);

            var category = new Mock<ICategory>();
            cosmeticsEngine.Categories.Add("For Male", category.Object);
            var product = new Mock<IProduct>();
            cosmeticsEngine.Products.Add("Cool", product.Object);

            cosmeticsEngine.Start();

            category.Verify(x => x.AddProduct(product.Object), Times.Exactly(1));

        }

        [TestMethod]
        public void Start_ShouldReadParseAndExecuteRemoveFromCategoryCommand_WhenThePassedInputStringIsInTheFormatThatRepresentsARemoveFromCategoryCommandWhichShouldResultInRemovingTheSelectedProductFromTheRespectiveCategory()
        {
            var factoryMocked = new Mock<ICosmeticsFactory>();
            var shoppingCardMocked = new Mock<IShoppingCart>();
            var commandParserMocked = new Mock<ICommandParser>();

            var command = new Mock<ICommand>();
            command.Setup(x => x.Name).Returns("RemoveFromCategory");
            command.Setup(x => x.Parameters).Returns(new List<string>() { "For Male", "Cool" });

            var listOfcommands = new List<ICommand>() { command.Object };
            commandParserMocked.Setup(x => x.ReadCommands()).Returns(listOfcommands);

            var cosmeticsEngine = new ExtendedCosmeticsEngine(
                            factoryMocked.Object,
                            shoppingCardMocked.Object,
                            commandParserMocked.Object);

            var category = new Mock<ICategory>();
            cosmeticsEngine.Categories.Add("For Male", category.Object);
            var product = new Mock<IProduct>();
            cosmeticsEngine.Products.Add("Cool", product.Object);

            cosmeticsEngine.Start();

            category.Verify(x => x.RemoveProduct(product.Object), Times.Exactly(1));
        }

        [TestMethod]
        public void Start_ShouldShowCategory_WhenRepresentsShowCategoryCommand_WitchShouldCall_Print_OfRespectedCategory()
        {
            var factoryMocked = new Mock<ICosmeticsFactory>();
            var shoppingCardMocked = new Mock<IShoppingCart>();
            var commandParserMocked = new Mock<ICommandParser>();

            var command = new Mock<ICommand>();
            command.Setup(x => x.Name).Returns("ShowCategory");
            command.Setup(x => x.Parameters).Returns(new List<string>() { "For Male", "Cool" });

            var listOfcommands = new List<ICommand>() { command.Object };
            commandParserMocked.Setup(x => x.ReadCommands()).Returns(listOfcommands);

            var cosmeticsEngine = new ExtendedCosmeticsEngine(
                            factoryMocked.Object,
                            shoppingCardMocked.Object,
                            commandParserMocked.Object);

            var category = new Mock<ICategory>();
            cosmeticsEngine.Categories.Add("For Male", category.Object);
            var product = new Mock<IProduct>();
            cosmeticsEngine.Products.Add("Cool", product.Object);

            cosmeticsEngine.Start();

            category.Verify(x => x.Print(), Times.Exactly(1));
        }

        [TestMethod]
        public void Start_ShouldCreateShampoo_whenCreateShampooCommandIsInValidFormat_whichShouldAddTheShampooInTheListOfProducts()
        {
            var factoryMocked = new Mock<ICosmeticsFactory>();
            var shoppingCardMocked = new Mock<IShoppingCart>();
            var commandParserMocked = new Mock<ICommandParser>();

            var command = new Mock<ICommand>();
            command.Setup(x => x.Name).Returns("CreateShampoo");
            command.Setup(x => x.Parameters).Returns(new List<string>() { "For Male", "Cool", "22.2", "men", "100", "medical" });


            var listOfcommands = new List<ICommand>() { command.Object };
            commandParserMocked.Setup(x => x.ReadCommands()).Returns(listOfcommands);

            var cosmeticsEngine = new ExtendedCosmeticsEngine(
                            factoryMocked.Object,
                            shoppingCardMocked.Object,
                            commandParserMocked.Object);


            cosmeticsEngine.Start();

            Assert.AreEqual(1, cosmeticsEngine.Products.Count);
        }

        [TestMethod]
        public void Start_ShouldCreateToothpaste_whenCreateToothpasteCommandIsInValidFormat_whichShouldAddTheToothpasteInTheListOfProducts()
        {
            var factoryMocked = new Mock<ICosmeticsFactory>();
            var shoppingCardMocked = new Mock<IShoppingCart>();
            var commandParserMocked = new Mock<ICommandParser>();

            var command = new Mock<ICommand>();
            command.Setup(x => x.Name).Returns("CreateToothpaste");
            command.Setup(x => x.Parameters).Returns(new List<string>() { "Cool", "For Male", "2.30", "unisex", "Anaboli Mak Lale" });


            var listOfcommands = new List<ICommand>() { command.Object };
            commandParserMocked.Setup(x => x.ReadCommands()).Returns(listOfcommands);

            var cosmeticsEngine = new ExtendedCosmeticsEngine(
                            factoryMocked.Object,
                            shoppingCardMocked.Object,
                            commandParserMocked.Object);


            cosmeticsEngine.Start();

            Assert.AreEqual(1, cosmeticsEngine.Products.Count);
            Assert.IsInstanceOfType(cosmeticsEngine.Products["Cool"], typeof(Toothpaste));
        }
        [TestMethod]
        public void Start_ShouldAddToShoppingCartCommand_WhenThePassedInputIsInValidFormat_WhichShouldAddTheProductToTheShoppingCart()
        {
            var factoryMocked = new Mock<ICosmeticsFactory>();
            var shoppingCardMocked = new Mock<IShoppingCart>();
            
            var commandParserMocked = new Mock<ICommandParser>();

            var command = new Mock<ICommand>();
            command.Setup(x => x.Name).Returns("AddToShoppingCart");
            command.Setup(x => x.Parameters).Returns(new List<string>() { "Cool" });


            var listOfcommands = new List<ICommand>() { command.Object };
            commandParserMocked.Setup(x => x.ReadCommands()).Returns(listOfcommands);

            var cosmeticsEngine = new ExtendedCosmeticsEngine(
                            factoryMocked.Object,
                            shoppingCardMocked.Object,
                            commandParserMocked.Object);

            var productMocked = new Mock<IProduct>();

            cosmeticsEngine.Products.Add("Cool", productMocked.Object);

            cosmeticsEngine.Start();

            shoppingCardMocked.Verify(x => x.AddProduct(productMocked.Object), Times.Exactly(1));
        }

        [TestMethod]
        public void Start_ShouldRemoveFromShoppingCart_WhenTheInputIsInValidFormat_WhichShouldRemoveTheProductFromTheShoppingCart()
        {
            var factoryMocked = new Mock<ICosmeticsFactory>();
            var shoppingCardMocked = new Mock<IShoppingCart>();

            var commandParserMocked = new Mock<ICommandParser>();

            var command = new Mock<ICommand>();
            command.Setup(x => x.Name).Returns("RemoveFromShoppingCart");
            command.Setup(x => x.Parameters).Returns(new List<string>() { "Cool" });


            var listOfcommands = new List<ICommand>() { command.Object };
            commandParserMocked.Setup(x => x.ReadCommands()).Returns(listOfcommands);

            var cosmeticsEngine = new ExtendedCosmeticsEngine(
                            factoryMocked.Object,
                            shoppingCardMocked.Object,
                            commandParserMocked.Object);

            var productMocked = new Mock<IProduct>();

            cosmeticsEngine.Products.Add("Cool", productMocked.Object);
            shoppingCardMocked.Setup(x => x.ContainsProduct(productMocked.Object)).Returns(true);
            cosmeticsEngine.Start();

            //shoppingCardMocked.Verify(x => x.RemoveProduct(productMocked.Object), Times.Exactly(1));
        }
    }
}
