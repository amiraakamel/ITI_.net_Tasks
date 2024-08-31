using System.Collections;

namespace Day_7
{
    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public Student(int id = 0, string name = "", int age = 0)
        {
            this.Id = id;
            this.Name = name;
            this.Age = age;
        }

        public override string ToString()
        {
            return $"Student Id: {Id} ,Name: {Name} ,Age: {Age}";
        }
    }

    class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }

        public Subject(int id = 0, string name = "", int duration = 0)
        {
            this.Id = id;
            this.Name = name;
            this.Duration = duration;
        }

        public override string ToString()
        {
            return $"Subject Id:{Id} ,Name: {Name} ,Duration: {Duration}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<Student, List<Subject>> studDic = new Dictionary<Student, List<Subject>>();
            Console.Write("Enter the number of students:");
            int studentsNumber = int.Parse(Console.ReadLine());
            for (int i = 0; i < studentsNumber; i++)
            {
                Student s = new Student();
                Console.Write($"Enter the student:{i + 1} Id:");
                s.Id = int.Parse(Console.ReadLine());
                Console.Write($"Enter the student:{i + 1} Name:");
                s.Name = Console.ReadLine();
                Console.Write($"Enter the student:{i + 1} Age:");
                s.Age = int.Parse(Console.ReadLine());

                Console.Write($"\nEnter the student:{i + 1} number of Subjects:");
                int subjectsNumber = int.Parse(Console.ReadLine());
                List<Subject> Subjects = new List<Subject>();
                for (int j = 0; j < subjectsNumber; j++)
                {
                    Subject sb = new Subject();
                    Console.Write($"Enter the student:{i + 1} Subject {j + 1} Id:");
                    sb.Id = int.Parse(Console.ReadLine());
                    Console.Write($"Enter the student:{i + 1} Subject {j + 1} Name:");
                    sb.Name = Console.ReadLine();
                    Console.Write($"Enter the student:{i + 1} Subject {j + 1} Duration:");
                    sb.Duration = int.Parse(Console.ReadLine());
                    Console.WriteLine();
                    Subjects.Add(sb);
                }
                studDic.Add(s, Subjects);
                Console.WriteLine($"-------------------------------------------");
            }

            foreach (var entry in studDic)
            {
                Console.WriteLine($"Student: {entry.Key}");
                Console.WriteLine("Subjects:");
                foreach (var subject in entry.Value)
                {
                    Console.WriteLine(subject);
                }
                Console.WriteLine($"-------------------------------------------");
            }
        }
    }
}
