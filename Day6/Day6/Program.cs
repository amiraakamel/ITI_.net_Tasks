namespace Day6
{
    class Student
    {
        public int id { get; set; }
        public string name { get; set; }
        public int age { get; set; }

        public Student(int id = 0, string name = "", int age = 0)
        {
            this.id = id;
            this.name = name;
            this.age = age;
        }

        public static bool operator >(Student s1, Student s2)
        {
            return s1.age > s2.age;
        }
        public static bool operator <(Student s1, Student s2)
        {
            return s1.age < s2.age;
        }

        public static implicit operator int(Student s)
        {
            return (int)s.id;
        }
        public static explicit operator string(Student s)
        {
            return (string)s.name;
        }

        public override string ToString()
        {
            return $"Student id:{id} ,name:{name} ,age:{age} Years old";
        }
    }

    struct Complexnum
    {
        public int real { get; set; }
        public int img { get; set; }

        public Complexnum(int real = 0, int img = 0)
        {
            this.real = real;
            this.img = img;
        }

        public static Complexnum operator +(Complexnum c1, Complexnum c2)
        {
            Complexnum c = new Complexnum();
            c.real = c1.real + c2.real;
            c.img = c1.img + c2.img;
            return c;

        }
        public static Complexnum operator -(Complexnum c1, Complexnum c2)
        {
            Complexnum c = new Complexnum();
            c.real = c1.real - c2.real;
            c.img = c1.img - c2.img;
            return c;

        }
        public static bool operator >(Complexnum c1, Complexnum c2)
        {
            return (c1.real > c2.real && c1.img > c2.real);
        }
        public static bool operator <(Complexnum c1, Complexnum c2)
        {
            return !(c1.real > c2.real && c1.img > c2.real);
        }
        public static bool operator ==(Complexnum c1, Complexnum c2)
        {
            Complexnum c = new Complexnum();
            return c1.real == c2.real &&
                  c1.img == c2.img;


        }
        public static bool operator !=(Complexnum c1, Complexnum c2)
        {
            return !(c1.img != c2.img || c1.real != c2.real);
        }

        public override string ToString()
        {
            return $"{real}+{img}i";
        }
    }



    internal class Program
    {
        static void Main(string[] args)
        {
            Student s = new Student();
            Console.Write("Enter student first id:");
            s.id = int.Parse(Console.ReadLine());
            Console.Write("Enter student first name:");
            s.name = Console.ReadLine();
            Console.Write("Enter student first age:");
            s.age = int.Parse(Console.ReadLine());

            Student s2 = new Student();
            Console.Write("Enter student second id:");
            s2.id = int.Parse(Console.ReadLine());
            Console.Write("Enter student second name:");
            s2.name = Console.ReadLine();
            Console.Write("Enter student second age:");
            s2.age = int.Parse(Console.ReadLine());
            
            if (s < s2)
            {
                Console.WriteLine(s.ToString());
            }

            Console.WriteLine("-------------------------------------");

            Complexnum c = new Complexnum();
            Console.Write("Enter the first real number: ");
            c.real= int.Parse(Console.ReadLine());
            Console.Write("Enter the first image: ");
            c.img = int.Parse(Console.ReadLine());

            Complexnum c2 = new Complexnum();
            Console.Write("Enter the second real number: ");
            c2.real = int.Parse(Console.ReadLine());
            Console.Write("Enter the second image: ");
            c2.img = int.Parse(Console.ReadLine());

            if (c == c2)
            {
                Console.WriteLine(c.ToString());
            }


        }
    }
}
