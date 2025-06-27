using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportManagementSystem.entity
{
    public class Bookings
    {
        private string[] AllowedStatuses = { "Confirmed", "Cancelled", "Completed" };

            //fields
           // private int _bookingID;// private mean _ and interface mean I
        private int _tripID;
        private int _passengerID;
        private DateTime _bookingDate;
        private string _status;

        //Properties
        public int BookingID
        {
            get; set;
        }

        public int TripID
        {
            get { return _tripID; }
            set { _tripID = value; }
        }

        public int PassengerID
        {
            get { return _passengerID; }
            set { _passengerID = value; }
        }

        public DateTime BookingDate
        {
            get { return _bookingDate; }
            set
            {
                if (value > DateTime.Now)
                    throw new ArgumentException("Booking date cannot be in the future.");
                _bookingDate = value;
            }
        }

        public string Status
        {
            get { return _status; }
            set
            {
                if (!(AllowedStatuses.Contains(value)))
                    throw new ArgumentException($"Invalid status. Allowed values: {string.Join(", ", AllowedStatuses)}");
                _status = value;
            }
        }

        //Constructor
        public Bookings(int bookingID, int tripID, int passengerID, DateTime bookingDate, string status)
        {
            BookingID = bookingID;
            TripID = tripID;
            PassengerID = passengerID;
            BookingDate = bookingDate;
            Status = status;
        }
    }
}
