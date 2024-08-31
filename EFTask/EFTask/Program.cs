using EFTask.Models;
using Microsoft.EntityFrameworkCore;

namespace EFTask
{
    internal class Program
    {
        ITIDBContext context = new ITIDBContext();
        public void Display()
        {
            var q = context.Courses.Include(t=>t.Top).ToList();
            foreach ( var item in q )
            {
                Console.WriteLine($"Course ID: {item.Crs_Id}, Name: {item.Crs_Name}, Duration: {item.Crs_Duration} hours, Topic: {item.Top.Top_Name}");
            }
        }
        public void Add()
        {
            Course c = new Course();
            Console.Write("Enter Course ID : ");
            c.Crs_Id = int.Parse(Console.ReadLine());
            Console.Write("Enter Course Name : ");
            c.Crs_Name = Console.ReadLine();
            Console.Write("Enter Course Duration : ");
            c.Crs_Duration = int.Parse( Console.ReadLine() );
            Console.Write("Enter Topic ID : ");
            c.Top_Id = int.Parse(Console.ReadLine());

            context.Add( c );
            context.SaveChanges();
        }
        public void Remove()
        {
            Console.Write("Enter Course ID : ");
            int id = int.Parse(Console.ReadLine());
            Course c = context.Courses.FirstOrDefault(x=>x.Crs_Id == id);
            if( c != null )
            {
                context.Remove(c);
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Course not found.");
            }

        }
        public void Update()
        {
            Console.Write("Enter Course ID : ");
            int id = int.Parse(Console.ReadLine());
            Course c = context.Courses.FirstOrDefault(x => x.Crs_Id == id);
            if(c != null)
            {
                Console.Write("Enter Course Name : ");
                c.Crs_Name = Console.ReadLine();
                Console.Write("Enter Course Duration : ");
                c.Crs_Duration = int.Parse(Console.ReadLine());
                Console.Write("Enter Topic ID : ");
                c.Top_Id = int.Parse(Console.ReadLine());

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Course not found.");
            }
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            int input = 0;
            while (input != 5)
            {
                Console.WriteLine("Welcome to ITI Courses DataBase! \n" +
                "If you want to Display the current courses Enter 1\n" +
                "If you want to Add to the current courses Enter 2\n" +
                "If you want to Delete from the current courses Enter 3\n" +
                "If you want to Update the current courses Enter 4\n" +
                "If you want to Exit Enter 5");
                input = int.Parse(Console.ReadLine());

                switch(input)
                {
                    case 1:
                        program.Display();
                        break;
                    case 2:
                        program.Add();
                        break;
                    case 3:
                        program.Remove();
                        break;
                    case 4:
                        program.Update();
                        break;
                    case 5:
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid input, please enter a number between 1 and 5.");
                        break;

                }
                Console.WriteLine("\n***************************************************************\n");
            }
            
        }
    }
}
