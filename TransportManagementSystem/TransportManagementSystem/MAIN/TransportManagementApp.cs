using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagementSystem.dao;
using TransportManagementSystem.entity;
using TransportManagementSystem.exception;

namespace TransportManagementSystem.MAIN
{
    public class TransportManagementApp
    {
        static void Main(string[] args)
        {
            try
            {
                bool running = true;
                //to access interface method
                TransportManagementServiceImpl service = new TransportManagementServiceImpl();
                while (running)
                {
                    Console.WriteLine("Transport Management App Menu Card");
                    Console.WriteLine("--------------------------");
                    Console.WriteLine("1.Add a vehicle");
                    Console.WriteLine("2.Update Vehicle");
                    Console.WriteLine("3.Delete Vehicle");
                    Console.WriteLine("4.Schedule a Trip");
                    Console.WriteLine("5.Cancel Trip");
                    Console.WriteLine("6.Book Trip");
                    Console.WriteLine("7.Cancel a Booking");
                    Console.WriteLine("8.Allocate Driver");
                    Console.WriteLine("9.Deallocate Driver");
                    Console.WriteLine("10.Get List of Booking By Passenger");
                    Console.WriteLine("11.Get List of Booking For a Trip");
                    Console.WriteLine("12.Get List of Drivers Available");
                    Console.WriteLine("13.To Exit The Menu Card");
                    Console.Write("Enter a Choice - ");
                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            try
                            {
                                Console.Write("Enter vehicle model: ");
                                string? model = Console.ReadLine();
                                Console.Write("Enter vehicle capacity: ");
                                decimal capacity = Convert.ToDecimal(Console.ReadLine());
                                Console.Write("Enter vehicle type (e.g., Truck, Bus): ");
                                string? type = Console.ReadLine();
                                Console.Write("Enter vehicle status (Available,On Trip,Maintenance): ");
                                string? statusInput = Console.ReadLine();
                                Vehicles v = new Vehicles(model, capacity, type, statusInput);
                                bool success = service.addVehicle(v);
                                if (success) { Console.WriteLine("Vehicle add successfully"); }
                                else { Console.WriteLine("Not added"); }
                            }
                            catch (ArgumentException ex) { Console.WriteLine(ex.Message); }
                            catch (Exception ex) { Console.WriteLine(ex.Message); }
                            break;
                        case "2":
                            try
                            {
                                Console.WriteLine("Available Vehicles:");
                                List<Vehicles> vehicles = service.getAllVehicles();
                                foreach (var v in vehicles)
                                {
                                    Console.WriteLine($"ID: {v.VehicleID}, Model: {v.Model}, Capacity: {v.Capacity}, Type: {v.Type}, Status: {v.Status}");
                                }
                                Console.Write("Enter the VehicleID to update: ");
                                int vehicleId1 = Convert.ToInt32(Console.ReadLine());

                                Console.Write("Enter new Model: ");
                                string model1 = Console.ReadLine();

                                Console.Write("Enter new Capacity: ");
                                decimal capacity1 = Convert.ToDecimal(Console.ReadLine());

                                Console.Write("Enter new Type (eg-truck,car,bus): ");
                                string type1 = Console.ReadLine();

                                Console.Write("Enter new Status (Available/On Trip/Maintenance): ");
                                string status1 = Console.ReadLine();

                                Vehicles updatedVehicle = new Vehicles(vehicleId1, model1, capacity1, type1, status1);

                                bool result = service.updateVehicle(updatedVehicle);
                                if (result)
                                {
                                    Console.WriteLine(" Vehicle updated successfully.");
                                }
                                else
                                {
                                    Console.WriteLine(" Vehicle update failed.");
                                }
                            }
                            catch(VechileNotFoundException ex) { Console.WriteLine(ex.Message); }
                            catch (ArgumentException ex) { Console.WriteLine(ex.Message); }
                            catch (Exception ex) { Console.WriteLine(ex.Message); }
                            break;
                        case "3":
                            try
                            {
                                Console.WriteLine("Available Vehicles:");
                                List<Vehicles> vehicles = service.getAllVehicles();
                                foreach (var v in vehicles)
                                {
                                    Console.WriteLine($"ID: {v.VehicleID}, Model: {v.Model}, Capacity: {v.Capacity}, Type: {v.Type}, Status: {v.Status}");
                                }
                                Console.Write("Enter The VehicleId You want to delete = ");
                                int vehicleid = Convert.ToInt32(Console.ReadLine());
                                bool result = service.deleteVehicle(vehicleid);
                                if (result) { Console.WriteLine("Vehicle Deleted SuccessFully"); }
                                else
                                {
                                    Console.WriteLine(" Vehicle Delete failed");
                                }
                            }
                            catch (VechileNotFoundException ex) { Console.WriteLine(ex.Message); }
                            catch (ArgumentException ex) { Console.WriteLine(ex.Message); }
                            catch (Exception ex) { Console.WriteLine(ex.Message); }
                            break;
                        case "4":
                            try
                            {
                                Console.WriteLine("Available Vehicles:");
                                List<Vehicles> vehicles = service.getAllVehicles();
                                foreach (var v in vehicles)
                                {
                                    Console.WriteLine($"ID: {v.VehicleID}, Model: {v.Model}, Capacity: {v.Capacity}, Type: {v.Type}, Status: {v.Status}");
                                }
                                Console.WriteLine("------------------------");
                                Console.WriteLine("Avaiable Drivers");
                                foreach (Drivers driver in service.getAvailableDrivers())
                                {
                                    Console.WriteLine(driver);
                                }
                                Console.WriteLine("------------------------");
                                Console.WriteLine("List of Routes");
                                List<Routes> route = service.getAllRoutes();
                                foreach(var v in route)
                                {
                                    Console.WriteLine($"RouteId:{v.RouteID} , StartDestination:{v.StartDestination} , EndDestination:{v.EndDestination} , Distance:{v.Distance}km");
                                }
                                Console.WriteLine("------------------------");
                                Console.Write("Enter the VehicleId = ");
                                int vehicleid = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Enter the DriverId = ");
                                int driverId = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Enter the RouteId = ");
                                int routeId = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Enter Departure Date (yyyy-mm-dd): ");
                                string departureDate = Console.ReadLine();
                                Console.Write("Enter Arrival Date (yyyy-mm-dd): ");
                                string arrivalDate = Console.ReadLine();
                                bool result = service.scheduleTrip(vehicleid, driverId, routeId, departureDate, arrivalDate);

                                if (result)
                                {
                                    Console.WriteLine("Trip scheduled successfully!");
                                }
                                else
                                {
                                    Console.WriteLine("Failed to schedule trip.");
                                }
                            }
                            catch (ArgumentException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Error--" + ex.Message);

                            }
                            break;
                        case "5":
                            try
                            {
                                List<Trips> trips = service.getAllTrips();
                                Console.WriteLine("All Trips:");
                                foreach (Trips trip in trips)
                                {
                                    Console.WriteLine(trip);
                                }
                                Console.Write("Enter Trip ID to cancel: ");
                                int tripId = Convert.ToInt32(Console.ReadLine());

                                bool isCancelled = service.cancelTrip(tripId);
                                if (isCancelled)
                                {
                                    Console.WriteLine("Trip cancelled successfully.");
                                }
                                else
                                {
                                    Console.WriteLine("Failed to cancel trip.");
                                }
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Please enter a valid numeric Trip ID.");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Unexpected Error: " + ex.Message);
                            }
                            break;
                        case "6":
                            try
                            {
                                List<Trips> trips = service.getAllTrips();
                                List<Passengers> passes = service.getAllPassengers();
                                foreach( Passengers passenger in passes) { Console.WriteLine(passenger); }
                                Console.WriteLine("List of All passengers:");
                                Console.WriteLine("All Trips:");

                                foreach (Trips trip in trips)
                                {
                                    Console.WriteLine(trip);
                                }

                                Console.Write("Enter Trip ID: ");
                                int tripId = Convert.ToInt32(Console.ReadLine());

                                Console.Write("Enter Passenger ID: ");
                                int passengerId = Convert.ToInt32(Console.ReadLine());

                                Console.Write("Enter Booking Date (yyyy-MM-dd): ");
                                string bookingDate = Console.ReadLine();

                                bool bookingSuccess = service.bookTrip(tripId, passengerId, bookingDate);

                                if (bookingSuccess)
                                {
                                    Console.WriteLine("Trip booked successfully.");
                                }
                                else
                                {
                                    Console.WriteLine("Trip booking failed.");
                                }
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Please enter a valid numeric ID and date in the correct format.");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Error: " + ex.Message);
                            }
                            break;
                        case "7":
                            try
                            {
                                List<Bookings> bookings = service.getAllBookings(); 
                                Console.WriteLine("Current Bookings:");
                                foreach (var booking in bookings)
                                {
                                    Console.WriteLine($"BookingID: {booking.BookingID}, TripID: {booking.TripID}, PassengerID: {booking.PassengerID}, Status: {booking.Status}");
                                }

                                Console.Write("\nEnter the BookingID you want to cancel: ");
                                int bookingId = Convert.ToInt32(Console.ReadLine());

                                bool result = service.cancelBooking(bookingId);

                                if (result)
                                {
                                    Console.WriteLine("Booking cancelled successfully.");
                                }
                                else
                                {
                                    Console.WriteLine("Booking cancellation failed.");
                                }
                            }
                            catch (Exception ex) { Console.WriteLine("Error" + ex.Message); }
                            break;
                        case "8":
                            try
                            {
                                Console.WriteLine("------------------------");
                                Console.WriteLine("Avaiable Drivers");
                                foreach (Drivers driver in service.getAvailableDrivers())
                                {
                                    Console.WriteLine(driver);
                                }
                                Console.WriteLine("------------------------");
                                List<Trips> trips = service.getAllTrips();
                                Console.WriteLine("All Trips:");
                                foreach (Trips trip in trips)
                                {
                                    Console.WriteLine(trip);
                                }
                                Console.Write("Enter Trip ID: ");
                                int tripId = Convert.ToInt32(Console.ReadLine());

                                Console.Write("Enter Driver ID: ");
                                int driverId = Convert.ToInt32(Console.ReadLine());

                                bool result = service.allocateDriver(tripId, driverId);

                                if (result)
                                {
                                    Console.WriteLine("Driver allocated successfully to the trip.");
                                }
                                else
                                {
                                    Console.WriteLine("Driver allocation failed.");
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Unexpected error: " + ex.Message);
                            }
                            break;
                        case "9":
                            try
                            {
                                List<Trips> trips = service.getAllTrips();
                                Console.WriteLine("All Trips:");
                                foreach (Trips trip in trips)
                                {
                                    Console.WriteLine(trip);
                                }
                                Console.Write("Enter Trip ID to deallocate driver from: ");
                                int tripId = Convert.ToInt32(Console.ReadLine());
                                bool success = service.deallocateDriver(tripId);

                                if (success)
                                {
                                    Console.WriteLine("Driver deallocated successfully.");
                                }
                                else
                                {
                                    Console.WriteLine("Failed to deallocate driver.");
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Unexpected error: " + ex.Message);
                            }
                            break;
                        case "10":
                            try
                            {
                                Console.Write("Enter Passenger ID to view bookings: ");
                                int passengerId = Convert.ToInt32(Console.ReadLine());

                                List<Bookings> passengerBookings = service.getBookingsByPassenger(passengerId);
                                if (passengerBookings.Count == 0)
                                {
                                    Console.WriteLine("No bookings found for this passenger.");
                                }
                                else
                                {
                                    Console.WriteLine("Bookings for Passenger ID: " + passengerId);
                                    foreach (var booking in passengerBookings)
                                    {
                                        Console.WriteLine($"Booking ID: {booking.BookingID}, Trip ID: {booking.TripID}, Date: {booking.BookingDate.ToShortDateString()}, Status: {booking.Status}");
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Unexpected error: " + ex.Message);
                            }
                            break;
                        case "11":
                            try
                            {
                                Console.Write("Enter Trip ID to view bookings: ");
                                int tripId = Convert.ToInt32(Console.ReadLine());

                                List<Bookings> tripBookings = service.getBookingsByTrip(tripId);
                                if (tripBookings.Count == 0)
                                {
                                    Console.WriteLine("No bookings found for this trip.");
                                }
                                else
                                {
                                    Console.WriteLine("Bookings for Trip ID: " + tripId);
                                    foreach (var booking in tripBookings)
                                    {
                                        Console.WriteLine($"Booking ID: {booking.BookingID}, Passenger ID: {booking.PassengerID}, Date: {booking.BookingDate.ToShortDateString()}, Status: {booking.Status}");
                                    }
                                }
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Invalid input. Please enter a valid Trip ID.");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Unexpected error: " + ex.Message);
                            }
                            break;
                        case "12":
                            try
                            {
                                Console.WriteLine("Available Drivers:");
                                List<Drivers> availableDrivers = service.getAvailableDrivers();

                                if (availableDrivers.Count == 0)
                                {
                                    Console.WriteLine("No available drivers found.");
                                }
                                else
                                {
                                    foreach (Drivers driver in availableDrivers)
                                    {
                                        Console.WriteLine(driver.ToString());
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Unexpected error: " + ex.Message);
                            }
                            break;
                        case "13":
                            Console.WriteLine("Exiting");
                            running = false;
                            break;
                        default:
                            Console.WriteLine("Enter a Valid CHoice");
                            break;
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
