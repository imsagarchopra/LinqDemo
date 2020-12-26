using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingOperators
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Example1
            //Sort Students by Name in ascending order
            IEnumerable<Student> result = Student.GetAllStudents().OrderBy(s => s.Name);
            foreach (Student student in result)
            {
                Console.WriteLine(student.Name);
            }
            Console.WriteLine(".........................................");
            //...............................................................
            //Using SQL like syntax
            //....................................................................
            result = from student in Student.GetAllStudents()
                     orderby student.Name
                     select student;

            foreach (Student student in result)
            {
                Console.WriteLine(student.Name);
            }
            Console.WriteLine(".........................................");
            #endregion Example1

            #region Example2
            //Sort Students by Name in descending order
            result = Student.GetAllStudents().OrderByDescending(s => s.Name);
            foreach (Student student in result)
            {
                Console.WriteLine(student.Name);
            }
            Console.WriteLine(".........................................");
            //...............................................................
            //Using SQL like syntax
            //....................................................................
            result = from student in Student.GetAllStudents()
                     orderby student.Name descending
                     select student;

            foreach (Student student in result)
            {
                Console.WriteLine(student.Name);
            }
            Console.WriteLine(".........................................");
            #endregion Example2

            #region Example3
            //a) Sorts Students first by TotalMarks in ascending order(Primary Sort) 
            //b) The 4 Students with TotalMarks of 800, will then be sorted by Name in ascending order(First Secondary Sort)
            //c) The 2 Students with Name of John, will then be sorted by StudentID in ascending order(Second Secondary Sort)


            result = Student.GetAllStudents()
                    .OrderBy(s => s.TotalMarks).ThenBy(s => s.Name).ThenBy(s => s.StudentID);
            foreach (Student student in result)
            {
                Console.WriteLine(student.TotalMarks + "\t" + student.Name + "\t" + student.StudentID);
            }
            Console.WriteLine("................................................");

            //..............................................
            //Using SQL like syntax
            //..........................................

            result = from student in Student.GetAllStudents()
                     orderby student.TotalMarks, student.Name, student.StudentID
                     select student;
            foreach (Student student in result)
            {
                Console.WriteLine(student.TotalMarks + "\t" + student.Name + "\t" + student.StudentID);
            }
            Console.WriteLine("................................................");
            #endregion Example3

            #region Example4
            //Reverses the items in the collection. 

            IEnumerable<Student> students = Student.GetAllStudents();

            Console.WriteLine("Before calling Reverse");
            foreach (Student s in students)
            {
                Console.WriteLine(s.StudentID + "\t" + s.Name + "\t" + s.TotalMarks);
            }

            Console.WriteLine();
            result = students.Reverse();

            Console.WriteLine("After calling Reverse");
            foreach (Student s in result)
            {
                Console.WriteLine(s.StudentID + "\t" + s.Name + "\t" + s.TotalMarks);
            }
            #endregion Example4
            Console.Read();
        }
    }
}
