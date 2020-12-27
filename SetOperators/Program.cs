using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetOperators
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Distinct
            #region Example1
            //Return distinct country names.
            //In this example the default comparer is being used and the comparison is case-sensitive,
            //so in the output we see country USA 2 times. 

            string[] countries = { "USA", "usa", "INDIA", "UK", "UK" };

            var result = countries.Distinct();

            foreach (var v in result)
            {
                Console.WriteLine(v);
            }
            Console.WriteLine("...........................................................");
            #endregion Example1

            #region Example2
            //For the comparison to be case-insensitive,
            //use the other overloaded version of Distinct() method to which we can pass a class
            //that implements IEqualityComparer as an argument.
            //In this case we see country USA only once in the output.
           
            result = countries.Distinct(StringComparer.OrdinalIgnoreCase);

            foreach (var v in result)
            {
                Console.WriteLine(v);
            }
            Console.WriteLine("...........................................................");
            #endregion Example2

            #region Example3
            /*When comparing elements, Distinct() works in a slightly different manner with complex types
             * like Employee, Customer etc.
             * Notice that in the output we don't get unique employees.
             * This is because, the default comparer is being used which will just check for object references
             * being equal and not the individual property values.*/

            List<Employee> list = new List<Employee>()
            {
                new Employee { ID = 101, Name = "Mike"},
                new Employee { ID = 101, Name = "Mike"},
                new Employee { ID = 102, Name = "Mary"}
            };

            var result1 = list.Distinct();

            foreach (var v in result1)
            {
                Console.WriteLine(v.ID + "\t" + v.Name);
            }
            Console.WriteLine("...........................................................");
            #endregion Example3

            #region Example4
            /*Using the overloaded version of Distinct() method to which we can pass a custom class
             * that implements IEqualityComparer*/

            result1 = list.Distinct(new EmployeeComparer());

            foreach (var v in result1)
            {
                Console.WriteLine(v.ID + "\t" + v.Name);
            }
            Console.WriteLine("...........................................................");
            #endregion Example4

            #region Example5
            /*Override Equals() and GetHashCode() methods in Employee class*/

            result1 = list.Distinct();

            foreach (var v in result1)
            {
                Console.WriteLine(v.ID + "\t" + v.Name);
            }
            Console.WriteLine("...........................................................");
            #endregion Example5

            #region Example6
            /* Project the properties into a new anonymous type, which overrides Equals() and GetHashCode() methods*/

            var result2 = list.Select(x => new { x.ID, x.Name }).Distinct();

            foreach (var v in result2)
            {
                Console.WriteLine(v.ID + "\t" + v.Name);
            }
            Console.WriteLine("...........................................................");
            #endregion Example6

            #endregion Distinct

            #region Union
            int[] numbers1 = { 1, 2, 3, 4, 5 };
            int[] numbers2 = { 1, 3, 6, 7, 8 };

            var result3 = numbers1.Union(numbers2);

            foreach (var v in result3)
            {
                Console.WriteLine(v);
            }
            Console.WriteLine(".......................................................");
            #endregion Union

            #region Intersect

            result3 = numbers1.Intersect(numbers2);

            foreach (var v in result3)
            {
                Console.WriteLine(v);
            }
            Console.WriteLine(".......................................................");
            #endregion Intersect

            #region Except

            result3 = numbers1.Except(numbers2);

            foreach (var v in result3)
            {
                Console.WriteLine(v);
            }
            Console.WriteLine(".......................................................");
            #endregion Except
            Console.Read();
}
}
}
