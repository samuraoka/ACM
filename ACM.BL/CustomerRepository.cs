using System;
using System.Collections.Generic;
using System.Linq;

namespace ACM.BL
{
    public abstract class CustomerRepository
    {
        public abstract IList<Customer> Retrieve();

        public IEnumerable<Customer> Find(IEnumerable<Customer> customerList, int customerId)
        {
            return customerList.Where(c => c.CustomerId == customerId);
        }

        public IEnumerable<Customer> SortByName(IEnumerable<Customer> customerList)
        {
            return customerList.OrderBy(c => c.LastName).ThenBy(c => c.FirstName);
        }

        public IEnumerable<Customer> SortByNameInReverse(IEnumerable<Customer> customerList)
        {
            return customerList
                .OrderByDescending(c => c.LastName)
                .ThenByDescending(c => c.FirstName);
        }

        public IEnumerable<Customer> SortByType(IEnumerable<Customer> customerList)
        {
            return customerList
                .OrderByDescending(c => c.CustomerTypeId.HasValue)
                .ThenBy(c => c.CustomerTypeId);
        }

        public IEnumerable<string> GetNames(IEnumerable<Customer> customerList)
        {
            return customerList
                .Select(c => c.LastName + ", " + c.FirstName);
        }

        public dynamic GetNamesAndId(IEnumerable<Customer> customerList)
        {
            var query = customerList.OrderBy(c => c.LastName)
                .ThenBy(c => c.FirstName)
                .Select(c => new
                {
                    Name = string.Join(", ", c.LastName, c.FirstName),
                    c.CustomerId,
                });
            return query.ToList();
        }

        public IEnumerable<CustomerNameAndEmail> GetNameAndEmails(IEnumerable<Customer> customerList)
        {
            return customerList
                .Select(c => new CustomerNameAndEmail
                {
                    Name = c.LastName + ", " + c.FirstName,
                    EmailAddress = c.EmailAddress
                });
        }

        public IEnumerable<CustomerNameAndType> GetNameAndTypes(IEnumerable<Customer> customerList, IEnumerable<CustomerType> customerTypeList)
        {
            return customerList.Join(
                customerTypeList, c => c.CustomerTypeId, t => t.CustomerTypeId,
                (c, t) => new CustomerNameAndType
                {
                    Name = c.LastName + ", " + c.FirstName,
                    CustomerTypeName = t.TypeName
                });
        }

        public IEnumerable<Customer> GetOverdueCustomers(IEnumerable<Customer> customerList)
        {
            // ?? Operator (C# Reference)
            // https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/null-conditional-operator
            return customerList
                .SelectMany(c => c.InvoiceList.Where(i => (i.IsPaid ?? false) == false),
                (c, i) => c).Distinct();
        }

        public IDictionary<int, Tuple<string, decimal>> GetInvoiceTotalByCustomerType(
            IEnumerable<Customer> customerList, IEnumerable<CustomerType> customerTypeList)
        {
            return customerList.Join(customerTypeList,
                c => c.CustomerTypeId ?? 0, ct => ct.CustomerTypeId,
                (c, ct) => new
                {
                    CustomerInstance = c,
                    CustomerTypeName = ct.TypeName,
                }).GroupBy(c => new
                {
                    CustomerType = c.CustomerInstance.CustomerTypeId ?? 0,
                    c.CustomerTypeName,
                },
                c => c.CustomerInstance.InvoiceList.Sum(inv => inv.TotalAmount)).
                ToDictionary(g => g.Key.CustomerType, g => Tuple.Create(g.Key.CustomerTypeName, g.Sum()));
        }

        public IEnumerable<KeyValuePair<string, decimal>> GetInvoiceTotalByCustomerTypeInKeyValuePair(
            IEnumerable<Customer> customerList, IEnumerable<CustomerType> customerTypeList)
        {
            var data = new List<KeyValuePair<string, decimal>>();
            GetInvoiceTotalByCustomerType(customerList, customerTypeList).Values.ToList().ForEach(
                x => data.Add(new KeyValuePair<string, decimal>(x.Item1, x.Item2)));
            return data;
        }
    }
}
