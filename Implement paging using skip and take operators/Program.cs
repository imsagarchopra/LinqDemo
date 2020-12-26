using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implement_paging_using_skip_and_take_operators
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Student> students = Student.GetAllStudetns();

            do
            {
                Console.WriteLine("Please enter Page Number - 1,2,3 or 4");
                int pageNumber = 0;

                if (int.TryParse(Console.ReadLine(), out pageNumber))
                {
                    if (pageNumber >= 1 && pageNumber <= 4)
                    {
                        int pageSize = 3;
                        IEnumerable<Student> result = students
                                                     .Skip((pageNumber - 1) * pageSize).Take(pageSize);

                        Console.WriteLine();
                        Console.WriteLine("Displaying Page " + pageNumber);
                        foreach (Student student in result)
                        {
                            Console.WriteLine(student.StudentID + "\t" +
                                                                        student.Name + "\t" + student.TotalMarks);
                        }
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("Page number must be an integer between 1 and 4");
                    }
                }
                else
                {
                    Console.WriteLine("Page number must be an integer between 1 and 4");
                }
            } while (1 == 1);
        }
    }
}
