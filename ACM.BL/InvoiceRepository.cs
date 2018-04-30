using System.Collections.Generic;
using System.Linq;

namespace ACM.BL
{
    public abstract class InvoiceRepository
    {
        /// <summary>
        /// Retrieves the list of invoices.
        /// </summary>
        public abstract IList<Invoice> Retrieve();

        /// <summary>
        /// Retrieves the list of invoices.
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public abstract IList<Invoice> Retrieve(int customerId);

        public decimal CalculateTotalAmountInvoiced(IList<Invoice> invoiceList)
        {
            return invoiceList.Sum(inv => inv.TotalAmount);
        }

        public decimal CalculateTotalUnitsSold(IList<Invoice> invoiceList)
        {
            return invoiceList.Sum(inv => inv.NumberOfUnits);
        }
    }
}
