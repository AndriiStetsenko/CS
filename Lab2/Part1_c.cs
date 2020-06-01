using System;

namespace part1_c
{
    class Part1_c
    {
        static void Main(string[] args)
        {
            Console.Write("First number: ");
            Int32 multiplicand = Convert.ToInt32(Console.ReadLine());
            Console.Write("Second number: ");
            Int32 multiplier = Convert.ToInt32(Console.ReadLine());
            Int64 product = (long)multiplier;
            Int64 support = (long)multiplicand;
            support <<= 32;

            Console.WriteLine("Multiplicand: " + Convert.ToString(multiplicand, 2).PadLeft(32, '0'));
            Console.WriteLine("Multiplier: " + Convert.ToString(multiplier, 2).PadLeft(32, '0'));
            Console.WriteLine("*Assigning multiplier to right 32 bits of product*\nProduct: " + Convert.ToString(multiplier, 2).PadLeft(32, '0'));

            for (int i = 0; i < 32; i++)
            {
                if ((product & 1) == 1)
                {
                    Console.WriteLine("*Last bit in product is 1 - adding*");
                    product += support;
                }
                Console.WriteLine("* Shifting product right*");
                product >>= 1;
                Console.WriteLine(Convert.ToString(product, 2).PadLeft(64, '0'));
            }
            Console.WriteLine("Result = " + product);
        }
    }
}
