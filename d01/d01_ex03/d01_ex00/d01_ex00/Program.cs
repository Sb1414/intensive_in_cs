// See https://aka.ms/new-console-template for more information
using d01_ex00;
using System;

// ex00
Console.WriteLine("============ ex00 ============");
Storage storage = new Storage(100);

if (storage.IsEmpty())
{
    Console.WriteLine("Storage is empty.");
}
else
{
    Console.WriteLine("Storage is not empty.");
}

// ex01
Console.WriteLine("============ ex01 ============");
Customer customer = new Customer(1, "Andrew");
Console.WriteLine(customer.ToString());

var customer1 = new Customer(1, "Andrew");
var customer2 = new Customer(1, "Andrew");

Console.WriteLine(customer1 == customer2);

// ex02
Console.WriteLine("============ ex02 ============");
var customer3 = new Customer(1, "Andrew");
var customer4 = new Customer(2, "John");
var customer5 = new Customer(3, "Emily");

customer3.FillCart(15);
customer4.FillCart(15);
customer5.FillCart(15);

Console.WriteLine(customer3);
Console.WriteLine(customer4);
Console.WriteLine(customer5);

// ex03
Console.WriteLine("============ ex03 ============");
var cashRegister1 = new CashRegister("Register #1");
var cashRegister2 = new CashRegister("Register #1");

Console.WriteLine(cashRegister1 == cashRegister2);

var customer6 = new Customer(1, "Andrew");

cashRegister1.AddCustomer(customer6);
customer6.FillCart(15);

Console.WriteLine(cashRegister1);

var servedCustomer = cashRegister1.ServeNextCustomer();
Console.WriteLine(servedCustomer);

