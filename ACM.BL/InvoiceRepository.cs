using System.Collections.Generic;

namespace ACM.BL
{
    public abstract class InvoiceRepository
    {
        /// <summary>
        /// Retrieves the list of invoices.
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public abstract IList<Invoice> Retrieve(int customerId);
    }
}
