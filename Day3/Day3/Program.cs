namespace Day3
{
    struct Complexnum
    {
        public int Real { get; set; }
        int img;
    public int Img
    {
        set
        {
            if (value >= 0)
            {
                img = value;
            }
            else
            {
                img = 0;
            }
        }
        get
        {
            return img;
        }
    }

        public void Print()
    {
        Console.WriteLine($"{Real}+{Img}i");
    }
}
internal class Program
    {
    static void Main(string[] args)
        {
            Console.WriteLine("Enter num of Complexnum");

            int sizeOfComplexnum = int.Parse(Console.ReadLine());

            Complexnum[] arr = new Complexnum[sizeOfComplexnum];
            for (int i = 0; i < sizeOfComplexnum; i++)
            {
                Console.WriteLine("Enter Real number");
                arr[i].Real = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Img number");
                arr[i].Img = int.Parse(Console.ReadLine());
                Console.WriteLine("---------------------     ");


            }
            foreach (Complexnum item in arr)
            {
                item.Print();
                

            }
        }
    }
}
