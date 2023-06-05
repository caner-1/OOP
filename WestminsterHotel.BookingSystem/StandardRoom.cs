using System.Text;

namespace WestminsterHotelConsoleApp
{
    /// <summary>
    /// Standard Room derived class from Room base class
    /// </summary>
    public class StandardRoom : Room
    {
        /// <summary>
        /// Gets of sets the number of windows
        /// </summary>
        public int NumberOfWindows { get; set; }

        /// <summary>
        /// Initializes the new instance of StandardRoom class
        /// </summary>
        public StandardRoom()
        {
            this.NumberOfWindows = 1;
        }

        /// <summary>
        /// Gets the room detail
        /// </summary>
        /// <returns>Room detail</returns>
        public override string GetDetail()
        {
            StringBuilder sb = new StringBuilder();

            // Get room detail from base class
            sb.Append(base.GetDetail());

            // append the deluxe room detail into base room detail
            sb.AppendFormat("Number of Windows: {0}\t", this.NumberOfWindows);
            sb.AppendLine();

            sb.Append(base.GetBookings());

            return sb.ToString();
        }
    }
}