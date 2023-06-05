namespace WestminsterHotelConsoleApp
{
    /// <summary>
    /// Interface for hotel manager
    /// </summary>
    public interface IHotelManager
    {
        /// <summary>
        /// Adds new room
        /// </summary>
        /// <param name="room">The room detail</param>
        /// <returns>True if room is added, else false</returns>
        bool AddRoom(Room room);

        /// <summary>
        /// Deletes the room
        /// </summary>
        /// <param name="roomNumber">The room number to delete</param>
        /// <returns>True if room is deleted, else false</returns>
        bool DeleteRoom(int roomNumber);

        /// <summary>
        /// Lists rooms
        /// </summary>
        void ListRooms();

        /// <summary>
        /// Lists rooms ordered by price
        /// </summary>
        void ListRoomsOrderedByPrice();

        /// <summary>
        /// Generates room report and write to given file
        /// </summary>
        /// <param name="fileName">The file name to save report</param>
        void GenerateReport(string fileName);
    }
}