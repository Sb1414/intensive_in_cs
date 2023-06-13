// See https://aka.ms/new-console-template for more information
using d01_ex00;

// ex00
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
Customer customer = new Customer(1, "Andrew");
Console.WriteLine(customer.ToString());

var customer1 = new Customer(1, "Andrew");
var customer2 = new Customer(1, "Andrew");

Console.WriteLine(customer1 == customer2);

// ex02
var customer3 = new Customer(1, "Andrew");
var customer4 = new Customer(2, "John");
var customer5 = new Customer(3, "Emily");

customer3.FillCart(15);
customer4.FillCart(15);
customer5.FillCart(15);

Console.WriteLine(customer3);
Console.WriteLine(customer4);
Console.WriteLine(customer5);
