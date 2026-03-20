namespace lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of items:");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the seed:");
            int seed = int.Parse(Console.ReadLine());

            Problem problem = new Problem(n, seed);
            Console.WriteLine("\nGenerated Items:");
            Console.WriteLine(problem.ToString());

            Console.WriteLine("\nEnter the capacity:");
            int capacity = int.Parse(Console.ReadLine());

            Result wynik = problem.Solve(capacity);

            Console.WriteLine("\nResults:");
            Console.WriteLine(wynik.ToString());
        }


    }

    

    

}
