using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequenceEqualOperator
{
    class Program
    {
        //For 2 sequences to be equal
        //1. Both the sequences should have same number of elements and
        //2. Same values should be present in the same order in both the sequences
        static void Main(string[] args)
        {
            #region Example1
            //SequenceEqual() returns true.

            string[] countries1 = { "USA", "India", "UK" };
            string[] countries2 = { "USA", "India", "UK" };

            var result = countries1.SequenceEqual(countries2);

            Console.WriteLine("Are Equal = " + result);
            Console.WriteLine("..............................................");
            #endregion Example1

            #region Example2
            //SequenceEqual() returns false, as the default comparison is case sensitive. 

            string[] countries3 = { "USA", "India", "UK" };
            string[] countries4 = { "usa", "india", "uk" };

            result = countries3.SequenceEqual(countries4);

            Console.WriteLine("Are Equal = " + result);
            Console.WriteLine("..............................................");
            #endregion Example2

            #region Example3
            //If we want the comparison to be case-insensitive,
            //then use the other overloaded version of SequenceEqual() method
            //to which we can pass an alternate comparer.       

            result = countries3.SequenceEqual(countries4, StringComparer.OrdinalIgnoreCase);

            Console.WriteLine("Are Equal = " + result);
            Console.WriteLine("..............................................");
            #endregion Example3

            #region Example4
            //SequenceEqual() returns false. This is because, although both the sequences contain same data,
            //the data is not present in the same order.

            string[] countries5 = { "USA", "INDIA", "UK" };
            string[] countries6 = { "UK", "INDIA", "USA" };

            result = countries5.SequenceEqual(countries6);

            Console.WriteLine("Are Equal = " + result);
            Console.WriteLine("..............................................");
            #endregion Example4

            #region Example5
            //: To fix the problem in Example 4, use OrderBy() to sort data in the source sequences.

            result = countries5.OrderBy(c => c).SequenceEqual(countries6.OrderBy(c => c));

            Console.WriteLine("Are Equal = " + result);
            #endregion Example5

            #region Example6
            #endregion Example6
            Console.Read();
        }
    }
}
