// See https://aka.ms/new-console-template for more information
using System.Globalization;
using System;
using System.Runtime.InteropServices;

try
{
    if (args.Length < 3)
    {
        throw new Exception("Something went wrong. Check your input and retry.");
    }

    if (!double.TryParse(args[0], out double loanAmount) || loanAmount <= 0 ||
        !double.TryParse(args[1], out double annualPercentageRate) || annualPercentageRate <= 0 ||
        !int.TryParse(args[2], out int numberOfMonths) || numberOfMonths <= 0)
    {
        throw new Exception("Something went wrong. Check your input and retry.");
    }
    CultureInfo enGBCulture = new CultureInfo("en-GB");

    double monthlyInterestRate = annualPercentageRate / 12 / 100;

    double monthlyPayment = (loanAmount * monthlyInterestRate * Math.Pow(1 + monthlyInterestRate, numberOfMonths)) /
                                (Math.Pow(1 + monthlyInterestRate, numberOfMonths) - 1);

    double totalDebtBalance = loanAmount;

    // DateTime currentDate = DateTime.Now;
    DateTime currentDate = new DateTime(2021, 5, 1);
    for (int paymentNumber = 1; paymentNumber <= numberOfMonths; paymentNumber++)
    {
        DateTime paymentDate = currentDate.AddMonths(paymentNumber);
        double interestPayment = totalDebtBalance * monthlyInterestRate;
        double principalPayment = monthlyPayment - interestPayment;
        totalDebtBalance -= principalPayment;
        double roundedTotalDebtBalance = Math.Round(totalDebtBalance, 2); // чтобы не было -0 в конце

        Console.WriteLine($"{paymentNumber,-9}\t{paymentDate.ToString("d", enGBCulture),-12}\t{monthlyPayment.ToString("N2", enGBCulture),13}\t" +
                $"{principalPayment.ToString("N2", enGBCulture),12}\t{interestPayment.ToString("N2", enGBCulture),15}\t{roundedTotalDebtBalance.ToString("N2", enGBCulture),15}");

    }

}
catch (Exception ex)
{
    Console.WriteLine($"{ex.Message}");
}

