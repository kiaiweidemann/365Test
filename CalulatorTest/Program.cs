using System;
using System.Text.RegularExpressions;

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
         * on string and can handle string with numbers
         * separated by ',' or \n. and you can define a custom
         * single character delimiter or a multicharacter 
         * delimiter with these two formats: 
         *  //{delimiter}\n{numbers}
         *  //[{delimiter}]\n{numbers}
         * Important Note: Negative number are now tabboo
         * 
         */

        public static int Add(string input)
        {
            if (string.IsNullOrEmpty(input))
                return 0;
            //try first method
            string pattern = @"^//(.)\n(.*)$";
            Match match = Regex.Match(input, pattern);

            string customDelimiter = ",";
            string numbersStr = input;

            if (match.Success)
            {  //try the first mesthod first
                customDelimiter = match.Groups[1].Value;
                numbersStr = match.Groups[2].Value;
            }
            else
            {   //try the second method
                pattern = @"^//\[([\s\S]+)\]\n(.*)$";
                match = Regex.Match(input, pattern);
                if (match.Success)
                { 
                    customDelimiter = match.Groups[1].Value;
                    numbersStr = match.Groups[2].Value;
                }
            }

            string[] numbers = numbersStr.Split(new string[] {",", "\x0A", customDelimiter},StringSplitOptions.RemoveEmptyEntries);

            List<int> negatives = new List<int>();
            int sum = 0;
            foreach (string num in numbers)
            {
                if (int.TryParse(num, out int parsedNum))
                {
                    if (parsedNum < 0)
                        negatives.Add(parsedNum);
                    else if (parsedNum <= 1000) // Ignore numbers greater than 1000
                        sum += parsedNum;
                }
            }
            if (negatives.Count > 0)
            {
                throw new ArgumentException("We no longer allow those negatives: " + string.Join(",", negatives));
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
