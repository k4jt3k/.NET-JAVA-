using System.Collections.Generic;

namespace KantorAvalonia;

public class ExchangeRate
{
    public string? @base { get; set; }
    public Dictionary<string, double>? rates { get; set; }
}