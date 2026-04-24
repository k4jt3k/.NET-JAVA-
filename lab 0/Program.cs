namespace Lab0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            FizzBuzz gra = new FizzBuzz(20);
        }
    }

    internal class FizzBuzz
    {
        public FizzBuzz(int zakres)
        {
            for (int n = 1; n <= zakres; n++)
            {
                if (n % 3 ==0 && n % 5 == 0)
                {
                    Console.WriteLine("FizzBuzz");
                }
                else if (n % 3 == 0)
                {
                    Console.WriteLine("Fizz");
                }
                else if (n % 5 == 0)
                {
                    Console.WriteLine("Buzz");
                }
                else
                {
                    Console.WriteLine(n);
                }
            }
        }
    }
}
