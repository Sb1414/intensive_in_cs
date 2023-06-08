// See https://aka.ms/new-console-template for more information
using d01_ex00;

Storage storage = new Storage(100);

if (storage.IsEmpty())
{
    Console.WriteLine("Storage is empty.");
}
else
{
    Console.WriteLine("Storage is not empty.");
}

Customer customer = new Customer(1, "Andrew");
Console.WriteLine(customer.ToString());

var customer1 = new Customer(1, "Andrew");
var customer2 = new Customer(1, "Andrew");

Console.WriteLine(customer1 == customer2);
