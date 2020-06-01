using System;

namespace part2_b
{
    class Part2_b
    {
        static string generate_number(Int64 num)
        {
            string str = Convert.ToString(num, 2);
            str = str.PadLeft(64, '0');
            return str;
        }
        static void Main(string[] args)
        {
            Console.Write("Enter a first number: ");
            string remainder = Console.ReadLine();
            Console.Write("Enter a second number: ");
            string divisior = Console.ReadLine();
            Int64 rem64 = Int32.Parse(remainder);
            Int64 div64 = Int32.Parse(divisior);
            div64 <<= 32;
            bool remToOne = false;
            for (int i = 0; i <= 32; i++)
            {
                Console.WriteLine($"\nStep {i + 1} ");
                if (div64 <= rem64)
                {
                    rem64 -= div64;
                    remToOne = true;
                    Console.WriteLine("Divisior lediv64 than remainder");
                }
                else
                    Console.WriteLine("Divisior more than remainder");
                Console.WriteLine("Shift remainder left one bit");
                rem64 <<= 1;
                if (remToOne)
                {
                    remToOne = false;
                    rem64 |= 1;
                    Console.WriteLine("Set remainder right bit to 1");
                }
                Console.WriteLine($"Remaider: {generate_number(rem64)}");
                Console.WriteLine($"Divisior: {generate_number(div64)}");
            }
            long quotient = rem64 & ((long)Math.Pow(2, 33) - 1);
            long rem = rem64 >> 33;
            Console.WriteLine("\n\nQuotient: " + generate_number(quotient) +
            " ( " + quotient + " )\n");

            Console.WriteLine("Remainder: " + generate_number(rem) +
            " ( " + rem + " )");
        }
    }
}
