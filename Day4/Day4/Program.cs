namespace Day4
{
    class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }

        public Subject()
        {
            Id = 1;
            Duration = 12;
        }
        public Subject(int Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
            Duration = 12;
        }
        public Subject(int Id, string Name, int Duration)
        {
            this.Id = Id;
            this.Name = Name;
            this.Duration = Duration;

        }

        public string Print()
        {
            return $"Subject Id: {Id} ,Name: {Name} ,Duration: {Duration} Hours";
        }

    }

    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Subject[] Sub { get; set; } // >> Has A


        public Student()
        {
            Id = 1;
        }
        public Student(int Id, string Name, int Age)
        {
            this.Id = Id;
            this.Name = Name;
            this.Age = Age;
        }

        public Student(int Id, string Name, int Age, Subject[] Sub)
        {
            this.Id = Id;
            this.Name = Name;
            this.Age = Age;
            this.Sub = Sub;
        }
        public string Print()
        {
            string txt = $"Student Id: {Id} ,Name: {Name} ,Age: {Age} Years Old \n";

            for (int i = 0; i < Sub.Length; i++)
            {
                txt += Sub[i].Print();
                txt += "\n";
            }

            return txt;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number of students : ");
            int numOfStudents = int.Parse(Console.ReadLine());
            Student[] arr = new Student[numOfStudents];
            for (int i = 0; i < numOfStudents; i++)
            {
                arr[i] = new Student();
                Console.Write($"Enter Studnet {i+1} Id : ");
                arr[i].Id = int.Parse(Console.ReadLine());
                Console.Write($"Enter Student {i+1} Name : ");
                arr[i].Name = Console.ReadLine();
                Console.Write($"Enter Student {i+1} Age : ");
                arr[i].Age = int.Parse(Console.ReadLine());

                Console.Write($"Enter number of subjects of student {i+1} : ");
                int numOfSubjects = int.Parse(Console.ReadLine());
                Subject[] arr2 = new Subject[numOfSubjects];
                for (int j = 0; j < numOfSubjects; j++)
                {
                    arr2[j] = new Subject();
                    Console.Write($"Enter Subject {j+1} Id : ");
                    arr2[j].Id = int.Parse(Console.ReadLine());
                    Console.Write($"Enter Subject {j+1} Name : ");
                    arr2[j].Name = Console.ReadLine();
                    Console.Write($"Enter Subject {j+1} Duration : ");
                    arr2[j].Duration = int.Parse(Console.ReadLine());
                }
                arr[i].Sub = arr2;
                Console.Write("---------------------------------------\n");
            }
            Console.WriteLine("\n");
            foreach (Student item in arr)
            {
                Console.WriteLine(item.Print());
                Console.WriteLine("================================");
            }
        }
    }
}
