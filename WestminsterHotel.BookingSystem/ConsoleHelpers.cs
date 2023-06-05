using System;
using System.Drawing;

namespace WestminsterHotelConsoleApp
{
    /// <summary>
    /// Helper class to interact with console
    /// </summary>
    public static class ConsoleHelpers
    {
        /// <summary>
        /// Displays the given text at Console in red color
        /// </summary>
        /// <param name="text">The text to display</param>
        public static void PrintError(string text)
        {
            // Change foreground color of console to Red
            Console.ForegroundColor = ConsoleColor.Red;

            // Write given text to console
            Console.WriteLine(text);

            // Change foreground color of console to Gray
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        /// <summary>
        /// Reads room number from user
        /// </summary>
        /// <returns>The room number</returns>
        public static int ReadRoomNumberFromUser()
        {
            Console.Write("Enter Room Number : ");

            int roomNumber = Convert.ToInt32(Console.ReadLine());

            return roomNumber;
        }

        /// <summary>
        /// Reads booking detail from user
        /// </summary>
        /// <returns>The booking object</returns>
        public static Booking ReadBookingDetailFromUser()
        {
            Console.Write("Enter Check-in Date (dd/MM/yyyy) : ");

            // Read text from console and convert to date time object
            DateTime checkInDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
            Console.Write("Enter Check-out Date (dd/MM/yyyy) : ");

            // Read text from console and convert to date time object
            DateTime checkOutDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

            // Initialize booking object and set its attributes
            Booking wantedBooking = new Booking();
            wantedBooking.CheckInDate = checkInDate;
            wantedBooking.CheckOutDate = checkOutDate;

            return wantedBooking;
        }

        /// <summary>
        /// Reads room size from user
        /// </summary>
        /// <returns>The room size</returns>
        public static Size ReadRoomSizeFromUser()
        {
            Console.Write("Select Room Size (1 = {0}, 2 = {1}, 3 = {2}) : ", Size.Single, Size.Double, Size.Triple);

            // Read room size from console
            int size = Convert.ToInt32(Console.ReadLine());

            Size roomSize = Size.Single;
            if (size == 1)
            {
                roomSize = Size.Single;
            }
            else if (size == 2)
            {
                roomSize = Size.Double;
            }
            else if (size == 3)
            {
                roomSize = Size.Triple;
            }

            return roomSize;
        }
    }
}