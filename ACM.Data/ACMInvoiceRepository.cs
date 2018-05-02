using ACM.BL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ACM.Data
{
    public class ACMInvoiceRepository : InvoiceRepository
    {
        private readonly List<Invoice> invoices;

        public ACMInvoiceRepository()
        {
            invoices = new List<Invoice> {
                new Invoice()
                {
                    InvoiceId = 1,
                    CustomerId = 1,
                    InvoiceDate = new DateTime(2013, 6, 20),
                    DueDate = new DateTime(2013, 7,29),
                    IsPaid = null,
                    Amount=199.99M,
                    NumberOfUnits=20,
                    DiscountPercent=0M,
                },
                new Invoice()
                {
                    InvoiceId = 2,
                    CustomerId = 1,
                    InvoiceDate = new DateTime(2013, 7, 20),
                    DueDate = new DateTime(2013, 8,20),
                    IsPaid = null,
                    Amount=98.50M,
                    NumberOfUnits=10,
                    DiscountPercent=10M,
                },
                new Invoice()
                {
                    InvoiceId = 3,
                    CustomerId = 2,
                    InvoiceDate=new DateTime(2013, 7, 25),
                    DueDate=new DateTime(2013, 8,25),
                    IsPaid=null,
                    Amount=250M,
                    NumberOfUnits=25,
                    DiscountPercent=10M,
                },
                new Invoice()
                {
                    InvoiceId = 4,
                    CustomerId = 3,
                    InvoiceDate=new DateTime(2013, 7, 1),
                    DueDate=new DateTime(2013, 8,1),
                    IsPaid=true,
                    Amount=20M,
                    NumberOfUnits=2,
                    DiscountPercent=15M,
                },
                new Invoice()
                {
                    InvoiceId = 5,
                    CustomerId = 1,
                    InvoiceDate=new DateTime(2013, 8, 20),
                    DueDate=new DateTime(2013, 9,29),
                    IsPaid=true,
                    Amount=225M,
                    NumberOfUnits=22,
                    DiscountPercent=10M
                },
                new Invoice()
                {
                    InvoiceId = 6,
                    CustomerId = 2,
                    InvoiceDate=new DateTime(2013, 8, 20),
                    DueDate =new DateTime(2013, 8,20),
                    IsPaid=false,
                    Amount =75M,
                    NumberOfUnits =8,
                    DiscountPercent =0M
                },
                new Invoice()
                {
                    InvoiceId = 7,
                    CustomerId = 3,
                    InvoiceDate =new DateTime(2013,8, 25),
                    DueDate =new DateTime(2013, 9,25),
                    IsPaid =null,
                    Amount =500M,
                    NumberOfUnits =42,
                    DiscountPercent =10M
                },
                new Invoice()
                {
                    InvoiceId = 8,
                    CustomerId = 4,
                    InvoiceDate =new DateTime(2013, 8, 1),
                    DueDate =new DateTime(2013, 9,1),
                    IsPaid =true,
                    Amount =75M,
                    NumberOfUnits =7,
                    DiscountPercent =0M
                },
            };
        }

        public override IList<Invoice> Retrieve()
        {
            return invoices;
        }

        public override IList<Invoice> Retrieve(int customerId)
        {
            return invoices.Where(i => i.CustomerId == customerId).ToList();
        }

        public decimal CalculateMean(IEnumerable<Invoice> invoiceList)
        {
            return invoiceList.Average(inv => inv.DiscountPercent);
        }

        public decimal CalculateMedian(IEnumerable<Invoice> invoiceList)
        {
            if (invoiceList == null)
            {
                throw new ArgumentNullException("invoiceList");
            }

            var sortedList = invoiceList.OrderBy(inv => inv.DiscountPercent);
            int count = sortedList.Count();
            int position = count / 2;

            decimal median;
            if ((count % 2) == 0)
            {
                median = (sortedList.ElementAt(position - 1).DiscountPercent
                    + sortedList.ElementAt(position).DiscountPercent) / 2;
            }
            else
            {
                median = sortedList.ElementAt(position).DiscountPercent;
            }

            return median;
        }

        public decimal CalculateMode(IList<Invoice> invoiceList)
        {
            return invoiceList.GroupBy(inv => inv.DiscountPercent)
                .OrderByDescending(g => g.Count())
                .FirstOrDefault().Key;
        }
    }
}
