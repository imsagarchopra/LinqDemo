using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectManyOperator
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Example 1
            //Projects all subject strings of a given a student to an IEnumerable<string>.
            //In this example since we have 4 students, there will be 4 IEnumerable<string> sequences,
            //which are then flattened to form a single sequence
            //i.e a single IEnumerable<string> sequence.

            IEnumerable<string> allSubjects = Student.GetAllStudetns().SelectMany(s => s.Subjects);
            foreach (string subject in allSubjects)
            {
                Console.WriteLine(subject);
            }
            Console.WriteLine("......................................................");
            //..................................
            //With SQL like syntax
            //..................................

            allSubjects = from student in Student.GetAllStudetns()
                                              from subject in student.Subjects
                                              select subject;

            foreach (string subject in allSubjects)
            {
                Console.WriteLine(subject);
            }
            Console.WriteLine("......................................................");
            #endregion

            #region Example2
            //Projects each string to an IEnumerable<char>.
            //In this example since we have 2 strings, there will be 2 IEnumerable<char> sequences,
            //which are then flattened to form a single sequence i.e a single IEnumerable<char> sequence.

            string[] stringArray =  {
                                        "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                                        "0123456789"
                                    };

            IEnumerable<char> result = stringArray.SelectMany(s => s);

            foreach (char c in result)
            {
                Console.WriteLine(c);
            }

            //..................................
            //With SQL like syntax
            //..................................

            result = from s in stringArray
                     from c in s
                     select c;

            foreach (char c in result)
            {
                Console.WriteLine(c);
            }

            #endregion Example2

            #region Example3
            //Selects only the distinct subject

            allSubjects = Student.GetAllStudetns().SelectMany(s => s.Subjects).Distinct();
            foreach (string subject in allSubjects)
            {
                Console.WriteLine(subject);
            }

            //..................................
            //With SQL like syntax
            //..................................

            allSubjects = (from student in Student.GetAllStudetns()
                           from subject in student.Subjects
                           select subject).Distinct();

            foreach (string subject in allSubjects)
            {
                Console.WriteLine(subject);
            }

            #endregion Example3

            #region Example4
            //Selects student name along with all the subjects
            var result1 = Student.GetAllStudetns().SelectMany(s => s.Subjects, (student, subject) =>
    new { StudentName = student.Name, Subject = subject });

            foreach (var v in result1)
            {
                Console.WriteLine(v.StudentName + " - " + v.Subject);
            }

            //..................................
            //With SQL like syntax
            //..................................

            var result2 = from student in Student.GetAllStudetns()
                         from subject in student.Subjects
                         select new { StudnetName = student.Name, Subject = subject };

            foreach (var v in result2)
            {
                Console.WriteLine(v.StudnetName + " - " + v.Subject);
            }

            #endregion Example4
            Console.Read();
        }
    }
}
