﻿using System;
using System.Collections.Generic;
using System.Globalization;
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

        public IDictionary<bool, decimal> GetInvoiceTotalByIsPaid(IList<Invoice> invoiceList)
        {
            // Is there a better way to aggregate a dictionary using LINQ?
            // https://stackoverflow.com/questions/3338166/is-there-a-better-way-to-aggregate-a-dictionary-using-linq
            return invoiceList.GroupBy(
                inv => inv.IsPaid ?? false,
                inv => inv.TotalAmount).ToDictionary(g => g.Key, g => g.Sum());
        }

        public IDictionary<Tuple<bool, string>, decimal> GetInvoiceTotalByIsPaidAndMonth(IList<Invoice> invoiceList)
        {
            return invoiceList.GroupBy(
                inv => new
                {
                    IsPaid = inv.IsPaid ?? false,
                    InvoiceMonth = inv.InvoiceDate.ToString("MMMM", new CultureInfo("en-us")),
                },
                inv => inv.TotalAmount).
                ToDictionary(g => Tuple.Create(g.Key.IsPaid, g.Key.InvoiceMonth), g => g.Sum());
        }
    }
}
