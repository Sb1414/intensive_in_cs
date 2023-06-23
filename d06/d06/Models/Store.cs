using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace d06.Models;

public class Store
{
    public List<CashRegister> Registers { get; }
    public Storage Storage { get; }

    public bool IsOpen => !Storage.IsEmpty;

    public Store(int registerCount, int storageCapacity, int processingTimePerItem, int customerSwitchingTime)
    {
        Storage = new Storage(storageCapacity);
        Registers = Enumerable.Range(1, registerCount)
            .Select(i => new CashRegister(i, processingTimePerItem, customerSwitchingTime))
            .ToList();
    }
    
    public void OpenRegisters()
    {
        var registerThreads = Registers.Select(register => new Thread(() => ProcessRegister(register))).ToList();

        foreach (var thread in registerThreads)
        {
            thread.Start();
        }

        foreach (var thread in registerThreads)
        {
            thread.Join();
        }
    }

    private void ProcessRegister(CashRegister register) // для наглядности
    {
        Console.WriteLine($"==> Register #{register.No} is processing customers");

        register.Process();

        Console.WriteLine($"==> Register #{register.No} has finished processing customers");
    }
}