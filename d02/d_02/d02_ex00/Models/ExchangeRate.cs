namespace d02_ex00.Models;

public struct ExchangeRate
{
    public string FromCurrency { get; }
    public string ToCurrency { get; }
    public double Rate { get; }

    public ExchangeRate(string fromCurrency, string toCurrency, double rate)
    {
        FromCurrency = fromCurrency;
        ToCurrency = toCurrency;
        Rate = rate;
    }
}