using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerationOperators
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Range
            IEnumerable<int> evenNumbers = Enumerable.Range(1, 10);

            foreach(int i in evenNumbers)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("..................................................");
            #endregion Range

            #region Repeat
            IEnumerable<string> result = Enumerable.Repeat("Hello", 5);

            foreach(string str in result)
            {
                Console.WriteLine(str);
            }
            Console.WriteLine("..................................................");
            #endregion Repeat

            #region Empty
            IEnumerable<int> result1 = Enumerable.Empty<int>();

            Console.WriteLine($"Count = {result1.Count()}");
            #endregion Empty

            Console.Read();
        }
    }
}
