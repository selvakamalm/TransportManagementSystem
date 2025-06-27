using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using TransportManagementSystem.dao;

namespace TransportManagementSystem.test
{
    public class allocateDriverTest
    {
        [Test]
        public void Check_Whether_AllocateDriver_Returns_True()
        {
            //Arranging
            var tester = new TransportManagementServiceImpl();
            int tripId = 3;      
            int driverId = 19;

            //Act
            bool result = tester.allocateDriver(tripId, driverId);

            //Assert
            ClassicAssert.IsTrue(result, "Driver allocated successfully to the trip");
        }

        [Test]
        public void Check_Whether_AllocateDriver_Return_False()
        {
            //arrange
            var tester = new TransportManagementServiceImpl();
            int tripId = -1;
            int driverId = 6;

            //act
            bool result = tester.allocateDriver(tripId, driverId);

            //Assert
            ClassicAssert.IsFalse(result, "Driver not allocated to the trip");
        }

        [Test]
        public void AllocateDriver_UnavailableDriver_ReturnsFalse()
        {
            // Arrange
            var tester = new TransportManagementServiceImpl();
            int tripId = 1;
            int driverId = 3; 

            // Act
            bool result = tester.allocateDriver(tripId, driverId);

            // Assert
            ClassicAssert.IsFalse(result, "Should return false for unavailable driver.");
        }

    }
}
