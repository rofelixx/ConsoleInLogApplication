using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleInLogBusiness.DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework.Internal;

namespace ConsoleInLogTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestTryParse()
        {

            int number;
            bool isNumber;
            if (Int32.TryParse("Teste", out number))
            {
                isNumber = number > 0 ? isNumber = true : isNumber = false;
            }
        }

        [TestMethod]
        public void TestGetVehicleByChassi()
        {
            var vehicle1 = new VehicleDTO();
            var vehicle2 = new VehicleDTO();
            var ListVehicles = new List<VehicleDTO>();
            vehicle1.ChassisNumber = "12";
            vehicle1.Color = "Blue";
            vehicle2.ChassisNumber = "1212";
            vehicle2.Color = "White";
            ListVehicles.Add(vehicle1);
            ListVehicles.Add(vehicle2);
            var vehicleToDelete = ListVehicles.Where(w => w.ChassisNumber == vehicle2.ChassisNumber).FirstOrDefault();
            ListVehicles.Remove(vehicleToDelete);
            Assert.IsTrue(ListVehicles.Count == 1);
        }

        [TestMethod]
        public void TestSaveNewColor()
        {
            var ConsoleInLogBusiness = new ConsoleInLogBusiness.Business.VehicleBusiness();
            var vehicle = new VehicleDTO();
            vehicle.ChassisNumber = "12";
            vehicle.Color = "Blue";
            var ListVehicles = new List<VehicleDTO>();
            ListVehicles.Add(vehicle);
            var newColor = "White";
            ConsoleInLogBusiness.EditColor(ListVehicles, vehicle.ChassisNumber, newColor);
            var newColorHasChanged = ListVehicles.Select(s => s.Color).FirstOrDefault();
            Assert.IsTrue(newColorHasChanged.Equals("White"));
        }

        [TestMethod]
        public void SaveLog()
        {
            var ConsoleInLogBusiness = new ConsoleInLogBusiness.Business.VehicleBusiness();
            ConsoleInLogBusiness.Logging("Teste");
        }
    }
}
