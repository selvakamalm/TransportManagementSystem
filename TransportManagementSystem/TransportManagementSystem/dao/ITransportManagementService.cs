using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagementSystem.entity;

namespace TransportManagementSystem.dao
{
    public interface ITransportManagementService
    {
        bool addVehicle(Vehicles vehicles);
        bool updateVehicle(Vehicles vehicles);
        bool deleteVehicle(int vehicleId);
        bool scheduleTrip(int vehicleId,int driverId,int routeId,string departureDate,string arrivalDate);
        bool cancelTrip(int tripId);
        bool bookTrip(int tripId,int passengerId,string bookingDate);
        bool cancelBooking(int bookingId);
        bool allocateDriver(int tripId, int driverId);
        bool deallocateDriver(int tripId);
        List<Bookings> getBookingsByPassenger(int passengerId);
        List<Bookings> getBookingsByTrip(int tripId);
        List<Drivers> getAvailableDrivers();
        List<Passengers> getAllPassengers();

    }
}
