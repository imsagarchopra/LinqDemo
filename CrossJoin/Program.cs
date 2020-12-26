using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossJoin
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Example1
            // Cross Join Employees collection with Departments collections.

            var result = from e in Employee.GetAllEmployees()
                         from d in Department.GetAllDepartments()
                         select new { e, d };

            foreach (var v in result)
            {
                Console.WriteLine(v.e.Name + "\t" + v.d.Name);
            }
            Console.WriteLine("............................................");
            #endregion Example1

            #region Example2
            //Using selectmany operator
            var result1 = Employee.GetAllEmployees().SelectMany(e => Department.GetAllDepartments(), (e, d) => new { e, d });

            foreach (var v in result1)
            {
                Console.WriteLine(v.e.Name + "\t" + v.d.Name);
            }
            Console.WriteLine("....................................................");
            //Using Join operator

            var result2 = Employee.GetAllEmployees().Join(Department.GetAllDepartments(), e => true, d => true, (e, d) => new { e, d });
            
            foreach (var v in result2)
            {
                Console.WriteLine(v.e.Name + "\t" + v.d.Name);
            }
            #endregion Example2

            Console.Read();
        }
    }
}
