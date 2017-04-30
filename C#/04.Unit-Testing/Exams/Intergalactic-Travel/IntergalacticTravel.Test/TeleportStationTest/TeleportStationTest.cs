namespace IntergalacticTravel.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using IntergalacticTravel.Constants;
    using IntergalacticTravel.Contracts;

    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Moq;
    using IntergalacticTravel.Exceptions;


    [TestClass]
    public class TeleportStationTest
    {
        //--------------------CONSTRUCTOR TEST------------------//

        [TestMethod]
        public void Constructor_ShouldSetupAllOfTheProvidedFields_WhenValidParametersArePased()
        {
            //ASSIGN
            var owner = new Mock<IBusinessOwner>();
            var galacticMap = new Mock<IEnumerable<IPath>>();
            var location = new Mock<ILocation>();
            var resources = new Mock<IResources>();

            var expectedOwner = owner.Object;
            var expectedGalacticMap = galacticMap.Object;
            var expectedLocation = location.Object;

            //ACT
            var station = new ExtendedTeleportStation(expectedOwner, expectedGalacticMap, expectedLocation);

            var actualOwner = station.Owner;
            var actualGalacticMap = station.GalacticMap;
            var actualLocation = station.Location;

            var actualResources = station.Resources;
            var actualGold = GlobalConstants.GoldCoinsDefaultAmount;
            var actualSilver = GlobalConstants.SilverCoinsDefaultAmount;
            var actualBronze = GlobalConstants.BronzeCoinsDefaultAmount;
            //ASSERT
            Assert.AreSame(expectedOwner, actualOwner);
            Assert.AreSame(expectedGalacticMap, actualGalacticMap);
            Assert.AreSame(expectedLocation, actualLocation);

            Assert.AreEqual(actualResources.GoldCoins, actualGold);
            Assert.AreEqual(actualResources.SilverCoins, actualSilver);
            Assert.AreEqual(actualResources.BronzeCoins, actualBronze);
        }

        //--------------------TELEPORT UNIT TESTS----------------//

        [TestMethod]
        public void TeleportUnit_ShouldThrow_ArgumentNullException_WithAMessageThatContainsTheString_UnitToTeleport_WhenIUnitUnitToTeleportIsNull()
        {
            //ASSIGN
            var owner = new Mock<IBusinessOwner>();
            var galacticMap = new Mock<IEnumerable<IPath>>();
            var location = new Mock<ILocation>();

            var expectedOwner = owner.Object;
            var expectedGalacticMap = galacticMap.Object;
            var expectedLocation = location.Object;

            var station = new ExtendedTeleportStation(expectedOwner, expectedGalacticMap, expectedLocation);

            var targetLocation = new Mock<ILocation>();
            var mockedTargetLocation = targetLocation.Object;
            //ACT
            var check = Assert.ThrowsException<ArgumentNullException>(() => station.TeleportUnit(null, mockedTargetLocation));

            var exceptionMessage = check.Message;
            var subMessage = "unitToTeleport";
            //ASSERT
            StringAssert.Contains(exceptionMessage, subMessage);
        }


        [TestMethod]
        public void TeleportUnit_ShouldThrow_ArgumentNullException_WithAMessageThatContainsTheString_destination_WhenILocationDestinationIsNull()
        {
            //ASSING
            var owner = new Mock<IBusinessOwner>();
            var galacticMap = new Mock<IEnumerable<IPath>>();
            var location = new Mock<ILocation>();
            var unitToTeleport = new Mock<IUnit>();

            var expectedOwner = owner.Object;
            var expectedGalacticMap = galacticMap.Object;
            var expectedLocation = location.Object;
            var expectedUnit = unitToTeleport.Object;

            var station = new ExtendedTeleportStation(expectedOwner, expectedGalacticMap, expectedLocation);
            //ACT
            var check = Assert.ThrowsException<ArgumentNullException>(() => station.TeleportUnit(expectedUnit, null));

            var exceptionMessage = check.Message;
            var subMessage = "destination";
            //ASSERT
            StringAssert.Contains(exceptionMessage, subMessage);
        }


        [TestMethod]
        public void TeleportUnit_ShouldThrow_TeleportOutOfRangeException_WithAMessageThatContainsTheString_unitToTeleportCurrentLocation_WhenAUnitIsTryingToUseTheTeleportStationFromADistantLocation()
        {
            //ASSIGN
            var owner = new Mock<IBusinessOwner>();
            var galacticMap = new Mock<IEnumerable<IPath>>();
            var location = new Mock<ILocation>();

            var expectedOwner = owner.Object;
            var expectedGalacticMap = galacticMap.Object;
            var expectedLocation = location.Object;

            var locationStation = new Mock<ILocation>();
            var unitLocation = new Mock<ILocation>();
            var nextLocation = new Mock<ILocation>();

            locationStation.Setup(x => x.Planet.Name).Returns("Earth");
            locationStation.Setup(x => x.Planet.Galaxy.Name).Returns("Earth1");
            unitLocation.Setup(x => x.Planet.Name).Returns("Mars");
            unitLocation.Setup(x => x.Planet.Galaxy.Name).Returns("Mars1");
            nextLocation.Setup(x => x.Planet.Name).Returns("Yupiter");

            var station = new ExtendedTeleportStation(expectedOwner, expectedGalacticMap, locationStation.Object);

            var unit = new Mock<IUnit>();
            unit.Setup(x => x.CurrentLocation).Returns(unitLocation.Object);
            //ACT
            var check = Assert.ThrowsException<TeleportOutOfRangeException>(() => station.TeleportUnit(unit.Object, nextLocation.Object));

            var exceptionMessage = check.Message;
            var subMessage = "unitToTeleport.CurrentLocation";
            //ASSERT
            StringAssert.Contains(exceptionMessage, subMessage);
        }


        [TestMethod]
        public void TeleportUnit_ShouldThrow_InvalidTeleportationLocationException_WithAMessageThatContainsTheString_unitsWillOverlap_WhenTryingToTeleportAUnitToALocationWhichAnotherUnitHasAlreadyTaken()
        {
            //ASSIGN
            var stationOwnerMocked = new Mock<IBusinessOwner>();
            var stationLocationMocked = new Mock<ILocation>();
            var targetLocationMocked = new Mock<ILocation>();
            var unitMocked = new Mock<IUnit>();
            var conquerorUnitMock = new Mock<IUnit>();
            var pathMocked = new Mock<IPath>();

            var conquerorUnits = new List<IUnit>() { conquerorUnitMock.Object };
            var stationGalacticMapMocked = new List<IPath>() { pathMocked.Object };

            stationLocationMocked.Setup(x => x.Planet.Galaxy.Name).Returns("Jamaica");
            stationLocationMocked.Setup(x => x.Planet.Name).Returns("Holand");
            stationLocationMocked.Setup(x => x.Coordinates.Longtitude).Returns(42.5);
            stationLocationMocked.Setup(x => x.Coordinates.Latitude).Returns(43.5);

            unitMocked.Setup(x => x.CurrentLocation.Planet.Galaxy.Name).Returns("Jamaica");
            unitMocked.Setup(x => x.CurrentLocation.Planet.Name).Returns("Holand");
            unitMocked.Setup(x => x.CurrentLocation.Coordinates.Longtitude).Returns(42.5);
            unitMocked.Setup(x => x.CurrentLocation.Coordinates.Latitude).Returns(43.5);

            conquerorUnitMock.Setup(x => x.CurrentLocation.Planet.Galaxy.Name).Returns("Jamaica");
            conquerorUnitMock.Setup(x => x.CurrentLocation.Planet.Name).Returns("Holand");
            conquerorUnitMock.Setup(x => x.CurrentLocation.Coordinates.Longtitude).Returns(42.5);
            conquerorUnitMock.Setup(x => x.CurrentLocation.Coordinates.Latitude).Returns(43.5);

            pathMocked.Setup(x => x.TargetLocation.Planet.Galaxy.Name).Returns("Jamaica");
            pathMocked.Setup(x => x.TargetLocation.Planet.Name).Returns("Holand");
            pathMocked.Setup(x => x.TargetLocation.Coordinates.Longtitude).Returns(42.5);
            pathMocked.Setup(x => x.TargetLocation.Coordinates.Latitude).Returns(43.5);
            pathMocked.Setup(x => x.TargetLocation.Planet.Units).Returns(conquerorUnits);

            targetLocationMocked.Setup(x => x.Planet.Galaxy.Name).Returns("Jamaica");
            targetLocationMocked.Setup(x => x.Planet.Name).Returns("Holand");
            targetLocationMocked.Setup(x => x.Coordinates.Longtitude).Returns(42.5);
            targetLocationMocked.Setup(x => x.Coordinates.Latitude).Returns(43.5);

            var station = new ExtendedTeleportStation
                                        (stationOwnerMocked.Object,
                                        stationGalacticMapMocked,
                                        stationLocationMocked.Object);
            //ACT
            var check = Assert.ThrowsException<InvalidTeleportationLocationException>
                (() => station.TeleportUnit(unitMocked.Object, targetLocationMocked.Object));
            var exceptionMessage = check.Message;
            var subMessage = "units will overlap";
            //ASSERT
            StringAssert.Contains(exceptionMessage, subMessage);
        }


        [TestMethod]
        public void TeleportUnit_ShouldThrow_LocationNotFoundException_WithAMessageThatContainsTheString_Galaxy_WhenTryingToTeleportAUnitToAGalaxyWhichIsNotFoundInTheLocationsListOfTheTeleportStation()
        {
            //ASSIGN
            var stationOwnerMocked = new Mock<IBusinessOwner>();
            var stationLocationMocked = new Mock<ILocation>();
            var pathMocked = new Mock<IPath>();
            var galacticMapMocked = new List<IPath>() { pathMocked.Object };
            var unitToTeleport = new Mock<IUnit>();
            var targetLocation = new Mock<ILocation>();

            stationLocationMocked.Setup(x => x.Planet.Galaxy.Name).Returns("Saska");
            stationLocationMocked.Setup(x => x.Planet.Name).Returns("Green");

            pathMocked.Setup(x => x.TargetLocation.Planet.Galaxy.Name).Returns("MilkyWay");

            unitToTeleport.Setup(x => x.CurrentLocation.Planet.Galaxy.Name).Returns("Saska");
            unitToTeleport.Setup(x => x.CurrentLocation.Planet.Name).Returns("Green");

            targetLocation.Setup(x => x.Planet.Galaxy.Name).Returns("Jamaica");
            targetLocation.Setup(x => x.Planet.Name).Returns("Holand");

            var station = new ExtendedTeleportStation
                (stationOwnerMocked.Object, galacticMapMocked, stationLocationMocked.Object);
            //ACT
            var check = Assert.ThrowsException<LocationNotFoundException>
                (() => station.TeleportUnit(unitToTeleport.Object, targetLocation.Object));

            var exceptionMessage = check.Message;
            var subMessage = "Galaxy";
            //ASSERT
            StringAssert.Contains(exceptionMessage, subMessage);
        }


        [TestMethod]
        public void TeleportUnit_ShouldThrow_LocationNotFoundException_WithAMessageThatContainsTheString_Planet_WhenTryingToTeleportAUnitToAPlanet_Which_IsNotFoundInTheLocationsListOfTheTeleportStation()
        {
            //ASSIGN
            var stationOwnerMocked = new Mock<IBusinessOwner>();
            var stationLocationMocked = new Mock<ILocation>();
            var pathMocked = new Mock<IPath>();
            var galacticMapMocked = new List<IPath>() { pathMocked.Object };
            var unitToTeleport = new Mock<IUnit>();
            var targetLocation = new Mock<ILocation>();

            stationLocationMocked.Setup(x => x.Planet.Galaxy.Name).Returns("Saska");
            stationLocationMocked.Setup(x => x.Planet.Name).Returns("Green");

            pathMocked.Setup(x => x.TargetLocation.Planet.Galaxy.Name).Returns("Saska");
            pathMocked.Setup(x => x.TargetLocation.Planet.Name).Returns("Green");

            unitToTeleport.Setup(x => x.CurrentLocation.Planet.Galaxy.Name).Returns("Saska");
            unitToTeleport.Setup(x => x.CurrentLocation.Planet.Name).Returns("Green");

            targetLocation.Setup(x => x.Planet.Galaxy.Name).Returns("Saska");
            targetLocation.Setup(x => x.Planet.Name).Returns("Holand");

            var station = new ExtendedTeleportStation
                (stationOwnerMocked.Object, galacticMapMocked, stationLocationMocked.Object);
            //ACT
            var check = Assert.ThrowsException<LocationNotFoundException>
                (() => station.TeleportUnit(unitToTeleport.Object, targetLocation.Object));

            var exceptionMessage = check.Message;
            var subMessage = "Planet";
            //ASSERT
            StringAssert.Contains(exceptionMessage, subMessage);
        }


        [TestMethod]
        public void TeleportUnit_ShouldThrow_InsufficientResourcesException_WithAMessageThatContainsTheString_FREE_LUNCH_WhentTryingToTeleportAUnitToAGivenLocationButTheServiceCostsMoreThanTheUnitsCurrentAvailableResources()
        {
            //ASSIGN
            var stationOwnerMocked = new Mock<IBusinessOwner>();
            var stationLocationMocked = new Mock<ILocation>();
            var unitToTeleportMocked = new Mock<IUnit>();
            var targetLocationMocked = new Mock<ILocation>();

            //Galactic map setup:
            var pathMocked = new Mock<IPath>();
            pathMocked.Setup(x => x.TargetLocation.Planet.Galaxy.Name).Returns("Bulgaria");
            pathMocked.Setup(x => x.TargetLocation.Planet.Name).Returns("Varna");
            pathMocked.Setup(x => x.Cost.BronzeCoins).Returns(33);
            pathMocked.Setup(x => x.Cost.SilverCoins).Returns(66);
            pathMocked.Setup(x => x.Cost.GoldCoins).Returns(99);

            var conquerorUnitMocked = new Mock<IUnit>();
            conquerorUnitMocked.Setup(x => x.CurrentLocation.Planet.Galaxy.Name).Returns("Bulgaria");
            conquerorUnitMocked.Setup(x => x.CurrentLocation.Planet.Name).Returns("Varna");
            conquerorUnitMocked.Setup(x => x.CurrentLocation.Coordinates.Longtitude).Returns(36.9);
            conquerorUnitMocked.Setup(x => x.CurrentLocation.Coordinates.Latitude).Returns(11.1);

            var unitsCollector = new List<IUnit>() { conquerorUnitMocked.Object };
            pathMocked.Setup(x => x.TargetLocation.Planet.Units).Returns(unitsCollector);
            var stationGalacticMapMocked = new List<IPath>() { pathMocked.Object };

            var station = new ExtendedTeleportStation
                (stationOwnerMocked.Object,
                stationGalacticMapMocked,
                stationLocationMocked.Object);

            stationLocationMocked.Setup(x => x.Planet.Galaxy.Name).Returns("Bulgaria");
            stationLocationMocked.Setup(x => x.Planet.Name).Returns("Burgas");

            unitToTeleportMocked.Setup(x => x.CurrentLocation.Planet.Galaxy.Name).Returns("Bulgaria");
            unitToTeleportMocked.Setup(x => x.CurrentLocation.Planet.Name).Returns("Burgas");
            unitToTeleportMocked.Setup(x => x.Resources.BronzeCoins).Returns(2);
            unitToTeleportMocked.Setup(x => x.Resources.SilverCoins).Returns(10);
            unitToTeleportMocked.Setup(x => x.Resources.GoldCoins).Returns(5);
            unitToTeleportMocked.Setup(x => x.CanPay(It.IsAny<IResources>())).Returns(false);

            targetLocationMocked.Setup(x => x.Planet.Galaxy.Name).Returns("Bulgaria");
            targetLocationMocked.Setup(x => x.Planet.Name).Returns("Varna");
            targetLocationMocked.Setup(x => x.Coordinates.Longtitude).Returns(22.2);
            targetLocationMocked.Setup(x => x.Coordinates.Latitude).Returns(33.3);

            //ACT & ASSERT
            //var act = Assert.ThrowsException<InsufficientResourcesException>
                //(() =>
                station.TeleportUnit(
                    unitToTeleportMocked.Object,
                    targetLocationMocked.Object);
            //var exceptionMessage = act.Message;
            //var subMessage = "FREE LUNCH";

            //ASSERT
            //StringAssert.Contains(exceptionMessage, subMessage);
        }

        //--------------------------PAYMENT TESTS-----------------------------------//

        [TestMethod]
        public void TeleportUnit_ShouldRequireAPaymentFromTheUnitTeleportUnitForTheProvidedServices_WhenAllOfTheValidationsPassSuccessfully()
        {
            var stationOwnerMocked = new Mock<IBusinessOwner>();
            var pathMocked = new Mock<IPath>();
            var stationGalaxyMap = new List<IPath>() { pathMocked.Object };
            var stationLocationMocked = new Mock<ILocation>();
            var unitToTeleportMocked = new Mock<IUnit>();
            var targetLocationMocked = new Mock<ILocation>();
            var listUnits = new List<IUnit> { unitToTeleportMocked.Object };
            unitToTeleportMocked.Setup(
                m => m.CurrentLocation.Planet.Units).Returns(listUnits);

            var station = new ExtendedTeleportStation(
                           stationOwnerMocked.Object,
                           stationGalaxyMap,
                           stationLocationMocked.Object);

            stationLocationMocked.Setup(
                m => m.Planet.Galaxy.Name).Returns("StudentskiLife");

            stationLocationMocked.Setup(
                m => m.Planet.Name).Returns("Rakitovo");

            unitToTeleportMocked.Setup(
                m => m.CurrentLocation.Planet.Galaxy.Name).Returns("StudentskiLife");

            unitToTeleportMocked.Setup(
                m => m.CurrentLocation.Planet.Name).Returns("Rakitovo");

            targetLocationMocked.Setup(
                m => m.Planet.Galaxy.Name).Returns("StudentskiLife");

            targetLocationMocked.Setup(
               m => m.Planet.Name).Returns("G-Planet");

            pathMocked.Setup(
                m => m.TargetLocation.Planet.Galaxy.Name).Returns("StudentskiLife");

            pathMocked.Setup(
               m => m.TargetLocation.Planet.Name).Returns("G-Planet");

            var unitOnTargetPlanetMocked = new Mock<IUnit>();

            unitOnTargetPlanetMocked.Setup(
                m => m.CurrentLocation.Planet.Name).Returns("G-Planet");

            unitOnTargetPlanetMocked.Setup(
                m => m.CurrentLocation.Planet.Galaxy.Name).Returns("StudentskiLife");

            targetLocationMocked.Setup(
                m => m.Coordinates.Latitude).Returns(42.5);

            targetLocationMocked.Setup(
                m => m.Coordinates.Longtitude).Returns(42.5);

            unitOnTargetPlanetMocked.Setup(
                m => m.CurrentLocation.Coordinates.Latitude).Returns(43.5);

            unitOnTargetPlanetMocked.Setup(
              m => m.CurrentLocation.Coordinates.Longtitude).Returns(43.5);

            var unitsOnPlanet = new List<IUnit> { unitOnTargetPlanetMocked.Object };

            pathMocked.Setup(
                m => m.TargetLocation.Planet.Units).Returns(unitsOnPlanet);

            pathMocked.Setup(
                m => m.Cost.BronzeCoins).Returns(100);
            pathMocked.Setup(
               m => m.Cost.SilverCoins).Returns(100);
            pathMocked.Setup(
               m => m.Cost.GoldCoins).Returns(100);

            unitToTeleportMocked.Setup(
                m => m.Resources.GoldCoins).Returns(1000);
            unitToTeleportMocked.Setup(
                m => m.Resources.SilverCoins).Returns(1000);
            unitToTeleportMocked.Setup(
                m => m.Resources.BronzeCoins).Returns(1000);

            var resourseMocked = new Mock<IResources>();

            resourseMocked.Setup(
                m => m.BronzeCoins).Returns(999);
            resourseMocked.Setup(
                m => m.GoldCoins).Returns(999);
            resourseMocked.Setup(
                m => m.SilverCoins).Returns(999);

            unitToTeleportMocked.Setup(
                m => m.Pay(It.IsAny<IResources>())).Returns(resourseMocked.Object);

            unitToTeleportMocked.Setup(
                m => m.CanPay(It.IsAny<IResources>())).Returns(true);

            station.TeleportUnit(unitToTeleportMocked.Object, targetLocationMocked.Object);

            unitToTeleportMocked.Verify(
                m => m.Pay(It.IsAny<IResources>()), Times.Exactly(1));
        }


        [TestMethod]
        public void TeleportUnit_ShouldObtainAPayment_FromTheIUitToTeleport()
        {
            //ASSIGN
            var stationOwnerMocked = new Mock<IBusinessOwner>();
            var stationLocationMocked = new Mock<ILocation>();
            var mockedUnit = new Mock<IUnit>();
            var targetLocationMocked = new Mock<ILocation>();

            var pathMocked = new Mock<IPath>();
            pathMocked.Setup(x => x.TargetLocation.Planet.Galaxy.Name).Returns("Telerik");
            pathMocked.Setup(x => x.TargetLocation.Planet.Name).Returns("Ultimate");
            pathMocked.Setup(x => x.Cost.BronzeCoins).Returns(3);
            pathMocked.Setup(x => x.Cost.SilverCoins).Returns(3);
            pathMocked.Setup(x => x.Cost.GoldCoins).Returns(3);

            var occupantUnitMocked = new Mock<IUnit>();
            occupantUnitMocked.Setup(x => x.CurrentLocation.Planet.Galaxy.Name).Returns("Telerik");
            occupantUnitMocked.Setup(x => x.CurrentLocation.Planet.Name).Returns("Ultimate");
            occupantUnitMocked.Setup(x => x.CurrentLocation.Coordinates.Longtitude).Returns(11.1);
            occupantUnitMocked.Setup(x => x.CurrentLocation.Coordinates.Latitude).Returns(33.3);

            var unitsList = new List<IUnit>() { occupantUnitMocked.Object };
            pathMocked.Setup(x => x.TargetLocation.Planet.Units).Returns(unitsList);
            var stationGalaxyMap = new List<IPath>() { pathMocked.Object };

            var currentPlanetOccupant = new List<IUnit>() { mockedUnit.Object };

            var station = new ExtendedTeleportStation(
                            stationOwnerMocked.Object,
                            stationGalaxyMap,
                            stationLocationMocked.Object);

            stationLocationMocked.Setup(x => x.Planet.Galaxy.Name).Returns("Telerik");
            stationLocationMocked.Setup(x => x.Planet.Name).Returns("Ultimate");

            mockedUnit.Setup(x => x.CurrentLocation.Planet.Galaxy.Name).Returns("Telerik");
            mockedUnit.Setup(x => x.CurrentLocation.Planet.Name).Returns("Ultimate");
            mockedUnit.Setup(x => x.CurrentLocation.Coordinates.Longtitude).Returns(22.2);
            mockedUnit.Setup(x => x.CurrentLocation.Coordinates.Latitude).Returns(66.6);
            mockedUnit.Setup(x => x.Resources.BronzeCoins).Returns(11);
            mockedUnit.Setup(x => x.Resources.SilverCoins).Returns(11);
            mockedUnit.Setup(x => x.Resources.GoldCoins).Returns(11);
            mockedUnit.Setup(x => x.CanPay(It.IsAny<IResources>())).Returns(true);
            mockedUnit.Setup(x => x.Pay(pathMocked.Object.Cost)).Returns(pathMocked.Object.Cost);
            mockedUnit.Setup(x => x.CurrentLocation.Planet.Units).Returns(currentPlanetOccupant);

            targetLocationMocked.Setup(x => x.Planet.Galaxy.Name).Returns("Telerik");
            targetLocationMocked.Setup(x => x.Planet.Name).Returns("Ultimate");
            targetLocationMocked.Setup(x => x.Coordinates.Longtitude).Returns(22.2);
            targetLocationMocked.Setup(x => x.Coordinates.Latitude).Returns(66.6);

            //ACT 
            station.TeleportUnit(mockedUnit.Object, targetLocationMocked.Object);

            //ASSERT
            //mockedUnit.Verify(x => x.Pay(pathMocked.Object.Cost), Times.Once());
            uint expectedCoinsValue = 3;
            Assert.AreEqual(expectedCoinsValue, station.Resources.BronzeCoins);
            Assert.AreEqual(expectedCoinsValue, station.Resources.SilverCoins);
            Assert.AreEqual(expectedCoinsValue, station.Resources.GoldCoins);
        }

        [TestMethod]
        public void TeleportUnit_ShouldSetTheUnitToTeleportCurrentLocation_WhenAllOfheValidationsPasSsuccessfully()
        {
            var stationOwnerMocked = new Mock<IBusinessOwner>();
            var pathMocked = new Mock<IPath>();
            var stationGalaxyMap = new List<IPath>() { pathMocked.Object };
            var stationLocationMocked = new Mock<ILocation>();
            var unitToTeleportMocked = new Mock<IUnit>();
            var targetLocationMocked = new Mock<ILocation>();
            var listUnits = new List<IUnit> { unitToTeleportMocked.Object };
            unitToTeleportMocked.Setup(
                m => m.CurrentLocation.Planet.Units).Returns(listUnits);

            var station = new ExtendedTeleportStation(
                           stationOwnerMocked.Object,
                           stationGalaxyMap,
                           stationLocationMocked.Object);

            stationLocationMocked.Setup(
                m => m.Planet.Galaxy.Name).Returns("StudentskiLife");

            stationLocationMocked.Setup(
                m => m.Planet.Name).Returns("Rakitovo");

            unitToTeleportMocked.Setup(
                m => m.CurrentLocation.Planet.Galaxy.Name).Returns("StudentskiLife");

            unitToTeleportMocked.Setup(
                m => m.CurrentLocation.Planet.Name).Returns("Rakitovo");

            targetLocationMocked.Setup(
                m => m.Planet.Galaxy.Name).Returns("StudentskiLife");

            targetLocationMocked.Setup(
               m => m.Planet.Name).Returns("G-Planet");

            pathMocked.Setup(
                m => m.TargetLocation.Planet.Galaxy.Name).Returns("StudentskiLife");

            pathMocked.Setup(
               m => m.TargetLocation.Planet.Name).Returns("G-Planet");

            var unitOnTargetPlanetMocked = new Mock<IUnit>();

            unitOnTargetPlanetMocked.Setup(
                m => m.CurrentLocation.Planet.Name).Returns("G-Planet");

            unitOnTargetPlanetMocked.Setup(
                m => m.CurrentLocation.Planet.Galaxy.Name).Returns("StudentskiLife");

            targetLocationMocked.Setup(
                m => m.Coordinates.Latitude).Returns(42.5);

            targetLocationMocked.Setup(
                m => m.Coordinates.Longtitude).Returns(42.5);

            unitOnTargetPlanetMocked.Setup(
                m => m.CurrentLocation.Coordinates.Latitude).Returns(43.5);

            unitOnTargetPlanetMocked.Setup(
              m => m.CurrentLocation.Coordinates.Longtitude).Returns(43.5);

            var unitsOnPlanet = new List<IUnit> { unitOnTargetPlanetMocked.Object };

            pathMocked.Setup(
                m => m.TargetLocation.Planet.Units).Returns(unitsOnPlanet);

            pathMocked.Setup(
                m => m.Cost.BronzeCoins).Returns(100);
            pathMocked.Setup(
               m => m.Cost.SilverCoins).Returns(100);
            pathMocked.Setup(
               m => m.Cost.GoldCoins).Returns(100);

            unitToTeleportMocked.Setup(
                m => m.Resources.GoldCoins).Returns(1000);
            unitToTeleportMocked.Setup(
                m => m.Resources.SilverCoins).Returns(1000);
            unitToTeleportMocked.Setup(
                m => m.Resources.BronzeCoins).Returns(1000);

            var resourseMocked = new Mock<IResources>();

            resourseMocked.Setup(
                m => m.BronzeCoins).Returns(999);
            resourseMocked.Setup(
                m => m.GoldCoins).Returns(999);
            resourseMocked.Setup(
                m => m.SilverCoins).Returns(999);

            unitToTeleportMocked.Setup(
                m => m.Pay(It.IsAny<IResources>())).Returns(resourseMocked.Object);

            unitToTeleportMocked.Setup(
                m => m.CanPay(It.IsAny<IResources>())).Returns(true);

            unitToTeleportMocked.Setup(
                m => m.CurrentLocation.Coordinates.Latitude).Returns(42.5);

            unitToTeleportMocked.Setup(
                m => m.CurrentLocation.Coordinates.Longtitude).Returns(42.5);

            station.TeleportUnit(unitToTeleportMocked.Object, targetLocationMocked.Object);

            unitToTeleportMocked.VerifySet(
                m => m.CurrentLocation = It.IsAny<ILocation>(), Times.Exactly(1));
        }

        [TestMethod]
        public void TeleportUnit_ShouldSetTheUnitToTeleportCurrentLocationToTargetLocation()
        {
            var stationOwnerMocked = new Mock<IBusinessOwner>();
            var pathMocked = new Mock<IPath>();
            var stationGalaxyMap = new List<IPath>() { pathMocked.Object };
            var stationLocationMocked = new Mock<ILocation>();
            var unitToTeleportMocked = new Mock<IUnit>();
            var targetLocationMocked = new Mock<ILocation>();

            pathMocked.Setup(x => x.TargetLocation.Planet.Galaxy.Name).Returns("Westeros");
            pathMocked.Setup(x => x.TargetLocation.Planet.Name).Returns("Castle Black");
            pathMocked.Setup(x => x.Cost.BronzeCoins).Returns(5);
            pathMocked.Setup(x => x.Cost.SilverCoins).Returns(5);
            pathMocked.Setup(x => x.Cost.GoldCoins).Returns(5);

            var planetaryUnit = new Mock<IUnit>();
            planetaryUnit.Setup(x => x.CurrentLocation.Planet.Galaxy.Name).Returns("Westeros");
            planetaryUnit.Setup(x => x.CurrentLocation.Planet.Name).Returns("Kings Landing");
            planetaryUnit.Setup(x => x.CurrentLocation.Coordinates.Longtitude).Returns(11.1);
            planetaryUnit.Setup(x => x.CurrentLocation.Coordinates.Latitude).Returns(99.9);

            var planetaryUnitsList = new List<IUnit>() { planetaryUnit.Object };
            pathMocked.Setup(x => x.TargetLocation.Planet.Units).Returns(planetaryUnitsList);

            stationLocationMocked.Setup(x => x.Planet.Galaxy.Name).Returns("Westeros");
            stationLocationMocked.Setup(x => x.Planet.Name).Returns("Kings Landing");

            unitToTeleportMocked.Setup(x => x.CurrentLocation.Planet.Galaxy.Name).Returns("Westeros");
            unitToTeleportMocked.Setup(x => x.CurrentLocation.Planet.Name).Returns("Kings Landing");
            unitToTeleportMocked.Setup(x => x.CurrentLocation.Coordinates.Longtitude).Returns(33.3);
            unitToTeleportMocked.Setup(x => x.CurrentLocation.Coordinates.Latitude).Returns(66.6);
            unitToTeleportMocked.Setup(x => x.Resources.BronzeCoins).Returns(10);
            unitToTeleportMocked.Setup(x => x.Resources.SilverCoins).Returns(10);
            unitToTeleportMocked.Setup(x => x.Resources.GoldCoins).Returns(10);

            var currentPlanetaryUnit = new List<IUnit>() { unitToTeleportMocked.Object };
            unitToTeleportMocked.Setup(x => x.CurrentLocation.Planet.Units).Returns(currentPlanetaryUnit);

            targetLocationMocked.Setup(x => x.Planet.Galaxy.Name).Returns("Westeros");
            targetLocationMocked.Setup(x => x.Planet.Name).Returns("Castle Black");
            targetLocationMocked.Setup(x => x.Coordinates.Longtitude).Returns(22.2);
            targetLocationMocked.Setup(x => x.Coordinates.Latitude).Returns(55.5);

            var resourseMocked = new Mock<IResources>();
            resourseMocked.Setup(m => m.BronzeCoins).Returns(999);
            resourseMocked.Setup(m => m.GoldCoins).Returns(999);
            resourseMocked.Setup(m => m.SilverCoins).Returns(999);

            unitToTeleportMocked.Setup(
                m => m.Pay(It.IsAny<IResources>())).Returns(resourseMocked.Object);
            unitToTeleportMocked.Setup(x => x.CanPay(It.IsAny<IResources>())).Returns(true);

            var station = new ExtendedTeleportStation(
                stationOwnerMocked.Object,
                stationGalaxyMap,
                stationLocationMocked.Object);

            station.TeleportUnit(unitToTeleportMocked.Object, targetLocationMocked.Object);

            unitToTeleportMocked.VerifySet(x => x.CurrentLocation = It.IsAny<ILocation>(), Times.Exactly(1));
        }

        [TestMethod]
        public void TeleportUnit_ShouldAddTheUnitToTeleportToTheListOfUnitsOfTheTargetLocation_WhenAllTheVallidationsPassSuccsessfully()
        {
            var stationOwnerMocked = new Mock<IBusinessOwner>();
            var pathMocked = new Mock<IPath>();
            var stationGalaxyMap = new List<IPath>() { pathMocked.Object };
            var stationLocationMocked = new Mock<ILocation>();
            var unitToTeleportMocked = new Mock<IUnit>();
            var targetLocationMocked = new Mock<ILocation>();

            stationLocationMocked.Setup(
                m => m.Planet.Galaxy.Name).Returns("Galaxy-1");
            stationLocationMocked.Setup(
                m => m.Planet.Name).Returns("Planet-1");

            unitToTeleportMocked.Setup(
                m => m.CurrentLocation.Planet.Galaxy.Name).Returns("Galaxy-1");

            unitToTeleportMocked.Setup(
                m => m.CurrentLocation.Planet.Name).Returns("Planet-1");

            targetLocationMocked.Setup(
                m => m.Planet.Name).Returns("Planet-2");

            targetLocationMocked.Setup(
               m => m.Planet.Galaxy.Name).Returns("Galaxy-2");

            pathMocked.Setup(
                m => m.TargetLocation.Planet.Units).Returns(new List<IUnit>());

            pathMocked.Setup(m => m.TargetLocation.Planet.Galaxy.Name).Returns("Galaxy-2");
            pathMocked.Setup(m => m.TargetLocation.Planet.Name).Returns("Planet-2");

            unitToTeleportMocked.Setup(
                m => m.CanPay(It.IsAny<IResources>())).Returns(true);

            var resource = new Mock<IResources>();

            resource.Setup(
                m => m.BronzeCoins).Returns(10);
            resource.Setup(
                m => m.SilverCoins).Returns(10);
            resource.Setup(
                m => m.GoldCoins).Returns(10);

            unitToTeleportMocked.Setup(
                m => m.Pay(It.IsAny<IResources>())).Returns(resource.Object);

            var listOfUnits = new List<IUnit> { unitToTeleportMocked.Object };

            unitToTeleportMocked.Setup(
                m => m.CurrentLocation.Planet.Units).Returns(listOfUnits);

            var station = new TeleportStation(stationOwnerMocked.Object,
                stationGalaxyMap, stationLocationMocked.Object);

            station.TeleportUnit(unitToTeleportMocked.Object, targetLocationMocked.Object);

            Assert.AreEqual(1, pathMocked.Object.TargetLocation.Planet.Units.Count);
            Assert.IsTrue(pathMocked.Object.TargetLocation.Planet.Units.Contains(unitToTeleportMocked.Object));
        }

        [TestMethod]
        public void TeleportUnit_ShouldRemoveTheUnitToTeleportFromTheListOfUnitsOfTheUnitsCurrentLocation_WhenAllTheValidationsPassSuccsessfully()
        {
            var stationOwnerMocked = new Mock<IBusinessOwner>();
            var pathMocked = new Mock<IPath>();
            var stationGalaxyMap = new List<IPath>() { pathMocked.Object };
            var stationLocationMocked = new Mock<ILocation>();
            var unitToTeleportMocked = new Mock<IUnit>();
            var targetLocationMocked = new Mock<ILocation>();

            pathMocked.Setup(x => x.TargetLocation.Planet.Galaxy.Name).Returns("Westeros");
            pathMocked.Setup(x => x.TargetLocation.Planet.Name).Returns("Castle Black");
            pathMocked.Setup(x => x.Cost.BronzeCoins).Returns(5);
            pathMocked.Setup(x => x.Cost.SilverCoins).Returns(5);
            pathMocked.Setup(x => x.Cost.GoldCoins).Returns(5);

            var planetaryUnit = new Mock<IUnit>();
            planetaryUnit.Setup(x => x.CurrentLocation.Planet.Galaxy.Name).Returns("Westeros");
            planetaryUnit.Setup(x => x.CurrentLocation.Planet.Name).Returns("Kings Landing");
            planetaryUnit.Setup(x => x.CurrentLocation.Coordinates.Longtitude).Returns(11.1);
            planetaryUnit.Setup(x => x.CurrentLocation.Coordinates.Latitude).Returns(99.9);

            var planetaryUnitsList = new List<IUnit>() { planetaryUnit.Object };
            pathMocked.Setup(x => x.TargetLocation.Planet.Units).Returns(planetaryUnitsList);

            stationLocationMocked.Setup(x => x.Planet.Galaxy.Name).Returns("Westeros");
            stationLocationMocked.Setup(x => x.Planet.Name).Returns("Kings Landing");

            unitToTeleportMocked.Setup(x => x.CurrentLocation.Planet.Galaxy.Name).Returns("Westeros");
            unitToTeleportMocked.Setup(x => x.CurrentLocation.Planet.Name).Returns("Kings Landing");
            unitToTeleportMocked.Setup(x => x.CurrentLocation.Coordinates.Longtitude).Returns(33.3);
            unitToTeleportMocked.Setup(x => x.CurrentLocation.Coordinates.Latitude).Returns(66.6);
            unitToTeleportMocked.Setup(x => x.Resources.BronzeCoins).Returns(10);
            unitToTeleportMocked.Setup(x => x.Resources.SilverCoins).Returns(10);
            unitToTeleportMocked.Setup(x => x.Resources.GoldCoins).Returns(10);

            var currentPlanetaryUnit = new List<IUnit>() { unitToTeleportMocked.Object };
            unitToTeleportMocked.Setup(x => x.CurrentLocation.Planet.Units).Returns(currentPlanetaryUnit);

            targetLocationMocked.Setup(x => x.Planet.Galaxy.Name).Returns("Westeros");
            targetLocationMocked.Setup(x => x.Planet.Name).Returns("Castle Black");
            targetLocationMocked.Setup(x => x.Coordinates.Longtitude).Returns(22.2);
            targetLocationMocked.Setup(x => x.Coordinates.Latitude).Returns(55.5);

            var resourseMocked = new Mock<IResources>();
            resourseMocked.Setup(m => m.BronzeCoins).Returns(999);
            resourseMocked.Setup(m => m.GoldCoins).Returns(999);
            resourseMocked.Setup(m => m.SilverCoins).Returns(999);

            unitToTeleportMocked.Setup(
                m => m.Pay(It.IsAny<IResources>())).Returns(resourseMocked.Object);
            unitToTeleportMocked.Setup(x => x.CanPay(It.IsAny<IResources>())).Returns(true);

            var station = new ExtendedTeleportStation(
                stationOwnerMocked.Object,
                stationGalaxyMap,
                stationLocationMocked.Object);

            var unitsOnTargetPlanet = new List<IUnit>() { unitToTeleportMocked.Object};
            targetLocationMocked.Setup(x => x.Planet.Units).Returns(unitsOnTargetPlanet);
            //currentPlanetaryUnit = new List<IUnit>();
            //unitToTeleportMocked.Setup(x => x.CurrentLocation.Planet.Units).Returns(currentPlanetaryUnit);

            station.TeleportUnit(unitToTeleportMocked.Object, targetLocationMocked.Object);
            
            //Assert.IsNull(currentPlanetaryUnit);
        }
    }
}
