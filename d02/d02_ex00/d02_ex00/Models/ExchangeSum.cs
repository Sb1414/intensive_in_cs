using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace d02_ex00.Models
{
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
            return $"Amount in {Currency}: {Amount} {Currency}";
        }
    }
}
