using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportManagementSystem.entity
{
    public class Trips
    {
        //Fields
        private int _tripID;
        private int _vehicleID;
        private int _routeID;
        private DateTime _departureDate;
        private DateTime _arrivaldate;
        private string _status;
        private string _tripType;
        private int _maxPassengers;
        private int? _driverID;

        private string[] AllowedStatuses = {"Scheduled","In Progress","Completed","Cancelled" };
        private string[] AllowedTripStatus = { "Freight", "Passenger" };

        //Properties
        public int TripID  //encapsulation

        {
            get { return _tripID; }
            set { _tripID = value; }
        }

        public int VehicleID
        {
            get { return _vehicleID; }
            set { _vehicleID = value; }
        }

        public int RouteID
        {
            get { return _routeID; }
            set { _routeID = value; }
        }

        public DateTime DepartureDate
        {
            get { return _departureDate; }
            set { _departureDate = value; }
        }

        public DateTime ArrivalDate
        {
            get { return _arrivaldate; }
            set { _arrivaldate = value; }
        }
        public string Status
        {
            get { return _status; }
            set 
            {
                if (!(AllowedStatuses.Contains(value)))
                {
                    throw new ArgumentException("Error--The Status Does not Match ! \n Allowed status are \n1.Available,\n2.In Service,\n3.Out of Service");
                }
                _status = value;
            }
        }
        public string TripType
        {
            get { return _tripType; }
            set 
            {
                if (!(AllowedTripStatus.Contains(value)))
                {
                    throw new ArgumentException("Error--The Status Does not Match ! Allowed status are -- \n1.Freight,\n2.Passenger");
                }
                _tripType = value; 
            }
        }

        public int MaxPassengers
        {
            get { return _maxPassengers; }
            set { _maxPassengers = value; }
        }
        public int? DriverID
        {
            get { return _driverID; }
            set { _driverID = value; }
        }

        //Constructor   ? it can be null
        public Trips(int tripId, int vehicleId, int routeId, int? driverId, DateTime departureDate, DateTime arrivalDate, string status)
        {
            TripID = tripId;
            VehicleID = vehicleId;
            RouteID = routeId;
            DriverID = driverId;
            DepartureDate = departureDate;
            ArrivalDate = arrivalDate;
            Status = status;
        }
        public Trips(int tripID, int vehicleID, int routeID, DateTime departureDate, DateTime arrivalDate,
                    string status, string tripType, int maxPassengers)
        {

            TripID = tripID;
            VehicleID = vehicleID;
            RouteID = routeID;
            DepartureDate = departureDate;
            ArrivalDate = arrivalDate;
            Status = status;
            TripType = tripType;
            MaxPassengers = maxPassengers;
        }

        //Overiding To Display List
        public override string ToString()
        {
            return $"TripID: {TripID}, VehicleID: {VehicleID}, RouteID: {RouteID},DriverID: {(DriverID.HasValue ? DriverID.ToString() : "UnAssigned")}, Departure: {DepartureDate}, Arrival: {ArrivalDate}, Status: {Status}";
        }
    }
}
