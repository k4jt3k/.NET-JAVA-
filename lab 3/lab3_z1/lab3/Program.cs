using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace lab3
{
    class Matrix
    {
        public int[,] Data { get; private set; }
        public int Rows { get; private set; }
        public int Cols { get; private set; }


        public Matrix(int rows, int cols)
        {
            Rows = rows;
            Cols = cols;
            Data = new int[rows, cols];
        }

        public void FillRandom()
        {
            Random rand = new Random();
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    Data[i, j] = rand.Next(1, 10);
                }
            }
        }

        public void Print()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    Console.Write(Data[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        public static Matrix MultiplyParallel(Matrix a, Matrix b, int maxThreads)
        {
            if (a.Cols != b.Rows)
            {
                throw new ArgumentException("Nie można pomnożyć");
            }

            Matrix result = new Matrix(a.Rows, b.Cols);

            ParallelOptions opt = new ParallelOptions { MaxDegreeOfParallelism = maxThreads };

            Parallel.For(0, a.Rows, opt, i =>
            {
                for (int j = 0; j < b.Cols; j++)
                {
                    int sum = 0;
                    for (int k = 0; k < a.Cols; k++)
                    {
                        sum += a.Data[i, k] * b.Data[k, j];
                    }
                    result.Data[i, j] = sum;
                }
            }); 

            return result;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ZADANIE 1:\n");

            int[] matrixSizes = { 100, 300, 500 }; 

            int cores = Environment.ProcessorCount;
            int[] threadCounts = { 1, 2, 4, cores, cores * 2 };

            int tries = 3; 

            Console.WriteLine($"Liczba rdzeni : {cores}");
            Console.WriteLine($"Liczba prób : {tries}\n");

            Console.WriteLine("{0,-15} | {1,-15} | {2,-15}", "Rozmiar ", "Wątki", "Czas (ms)");
            Console.WriteLine(new string('-', 53));


            foreach (int size in matrixSizes)
            {
                var a = new Matrix(size, size);
                var b = new Matrix(size, size);
                a.FillRandom();
                b.FillRandom();

                foreach (int threads in threadCounts)
                {
                    long totalTime = 0;

                    for (int i = 0; i < tries; i++)
                    {
                        var sw = Stopwatch.StartNew();
                        Matrix.MultiplyParallel(a, b, threads);
                        sw.Stop();
                        totalTime += sw.ElapsedMilliseconds;
                    }

                    long averageTime = totalTime / tries;

                    string threadLabel = threads == 1 ? "1 " : threads.ToString();

                    Console.WriteLine("{0,-15} | {1,-15} | {2,-15}", $"{size}x{size}", threadLabel, averageTime);
                }

                Console.WriteLine(new string('-', 53));
            }

            Console.ReadKey();
        }
    }

}
