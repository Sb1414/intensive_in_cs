using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace d01_ex00
{
    internal class CashRegister
    {
        private readonly string name;
        private Queue<Customer> customers;

        public string Name { get { return name; } }

        public CashRegister(string name)
        {
            this.name = name;
            customers = new Queue<Customer>();
        }

        public void AddCustomer(Customer customer)
        {
            customers.Enqueue(customer);
        }

        public Customer ServeNextCustomer()
        {
            return customers.Dequeue();
        }

        public override string ToString()
        {
            return Name;
        }

        public static bool operator ==(CashRegister register1, CashRegister register2)
        {
            if (ReferenceEquals(register1, register2))
                return true;

            if (register1 is null || register2 is null)
                return false;

            return register1.Name == register2.Name;
        }

        public static bool operator !=(CashRegister register1, CashRegister register2)
        {
            return !(register1 == register2);
        }

    }
}
