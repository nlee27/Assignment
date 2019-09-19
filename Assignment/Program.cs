using System;
using System.Collections;
using System.Text;
using System.Text.RegularExpressions;

namespace Assignment
{
    class Program
    {
        static readonly ArrayList lessThan20List = new ArrayList(new string[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" });
        static readonly ArrayList tensList = new ArrayList(new string[] { "", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" });

        static void Main(string[] args)
        {
            var count = 0;

            for (var i = 1; i < 1001; i++)
            {
                var inWords = GetNumberInWords(i);
                var trimmedWords = inWords.Replace(" ", "").Replace("-", "");

                Regex regex = new Regex("[a-z]*");
                var match = regex.Match(trimmedWords);
                count += match.Length;

                Console.WriteLine(i + " " + inWords + " " + count);
            }

            Console.WriteLine();
            Console.WriteLine("Total number letter count : " + count);
            Console.ReadLine();
        }

        private static string GetNumberInWords(int number)
        {
            StringBuilder inWords = new StringBuilder();

            if ((number / 1000) > 0)
            {
                inWords.Append(GetNumberInWords(number / 1000) + " thousand ");
                number = number % 1000;
            }

            if ((number / 100) > 0)
            {
                inWords.Append(GetNumberInWords(number / 100) + " hundred ");
                number = number % 100;
            }

            if (number > 0)
            {
                if (!string.IsNullOrEmpty(inWords.ToString()))
                    inWords.Append("and ");

                if (number < 20)
                {
                    inWords.Append(lessThan20List[number].ToString());
                    return inWords.ToString();
                }                
                
                inWords.Append(tensList[number / 10].ToString());
                number = number % 10;
                if ((number % 10) > 0)
                    inWords.Append("-" + lessThan20List[number].ToString());                
            }

            return inWords.ToString();
        }
    }
}
