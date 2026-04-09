using System.Collections.Generic;

namespace Lab2
{
    public class CurrencyRate
    {
        public int Id { get; set; }
        public string? Symbol { get; set; } 
        public double Rate { get; set; }
        public string? Date { get; set; }
    }

    public class ExchangeRate
    {
        public string? @base { get; set; } 
        public Dictionary<string, double>? rates { get; set; }
    }
}