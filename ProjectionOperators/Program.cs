using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectionOperators
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Example1
            //Retrieves just the EmployeeID property of all employees
            IEnumerable<int> employeeIds = Employee.GetAllEmployees()
                                            .Select(emp => emp.EmployeeID);
            foreach (int id in employeeIds)
            {
                Console.WriteLine(id);
            }
            #endregion Example1

            #region Example2
            //Projects FirstName & Gender properties of all employees into anonymous type

            var result = Employee.GetAllEmployees().Select(emp => new
            {
                FirstName = emp.FirstName,
                Gender = emp.Gender
            });
            foreach (var v in result)
            {
                Console.WriteLine(v.FirstName + " - " + v.Gender);
            }
            #endregion Example2

            #region Example3
            //Computes FullName and MonthlySalay of all employees and projects these 2 new computed properties into anonymous type.
            var result1 = Employee.GetAllEmployees().Select(emp => new
            {
                FullName = emp.FirstName + " " + emp.LastName,
                MonthlySalary = emp.AnnualSalary / 12
            });

            foreach (var v in result1)
            {
                Console.WriteLine(v.FullName + " - " + v.MonthlySalary);
            }
            #endregion Example3

            #region Example4
            //Give 10 % bonus to all employees whose annual salary is greater than 50000 and project all such employee's FirstName, AnnualSalay and Bonus into anonymous type.
            var result2 = Employee.GetAllEmployees()
                .Where(emp => emp.AnnualSalary > 50000)
                .Select(emp => new
                {
                    Name = emp.FirstName,
                    Salary = emp.AnnualSalary,
                    Bonus = emp.AnnualSalary * .1
                });

            foreach (var v in result2)
            {
                Console.WriteLine(v.Name + " : " + v.Salary + " - " + v.Bonus);
            }

            #endregion Example4

            #region Example5
            #endregion Example5

            Console.Read();
        }
    }
}
