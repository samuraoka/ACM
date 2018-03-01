using System.Collections.Generic;
using System.Linq;

namespace ACM.BL
{
    public abstract class CustomerRepository
    {
        public abstract IList<Customer> Retrieve();

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

        public IEnumerable<Customer> GetOverdueCustomers(IList<Customer> customerList)
        {
            // ?? Operator (C# Reference)
            // https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/null-conditional-operator
            return customerList
                .SelectMany(c => c.InvoiceList.Where(i => (i.IsPaid ?? false) == false),
                (c, i) => c).Distinct();
        }
    }
}
