using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ACM.BL
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? CustomerTypeId { get; set; }
        public string EmailAddress { get; set; }
        public IList<Invoice> InvoiceList { get; set; }

        public override bool Equals(object obj)
        {
            var customer = obj as Customer;
            return customer != null &&
                   CustomerId == customer.CustomerId &&
                   FirstName == customer.FirstName &&
                   LastName == customer.LastName &&
                   EqualityComparer<int?>.Default.Equals(CustomerTypeId, customer.CustomerTypeId) &&
                   EmailAddress == customer.EmailAddress &&
                   EqualityComparer<IList<Invoice>>.Default.Equals(InvoiceList, customer.InvoiceList);
        }

        public override int GetHashCode()
        {
            // What is the best algorithm for an overridden System.Object.GetHashCode?
            // https://stackoverflow.com/questions/263400/what-is-the-best-algorithm-for-an-overridden-system-object-gethashcode

            unchecked
            {
                var hashCode = 1284107729;
                hashCode = hashCode * -1521134295 + CustomerId.GetHashCode();
                hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FirstName);
                hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(LastName);
                hashCode = hashCode * -1521134295 + EqualityComparer<int?>.Default.GetHashCode(CustomerTypeId);
                hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(EmailAddress);
                hashCode = hashCode * -1521134295 + EqualityComparer<IList<Invoice>>.Default.GetHashCode(InvoiceList);
                return hashCode;
            }
        }

        public override string ToString()
        {
            // Convert JSON String To C# Object
            // https://stackoverflow.com/questions/4611031/convert-json-string-to-c-sharp-object
            return JsonConvert.SerializeObject(this);
        }
    }

    public class CustomerEqualityComparer : IEqualityComparer<Customer>
    {
        public bool Equals(Customer x, Customer y)
        {
            if (x == null || y == null)
            {
                throw new ArgumentNullException("arguments cannot be null");
            }

            if (x.InvoiceList == null || y.InvoiceList == null
                || x.InvoiceList.Count != y.InvoiceList.Count)
            {
                return false;
            }

            bool result = true;
            result &= x.CustomerId.Equals(y.CustomerId);
            result &= x.FirstName.Equals(y.FirstName);
            result &= x.LastName.Equals(y.LastName);
            result &= x.EmailAddress.Equals(y.EmailAddress);
            result &= x.CustomerTypeId.Equals(y.CustomerTypeId);

            for (int i = 0; i < x.InvoiceList.Count; i++)
            {
                result &= x.InvoiceList[i].Equals(y.InvoiceList[i]);
            }
            return result;
        }

        public int GetHashCode(Customer obj)
        {
            //TODO
            throw new System.NotImplementedException();
        }
    }
}
