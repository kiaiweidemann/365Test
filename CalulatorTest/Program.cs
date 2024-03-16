using System;

namespace CalculatorTest
{
    /*
     * This is the Calculator class to test skills,
     * a challenge if you will. A challenge is kind 
     * of awesome. It is intended to perform one
     * addition operation. 
     */

    public class Calculator
    {
        /*
         * Here is our one addition operation. it takes
         * on string and can handle string with 0-2 numbers
         * separated by ','. 
         */

        public static int Add(string input)
        {
            if (string.IsNullOrEmpty(input))
                return 0;

            string[] numbers = input.Split(',');

            int sum = 0;
            foreach (string num in numbers)
            {
                if (int.TryParse(num, out int parsedNum))
                    sum += parsedNum;
            }

            return sum;
        }
    }
}

namespace CalculatorTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter numbers separated by commas:");
                string input = Console.ReadLine();
                int result = Calculator.Add(input);
                Console.WriteLine("Result: " + result);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
