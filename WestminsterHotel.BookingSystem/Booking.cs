using System;

namespace WestminsterHotelConsoleApp
{
    /// <summary>
    /// Booking class
    /// </summary>
    public class Booking : IOverlappable
    {
        // expected at 3pm on the day the booking starts
        /// <summary>
        /// Gets or sets the check-in date
        /// </summary>
        public DateTime CheckInDate { get; set; }


        // expected at 11am on the last day of the booking
        /// <summary>
        /// Gets or sets the check-out date
        /// </summary>
        public DateTime CheckOutDate { get; set; }

        /// <summary>
        /// Checks whether booking overlaps with other booking or not.
        /// </summary>
        /// <param name="other">The booking.</param>
        /// <returns>Return true if overlaps else return false</returns>
        public bool OverLaps(Booking other)
        {
            bool overlaps = false;

            // check whether check-in date of this object is between check-in and check-out date of given booking object
            if (this.CheckInDate >= other.CheckInDate && this.CheckInDate <= other.CheckOutDate)
            {
                overlaps = true;
            }
            // check whether check-out date of this object is between check-in and check-out date of given booking object
            else if (this.CheckOutDate >= other.CheckInDate && this.CheckInDate <= other.CheckOutDate)
            {
                overlaps = true;
            }

            return overlaps;
        }
    }
}