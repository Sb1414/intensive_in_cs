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
var customer8 = new Customer(1, "Customer 2");
var customer9 = new Customer(2, "Customer 3");

customer7.FillCart(50);
customer8.FillCart(5);
customer9.FillCart(5);

cashRegister3.AddCustomer(customer7);
cashRegister4.AddCustomer(customer8);
cashRegister4.AddCustomer(customer9);

var cashRegisters = new List<CashRegister> { cashRegister3, cashRegister4 };

var chosenCashRegister3 = customer9.ChooseCashRegisterByFewestCustomers(cashRegisters);
Console.WriteLine($"наименьшее количество клиентов: {chosenCashRegister3?.Name}");

var chosenCashRegister4 = customer9.ChooseCashRegisterByFewestItems(cashRegisters);
Console.WriteLine($"наименьшее количество товаров: {chosenCashRegister4?.Name}");

// ex06
Console.WriteLine("\n============ ex06 ============\n");

var store_ = new Store(40, 3);

var customers = new List<Customer>
{
    new Customer(1, "Andrew"),
    new Customer(2, "Pavel"),
    new Customer(3, "Anastasia"),
    new Customer(4, "Marina"),
    new Customer(5, "Ekaterina"),
    new Customer(6, "Ivan"),
    new Customer(7, "Dmitry"),
    new Customer(8, "Anna"),
    new Customer(9, "Elena"),
    new Customer(10, "Tanya")
};

while (store_.IsOpen() && customers.Any())
{
    foreach (var customer_ in customers.ToList())
    {
        if (customer_.CartItems == 0)
        {
            customer_.FillCart(7);
            if (customer_.CartItems > store_.Storage.CurrentQuantity)
            {
                var chosenCashRegister_ = customer_.ChooseCashRegisterByFewestCustomers(store_.CashRegisters);
                Console.WriteLine($"{customer_.Name}, Customer #{customer_.CustomerNumber} ({customer_.CartItems} items in cart) - " +
                    $"{chosenCashRegister_}, ({chosenCashRegister_.GetCustomersCount()} people with " +
                    $"{chosenCashRegister_.GetTotalItemsInQueue()} items behind)");
                customer_.SetCartItems(store_.Storage.CurrentQuantity);
            }
            store_.Storage.TakeItems(customer_.CartItems);
        }

        var chosenCashRegister = customer_.ChooseCashRegisterByFewestCustomers(store_.CashRegisters);
        if (chosenCashRegister != null)
        {
            chosenCashRegister.AddCustomer(customer_);
            customers.Remove(customer_);
        }
    }
}


/*

// Create a store with 3 cash registers and a storage capacity of 40
Store st = new Store(40, 3);
Storage storage2 = new Storage(40); // Создайте экземпляр класса Storage

// Create 10 different customers
List<Customer> customers = new List<Customer>();
for (int i = 1; i <= 10; i++)
{
    customers.Add(new Customer(i, $"Customer{i}"));
}

while (st.IsOpen() && customers.Count > 0)
{
    foreach (Customer cust in customers.ToArray())
    {
        cust.FillCart(7);

        CashRegister chosenCashRegister = cust.ChooseCashRegisterByFewestCustomers(st.CashRegisters);

        chosenCashRegister.AddCustomer(cust);

        if (cust.CartItems == 0)
        {
            customers.Remove(cust);
        }
        foreach (CashRegister cashRegister in st.CashRegisters)
        {
            if (cashRegister.GetCustomersCount() > 0)
            {
                Customer servedCustomer_ = cashRegister.ServeNextCustomer();

                st.StorageCapacity -= servedCustomer_.CartItems; // Обновление storageCapacity

                if (st.StorageCapacity < 0 && servedCustomer_.CartItems > 0)
                {
                    Console.WriteLine($"{servedCustomer_.Name}, покупатель #{servedCustomer_.CustomerNumber} ({servedCustomer_.CartItems} предметов осталось в корзине)");
                }

                Console.WriteLine($"{servedCustomer_}, {chosenCashRegister} ({cashRegister.GetCustomersCount()} человек с {cashRegister.GetTotalItemsInQueue()} предметами позади)");
            }
        }
    }
}

*/
