using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CastAndOfTypeOperators
{
    class Program
    {
        static void Main(string[] args)
        {
            #region CastOperator
            ArrayList list = new ArrayList();
            list.Add(1);
            list.Add(2);
            list.Add(3);

            // The following item causes an exception
            // list.Add("ABC");

            IEnumerable<int> result = list.Cast<int>();

            foreach (int i in result)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine(".......................................");
            #endregion CastOperator

            #region OfTypeOperator
            ArrayList list1 = new ArrayList();
            list1.Add(1);
            list1.Add(2);
            list1.Add(3);
            list1.Add("4");
            list1.Add("ABC");

            IEnumerable<int> result1 = list1.OfType<int>();

            foreach (int i in result1)
            {
                Console.WriteLine(i);
            }
            #endregion OfTypeOperator

            Console.Read();
        }
    }
}
