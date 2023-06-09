// See https://aka.ms/new-console-template for more information

using d02_ex00.Models;
using d02_ex00;

if (args.Length != 2)
{
    Console.WriteLine("Input error. Check the input data and repeat the request.");
    return;
}

string amountString = args[0].Trim('"');
string ratesDirectory = args[1].Trim('"');

string[] amountParts = amountString.Split(' ');

// Console.WriteLine(amountString + " <-- ");
// Console.WriteLine(ratesDirectory + " <-- ");
/*
for (int i = 0; i < amountParts.Length; i++)
{
    Console.WriteLine(amountParts[i] + " - " + i);
}
*/
if (amountParts.Length != 2)
{
    Console.WriteLine("Input error. Invalid amount format.");
    return;
}

if (!decimal.TryParse(amountParts[0], out decimal amount))
{
    Console.WriteLine("Input error. Invalid amount.");
    return;
}

string currency = amountParts[1];

Exchanger exchanger = new Exchanger(ratesDirectory);

List<ExchangeSum> convertedSums = exchanger.Convert(amount, currency);

foreach (ExchangeSum sum in convertedSums)
{
    Console.WriteLine(sum.ToString());
}