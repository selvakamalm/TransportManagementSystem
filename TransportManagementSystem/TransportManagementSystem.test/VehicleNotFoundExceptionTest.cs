using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using TransportManagementSystem.dao;
using TransportManagementSystem.entity;
using TransportManagementSystem.exception;

namespace TransportManagementSystem.test
{
    class VehicleNotFoundExceptionTest
    {
        [Test]
        public void Check_Whether_It_Throws_Vehicle_NotFound_Exception()
        {
            //Arrange
            int vehicleid = -1;
            var tester = new TransportManagementServiceImpl();
            Vehicles lorry = new Vehicles("Tata LPT", 100, "Lorry", "Available");
            lorry.VehicleID= vehicleid;

            //Act
            try
            {
                bool result = tester.updateVehicle(lorry);
                ClassicAssert.IsFalse(result, "Expected update to fail for non-existent vehicle.");
            }
            catch(VechileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
