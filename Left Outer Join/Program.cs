using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Left_Outer_Join
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Example1
            //Implement a Left Outer Join between Employees and Department collections
            //and print all the Employees and their respective department names.
            //Employees without a department, should display "No Department" against their name.
            var result = from e in Employee.GetAllEmployees()
                         join d in Department.GetAllDepartments()
                         on e.DepartmentID equals d.ID into eGroup
                         from d in eGroup.DefaultIfEmpty()
                         select new
                         {
                             EmployeeName = e.Name,
                             DepartmentName = d == null ? "No Department" : d.Name
                         };

            foreach (var v in result)
            {
                Console.WriteLine(v.EmployeeName + "\t" + v.DepartmentName);
            }
            Console.WriteLine(".........................................................");

            //.......................................................
            //Using Extension method syntax
            //...................................................

            var result1 = Employee.GetAllEmployees()
                        .GroupJoin(Department.GetAllDepartments(),
                                e => e.DepartmentID,
                                d => d.ID,
                                (emp, depts) => new { emp, depts })
                        .SelectMany(z => z.depts.DefaultIfEmpty(),
                                (a, b) => new
                                {
                                    EmployeeName = a.emp.Name,
                                    DepartmentName = b == null ? "No Department" : b.Name
                                });

            foreach (var v in result1)
            {
                Console.WriteLine(" " + v.EmployeeName + "\t" + v.DepartmentName);
            }
            #endregion Example1

            Console.Read();

        }
    }
}
