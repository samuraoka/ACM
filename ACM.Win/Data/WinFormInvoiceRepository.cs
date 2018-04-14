using ACM.BL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ACM.Win.Data
{
    internal class WinFormInvoiceRepository : InvoiceRepository
    {
        private readonly List<Invoice> invoices;

        public WinFormInvoiceRepository()
        {
            invoices = new List<Invoice> {
                new Invoice()
                {
                    InvoiceId = 1,
                    CustomerId = 1,
                    InvoiceDate = new DateTime(2013, 6, 20),
                    DueDate = new DateTime(2013, 8,29),
                    IsPaid = null
                },
                new Invoice()
                {
                    InvoiceId = 2,
                    CustomerId = 1,
                    InvoiceDate = new DateTime(2013, 7, 20),
                    DueDate = new DateTime(2013, 8,20),
                    IsPaid = null
                },
                new Invoice()
                {
                    InvoiceId = 3,
                    CustomerId = 2,
                    InvoiceDate=new DateTime(2013, 7, 25),
                    DueDate=new DateTime(2013, 8,25),
                    IsPaid=null
                },
                new Invoice()
                {
                    InvoiceId = 4,
                    CustomerId = 3,
                    InvoiceDate=new DateTime(2013, 7, 1),
                    DueDate=new DateTime(2013, 9,1),
                    IsPaid=true
                },
            };
        }

        public override IList<Invoice> Retrieve(int customerId)
        {
            return invoices.Where(i => i.CustomerId == customerId).ToList();
        }
    }
}
