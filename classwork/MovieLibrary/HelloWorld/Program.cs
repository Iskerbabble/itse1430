using System;
using System.Text;

namespace HelloWorld
{
    class Program
    {
        static void Main ( string[] args )
        {
            //single line
            int xyz;
            Console.WriteLine("Hello World!");

            sbyte code = 10;
            short port = 1234;
            int hours = 45;
            long debtPayBackInYears = 10000;

            byte errorCode = 0xAF;
            ushort errorPort = 0x145;
            uint unpaidHours = 0;

            double hoursWorked = 80.9;
            decimal payRate = 12.50M;

            char letter = 'A';
            string name = "Ben";

            //Not primative 
            DateTime today = DateTime.Now;
            TimeSpan interval = TimeSpan.FromMinutes(10);

            static void DemoLogicalOperators()
            {
                //Logical AND - true if both operands are true
                //logical OR - true if either operand is true

                //NOT ! - inverts expression

            }

            static void DemoRelationalOperators ()
            {
                int x = 10, y = 20;

                bool isLessThan = x < y;
                bool isLessThanOrEqualTo = x <= y;

                bool isGreaterThan = x > y;
                bool isGreaterThanOrEqualTo = x >= y;

                bool isEqual = x == y;
                bool isNotEqual = x != y;
            }

           static void DemoCombinationOperators ()
            {
                int x = 10;

                x += 10; // x = x+10
                x -= 10; // x = x-10;
                x *= 3; // x = x*3;
                x /= 5; // x = x/5
                x %= 2; // x = x%2
            }

            static void DemoPrefixPostfixOperators ()
            {
                int x = 10, y;

                //Prefix evaluates then assigns
                y = ++x;
                y = --x;

                //Postfix assigns then evaluates
                y = x++;
                y = x--;


            }

            static void DemoAssignmentOperator ()
            {
                int x;
                int y;
                int z;

                x = 10;
                y = 10;
                z = 10;

                // left associative operators (E1 to E2) => E1, E2 op
                //right associative operators

                y = x = y = z = 20; //x = (y = (z = 20))
            }

            static void ConditionalOperator()
            {
                int grade = 70;

                string passStatus;

                if (grade < 60)
                    passStatus = "Not Passing";
                 else
                    passStatus = "Passing";

                //Terninary - operands
                // E(bool) ?E(True) : E(false)

                string passStatus2 = (grade < 60) ? "Not Passing" : "Passing";
            }

            static void DemoStrings()
            {
                string firstName = "Ben";
                // Case sensative
                bool isBen = firstName == "Ben";

                //String literals \? only work in string literals
                // \n newline
                // \t horizontal tab
                // \\ literal \
                // \" double quote
                // \' character literal, single quote
                string literall = "Hello World";
                literall = "Hello\nWorld";

                //String length - >= how many characters
                int length = literall.Length;

                //Empty string
                string emptyString = ""; //.length = 0;
                string emptyString2 = String.Empty; // Length 0
                bool areEmptyStringsEqual = String.Empty == ""; // True 

                //null != empty string
                // default value for a string is null
                string nullString = null;
                bool areEqualNull = "" == null; // false

                // string is the universal type in C#
                // all expressions are convertable to string using .Tostring
                string asString = length.ToString(); // length as a string
                asString = 10.ToString(); // 10
                asString = areEqualNull.ToString(); // false


                //comparison
                int year = 2021;
                string value1 = "Hello", value2 = "hello";
                bool areEqual;
                areEqual = value1 == value2;
                areEqual = String.Compare(value1, value2) == 0; //prefered

                bool compareCaseInsensitive = value1.ToUpper() == value2.ToUpper();

                //Concatenation
                string firstName1 = "Bob";
                string lastName1 = "Smith";
                string name = firstName1 + " " + lastName1; // Bob Smith
                String.Concat(firstName1, " ", lastName1, " ", year); // same as upper

                var builder = new StringBuilder();
                builder.Append(firstName);
                builder.Append(" ");
                builder.Append(lastName1);
                builder.Append(" ");
                builder.Append(year);
                name = builder.ToString();

                name = String.Join(" ", firstName1, lastName1, year);

                //Misc
                bool startsWithB = name.StartsWith("B");
                startsWithB = name.StartsWith("B", StringComparison.CurrentCultureIgnoreCase);

                //empty strings

                bool isEmpty;
                isEmpty = name == ""; // not always going to work properly
                isEmpty = name.Length == 0; //will crash if null

                //handle null
                isEmpty = (name != null) ? name == "" : true;
                isEmpty = name == null || name == "";
                isEmpty = (name != null) ? name.Length == 0 : true;
                isEmpty = String.IsNullOrEmpty(name); // prefered

                //C style formating
                name = String.Format("Hello {0} {1}, the year is {2}.", firstName1, lastName1, year);

                decimal price = 8.75M;
                string priceString = price.ToString(); // 8.75000
                priceString = price.ToString("C"); // Money
                priceString = price.ToString("N6"); //8.7500
                priceString = String.Format("{0:C}", price); //

                //String interpolation - way to go
                name = $"Hello {firstName1} {lastName1}, the year is {year}.";


            }

        }
    }
}
