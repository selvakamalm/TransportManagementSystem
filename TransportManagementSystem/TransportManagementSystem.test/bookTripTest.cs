using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using TransportManagementSystem.dao;
using TransportManagementSystem.entity;

namespace TransportManagementSystem.test
{
    public class bookTripTest
    {
        [Test]
        public void Check_Whether_BookTrip_returns_true()
        {
            // Arrange
            var tester = new TransportManagementServiceImpl();
            int TripId = 4;
            int PassengerId = 4; 
            string bookingDate = "2025-04-10";

            //Act 
            bool result = tester.bookTrip(TripId, PassengerId, bookingDate);

            //Assert
            ClassicAssert.IsTrue(result, "Booking should succeed with valid data.");
        }

        [Test]
        public void Check_Whether_BookTrip_returns_false()
        {
            // Arrange
            var tester = new TransportManagementServiceImpl();
            int TripId = -1;
            int PassengerId = 2;
            string bookingDate = "2025-04-10";

            //Act 
            bool result = tester.bookTrip(TripId, PassengerId, bookingDate);

            //Assert
            ClassicAssert.IsFalse(result, "Booking should fail for an invalid Trip ID.");
           
        }
    }
}
