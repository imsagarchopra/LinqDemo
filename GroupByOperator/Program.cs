using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupByOperator
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Example1
            //Get Employee Count By Department
            var employeeGroup = from employee in Employee.GetAllEmployees()
                                group employee by employee.Department;

            foreach (var group in employeeGroup)
            {
                Console.WriteLine("{0} - {1}", group.Key, group.Count());
            }
            Console.WriteLine("...................................................");

            //Using Lambda expression syntax
            var empGroup = Employee.GetAllEmployees().GroupBy(emp => emp.Department);
            foreach (var group in employeeGroup)
            {
                Console.WriteLine("{0} - {1}", group.Key, group.Count());
            }
            Console.WriteLine("...................................................");
            #endregion Example1

            #region Example2
            //Get Employee Count By Department and also each employee and department name
            var empGrp = from employee in Employee.GetAllEmployees()
                                group employee by employee.Department;

            foreach (var group in empGrp)
            {
                Console.WriteLine("{0} - {1}", group.Key, group.Count());
                Console.WriteLine("----------");
                foreach (var employee in group)
                {
                    Console.WriteLine(employee.Name + "\t" + employee.Department);
                }
                Console.WriteLine(); Console.WriteLine();
            }

            Console.WriteLine(".....................................................");
            #endregion Example2

            #region Example3
            //Group employees by Department and then by Gender.
            //The employee groups should be sorted first by Department
            //and then by Gender in ascending order.
            //Also, employees within each group must be sorted in ascending order by Name.


            var employeeGroups = Employee.GetAllEmployees()
                                                    .GroupBy(x => new { x.Department, x.Gender })
                                                    .OrderBy(g => g.Key.Department).ThenBy(g => g.Key.Gender)
                                                    .Select(g => new
                                                    {
                                                        Dept = g.Key.Department,
                                                        Gender = g.Key.Gender,
                                                        Employees = g.OrderBy(x => x.Name)
                                                    });

            foreach (var group in employeeGroups)
            {
                Console.WriteLine("{0} department {1} employees count = {2}",
                    group.Dept, group.Gender, group.Employees.Count());
                Console.WriteLine("--------------------------------------------");
                foreach (var employee in group.Employees)
                {
                    Console.WriteLine(employee.Name + "\t" + employee.Gender
                        + "\t" + employee.Department);
                }
                Console.WriteLine(); Console.WriteLine();
            }


            //......................................................
            //Using SQL like syntax
            //............................................................

            var emplGrp = from employee in Employee.GetAllEmployees()
                                 group employee by new
                                 {
                                     employee.Department,
                                     employee.Gender
                                 } into eGroup
                                 orderby eGroup.Key.Department ascending,
                                               eGroup.Key.Gender ascending
                                 select new
                                 {
                                     Dept = eGroup.Key.Department,
                                     Gender = eGroup.Key.Gender,
                                     Employees = eGroup.OrderBy(x => x.Name)
                                 };

            #endregion Example3

            Console.Read();
        }
    }
}
