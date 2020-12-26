using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Partitioning_Operators
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Example1
            //Retrieves only the first 3 countries of the array.

            string[] countries = { "Australia", "Canada", "Germany", "US", "India", "UK", "Italy" };

            IEnumerable<string> result = countries.Take(3);

            foreach (string country in result)
            {
                Console.WriteLine(country);
            }
            Console.WriteLine(".........................................");

            //...............................................
            //Using SQL like syntax
            //...............................................

            result = (from country in countries
                      select country).Take(3);

            foreach (string country in result)
            {
                Console.WriteLine(country);
            }
            Console.WriteLine(".........................................");

            #endregion

            #region Example2
            //Skips the first 3 countries and retrieves the rest of them

            result = countries.Skip(3);

            foreach (string country in result)
            {
                Console.WriteLine(country);
            }
            Console.WriteLine(".........................................");
            //...............................................
            //Using SQL like syntax
            //...............................................

            result = (from country in countries
                      select country).Skip(3);

            foreach (string country in result)
            {
                Console.WriteLine(country);
            }
            Console.WriteLine(".........................................");
            #endregion Example2

            #region Example3
            //Return countries starting from the beginning of the array
            //until a country name is hit that does not have length greater than 2 characters.

            result = countries.TakeWhile(s => s.Length > 2);

            foreach (string country in result)
            {
                Console.WriteLine(country);
            }
            Console.WriteLine(".........................................");
            #endregion Example3

            #region Example4
            //Skip elements starting from the beginning of the array,
            //until a country name is hit that does not have length greater than 2 characters,
            //and then return the remaining elements.

            result = countries.SkipWhile(s => s.Length > 2);

            foreach (string country in result)
            {
                Console.WriteLine(country);
            }
            Console.WriteLine(".........................................");
            #endregion Example3
            Console.Read();
        }
    }
}
