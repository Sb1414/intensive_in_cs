using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace d01_ex00
{
    internal class Store
    {
        private int storageCapacity;
        private List<string> cashRegisters;

        public int StorageCapacity { get { return storageCapacity; } }
        public IReadOnlyList<string> CashRegisters { get { return cashRegisters.AsReadOnly(); } }

        public Store(int capacity, int countCashReg)
        {
            this.storageCapacity = capacity;

            cashRegisters = new List<string>();
            for (int i = 1; i <= countCashReg; i++)
            {
                cashRegisters.Add($"Cash Register #{i}");
            }
        }

        public bool IsOpen() // возвращает true, если на складе еще есть товар
        {
            return storageCapacity > 0;
        }
    }
}
