using System;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Lab2
{
    public class APIService
    {
        private readonly HttpClient client = new HttpClient();

        public async Task Get(string? date, string? currency)
        {
            if (string.IsNullOrEmpty(date) || string.IsNullOrEmpty(currency)) return;

            using (var db = new ExchangeContext())
            {
                string sym = currency.ToUpper();
                var cached = db.Rates.FirstOrDefault(r => r.Date == date && r.Symbol == sym);

                if (cached != null)
                {
                    Console.WriteLine($"[BAZA] {sym} z dnia {date}: {cached.Rate}");
                    return;
                }

                try
                {
                    string appid = "7a6581795e0846afa7495528f86c32d5";
                    string url = $"https://openexchangerates.org/api/historical/{date}.json?app_id={appid}";

                    string response = await client.GetStringAsync(url);
                    var data = JsonSerializer.Deserialize<ExchangeRate>(response);

                    if (data?.rates != null && data.rates.ContainsKey(sym))
                    {
                        double val = data.rates[sym];
                        db.Rates.Add(new CurrencyRate { Date = date, Symbol = sym, Rate = val });
                        db.SaveChanges();
                        Console.WriteLine($"[API] {sym} z dnia {date}: {val} (Zapisano)");
                    }
                }
                catch (Exception ex) { Console.WriteLine($"Błąd: {ex.Message}"); }
            }
        }
    }
}