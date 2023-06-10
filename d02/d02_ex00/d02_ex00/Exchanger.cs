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
                    if (parts.Length == 2 && double.TryParse(parts[1], out double rate))
                    {
                        rates.Add(new ExchangeRate(Path.GetFileNameWithoutExtension(file), parts[0], rate));
                    }
                }
            }

            return rates;
        }

        public double Convert(double amount, string fromCurrency, string toCurrency)
        {
            double rate = GetExchangeRate(fromCurrency, toCurrency);
            return amount * rate;
        }

        public List<ExchangeSum> Convert(double amount, string fromCurrency)
        {
            List<ExchangeSum> convertedSums = new List<ExchangeSum>();

            foreach (ExchangeRate rate in exchangeRates)
            {
                if (rate.FromCurrency == fromCurrency)
                {
                    double convertedAmount = Convert(amount, fromCurrency, rate.ToCurrency);
                    convertedSums.Add(new ExchangeSum(convertedAmount, rate.ToCurrency));
                }
            }

            return convertedSums;
        }

        private double GetExchangeRate(string fromCurrency, string toCurrency)
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
