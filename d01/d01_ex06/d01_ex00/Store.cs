using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace d01_ex00
{
    internal class Store
    {
        private int storageCapacity;
        private List<CashRegister> cashRegisters;
        public Storage Storage { get; }

        public int StorageCapacity { get; set; }
        public IReadOnlyList<CashRegister> CashRegisters { get { return cashRegisters.AsReadOnly(); } }

        public Store(int capacity, int countCashReg)
        {
            this.storageCapacity = capacity;
            Storage = new Storage(capacity);

            cashRegisters = new List<CashRegister>();
            for (int i = 1; i <= countCashReg; i++)
            {
                cashRegisters.Add(new CashRegister($"Register #{i}"));
            }
        }

        public bool IsOpen() // возвращает true, если на складе еще есть товар
        {
            return storageCapacity > 0;
        }
    }

}
