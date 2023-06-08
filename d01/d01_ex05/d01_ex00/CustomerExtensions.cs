using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace d01_ex00
{
    internal static class CustomerExtensions
    {
        public static CashRegister ChooseCashRegisterByFewestCustomers(this Customer customer, IEnumerable<CashRegister> cashRegisters)
        {
            // с наименьшим количеством покупателей
            return cashRegisters.OrderBy(cr => cr.GetCustomersCount()).FirstOrDefault();
        }

        public static CashRegister ChooseCashRegisterByFewestItems(this Customer customer, IEnumerable<CashRegister> cashRegisters)
        {
            // с наименьшим количеством товаров среди всех покупателей в очереди
            return cashRegisters.OrderBy(cr => cr.GetTotalItemsInQueue()).FirstOrDefault();
        }
    }

}
