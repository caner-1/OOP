using System;
using System.Drawing;

namespace WestminsterHotelConsoleApp
{
    class Program
    {
        /// <summary>
        /// Application main entry method
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            WestminsterHotel hotel = new WestminsterHotel();

            string option = null;

            // wait for option
            while (option != "x")
            {
                // displays customer menu

                Console.WriteLine();
                Console.WriteLine("---/// Customer Menu ///---");
                Console.WriteLine();
                Console.WriteLine("a - List Available Rooms by Booking and Room Size");
                Console.WriteLine("b - List Available Rooms by Booking, Room Size and Maximum Price");
                Console.WriteLine("c - Book Room");
                Console.WriteLine("am - Administrator Menu");

                Console.WriteLine("x - Exit Program");
                Console.WriteLine();

                Console.Write("Hi and welcome to Westminster Hotel. Please select an option from above: ");
                option = Console.ReadLine();

                // administrator menu
                if (option == "am")
                {
                    while (option != "cm")
                    {
                        // displays administrator menu

                        Console.WriteLine();
                        Console.WriteLine("---/// Administrator Menu ///---");
                        Console.WriteLine();
                        Console.WriteLine("a - Add Room");
                        Console.WriteLine("b - Delete Room");
                        Console.WriteLine("c - List Rooms");
                        Console.WriteLine("d - List Rooms by Price");
                        Console.WriteLine("e - Generate Report");
                        Console.WriteLine("s - Fill with Sample Data");

                        Console.WriteLine("cm - Customer Menu");
                        Console.WriteLine();
                        Console.Write("Please select an option from above: ");
                        option = Console.ReadLine();

                        // add room
                        if (option == "a")
                        {
                            Console.WriteLine("Add Room");
                            Console.WriteLine();

                            // read room number from user
                            int roomNumber = ConsoleHelpers.ReadRoomNumberFromUser();

                            // read room floor from user
                            Console.Write("Enter Floor: ");
                            int floor = Convert.ToInt32(Console.ReadLine());

                            // read room size from user
                            Size roomSize = ConsoleHelpers.ReadRoomSizeFromUser();

                            // read room price from user
                            Console.Write("Enter Price (per night): ");
                            int price = Convert.ToInt32(Console.ReadLine());

                            // read room type from user
                            Console.Write("Enter Room Type (1 = {0}, 2 = {1}): ", "Standard", "Deluxe");
                            int roomType = Convert.ToInt32(Console.ReadLine());

                            // initialize room instance based on selected room type (Standard or Deluxe)
                            Room room = null;
                            if (roomType == 1)
                            {
                                // initialize room instance with StandardRoom
                                room = new StandardRoom();

                                // Read number of windows from user
                                Console.Write("Enter Number of Windows in Standard Room: ");
                                ((StandardRoom)room).NumberOfWindows = Convert.ToInt32(Console.ReadLine());
                            }
                            else if (roomType == 2)
                            {
                                // initialize room instance with DeluxeRoom
                                room = new DeluxeRoom();

                                // read balcony size from user
                                Console.Write("Enter Balcony Size for Deluxe Room: ");
                                ((DeluxeRoom)room).BalconySize = Convert.ToInt32(Console.ReadLine());

                                // read view type from user
                                Console.Write("Select View Type for Deluxe Room (1 = {0}, 2 = {1}, 3 = {2}): ", ViewType.SeaView, ViewType.LandMarkView, ViewType.MountainView);
                                int viewType = Convert.ToInt32(Console.ReadLine());

                                if (viewType == 1)
                                {
                                    ((DeluxeRoom)room).View = ViewType.SeaView;
                                }
                                else if (viewType == 2)
                                {
                                    ((DeluxeRoom)room).View = ViewType.LandMarkView;
                                }
                                else if (viewType == 3)
                                {
                                    ((DeluxeRoom)room).View = ViewType.MountainView;
                                }
                            }

                            // set the attributes of room object
                            room.RoomNumber = roomNumber;
                            room.Floor = floor;
                            room.Size = roomSize;
                            room.Price = price;

                            // add the room to hotel
                            bool roomAdded = hotel.AddRoom(room);

                            if (roomAdded == false)
                            {
                                ConsoleHelpers.PrintError(string.Format("ERROR:: Room with number {0} already exists", room.RoomNumber));
                            }
                            else
                            {
                                Console.WriteLine("OK:: Room added");
                            }
                        }
                        // delete room
                        else if (option == "b")
                        {
                            Console.WriteLine("Delete Room");
                            Console.WriteLine();

                            // read room number from user
                            int roomNumber = ConsoleHelpers.ReadRoomNumberFromUser();

                            // delete the room from hotel
                            bool deleted = hotel.DeleteRoom(roomNumber);

                            if (deleted)
                            {
                                Console.WriteLine("OK:: Room with number {0} deleted successfully", roomNumber);
                            }
                            else
                            {
                                ConsoleHelpers.PrintError(string.Format("ERROR:: Room with number {0} does not exist", roomNumber));
                            }
                        }
                        // list rooms
                        else if (option == "c")
                        {
                            // display the list of room
                            hotel.ListRooms();
                        }
                        // list rooms by price
                        else if (option == "d")
                        {
                            // display the list of room sorted by price
                            hotel.ListRoomsOrderedByPrice();
                        }
                        // generate report
                        else if (option == "e")
                        {
                            // generate report
                            hotel.GenerateReport("WestminsterHotelReport.txt");
                        }

                        // fill with sample data
                        else if (option == "s")
                        {
                            hotel.AddRoom(new DeluxeRoom
                            {
                                RoomNumber = 2003,
                                Floor = 20,
                                Size = Size.Triple,
                                Price = 203,
                                BalconySize = 3,
                                View = ViewType.LandMarkView,
                            });


                            hotel.AddRoom(new StandardRoom
                            {
                                RoomNumber = 1001,
                                Floor = 10,
                                Size = Size.Single,
                                Price = 101,
                                NumberOfWindows = 1
                            });
                            hotel.AddRoom(new StandardRoom
                            {
                                RoomNumber = 1002,
                                Floor = 10,
                                Size = Size.Double,
                                Price = 102,
                                NumberOfWindows = 1
                            });

                            hotel.AddRoom(new StandardRoom
                            {
                                RoomNumber = 1003,
                                Floor = 10,
                                Size = Size.Triple,
                                Price = 103,
                                NumberOfWindows = 1
                            });

                            hotel.AddRoom(new DeluxeRoom
                            {
                                RoomNumber = 2001,
                                Floor = 20,
                                Size = Size.Single,
                                Price = 201,
                                BalconySize = 1,
                                View = ViewType.SeaView,
                            });
                            hotel.AddRoom(new DeluxeRoom
                            {
                                RoomNumber = 2002,
                                Floor = 20,
                                Size = Size.Double,
                                Price = 202,
                                BalconySize = 2,
                                View = ViewType.MountainView,
                            });
                        }

                    }
                }
                // list available rooms by booking and room size
                else if (option == "a")
                {
                    Console.WriteLine("List Available Rooms by Booking Date and Room Size");

                    // read booking detail from user
                    Booking wantedBooking = ConsoleHelpers.ReadBookingDetailFromUser();

                    // read room size from user
                    Size roomSize = ConsoleHelpers.ReadRoomSizeFromUser();

                    // display available rooms based on booking detail and room size
                    hotel.ListAvailableRooms(wantedBooking, roomSize);

                }
                // list available rooms by booking, room size and max price
                else if (option == "b")
                {
                    Console.WriteLine("List Available Rooms by Booking Date, Room Size and Maximum Price");

                    // read booking detail from user
                    Booking wantedBooking = ConsoleHelpers.ReadBookingDetailFromUser();

                    // read room size from user
                    Size roomSize = ConsoleHelpers.ReadRoomSizeFromUser();

                    // read max price from user
                    Console.Write("Enter Maximum Price for Room: ");
                    int maxPrice = Convert.ToInt32(Console.ReadLine());

                    // display available rooms based on booking detail, room size and max price
                    hotel.ListAvailableRooms(wantedBooking, roomSize, maxPrice);

                }
                // book room
                else if (option == "c")
                {
                    Console.WriteLine("Book Room by Booking Date");
                    Console.WriteLine();

                    // read room number from user
                    int roomNumber = ConsoleHelpers.ReadRoomNumberFromUser();

                    // read room detail from user
                    Booking wantedBooking = ConsoleHelpers.ReadBookingDetailFromUser();

                    // book the room
                    bool roomBooked = hotel.BookRoom(roomNumber, wantedBooking);
                    if (roomBooked)
                    {
                        Console.WriteLine("Room booked");
                    }
                    else
                    {
                        ConsoleHelpers.PrintError("Unable to book room");
                    }
                }
            }

            Console.WriteLine("Thank you for visiting Westminter Hotel! We hope to see you again, good bye!");
            Console.ReadLine();
        }
    }
}