using ACM.BL;
using System.Collections.Generic;

namespace ACM.Win.Data
{
    internal class WinFormCustomerTypeRepository : CustomerTypeRepository
    {
        public override IList<CustomerType> Retrieve()
        {
            return new List<CustomerType> {
                new CustomerType { CustomerTypeId = 1, TypeName = "Corporate", DisplayOrder = 2 },
                new CustomerType { CustomerTypeId = 2, TypeName = "Individual", DisplayOrder = 1 },
                new CustomerType { CustomerTypeId = 3, TypeName = "Educator", DisplayOrder = 4 },
                new CustomerType { CustomerTypeId = 4, TypeName = "Government", DisplayOrder = 3 },
            };
        }
    }
}
