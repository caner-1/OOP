using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace WestminsterHotelConsoleApp
{
    /// <summary>
    /// Room class
    /// </summary>
    public abstract class Room : IComparable
    {
        /// <summary>
        /// Gets or sets the room number
        /// </summary>
        public int RoomNumber { get; set; }

        /// <summary>
        /// Gets or sets the room floor
        /// </summary>
        public int Floor { get; set; }

        /// <summary>
        /// Gets or sets the room size
        /// </summary>
        public Size Size { get; set; }

        /// <summary>
        /// Gets or sets the room price per night
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// Gets or sets the bookings
        /// </summary>
        public List<Booking> Bookings { get; set; }

        /// <summary>
        /// Initializes the new instance of Room class
        /// </summary>
        public Room()
        {
            this.Bookings = new List<Booking>();
        }

        /// <summary>
        /// Compares the object based on Price attribute
        /// </summary>
        /// <param name="obj">The Room object</param>
        /// <returns>Comparision value</returns>
        public int CompareTo(object obj)
        {
            if (obj is Room)
                return Price.CompareTo(((Room)obj).Price);
            return 0;
        }

        /// <summary>
        /// Gets the detail of room
        /// </summary>
        /// <returns>Room detail</returns>
        public virtual string GetDetail()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Room #:{0}\tFloor:{1}\tSize:{2}\tPrice:{3}\t", this.RoomNumber, this.Floor, this.Size, this.Price);
            return sb.ToString();
        }

        /// <summary>
        /// Gets the booking detail
        /// </summary>
        /// <returns>Booking detail</returns>
        protected string GetBookings()
        {
            StringBuilder sb = new StringBuilder();

            // Check if booking exists for this room or not
            if (this.Bookings != null && this.Bookings.Count != 0)
            {
                sb.AppendLine(string.Format("Booking Count : {0}", this.Bookings.Count));

                // Iterates over booking list and appent text with booking detail
                foreach (var booking in this.Bookings)
                {
                    sb.AppendFormat("Booking Detail --> Check-in Date\t:{0}\tCheck-out Date\t:{1}", booking.CheckInDate.ToShortDateString(), booking.CheckOutDate.ToShortDateString());
                    sb.AppendLine();
                }
            }

            return sb.ToString();
        }
    }
}