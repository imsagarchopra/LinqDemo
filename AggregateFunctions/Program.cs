using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AggregateFunctions
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Example1
            int[] Numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            int smallestNumber = Numbers.Min();
            int smallestEvenNumber = Numbers.Where(n => n % 2 == 0).Min();

            int largestNumber = Numbers.Max();
            int largestEvenNumber = Numbers.Where(n => n % 2 == 0).Max();

            int sumOfAllNumbers = Numbers.Sum();
            int sumOfAllEvenNumbers = Numbers.Where(n => n % 2 == 0).Sum();

            int countOfAllNumbers = Numbers.Count();
            int countOfAllEvenNumbers = Numbers.Where(n => n % 2 == 0).Count();

            double averageOfAllNumbers = Numbers.Average();
            double averageOfAllEvenNumbers = Numbers.Where(n => n % 2 == 0).Average();

            Console.WriteLine("Smallest Number = " + smallestNumber);
            Console.WriteLine("Smallest Even Number = " + smallestEvenNumber);

            Console.WriteLine("Largest Number = " + largestNumber);
            Console.WriteLine("Largest Even Number = " + largestEvenNumber);

            Console.WriteLine("Sum of All Numbers = " + sumOfAllNumbers);
            Console.WriteLine("Sum of All Even Numbers = " + sumOfAllEvenNumbers);

            Console.WriteLine("Count of All Numbers = " + countOfAllNumbers);
            Console.WriteLine("Count of All Even Numbers = " + countOfAllEvenNumbers);

            Console.WriteLine("Average of All Numbers = " + averageOfAllNumbers);
            Console.WriteLine("Average of All Even Numbers = " + averageOfAllEvenNumbers);
            #endregion Example1

            #region Example2

            string[] countries = { "India", "USA", "UK" };

            int minCount = countries.Min(x => x.Length);
            int maxCount = countries.Max(x => x.Length);

            Console.WriteLine
                   ("The shortest country name has {0} characters in its name", minCount);
            Console.WriteLine
                   ("The longest country name has {0} characters in its name", maxCount);
            #endregion Example2

            #region AggregateFunction

            #region Example1
            string[] countrys = { "India", "US", "UK", "Canada", "Australia" };

            //.....................................................................
            // WITHOUT LINQ
            //.....................................................................
            string result = string.Empty;
            for (int i = 0; i < countrys.Length; i++)
            {
                result = result + countrys[i] + ", ";
            }

            int lastIndex = result.LastIndexOf(",");
            result = result.Remove(lastIndex);

            Console.WriteLine(result);

            //.....................................................................
            //WITH LINQ
            //.....................................................................
            string reslt = countrys.Aggregate((a, b) => a + ", " + b);
            Console.WriteLine(reslt);

            #endregion Example1

            #region Example2

            //.....................................................................
            // WITHOUT LINQ
            //.....................................................................

            int[] Numbrs = { 2, 3, 4, 5 };

            int res = 1;
            foreach (int i in Numbrs)
            {
                res = res * i;
            }

            Console.WriteLine(res);

            //.....................................................................
            //WITH LINQ
            //.....................................................................

            res = Numbrs.Aggregate((a, b) => a * b);
            Console.WriteLine(res);
            #endregion

            #region Example3

            //.....................................................................
            // WITHOUT LINQ
            //.....................................................................



            //.....................................................................
            //WITH LINQ
            //.....................................................................
            #endregion Example3

            #endregion AggregateFunction

            Console.Read();
        }
    }
}
