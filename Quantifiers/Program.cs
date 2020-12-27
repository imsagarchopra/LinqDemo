using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantifiers
{
    class Program
    {
        static void Main(string[] args)
        {
            #region All
            //Returns true, as all the numbers are less than 10

            int[] numbers = { 1, 2, 3, 4, 5 };

            var result = numbers.All(x => x < 10);

            Console.WriteLine(result);
            Console.WriteLine("...........................................");
            #endregion All

            #region Any
            // Returns true as the sequence contains at least one element
            result = numbers.Any();
            Console.WriteLine(result);
            Console.WriteLine("...........................................");

            //Returns false as the sequence does not contain any element
            //that satisfies the given condition(No element in the sequence is greater than 10)

            result = numbers.Any(x => x > 10);

            Console.WriteLine(result);
            Console.WriteLine("...........................................");

            #endregion Any

            #region Contains
            //Returns true as the sequence contains number 3.
            //In this case the default equality comparer is used.

            result = numbers.Contains(3);

            Console.WriteLine(result);
            Console.WriteLine("...........................................");

            // Returns true. In this case we are using an alternate equality comparer (StringComparer)
            //for the comparison to be case-insensitive.
            string[] countries = { "USA", "INDIA", "UK" };

            result = countries.Contains("india", StringComparer.OrdinalIgnoreCase);

            Console.WriteLine(result);
            Console.WriteLine("...........................................");
            #endregion Contains
            Console.Read();
        }
    }
}
