using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Collections.ObjectModel;
using System.Linq;

namespace KantorAvalonia;

public partial class MainWindow : Window
{
    public ObservableCollection<CurrencyRate> History { get; set; } = new();

    public MainWindow()
    {
        InitializeComponent();
        DataContext = this; 
        LoadFromDb();
    }

    private async void OnGetRateClicked(object sender, RoutedEventArgs e)
    {
        var dateEntry = this.FindControl<TextBox>("DateEntry");
        var currencyEntry = this.FindControl<TextBox>("CurrencyEntry");

        if (dateEntry != null && currencyEntry != null)
        {
            var service = new APIService();
            await service.GetRate(dateEntry.Text ?? "", currencyEntry.Text ?? "");
            LoadFromDb();
        }
    }

    private void LoadFromDb()
    {
        using var db = new ExchangeContext();
        db.Database.EnsureCreated(); 
        var data = db.Rates.ToList();
        History.Clear();
        foreach (var item in data) History.Add(item);
    }
}