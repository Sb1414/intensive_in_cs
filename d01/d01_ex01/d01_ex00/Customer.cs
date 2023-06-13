using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace d01_ex00
{
    internal class Customer
    {
        private readonly int customerNumber;
        private readonly string name;

        public int CustomerNumber { get { return customerNumber; } }
        public string Name { get { return name; } }

        public Customer(int customerNumber, string name)
        {
            this.customerNumber = customerNumber;
            this.name = name;
        }

        public override bool Equals(object obj)
        {
            if (obj is not Customer other)
                return false;

            return customerNumber == other.customerNumber && name == other.name;
        }

        public override string ToString()
        {
            return $"{Name}, customer #{CustomerNumber}";
        }

        public static bool operator ==(Customer customer1, Customer customer2)
        {
            if (ReferenceEquals(customer1, customer2))
                return true;

            if (customer1 is null || customer2 is null)
                return false;

            return customer1.Equals(customer2);
        }

        public static bool operator !=(Customer customer1, Customer customer2)
        {
            return !(customer1 == customer2);
        }
    }
}
