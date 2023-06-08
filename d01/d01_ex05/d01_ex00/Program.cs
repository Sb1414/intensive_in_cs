// See https://aka.ms/new-console-template for more information
using d01_ex00;
using System;

// ex00
Console.WriteLine("\n============ ex00 ============\n");
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
Console.WriteLine("\n============ ex01 ============\n");
Customer customer = new Customer(1, "Andrew");
Console.WriteLine(customer.ToString());

var customer1 = new Customer(1, "Andrew");
var customer2 = new Customer(1, "Andrew");

Console.WriteLine(customer1 == customer2);

// ex02
Console.WriteLine("\n============ ex02 ============\n");
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
Console.WriteLine("\n============ ex03 ============\n");
var cashRegister1 = new CashRegister("Register #1");
var cashRegister2 = new CashRegister("Register #1");

Console.WriteLine(cashRegister1 == cashRegister2);

var customer6 = new Customer(1, "Andrew");

cashRegister1.AddCustomer(customer6);
customer6.FillCart(15);

Console.WriteLine(cashRegister1);

var servedCustomer = cashRegister1.ServeNextCustomer();
Console.WriteLine(servedCustomer);

// ex04
Console.WriteLine("\n============ ex04 ============\n");

var store = new Store(100, 3);

Console.WriteLine($"Размер: {store.StorageCapacity}");
Console.WriteLine($"Кассовые аппараты: {string.Join(", ", store.CashRegisters)}");
Console.WriteLine(store.IsOpen());  // Output: Is Open? True

// ex05
Console.WriteLine("\n============ ex05 ============\n");

var cashRegister3 = new CashRegister("Cash Register #1");
var cashRegister4 = new CashRegister("Cash Register #2");

var customer7 = new Customer(1, "Customer 1");
var customer8 = new Customer(2, "Customer 2");

cashRegister3.AddCustomer(customer1);
cashRegister4.AddCustomer(customer2);

var cashRegisters = new List<CashRegister> { cashRegister3, cashRegister4 };

var chosenCashRegister1 = customer7.ChooseCashRegisterByFewestCustomers(cashRegisters);
Console.WriteLine($"наименьшее количество клиентов: {chosenCashRegister1?.Name}");

var chosenCashRegister2 = customer8.ChooseCashRegisterByFewestItems(cashRegisters);
Console.WriteLine($"наименьшее количество товаров: {chosenCashRegister2?.Name}");
