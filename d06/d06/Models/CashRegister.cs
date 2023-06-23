using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace d06.Models;

public class CashRegister
{
    public int No { get; }
    // public Queue<Customer> QueuedCustomers { get; }
    public ConcurrentQueue<Customer> QueuedCustomers { get; }

    public int ProcessingTimePerItem { get; set; }
    public int CustomerSwitchingTime { get; set; }
    public int TotalProcessingTime { get; private set; }
    public int SuccessfulCustomerCount { get; private set; }
    public List<Customer> SuccessfulCustomers { get; }


        
    public CashRegister(int number, int processingTimePerItem, int customerSwitchingTime)
    {
        No = number;
        // QueuedCustomers = new Queue<Customer>();
        QueuedCustomers = new ConcurrentQueue<Customer>();
        ProcessingTimePerItem = processingTimePerItem;
        CustomerSwitchingTime = customerSwitchingTime;
        TotalProcessingTime = 0;
        SuccessfulCustomers = new List<Customer>();
    }

    public void Process()
    {
        // while (QueuedCustomers.Count > 0)
        // {
        //     var customer = QueuedCustomers.Dequeue();
        //     var customerProcessingTime = customer.ItemsInCart * ProcessingTimePerItem;
        //     TotalProcessingTime += customerProcessingTime;
        //     SuccessfulCustomerCount++;
        //
        //     System.Threading.Thread.Sleep(customerProcessingTime * 1000);
        //
        //     System.Threading.Thread.Sleep(CustomerSwitchingTime * 1000);
        //     customer.ItemsInCart = 0;
        // }
        Customer customer;
        while (QueuedCustomers.TryDequeue(out customer))
        {
            var customerProcessingTime = customer.ItemsInCart * new Random().Next(1, ProcessingTimePerItem + 1); // ex Bonus
            TotalProcessingTime += customerProcessingTime;
            SuccessfulCustomerCount++;

            System.Threading.Thread.Sleep(customerProcessingTime * 1000);

            System.Threading.Thread.Sleep(CustomerSwitchingTime * 1000);

            customer.ItemsInCart = 0;
            SuccessfulCustomers.Add(customer);
        }
    }
    public override string ToString()
        => $"Register#{No} ({QueuedCustomers.Count} customers in line)";
}