﻿using System.Collections.Generic;
using System.Linq;
using d06.Models;

namespace d06.Extensions;

public static class CustomerExtensions
{
    public static CashRegister GetInLineByPeople(this Customer customer, IEnumerable<CashRegister> registers)
    {
        var register = registers
            .OrderBy(x => x.QueuedCustomers.Count)
            .FirstOrDefault();

        register?.QueuedCustomers.Enqueue(customer);

        return register;
    }

    public static CashRegister GetInLineByItems(this Customer customer, IEnumerable<CashRegister> registers)
    {
        var register = registers
            .OrderBy(x => x.QueuedCustomers.Sum(c => c.ItemsInCart))
            .FirstOrDefault();

        register?.QueuedCustomers.Enqueue(customer);

        return register;
    }
}