// See https://aka.ms/new-console-template for more information

using d02_ex00.Models;
using d02_ex00;

if (args.Length != 2)
{
    Console.WriteLine("Input error. Check the input data and repeat the request.");
    return;
}

string amountString = args[0];
string ratesDirectory = args[1];

if (!decimal.TryParse(amountString, out decimal amount))
{
    Console.WriteLine("Input error. Check the input data and repeat the request.");
    return;
}

Exchanger exchanger = new Exchanger(ratesDirectory);

Console.WriteLine($"Amount in the original currency: {amount} RUB");

List<ExchangeSum> convertedSums = exchanger.Convert(amount, "RUB");

foreach (ExchangeSum sum in convertedSums)
{
    Console.WriteLine(sum.ToString());
}