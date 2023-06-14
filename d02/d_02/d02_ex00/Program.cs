// See https://aka.ms/new-console-template for more information

using System.Globalization;
using d02_ex00;
using d02_ex00.Models;

if (args.Length != 2)
{
    Console.WriteLine("Input error. Check the input data and repeat the request.");
    return;
}

string amountString = args[0].Trim('"');
string ratesDirectory = args[1].Trim('"');

string[] amountParts = amountString.Split(' ');

if (amountParts.Length != 2)
{
    Console.WriteLine("Input error. Invalid amount format.");
    return;
}

if (!double.TryParse(amountParts[0], out double amount))
{
    Console.WriteLine("Input error. Invalid amount.");
    return;
}

string currency = amountParts[1];

Exchanger exchanger = new Exchanger(ratesDirectory);

List<ExchangeSum> convertedSums = exchanger.Convert(amount, currency);
CultureInfo enGbCulture = new CultureInfo("en-GB");
Console.WriteLine("Amount in the original currency: " + amount.ToString("N2", enGbCulture));
foreach (ExchangeSum sum in convertedSums)
{
    Console.WriteLine(sum.ToString());
}