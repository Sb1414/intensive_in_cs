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
