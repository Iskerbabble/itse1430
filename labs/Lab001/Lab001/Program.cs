using System;

namespace Lab001
{
    class Program
    {
        static void Main ( string[] args )
        {
            bool done = false;
            int xspot = 0;
            int yspot = 0;
            // int riddleCheck = 0;
            Console.WriteLine("You wake up in a strange room with nothing but the clothes on your back.\nYou know it, you are trapped in this place" +
                ", but there must be a way out\n");
            RoomDescription(xspot, yspot);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("If you need optons, type \"help\" for a list of commands");
            Console.ResetColor();

            do
            {
                char choice = GetInput();

                switch (choice)
                {
                    case 'N': moveCharacter(ref xspot, ref yspot, 'N'); break;
                    case 'S': moveCharacter(ref xspot, ref yspot, 'S'); break;
                    case 'E': moveCharacter(ref xspot, ref yspot, 'E'); break;
                    case 'W': moveCharacter(ref xspot, ref yspot, 'W'); break;
                    // case 'R': giveRiddle(xspot, yspot, ref riddleCheck); break;
                    case 'L': RoomDescription(xspot, yspot); break;
                    case 'H': diplayOptions(); break;
                    case 'Q': done = HandleQuit(); break;
                    default: DisplayError("Unknown option"); break;

                }

            } while (!done);
        }

        private static void diplayOptions ()
        {
            Console.WriteLine("       North(N)\nWest(W)        East(E)\n       South(S)\n");
            Console.WriteLine("Riddle(R) -- Look(L) -- Help(H) -- Quit(Q)");

        }

        //private static void giveRiddle ( int xspot, int yspot, ref int riddleCheck )
        //{
        //    Console.WriteLine("Beter");
        ////    if(xspot == 0 && yspot == 1)
        ////    {
        ////        bool done = false;
        ////        string input = "";



        ////        do
        ////        {
        ////            Console.Write("Say your answer-> ");
        ////            input = Console.ReadLine();
        ////            if (input.ToUpper() == "BURGER")
        ////            {
        ////                riddleCheck++;
        ////                break;
        ////            }
        ////            if()
        ////        } while (!done);
        ////    }
        //}

        private static void moveCharacter ( ref int xspot, ref int yspot, char direct )
        {
            if (direct == 'N' && xspot > 0)
            {
                xspot--;
                Console.WriteLine("\nYou go North and enter a new room.");
                RoomDescription(xspot, yspot);
            } else if (direct == 'S' && xspot < 2)
            {
                xspot++;
                Console.WriteLine("\nYou go South and enter a new room.");
                RoomDescription(xspot, yspot);
            } else if (direct == 'E' && yspot < 2)
            {
                yspot++;
                Console.WriteLine("\nYou go East and enter a new room.");
                RoomDescription(xspot, yspot);
            } else if (direct == 'W' && yspot > 0)
            {
                yspot--;
                Console.WriteLine("\nYou go West and enter a new room.");
                RoomDescription(xspot, yspot);
            } else
            {
                DisplayError("You hit the wall, no door that way");
            }

        }

