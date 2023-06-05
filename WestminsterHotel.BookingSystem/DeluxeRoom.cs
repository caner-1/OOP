using System.Text;

namespace WestminsterHotelConsoleApp
{
    /// <summary>
    /// Deluxe Room derived class from Room base class
    /// </summary>
    public class DeluxeRoom : Room
    {
        /// <summary>
        /// Gets or sets the balcony size
        /// </summary>
        public int BalconySize { get; set; }

        /// <summary>
        /// Gets or sets the room view
        /// </summary>
        public ViewType View { get; set; }

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
            sb.AppendFormat("Balcony Size:{0}\tView:{1}\t", this.BalconySize, this.View);
            sb.AppendLine();
            sb.Append(base.GetBookings());

            return sb.ToString();
        }
    }
}