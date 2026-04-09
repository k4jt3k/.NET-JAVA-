using System;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace KantorAvalonia;

public class APIService
{
    private readonly HttpClient client = new HttpClient();

    public async Task GetRate(string date, string currency)
    {
        using var db = new ExchangeContext();
        var cached = db.Rates.FirstOrDefault(r => r.Date == date && r.Symbol == currency.ToUpper());

        if (cached != null) return;

        try
        {
            string appid = "7a6581795e0846afa7495528f86c32d5";
            string url = $"https://openexchangerates.org/api/historical/{date}.json?app_id={appid}";

            string response = await client.GetStringAsync(url);
            var data = JsonSerializer.Deserialize<ExchangeRate>(response);

            if (data?.rates != null && data.rates.ContainsKey(currency.ToUpper()))
            {
                db.Rates.Add(new CurrencyRate
                {
                    Date = date,
                    Symbol = currency.ToUpper(),
                    Rate = data.rates[currency.ToUpper()]
                });
                await db.SaveChangesAsync();
            }
        }
        catch (Exception ex) { Console.WriteLine(ex.Message); }
    }
}