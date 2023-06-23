using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using d06.Extensions;
using d06.Models;
using Microsoft.Extensions.Configuration;

const int registerCount = 3;
const int storageCapacity = 40;
const int cartCapacity = 7;
const int customerCount = 10;

string currentDirectory = Directory.GetCurrentDirectory();
string appSettingsPath = Path.Combine(currentDirectory, "appsettings.json");

ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
configurationBuilder
    .AddJsonFile(appSettingsPath);
var conf = configurationBuilder.Build();

if (!int.TryParse(conf["ProcessingTimePerItem"], out var processingTimePerItem)
    || !int.TryParse(conf["CustomerSwitchingTime"], out var customerSwitchingTime))
{
    Console.WriteLine("Wrong \"appsettings.json\" file parameters");
    return;
}

var customers = Enumerable.Range(1, customerCount)
    .Select(x => new Customer(x))
    .ToArray();
            
var shop = new Store(registerCount, storageCapacity, processingTimePerItem, customerSwitchingTime);

Console.WriteLine("Lines by people count:");

var i = 0;
while (shop.IsOpen && i < customerCount)
{
    var customer = customers[i++];
                
    customer.FillCart(cartCapacity);
    // ex01 ---> TakeItemsFromStorage()
    if (customer.ItemsInCart <= shop.Storage.ItemsInStorage && shop.Storage.TakeItemsFromStorage(customer.ItemsInCart))
    {
        var register = customer.GetInLineByPeople(shop.Registers);
        Console.WriteLine($"{customer} to {register}");
    }
    else
    {
        Console.WriteLine($"{customer} leaves the store");
    }
}

Console.WriteLine("\n" + "Opening registers..."); // ex02
shop.OpenRegisters();


Console.WriteLine("================ ex04 =========================");

var shopEx4 = new Store(registerCount, storageCapacity, processingTimePerItem, customerSwitchingTime);
var customersEx4 = Enumerable.Range(1, 20)
    .Select(x => new Customer(x))
    .ToArray();

Parallel.ForEach(customersEx4, customer =>
{
    customer.FillCart(cartCapacity);
    if (customer.ItemsInCart <= shopEx4.Storage.ItemsInStorage && shopEx4.Storage.TakeItemsFromStorage(customer.ItemsInCart))
    {
        var register = customer.GetInLineByPeople(shopEx4.Registers);
        Console.WriteLine($"{customer} to {register}");
    }
    else // не хватает товаров на складе
    {
        Console.WriteLine($"{customer} leaves the store");
    }
});
