using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportManagementSystem.entity
{
    public class Vehicles
    {
        //fields
        private int _vehicleID;
        private string _model;
        private decimal _capacity;
        private string _type;
        private string _status;

        private string [] AllowedStatuses = { "Available","On Trip","Maintenance"};

        //Properties
        public int VehicleID
        {
            get { return _vehicleID; }
            set { _vehicleID = value; }
        }
        public string Model
        {
            get { return _model; }
            set { _model = value; }
        }

        public decimal Capacity
        {
            get { return _capacity; }   
            set 
            {
                if(value <= 0)
                {
                    throw new ArgumentException("Error -- Capacity Can't be Negative");
                }
                _capacity = value;
            }
        }
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }
        public string Status
        {
            get { return _status; }
            set 
            {
                if (!(AllowedStatuses.Contains(value)))
                {
                    throw new ArgumentException("Error--The Status Does not Match ! \n Allowed status are \n1.Available,\n2.On Trip,\n3.Maintenance");
                } 
                _status = value;
            }
        }

        //Constructor
        public Vehicles(string model,decimal capacity,string type,string status)
        {
            Model = model;
            Capacity = capacity;
            Type = type;
            Status = status;
        }

        public Vehicles(int vehicleID, string model, decimal capacity, string type, string status)
        {
            VehicleID = vehicleID;
            Model = model;
            Capacity = capacity;
            Type = type;
            Status = status;
        }
    }
}
