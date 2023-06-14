using System.Globalization;

namespace d02_ex00.Models;

public struct ExchangeSum
{
    public double Amount { get; }
    public string Currency { get; }

    public ExchangeSum(double amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }

    public override string ToString()
    {
        CultureInfo enGbCulture = new CultureInfo("en-GB");
        string formattedAmount = Amount.ToString("N2", enGbCulture);
        return $"Amount in {Currency}: {formattedAmount} {Currency}";
    }

}