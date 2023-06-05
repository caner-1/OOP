namespace WestminsterHotelConsoleApp
{

    /// <summary>
    /// Interface to check overlapping of booking with other booking
    /// </summary>
    public interface IOverlappable
    {
        /// <summary>
        /// Checks whether booking overlaps with other booking or not.
        /// </summary>
        /// <param name="other">The booking.</param>
        /// <returns>Return true if overlaps else return false</returns>
        bool OverLaps(Booking other);
    }
}