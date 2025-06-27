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
    public class addVehicleTest
    {
        [Test]
        public void Check_If_AddVehicle_ReturnsTrue()
        {
            //Arrange
            var tester = new TransportManagementServiceImpl();
            Vehicles lorry = new Vehicles("Tata LPT", (decimal)10.10, "lorry", "Available");

            //Act
            bool result = tester.addVehicle(lorry);

            //Assert
            ClassicAssert.IsTrue(result);
        }
    }
}
