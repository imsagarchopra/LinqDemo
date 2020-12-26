using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupJoin
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Example1
            //Group employees by Department.

            var employeesByDepartment = Department.GetAllDepartments().GroupJoin(Employee.GetAllEmployees(), d => d.ID, e => e.DepartmentID,
                (department, employees) => new { Department = department, Employees = employees });


            foreach (var department in employeesByDepartment)
            {
                Console.WriteLine(department.Department.Name);
                foreach (var employee in department.Employees)
                {
                    Console.WriteLine(" " + employee.Name);
                }
                Console.WriteLine();
            }

            Console.WriteLine(".....................................................");

            //...............................................
            //Using SQL like syntax
            //...................................................

            from d in Department.GetAllDepartments()
            join e in Employee.GetAllEmployees()
            on d.ID equals e.DepartmentID into eGroup
            select new
            {

                Department = d,
                Employees = eGroup
            }
            #endregion Example1

            #region Example2
            #endregion Example2

            Console.Read();
        }
    }
}
