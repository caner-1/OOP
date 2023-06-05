using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WestminsterHotelConsoleApp
{
    /// <summary>
    /// Westminster Hotel class having hotel manager and hotel customer functionality
    /// </summary>
    public class WestminsterHotel : IHotelManager, IHotelCustomer
    {
        /// <summary>
        /// Gets of sets the room dictionary
        /// </summary>
        public Dictionary<int, Room> Rooms { get; set; }

        /// <summary>
        /// Initializes the new instance of WestminsterHotel class
        /// </summary>
        public WestminsterHotel()
        {
            this.Rooms = new Dictionary<int, Room>();
        }

        // IHotelManager ==> a
        /// <summary>
        /// Adds new room
        /// </summary>
        /// <param name="room">The room detail</param>
        /// <returns>True if room is added, else false</returns>
        public bool AddRoom(Room room)
        {
            bool added = false;
            // Check whether room already exists in the dictionary by room number
            // If room does not exist, add the room to dictionary and return true
            if (this.Rooms.ContainsKey(room.RoomNumber) == false)
            {
                this.Rooms.Add(room.RoomNumber, room);
                added = true;
            }

            return added;
        }

        // IHotelManager ==> b
        /// <summary>
        /// Deletes the room
        /// </summary>
        /// <param name="roomNumber">The room number to delete</param>
        /// <returns>True if room is deleted, else false</returns>
        public bool DeleteRoom(int roomNumber)
        {
            bool deleted = false;

            // Check whether room already exists in the dictionary by room number
            // If room exists, delete it and return true
            if (this.Rooms.ContainsKey(roomNumber))
            {
                this.Rooms.Remove(roomNumber);
                deleted = true;
            }

            return deleted;
        }

        // IHotelManager ==> c
        /// <summary>
        /// Lists rooms
        /// </summary>
        public void ListRooms()
        {
            Console.WriteLine("Total Rooms : {0}", this.Rooms.Count);

            // Iterates over room dictionary and write the detail on console.
            foreach (var room in this.Rooms.Values)
            {
                Console.WriteLine(room.GetDetail());
            }
        }

        // IHotelManager ==> d
        /// <summary>
        /// Lists rooms ordered by price
        /// </summary>
        public void ListRoomsOrderedByPrice()
        {
            Console.WriteLine("Total Rooms : {0}", this.Rooms.Count);

            // Gets the room list from dictionary
            List<Room> roomsList = this.Rooms.Values.ToList();

            // Sort the room list, list will be sorted based on the implementation of IComparable interface
            roomsList.Sort();
            // Iterates over room dictionary and write the detail on console.
            foreach (var room in roomsList)
            {
                Console.WriteLine(room.GetDetail());
            }
        }

        // IHotelManager ==> e
        /// <summary>
        /// Generates room report and write to given file
        /// </summary>
        /// <param name="fileName">The file name to save report</param>
        public void GenerateReport(string fileName)
        {
            // Open file stream for write purpose
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);

            // Open stream writer
            StreamWriter sw = new StreamWriter(fs);

            // write to stream
            sw.WriteLine("Total Rooms : {0}", this.Rooms.Count);
            foreach (var room in this.Rooms.Values)
            {
                sw.WriteLine(room.GetDetail());
            }

            // close the stream
            sw.Close();

            // close the file stream
            fs.Close();
        }

        // IHotelCustomer ==> a
        /// <summary>
        /// List the available rooms by provided criteria
        /// </summary>
        /// <param name="wantedBooking">The booking detail</param>
        /// <param name="roomSize">The room size</param>
        public void ListAvailableRooms(Booking wantedBooking, Size roomSize)
        {
            List<Room> availableRooms = new List<Room>();

            // Iterates over room and filter based on booking detail and room size
            foreach (Room room in this.Rooms.Values)
            {
                // if room size matches
                if (room.Size == roomSize)
                {
                    // if no booking exists for the room
                    if (room.Bookings.Count == 0)
                    {
                        availableRooms.Add(room);
                    }
                    else
                    {
                        // Iterates over the bookings
                        foreach (var booking in room.Bookings)
                        {
                            // Checks whether booking overlaps with other booking or not
                            if (booking.OverLaps(wantedBooking) == false)
                            {
                                availableRooms.Add(room);
                            }
                        }
                    }
                }
            }

            if (availableRooms.Count > 0)
            {
                Console.WriteLine("Available Rooms : {0}", availableRooms.Count);

                // Iterates over the available rooms and displays its detail on console
                foreach (var room in availableRooms)
                {
                    Console.WriteLine(room.GetDetail());
                }
            }
            else
            {
                ConsoleHelpers.PrintError("No room available for given criteria");
            }
        }

        // IHotelCustomer ==> b
        /// <summary>
        /// List the available rooms by proved criteria
        /// </summary>
        /// <param name="wantedBooking">The booking detail</param>
        /// <param name="roomSize">The room size</param>
        /// <param name="maxPrice">Maximum price per night</param>
        public void ListAvailableRooms(Booking wantedBooking, Size roomSize, int maxPrice)
        {
            List<Room> availableRooms = new List<Room>();

            // Iterates over room and filter based on booking detail, room size and max price
            foreach (Room room in this.Rooms.Values)
            {
                // if room size matches and price is less than or equal to max price
                if (room.Size == roomSize && room.Price <= maxPrice)
                {
                    // if no booking exists for the room
                    if (room.Bookings.Count == 0)
                    {
                        availableRooms.Add(room);
                    }
                    else
                    {
                        // Iterates over the bookings
                        foreach (var booking in room.Bookings)
                        {
                            // Checks whether booking overlaps with other booking or not
                            if (booking.OverLaps(wantedBooking) == false)
                            {
                                availableRooms.Add(room);
                            }
                        }
                    }
                }
            }

            if (availableRooms.Count > 0)
            {
                Console.WriteLine("Available Rooms : {0}", availableRooms.Count);

                // Sort the room list based on IComparable interface (price)
                availableRooms.Sort();

                // Iterates over the available rooms and displays its detail on console
                foreach (var room in availableRooms)
                {
                    Console.WriteLine(room.GetDetail());
                }
            }
            else
            {
                ConsoleHelpers.PrintError("No room available for given criteria");
            }
        }

        // IHotelCustomer ==> c
        /// <summary>
        /// Books the room
        /// </summary>
        /// <param name="roomNumber">The room number to book</param>
        /// <param name="wantedBooking">The booking detail</param>
        /// <returns>True if room is booked, else return false</returns>
        public bool BookRoom(int roomNumber, Booking wantedBooking)
        {
            bool booked = false;

            // Check whether room exists with given room number
            if (this.Rooms.ContainsKey(roomNumber))
            {
                // Gets the room object from dictionary
                Room room = this.Rooms[roomNumber];

                bool bookingOverLaps = false;
                // Check if room has booking and overlaps with wanted booking
                foreach (var booking in room.Bookings)
                {
                    bookingOverLaps = booking.OverLaps(wantedBooking);
                    if (bookingOverLaps)
                        break;
                }

                // if booking does not overlaps add it to room's booking list
                if (bookingOverLaps == false)
                {
                    room.Bookings.Add(wantedBooking);
                    booked = true;
                }
                else
                {
                    ConsoleHelpers.PrintError(string.Format("Booking overlaps wither other bookings for same room"));
                }
            }
            else
            {
                ConsoleHelpers.PrintError("Room does not exist");
            }

            return booked;
        }
    }
}