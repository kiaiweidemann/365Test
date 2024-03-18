using System;
using System.Diagnostics.CodeAnalysis;
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
         
            List<string> delimiters = new List<string>();
            //string customDelimiter = ",";
            string numbersStr = input;

            //try first method customer delimiter method //{delimiter}\n{numbers}
            string pattern = @"^//(.)\n(.*)$";
            Match match = Regex.Match(input, pattern);

            if (match.Success)
            {  
                delimiters.Add(match.Groups[1].Value);
                numbersStr = match.Groups[2].Value;
            }

            //try 2nd/3rd method customer delimiter method 
            //  //[{delimiter}]\n{numbers}
            //  //[{delimiter1}][{delimiter2}]...\n{numbers}
            if (numbersStr.Equals(input))
            {
                pattern = @"^//((?:\[.*?\])+)\n(.*)$";
                match = Regex.Match(input, pattern);
                if (match.Success)
                {
                    string delimiterString = match.Groups[1].Value;
                    numbersStr = match.Groups[2].Value;

                    //let's get all those delimiters
                    delimiters = Regex.Matches(delimiterString, @"\[(.*?)\]")
                        .Cast<Match>()
                        .Select(m => m.Groups[1].Value)
                        .ToList();
                }
            }

            //add the defaults to the list
            delimiters.Add(",");
            delimiters.Add("\x0A");

            string[] numbers = numbersStr.Split(delimiters.ToArray(),StringSplitOptions.RemoveEmptyEntries);

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
