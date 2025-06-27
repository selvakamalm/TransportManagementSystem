using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TransportManagementSystem.entity
{
    public class Passengers
    {

        //Fields
        private int _passengerID;
        private string _firstName;
        private string _gender;
        private int _age;
        private string _email;
        private string _phoneNumber;

        private static string[] AllowedGenders = { "Male", "Female", "Others" };

        //Properties
        public int PassengersID
        {
            get { return _passengerID; }
            set { _passengerID = value; }
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

        public string Gender
        {
            get { return _gender; }
            set
            {
                if (!(AllowedGenders.Contains(value)))
                    throw new ArgumentException($"Gender must be one of: {string.Join(", ", AllowedGenders)}");
                _gender = value;
            }
        }

        public int Age
        {
            get { return _age; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Age must be non-negative.");
                _age = value;
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || !(value.Contains("@")))
                    throw new ArgumentException("Invalid email format.");
                _email = value;
            }
        }

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                if (!(value.Length==10))
                    throw new ArgumentException("Invalid phone number.");
                _phoneNumber = value;
            }
        }

        //COnstructor
        public Passengers(int passengerID, string firstName, string gender, int age, string email, string phoneNumber)
        {
            PassengersID = passengerID;
            FirstName = firstName;
            Gender = gender;
            Age = age;
            Email = email;
            PhoneNumber = phoneNumber;
        }
        public override string ToString()
        {
            return $"PassengerID: {PassengersID}, Name: {FirstName}, Gender: {Gender}, Age: {Age}, Email: {Email}, Phone: {PhoneNumber}";
        }
       
    }
}
