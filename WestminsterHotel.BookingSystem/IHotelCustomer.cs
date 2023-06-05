using System.Drawing;

namespace WestminsterHotelConsoleApp
{
    /// <summary>
    /// Interface for hotel customer
    /// </summary>
    public interface IHotelCustomer
    {
        /// <summary>
        /// List the available rooms by provided criteria
        /// </summary>
        /// <param name="wantedBooking">The booking detail</param>
        /// <param name="roomSize">The room size</param>
        void ListAvailableRooms(Booking wantedBooking, Size roomSize);

        /// <summary>
        /// List the available rooms by proved criteria
        /// </summary>
        /// <param name="wantedBooking">The booking detail</param>
        /// <param name="roomSize">The room size</param>
        /// <param name="maxPrice">Maximum price per night</param>
        void ListAvailableRooms(Booking wantedBooking, Size roomSize, int maxPrice);

        /// <summary>
        /// Books the room
        /// </summary>
        /// <param name="roomNumber">The room number to book</param>
        /// <param name="wantedBooking">The booking detail</param>
        /// <returns>True if room is booked, else return false</returns>
        bool BookRoom(int roomNumber, Booking wantedBooking);
    }
}