        private static void RoomDescription ( int x, int y )
        {
            if (x == 0 && y == 0)
            {
                Console.WriteLine("You are in a red room -Room 1--(" + (x+1) + ", " + (y+1) + "), there are doors to the east and south of the room.\n" +
                    "Fire symbols and depictions paint the walls around you, the fire on the walls almost seem moving and the air is \nstagnant with heat.");
            }

            if (x == 0 && y == 1)
            {
                Console.WriteLine("You are in a chrome-like room --Room 2--(" + (x+1) + ", " + (y+1) + "), there are doors to the east, west, and south of the room.\n" +
                    "There is a large door in front of you, it is the exit." +
                    " To leave, you must answer the riddle.");
            }

            if (x == 0 && y == 2)
            {
                Console.WriteLine("You are in a blue room --Room 3--(" + (x+1) + ", " + (y+1) + "), there are doors to the west and south of the room.\n" +
                    "Water symbols and depictions paint the walls around you, you hear the relaxing sound of moving water, and it seems the \nfloor sways ever" +
                    " so slightly like an ocean.");
            }

            if (x == 1 && y == 0)
            {
                Console.WriteLine("You are in a light green room --Room 4--(" + (x+1) + ", " + (y+1) + "), there are doors to the north, east, and south of the room.\n" +
                    "Grassland and plant-like symbols and depictions paint the walls around you and unkeept, ankle high grass covers the \nfloor." +
                    "Chirping chickets can be faintly heard");
            }

            if (x == 1 && y == 1)
            {
                Console.WriteLine("You are in a white room --Room 5--(" + (x+1) + ", " + (y+1) + "), there are doors to the north, east, west, and south of the room\n" +
                    "The room is completely white and deviod of color, and not a speck of dust is present. No sound can be made in the room, you yell but the silence" +
                    " overtakes it.");
            }

            if (x == 1 && y == 2)
            {
                Console.WriteLine("You are in a dark green room --Room 6(" + (x+1) + ", " + (y+1) + "), there are doors to the north, west, and south of the room.\n" +
                    "Vines creep along and cover the walls and floor, and a thick damp mist envolopes the room. You hear unfamilar sounds of bugs and animals faintly.");
            }

            if (x == 2 && y ==0)
            {
                Console.WriteLine("You are in a golden brown room --Room 7--(" + (x+1) + ", " + (y+1) + "), there are doors to the north and east of the room.\n" +
                    "Desert");
            }

            if (x == 2 && y == 1)
            {
                Console.WriteLine("You are in a pitch black room --Room 8--(" + (x+1) + ", " + (y+1) + "), there are doors to the north, east, and west of the room.\n" +
                    "You are unable to see anything but yourself and the doors, the room is so dark the color on your clothes almost seem to glow, and you cannot see" +
                    "where the walls meet. The darkness almost makes it seem as if you are floating, and the abyss of black seems to go on for eternity.");
            }

            if (x == 2 && y == 2)
            {
                Console.WriteLine("You are in a light blue room --Room 9--(" + (x+1) + ", " + (y+1) + "), there are doors to the north and west of the room.\n" +
                    "Light fluffy clouds spread across the walls and floors, slowly moving around the room as if they were in the sky, \n" +
                    "A strong, yet gentle breeze constatnly blows throught the room.");
            }

        }

        static string ReadString ( string message, bool required )
        {
            Console.Write(message);
            do
            {
                string input = Console.ReadLine().Trim();

                if (!String.IsNullOrEmpty(input) || !required)
                    return input;

                DisplayError("Nothing is not an answer");

            } while (true);

        }

        static int ReadInt32 ( string message, int minimumValue )
        {
            Console.Write(message);

            do
            {

                var input = Console.ReadLine();

                if (Int32.TryParse(input, out var result) && result >= minimumValue)
                    return result;

                DisplayError("The value must be an intergral value >= " + minimumValue);

            } while (true);

        }

        static void DisplayError ( string message )
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        private static bool HandleQuit ()
        {
            //Display a confermation
            if (ReadBoolean("Are you sure you want to quit, you will lose all your progress (Y/N)? "))
                return true;

            return false;
        }

        private static bool ReadBoolean ( string message )
        {
            Console.Write(message);

            do
            {
                ConsoleKeyInfo input = Console.ReadKey(true);
                if (input.Key == ConsoleKey.Y)
                    return true;
                else if (input.Key == ConsoleKey.N)
                    return false;

            } while (true);

        }

        private static char GetInput ()
        {

            Console.Write("\nWhat do you want to do?-> ");

            while (true)
            {
                string input = Console.ReadLine().Trim();

                switch (input.ToUpper())
                {

                    case "NORTH":
                    case "N": return 'N';

                    case "EAST":
                    case "E": return 'E';

                    case "WEST":
                    case "W": return 'W';

                    case "SOUTH":
                    case "S": return 'S';

                    //  case "RIDDLE":
                    //case "R": return 'R';

                    case "LOOK":
                    case "L": return 'L';

                    case "HELP":
                    case "H": return 'H';

                    case "QUIT":
                    case "Q": return 'Q';
                }

                DisplayError("Not a recognized command");
            };
        }
    }
}
