using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string strName = "test";

            string result1 = StringHelper.ChangeFirstLetterCase(strName);
            
            string result2 = strName.ChangeFirstLetterCase();

            Console.WriteLine(result1);
            Console.WriteLine(result2);
            Console.Read();
        }
    }
}
