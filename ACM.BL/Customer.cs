using Newtonsoft.Json;
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
                   new InvoiceListEqualityComparer().Equals(InvoiceList, customer.InvoiceList);
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

    public class InvoiceListEqualityComparer : IEqualityComparer<IList<Invoice>>
    {
        public bool Equals(IList<Invoice> x, IList<Invoice> y)
        {
            if (x == y)
            {
                return true;
            }

            if (x == null || y == null || x.Count != y.Count)
            {
                return false;
            }

            bool result = true;
            for (int i = 0; i < x.Count; i++)
            {
                result &= x[i].Equals(y[i]);
            }
            return result;
        }

        public int GetHashCode(IList<Invoice> obj)
        {
            // TODO
            throw new System.NotImplementedException();
        }
    }
}
