namespace Day5
{
    class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public Person()
        {
            Id = 0;
        }

        public Person(int id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }

        public virtual void Show()
        {
            Console.WriteLine($"Person Id: {Id}, Name: {Name}, Age: {Age}");
        }
    }

    class Teacher : Person
    {
        public string SubjectName { get; set; }
        public int NumOfHours { get; set; }

        public Teacher() : base()
        {
            NumOfHours = 0;
        }

        public Teacher(int id, string name, int age, string subjectName, int numOfHours) : base(id, name, age)
        {
            SubjectName = subjectName;
            NumOfHours = numOfHours;
        }

        public override void Show()
        {
            base.Show();
            Console.WriteLine($"Teacher SubjectName: {SubjectName}, NumOfHours: {NumOfHours}");
        }
    }

    class Student : Person
    {
        public string ParentPhone { get; set; }

        public Student() : base()
        {
            ParentPhone = "no PhoneNumber";
        }

        public Student(int id, string name, int age, string parentPhone) : base(id, name, age)
        {
            ParentPhone = parentPhone;
        }

        public override void Show()
        {
            base.Show();
            Console.WriteLine($"Student ParentPhone: {ParentPhone}");
        }
    }

    class Test
    {
        public void Display(Person p)
        {
            p.Show();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person(1, "Amira", 21);
            Teacher t = new Teacher(2, "Sara", 22, "OOP", 20);
            Student s = new Student(3, "Esraa", 23, "01025364447");

            Test test = new Test();
            test.Display(p);
            Console.WriteLine("-----------------------");
            test.Display(t);
            Console.WriteLine("-----------------------");
            test.Display(s);
            Console.WriteLine("-----------------------");
        }
    }
}
