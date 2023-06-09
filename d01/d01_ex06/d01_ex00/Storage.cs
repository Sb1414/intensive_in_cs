using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace d01_ex00
{
    internal class Storage
    {
        private int capacity; // capacity
        private int currentQuantity; // current quantity

        public Storage(int capacity)
        {
            Capacity = capacity;
            CurrentQuantity = capacity;
        }

        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }

        public int CurrentQuantity
        {
            get { return currentQuantity; }
            set { currentQuantity = value; }
        }

        public bool IsEmpty() => CurrentQuantity == 0;

        public void TakeItems(int quantity)
        {
            if (quantity <= CurrentQuantity)
            {
                CurrentQuantity -= quantity;
            }
            else
            {
                CurrentQuantity = 0;
            }
        }
    }

}
