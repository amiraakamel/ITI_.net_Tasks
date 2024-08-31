using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace LinqTask
{
    internal class Program
    {
        class Subject
        {
            public int Code { get; set; }
            public string Name { get; set; }

            public Subject(int code = 0, string name = "no name")
            {
                this.Code = code;
                this.Name = name;
            }
        }

        class Student
        {
            public int ID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public Subject[] Subjects { get; set; }

        }

        static void Main(string[] args)
        {
            //Task 1
            List<int> numbers = new List<int>() { 2, 4, 6, 7, 1, 4, 2, 9, 1 };

            var q1 = numbers.Distinct().OrderBy(num => num);
            foreach(var num in q1)
            {
                Console.WriteLine(num);
            }

            Console.WriteLine("------------------------------------------------------");

            var q2 = q1.Select(num => new { Number = num, Multiplication = num * num });
            foreach (var num in q2)
            {
                Console.WriteLine($"< Number = {num.Number}, Multiply = {num.Multiplication} >");
            }

            Console.WriteLine("///////////////////////////////////////////////////////////////////");

            //Task 2
            string[] names = { "Tom", "Dick", "Harry", "MARY", "Jay" };
            var q3 = names.Where(name=>name.Length == 3);

            foreach (var name in q3)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine("------------------------------------------------------");

            var q4 = names.Where(name => name.ToLower().Contains("a")).OrderBy(name => name.Length);
            foreach (var name in q4)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine("------------------------------------------------------");

            var q5 = names.Take(2);
            foreach (var name in q5)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine("///////////////////////////////////////////////////////////////////");

            //Task 3
            List<Student> students = new List<Student>()
            {
                new Student()
                {
                    ID = 1, FirstName ="Ali" , LastName ="Mohamed" ,
                    Subjects = new Subject[] {new Subject(22,"Ef") , new Subject(33, "UML") }
                },
                new Student()
                {
                    ID = 2, FirstName ="Mona" , LastName ="Gala" ,
                    Subjects = new Subject[] {new Subject(22,"Ef") , new Subject(34, "XML"), new Subject(25, "JS") }
                },new Student()
                {
                    ID = 3, FirstName ="Yara" , LastName ="Yousf" ,
                    Subjects = new Subject[] {new Subject(22,"Ef"), new Subject(25, "JS") }
                },new Student()
                {
                    ID = 4, FirstName ="Ali" , LastName ="Ali" ,
                    Subjects = new Subject[] { new Subject(33, "UML") }
                }

            };

            var q6 = students.Select(s => new { FullName = s.FirstName +" "+ s.LastName, NoOfSubjects = s.Subjects.Length });
            foreach (var student in q6)
            {
                Console.WriteLine($"< FullName = {student.FullName}, NoOfSubjects = {student.NoOfSubjects}");
            }

            Console.WriteLine("------------------------------------------------------");

            var q7 = students.OrderByDescending(s => s.FirstName)
            .ThenBy(s => s.LastName)
            .Select(s => new { FirstName = s.FirstName, LastName = s.LastName });
            foreach (var student in q7)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName}");
            }

            Console.WriteLine("------------------------------------------------------");

            var q8 = students
            .GroupBy(student => student.ID) 
            .Select(g => new
            {
                Student = g.First(), 
                Subjects = g.SelectMany(student => student.Subjects) 
            }).Select(group => new
            {
                FirstName = group.Student.FirstName,
                LastName = group.Student.LastName,
                Subjects = group.Subjects
            });
            foreach (var student in q8)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName}");
                foreach (var subject in student.Subjects)
                {
                    Console.WriteLine(subject.Name);
                }
            }
        }
    }
}
