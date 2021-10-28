//Benjamin West
//Lab2 CharacterCreator
//ITSE 1430
using System;

namespace BenjaminWest.CharacterCreator
{
    public class Character
    {
        /// <summary>
        /// Name of the character
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Profession of the character
        /// </summary>
        public string Profession { get; set; }
        /// <summary>
        /// Race of the character
        /// </summary>
        public string Race { get; set; }
        /// <summary>
        /// Strength stat of the character
        /// </summary>
        public int Str { get; set; } = 10;
        /// <summary>
        /// Agility stat of the character
        /// </summary>
        public int Agl { get; set; } = 10;
        /// <summary>
        /// Fortitude stat of the character
        /// </summary>
        public int Fort { get; set; } = 10;
        /// <summary>
        /// Intelligence stat of the character
        /// </summary>
        public int Int { get; set; } = 10;
        /// <summary>
        /// Charisma stat of the character
        /// </summary>
        public int Cha { get; set; } = 10;

        /// <summary>
        /// Prints out all relevant information about a character
        /// </summary>
        public void StatSheet()
        {
            
            Console.WriteLine("\nName: " + Name + "\nProfession: " + Profession +
                "\nRace: " + Race);
            Console.WriteLine("Strength - " + Str);
            Console.WriteLine("Agility - " + Agl);
            Console.WriteLine("Fortititude - " + Fort);
            Console.WriteLine("Intelligence - " + Int);
            Console.WriteLine("Charisma - " + Cha);
        }
       

        

    }
}
