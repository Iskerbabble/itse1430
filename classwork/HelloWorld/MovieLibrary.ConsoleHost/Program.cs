using System;

namespace MovieLibrary.ConsoleHost
{
    class Program
    {
        static void Main ( string[] args )
        {
            bool done = false;

            do
            {
                char choice = GetInput();
                //if (choice == 'Q')
                //    done = HandleQuit();
                //else if (choice == 'A')
                //    AddMovie();
                //else if (choice == 'V')
                //    ViewMovie();
                //else if (choice == 'D')
                //    DeleteMovie();
                //else
                //    Console.WriteLine("Unkown option");

                switch (choice)
                {
                    case 'Q': done = HandleQuit(); break;
                    case 'A': AddMovie(); break;
                    case 'V': ViewMovie(); break;
                    case 'D': DeleteMovie(); break;
                    default: DisplayError("Unknown option"); break;

                }

            } while (!done);

            //TODO: handle additional stuff



        }

        private static bool HandleQuit ()
        {
            //Display a confermation
            if (ReadBoolean("Are you sure you want to quit (Y/N)? "))
                return true;

            return false;
        }

        static string title;
        static string description;
        static int runLength;
        static int releaseYear;
        static double reviewRating;
        static string rating;
        static bool isClassic;

        static void AddMovie ()
        {
            title = ReadString("Enter the Movie title: ", true);
            description = ReadString("Enter the optional description: ", false);

            runLength = ReadInt32("Enter run length (in minutes): ", 0);
            releaseYear = ReadInt32("Enter the release year (min 1900): ", 1900);

            //reviewRating;
            rating = ReadString("Enter the MPAA rating: ", false);
            isClassic = ReadBoolean("Is this a classic (Y/N)? "); // Optional

        }

        static void ViewMovie ()
        {
            if(String.IsNullOrEmpty(title))
            {
                Console.WriteLine("No movie available");
                return;
            }

            Console.WriteLine($"title) ({ releaseYear}");
            Console.WriteLine($"Runtime: {runLength} mins");
            Console.WriteLine($"MPAA Rating: {rating}");
            Console.WriteLine($"Classic: {isClassic}");
            Console.WriteLine(description);
        }

        private static void DeleteMovie ()
        {
            if (!ReadBoolean("Are you sure (Y/N)? "))
                return;

            title = null;
        }

        static int ReadInt32 ( string message, int minimumValue )
        {
            Console.Write(message);

            do
            {
                //string input = Console.ReadLine();

                var input = Console.ReadLine();

                //int result = Int32.TryParse(input, result);
                //int result;

                // if (Int32.TryParse(input, out result))
                //if(result >= minimumValue)

                if (Int32.TryParse(input, out var result) && result >= minimumValue)
                    return result;

                DisplayError("The value must be an intergral value >= " + minimumValue);

            } while (true);

            //return -1;
        }

        static string ReadString ( string message, bool required )
        {
            Console.Write(message);
            do
            {
                string input = Console.ReadLine().Trim();

                if (!String.IsNullOrEmpty(input) || !required)
                    return input;

                DisplayError("Value is required");

            } while (true);

        }

        static void DisplayError ( string message )
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
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

            //TODO: Input Validation
            // not needed anymore return false;

        }

        static char GetInput ()
        {
            Console.WriteLine("Movie Library");
            Console.WriteLine("---------------");
            Console.WriteLine("".PadLeft(15, '-'));


            Console.WriteLine("Add Movie (A)");
            Console.WriteLine("View (V)");
            Console.WriteLine("Delete (D)");
            Console.WriteLine("Quit (Q)");

            //TODO: Input validation
            //GetInput

            while (true)
            {
                string input = Console.ReadLine().Trim();

                

               // if (input == "Q")
                  //  return 'Q';
               // else if (input == "A")
                //    return 'A';
                //else if (input == "V")
                 //   return 'V';
                //else if (input == "D")
                 //   return 'D';
                switch (input.ToUpper())
                {
                    case "q":
                    case "Q": return 'Q';

                    case "a":
                    case "A": return 'A';

                    case "v":
                    case "V": return 'V';

                    case "d":
                    case "D": return 'D';

                    //default;
                }

                DisplayError("Invalid input");
            };

            //return default(char); //default
        }

    }
}
