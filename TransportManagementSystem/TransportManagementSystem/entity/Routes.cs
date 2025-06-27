using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportManagementSystem.entity
{
    public class Routes
    {
        //Fields
        private int _routeID;
        private string _startDestination;
        private string _endDestination;
        private decimal _distance;

        //Properties
        public int RouteID { get { return _routeID; } set { _routeID = value; } }
        public string StartDestination
        {
            get { return _startDestination; }
            set { _startDestination = value; }
        }
        public string EndDestination
        {
            get { return _endDestination; }
            set { _endDestination = value; }
        }
        public decimal Distance
        {
            get { return _distance; }
            set { _distance = value; }
        }

        //Constructor
        public Routes(string StartDestination , string EndDestination,decimal distance) 
        {
            this.StartDestination = StartDestination;
            this.EndDestination = EndDestination;
            Distance = distance;
        }

        public Routes(int routeId, string startDestination,string endDestination,decimal distance)
        {
            RouteID= routeId;
            StartDestination = startDestination;
            EndDestination = endDestination;
            Distance = distance;
        }
    }
}
