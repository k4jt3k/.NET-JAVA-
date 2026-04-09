using System;
using System.Linq;
using Lab2;

namespace Lab2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            APIService service = new APIService();
            bool running = true;

            while (running)
            {
                Console.WriteLine("\n1. Pobierz | 2. Lista | 3. Filtruj | 4. Sortuj | 5. Koniec");
                string? choice = Console.ReadLine();

                using (var db = new ExchangeContext())
                {
                    switch (choice)
                    {
                        case "1":
                            Console.Write("Data (RRRR-MM-DD): ");
                            string? d = Console.ReadLine();
                            Console.Write("Waluta: ");
                            string? s = Console.ReadLine();
                            service.Get(d, s).Wait();
                            break;
                        case "2":
                            db.Rates.OrderBy(r => r.Date).ToList()
                              .ForEach(r => Console.WriteLine($"{r.Date} {r.Symbol}: {r.Rate}"));
                            break;
                        case "3":
                            Console.Write("Waluta: ");
                            string? f = Console.ReadLine()?.ToUpper();
                            db.Rates.Where(r => r.Symbol == f).ToList()
                              .ForEach(r => Console.WriteLine($"{r.Date}: {r.Rate}"));
                            break;
                        case "4":
                            db.Rates.OrderByDescending(r => r.Rate).ToList()
                              .ForEach(r => Console.WriteLine($"{r.Rate} - {r.Symbol} ({r.Date})"));
                            break;
                        case "5":
                            running = false;
                            break;
                    }
                }
            }
        }
    }
}