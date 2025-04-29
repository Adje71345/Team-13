using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Carapp_repository_pattern;

namespace TestRepositories
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void AddCar_SavesCorrectly()
        {
            // Arrange
            var carRepo = new FileCarRepository();
            var car = new Car("Toyota", "Corolla", 2020, "Red", "ABC123", "Gasoline");

            // Act
            carRepo.AddCar(car);
            var savedCar = carRepo.GetCar("ABC123");

            //Assert
            Assert.IsNotNull(savedCar);
            Assert.AreEqual(car.Make, savedCar.Make);
            Assert.AreEqual(car.Model, savedCar.Model);
            Assert.AreEqual(car.Year, savedCar.Year);
            Assert.AreEqual(car.Color, savedCar.Color);
            Assert.AreEqual(car.LicensePlate, savedCar.LicensePlate);
            Assert.AreEqual(car.FuelType, savedCar.FuelType);
            Assert.AreEqual(car.ToString(), savedCar.ToString());
        }

        [TestMethod]
        public void GetTripsForCar_ReturnsCorrectTrips()
        {
            // Arrange
            var tripRepo = new FileTripRepository();
            var car = new Car("Toyota", "Corolla", 2020, "Red", "ABC123", "Gasoline");

            var trip1 = new Trip("ABC123", 200, new DateTime(2020, 1, 1), new TimeSpan(14, 0, 0), new TimeSpan(16, 15, 0));
            var trip2 = new Trip("ABC123", 150, new DateTime(2020, 1, 2), new TimeSpan(10, 0, 0), new TimeSpan(12, 30, 0));
            var trip3 = new Trip("XYZ789", 300, new DateTime(2020, 1, 3), new TimeSpan(8, 0, 0), new TimeSpan(10, 45, 0));
            File.WriteAllLines("trips.txt", new[] { trip1.ToString(), trip2.ToString(), trip3.ToString() });

            // Act
            var tripsForCar = tripRepo.GetTripsForCar("ABC123").ToList();

            //Assert
            Assert.IsNotNull(tripsForCar);
            Assert.IsTrue(tripsForCar.Count() == 2);
            Assert.IsTrue(tripsForCar.Any(t => t.CarRegNr == "ABC123" && t.Distance == 200 && t.Date == new DateTime(2020, 1, 1) && t.StartTime == new TimeSpan(14, 0, 0) && t.EndTime == new TimeSpan(16, 15, 0)));
            Assert.IsTrue(tripsForCar.Any(t => t.CarRegNr == "ABC123" && t.Distance == 150 && t.Date == new DateTime(2020, 1, 2) && t.StartTime == new TimeSpan(10, 0, 0) && t.EndTime == new TimeSpan(12, 30, 0)));
            Assert.IsFalse(tripsForCar.Any(t => t.CarRegNr == "XYZ789"));
        }

        [TestMethod]
        public void AddTrip_WithUnknownCar_ThrowsException()
        {
            // Arrange
            var tripRepo = new FileTripRepository();
            var trip = new Trip("UNKNOWN", 100, new DateTime(2020, 1, 1), new TimeSpan(14, 0, 0), new TimeSpan(16, 15, 0));
            
            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => tripRepo.AddTrip(trip));
        }
    }
}
