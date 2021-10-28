//Benjamin West
//Lab2 CharacterCreator
//ITSE 1430
using System;

using BenjaminWest.CharacterCreator;

namespace Benjamin.CharacterCreator
{
    class Program
    {
        static void Main ( string[] args )
        {
            bool done = false;
            Console.WriteLine("Welcome! Please from the options below");

            do
            {
                DisplayMain();
                char choice = GetInput();

                switch (choice)
                {
                    case 'C': CharacterCreation();  break;
                    case 'V': CharacterViewer(); break;
                    case 'E': CharacterEditor(); break;
                    case 'D': CharacterDeletion(); break;
                    case 'Q': done = HandleQuit(); break;
                    default: DisplayError("Unknown option"); break;
                }

            } while (!done);
        }

        static Character s_player = new Character(); 
        private static char GetInput ()
        {

            Console.Write("\nEnter your decision?-> ");

            while (true)
            {
                string input = Console.ReadLine().Trim();

                switch (input.ToUpper())
                {
                    case "A": return 'A';
                    case "B": return 'B';
                    case "C": return 'C';
                    case "D": return 'D';
                    case "E": return 'E';
                    case "S": return 'S';
                    case "F": return 'F';
                    case "I": return 'I';
                    case "V": return 'V';
                    case "N": return 'N';
                    case "P": return 'P';
                    case "Q": return 'Q';
                    case "R": return 'R';


                }

                DisplayError("Not a recognized command");
            };
        }
        /// <summary>
        /// Prints out a custom error message of your choosing
        /// </summary>
        /// <param name="message"></param>
        static void DisplayError ( string message )
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        /// <summary>
        /// Promps user if they wish to exit the program
        /// </summary>
        /// <returns></returns>
        private static bool HandleQuit ()
        {
            //Display a confermation
            if (ReadBoolean("Are you sure you want to quit?(Y/N) "))
                return true;

            return false;
        }
        /// <summary>
        /// Reads boolean inputs
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Reads Interger inputs
        /// </summary>
        /// <param name="message"></param>
        /// <param name="minimumValue"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Reads String inputs
        /// </summary>
        /// <param name="message"></param>
        /// <param name="required"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Prints the Main Option Menu
        /// </summary>
        private static void DisplayMain()
        {
            Console.WriteLine("\n(C)reate New Character" +
                "\n(V)iew Character" +
                "\n(E)dit Character" +
                "\n(D)elete Character" +
                "\n(Q)uit");
        }
        /// <summary>
        /// Creates a character
        /// </summary>
        private static void CharacterCreation()
        {
            var newGuy = new Character();
            bool done = false;

            do
            {

                newGuy.Name = ReadString("Enter your characters name: ", true).Trim();

                newGuy.Profession = ChooseProf(newGuy);

                newGuy.Race = ChooseRace(newGuy);

                newGuy = ChooseStats(newGuy);

                newGuy.StatSheet();
                if (ReadBoolean("Is this who you are?(Y/N)"))
                {
                    s_player = newGuy;
                    break;
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nThen let's try again");
                Console.ResetColor();
            } while (!done);

        }
        /// <summary>
        /// Deletes a character
        /// </summary>
        private static void CharacterDeletion()
        {
            if (s_player?.Name == null)
                Console.WriteLine("You have yet to make a character you witless twat");

            if (s_player?.Name != null)
                if (ReadBoolean("Are you sure you want to delete your character?(Y/N)"))
                    s_player = null;

        }
        /// <summary>
        /// Allows you to view a character
        /// </summary>
        private static void CharacterViewer()
        {
            if (s_player?.Name != null)
                s_player.StatSheet();
            else
                Console.WriteLine("You haven't created a character nitwad");
        }
        /// <summary>
        /// Allows you to edit a character
        /// </summary>
        private static void CharacterEditor()
        {
            char input;
            bool done = false;
            if (s_player?.Name != null)
            {
                Console.WriteLine("This is your character");
                do
                {
                    s_player.StatSheet();
                    Console.WriteLine("(N)ame\n(P)rofession\n(R)ace\n(S)tats\n(D)one");
                    Console.WriteLine("What would you like to change? -> ");
                    input = GetInput();
                    switch (input)
                    {
                        case 'N':
                        s_player.Name = ReadString("What do you want to change your name to? ->", true); break;

                        case 'P': s_player.Profession = ChooseProf(s_player); break;

                        case 'R': s_player.Race = ChooseRace(s_player); break;

                        case 'S': s_player = ChooseStats(s_player); break;

                        case 'D': break;

                    }

                    if (input == 'D')
                        if(ReadBoolean("Are you sure your done?(Y/N)->"))
                        break;
    
                }while(!done);
            }

            else
                Console.WriteLine("And how exactly are you going to edit all that nothing?");
        }
        /// <summary>
        /// Prompts user to choose profession
        /// </summary>
        /// <param name="newGuy"></param>
        /// <returns></returns>
        private static string ChooseProf(Character newGuy)
        {
            char input;
            bool done = false;
            do
            {
                Console.WriteLine("Now please choose your profession from the following options");
                Console.WriteLine("(A) - Fighter\n(B) - Mage\n(C) - Thief");
                input = GetInput();
                switch (input)
                {
                    case 'A': newGuy.Profession = "Fighter"; break;
                    case 'B': newGuy.Profession = "Mage"; break;
                    case 'C': newGuy.Profession = "Thief"; break;
                    default: DisplayError("Unknown option"); break;
                }
                if (newGuy.Profession != "")
                    break;

            } while (!done);

            return newGuy.Profession;
        }
        /// <summary>
        /// Prompts user to choose Race
        /// </summary>
        /// <param name="newGuy"></param>
        /// <returns></returns>
        private static string ChooseRace(Character newGuy)
        {
            bool done = false;
            char input;
            do
            {
                Console.WriteLine("Now please choose you race from the following options");
                Console.WriteLine("(A) - Human\n(B) - Homunculus\n(C) - Elf\n(D) - Orc\n(E) - Ancient");
                input = GetInput();
                switch (input)
                {
                    case 'A': newGuy.Race = "Human"; break;
                    case 'B': newGuy.Race = "Homunculus"; break;
                    case 'C': newGuy.Race = "Elf"; break;
                    case 'D': newGuy.Race = "Orc"; break;
                    case 'E': newGuy.Race = "Ancient"; break;
                    default: DisplayError("Unknown option"); break;
                }
                if (newGuy.Race != "")
                    break;
            } while (!done);

            return newGuy.Race;
        }
        /// <summary>
        /// Prompts user to choose stats
        /// </summary>
        /// <param name="newGuy"></param>
        /// <returns></returns>
        private static Character ChooseStats(Character newGuy)
        {
            bool done = false;
            char input;
            int charPoints = 10;
            int intput;
            newGuy.Str=10;
            newGuy.Agl=10;
            newGuy.Fort=10;
            newGuy.Int=10;
            newGuy.Cha=10;

            do
            {
                Console.WriteLine("Now please allocate your stat points. You must allocate all of them before moving on");
                Console.WriteLine("(S)trength - " + newGuy.Str);
                Console.WriteLine("(A)gility - " + newGuy.Agl);
                Console.WriteLine("(F)ortitute - " + newGuy.Fort);
                Console.WriteLine("(I)ntelligence - " + newGuy.Int);
                Console.WriteLine("(C)harisma - " + newGuy.Cha);
                Console.WriteLine("Start Over - (V)");
                Console.WriteLine("(D)one");

                Console.WriteLine("Character points = " + charPoints);
                input = GetInput();
                switch (input)
                {
                    case 'S':
                    if (charPoints > 0)
                    {
                        intput = ReadInt32("\nBy how much? ->", 0);
                        if (intput > charPoints)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("To rich for your blood bucko, spend within your limit");
                            Console.ResetColor();
                            break;
                        }
                        newGuy.Str = newGuy.Str + intput; charPoints = charPoints - intput;
                    }
                    break;

                    case 'A':
                    if (charPoints > 0)
                    {
                        intput = ReadInt32("\nBy how much? ->", 0);
                        if (intput > charPoints)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("To rich for your blood bucko, spend within your limit");
                            Console.ResetColor();
                            break;
                        }
                        newGuy.Agl = newGuy.Agl + intput; charPoints = charPoints - intput;
                    }
                    break;

                    case 'F':
                    if (charPoints > 0)
                    {
                        intput = ReadInt32("\nBy how much? ->", 0);
                        if (intput > charPoints)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("To rich for your blood bucko, spend within your limit");
                            Console.ResetColor();
                            break;
                        }
                        newGuy.Fort = newGuy.Fort + intput; charPoints = charPoints - intput;
                    }
                    break;

                    case 'I':
                    if (charPoints > 0)
                    {
                        intput = ReadInt32("\nBy how much? ->", 0);
                        if (intput > charPoints)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("To rich for your blood bucko, spend within your limit");
                            Console.ResetColor();
                            break;
                        }
                        newGuy.Int = newGuy.Int + intput; charPoints = charPoints - intput;
                    }
                    break;

                    case 'C':
                    if (charPoints > 0)
                    {
                        intput = ReadInt32("\nBy how much? ->", 0);
                        if (intput > charPoints)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("To rich for your blood bucko, spend within your limit");
                            Console.ResetColor();
                            break;
                        }
                        newGuy.Cha = newGuy.Cha + intput; charPoints = charPoints - intput;
                    }
                    break;

                    case 'V':
                    newGuy.Str = 10; newGuy.Agl = 10; newGuy.Fort = 10;
                    newGuy.Int = 10; newGuy.Cha = 10; charPoints  = 10; break;
                    case 'D': break;
                    default: DisplayError("Unknown option"); break;
                }
                if (input == 'D' && charPoints == 0)
                    break;
            } while (!done);
            return newGuy;
        }
    }
}
