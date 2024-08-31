namespace ITI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int id , age; string name; 
            Console.WriteLine("Enter your Id : ");
            id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter your name : ");
            name = Console.ReadLine();  
            Console.WriteLine("Enter your age : ");
            age = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"Your id : {id} Your name : {name} Your age : {age}");

            Console.WriteLine("---------------------------------------------------");


            Console.WriteLine( "enter number of Tracks");
            int Tracks = int.Parse(Console.ReadLine());
            Console.WriteLine("enter number of Students");
            int Students = int.Parse(Console.ReadLine());
            int[,] StudentAge = new int[Tracks , Students];

            for (int i = 0; i < Tracks; i++)
            {
                for (int j = 0; j < Students; j++)
                {
                    Console.WriteLine($"enter age of student {i+1} {j+1}");
                    StudentAge[i,j] = int.Parse(Console.ReadLine());

                }

            }

            for (int i = 0; i < Tracks; i++)
            {
                double avg = 0;
                for (int j = 0; j < Students; j++)
                {
                    avg += StudentAge[i,j];
                }
                avg = avg/Students;
                Console.WriteLine($"average of the first track {avg}");
            }



        }
    }
}
