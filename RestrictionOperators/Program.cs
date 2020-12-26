using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestrictionOperators
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Example1
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            IEnumerable<int> evenNumbers = numbers.Where(num => num % 2 == 0);

            foreach (int evenNumber in evenNumbers)
            {
                Console.WriteLine(evenNumber);
            }

            //With SQL like syntax
            evenNumbers = from num in numbers
                          where num % 2 == 0
                          select num;

            foreach (int evenNumber in evenNumbers)
            {
                Console.WriteLine(evenNumber);
            }

            #endregion Example1

            #region Example2
            Func<int, bool> predicate = num => num % 2 == 0;
            evenNumbers = numbers.Where(predicate);

            foreach (int evenNumber in evenNumbers)
            {
                Console.WriteLine(evenNumber);
            }
            #endregion Example2

            #region Example3

            evenNumbers = numbers.Where(num => IsEven(num));

            foreach (int evenNumber in evenNumbers)
            {
                Console.WriteLine(evenNumber);
            }
            #endregion Example3

            #region Example4
            //get the index positions
            var result = numbers
                .Select((num, index) => new { Number = num, Index = index })
                .Where(x => x.Number % 2 == 0)
                .Select(x => x);

            foreach (var item in result)
            {
                Console.WriteLine("Number : {0}, Index : {1}", item.Number, item.Index);
            }
            #endregion Example4
            Console.Read();
        }

        public static bool IsEven(int num)
        {
            return num % 2 == 0;
        }
    }
}
