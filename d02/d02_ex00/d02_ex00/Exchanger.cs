using d02_ex00.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace d02_ex00
{
    internal class Exchanger
    {
        private List<ExchangeRate> exchangeRates;

        public Exchanger(string ratesDirectory)
        {
            exchangeRates = LoadExchangeRates(ratesDirectory);
        }

        private List<ExchangeRate> LoadExchangeRates(string ratesDirectory)
        {
            List<ExchangeRate> rates = new List<ExchangeRate>();

            string[] rateFiles = Directory.GetFiles(ratesDirectory, "*.txt");
            foreach (string file in rateFiles)
            {
                string[] lines = File.ReadAllLines(file);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(':');
                    if (parts.Length == 2 && decimal.TryParse(parts[1], out decimal rate))
                    {
                        rates.Add(new ExchangeRate(parts[0], Path.GetFileNameWithoutExtension(file), rate));
                    }
                }
            }

            return rates;
        }

        public decimal Convert(decimal amount, string fromCurrency, string toCurrency)
        {
            decimal rate = GetExchangeRate(fromCurrency, toCurrency);
            return amount * rate;
        }

        public List<ExchangeSum> Convert(decimal amount, string fromCurrency)
        {
            List<ExchangeSum> convertedSums = new List<ExchangeSum>();

            foreach (ExchangeRate rate in exchangeRates)
            {
                if (rate.FromCurrency == fromCurrency)
                {
                    decimal convertedAmount = Convert(amount, fromCurrency, rate.ToCurrency);
                    convertedSums.Add(new ExchangeSum(convertedAmount, rate.ToCurrency));
                }
            }

            return convertedSums;
        }

        private decimal GetExchangeRate(string fromCurrency, string toCurrency)
        {
            foreach (ExchangeRate rate in exchangeRates)
            {
                if (rate.FromCurrency == fromCurrency && rate.ToCurrency == toCurrency)
                {
                    return rate.Rate;
                }
            }

            throw new Exception("Exchange rate not found");
        }
    }
}
