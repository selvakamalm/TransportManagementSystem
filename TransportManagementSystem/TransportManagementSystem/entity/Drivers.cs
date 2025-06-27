using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportManagementSystem.entity
{
    public class Drivers
    {
        private static string[] allowedStatuses = { "Available", "Assigned", "On Leave" };

        //Fields
        private int? _driverID;
        private string _firstName;
        private string _lastName;
        private string _licenseNumber;
        private string _phoneNumber;
        private string _email;
        private string _status;

        //Properties
        public int DriverID
        {
            get { return (int)_driverID; }
            set { _driverID = value; }
        }

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("First name cannot be empty.");
                _firstName = value;
            }
        }
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public string LicenseNumber
        {
            get { return _licenseNumber; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("License number is required.");
                _licenseNumber = value;
            }
        }

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value) && !value.Contains("@"))
                    throw new ArgumentException("Invalid email format.");
                _email = value;
            }
        }

        public string Status
        {
            get { return _status; }
            set
            {
                if (!(allowedStatuses.Contains(value)))
                    throw new ArgumentException($"Status must be one of the following: {string.Join(", ", allowedStatuses)}");
                _status = value;
            }
        }

        // Constructor
        public Drivers(int driverId, string firstName, string lastName, string licenseNumber, string phoneNumber, string email, string status)
        {
            DriverID = driverId;
            FirstName = firstName;
            LastName = lastName;
            LicenseNumber = licenseNumber;
            PhoneNumber = phoneNumber;
            Email = email;
            Status = status;
        }

        //Overiding To Display List
        public override string ToString()
        {
            return $"DriverId :{DriverID} , DriverName:{FirstName+" "+LastName} , LicenseNumber:{LicenseNumber} , PhoneNumber:{PhoneNumber} , Email:{Email} , Status :{Status}";
        }
    }
}
