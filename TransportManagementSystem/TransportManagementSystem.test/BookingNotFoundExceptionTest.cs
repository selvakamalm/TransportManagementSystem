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
    public class BookingNotFoundExceptionTest
    {
        [Test]
        public void Check_Whether_Booking_NotFound_Exception_Throws_Error()
        {
            //Arrange
            int bookingid = -2;
            var tester = new TransportManagementServiceImpl();
            try
            {
                //Act
                bool result = tester.cancelBooking(bookingid);

                //Assert
                ClassicAssert.IsFalse(result, "Expected update to fail for non-existent vehicle.");
            }
            catch(BookingNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
