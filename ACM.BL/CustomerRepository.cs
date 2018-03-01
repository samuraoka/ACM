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
    }
}
