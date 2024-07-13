using Newtonsoft.Json.Linq;
using System.Text.Json;
using static System.Net.WebRequestMethods;

internal class Program
{
    private const string ConversionRates = "conversion_rates";
    private static readonly HttpClient client = new HttpClient();

    private static async Task Main(string[] args)
    {
        string fromCurrency = Console.ReadLine().ToUpper();
        string toCurrency = Console.ReadLine().ToUpper();
        decimal amount = Convert.ToDecimal(Console.ReadLine());

        string api = "43c55734a568eeb690a0455c";
        string url = $"https://v6.exchangerate-api.com/v6/{api}/latest/{fromCurrency}";

        string responce = await client.GetStringAsync(url);
        JObject data = JObject.Parse(responce);

        decimal exchangeRate = (decimal)data[ConversionRates][toCurrency];
        decimal convertedAmount = amount * exchangeRate;

        Console.WriteLine($"{amount} {fromCurrency} = {convertedAmount} {toCurrency}");
        Console.ReadKey();
        Console.Clear();
    }
}