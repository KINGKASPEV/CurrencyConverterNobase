// See https://aka.ms/new-console-template for more information
class CurrencyConverter
{
    private static readonly Dictionary<string, decimal> ConversionRates = new Dictionary<string, decimal>
    {
        {"USD_2_pound", 0.60m},
        { "USD_2_NAIRA", 721m},
        {"POUND_2_USD", 1/0.6M},
        {"NAIRA_2_USD", 1/721m }
    };

    static decimal ConvertCurrency(decimal amount, string fromCurrency, string toCurrency, out string message)
    {
        message = null;
        if (fromCurrency == toCurrency)
        {
            return amount;
        }

        string key = $"{fromCurrency}_to_{toCurrency}";

        if (ConversionRates.ContainsKey(key))
        {
            return amount * ConversionRates[key];
        }

        string toUSDKey = $"{fromCurrency}_to_USD";
        string fromUSDKey = $"USD_to_{toCurrency}";

        if (ConversionRates.ContainsKey(toUSDKey) && ConversionRates.ContainsKey(fromUSDKey))
        {
            decimal toUSD = amount * ConversionRates[toUSDKey];
            return toUSD * ConversionRates[fromUSDKey];
        }
        message = $"Conversion is not available";
        return 0;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("amount");
        decimal amount = Convert.ToDecimal(Console.ReadLine());

        Console.WriteLine("Enter the currency to convert from (e.g USD or POUND or NAIRA)");
        string fromCurrency = Console.ReadLine().ToUpper();

        Console.WriteLine("Enter the currency to convert to (e.g USD or POUND or NAIRA)");
        string toCurrency = Console.ReadLine().ToUpper();

        string message;
        decimal result = ConvertCurrency(amount, fromCurrency, toCurrency, out message);

        if (!string.IsNullOrEmpty(message))
        {
            Console.WriteLine($"{message}");
        }
        else
        {
            Console.WriteLine($"{amount} {fromCurrency} is equal to {result} {toCurrency}");
        }
        
    }
}





