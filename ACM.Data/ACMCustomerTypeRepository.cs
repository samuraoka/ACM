﻿using ACM.BL;
using System.Collections.Generic;

namespace ACM.Data
{
    public class ACMCustomerTypeRepository : CustomerTypeRepository
    {
        public override IList<CustomerType> Retrieve()
        {
            return new List<CustomerType> {
                new CustomerType { CustomerTypeId = 0, TypeName = "N/A", DisplayOrder = int.MaxValue },
                new CustomerType { CustomerTypeId = 1, TypeName = "Corporate", DisplayOrder = 2 },
                new CustomerType { CustomerTypeId = 2, TypeName = "Individual", DisplayOrder = 1 },
                new CustomerType { CustomerTypeId = 3, TypeName = "Educator", DisplayOrder = 4 },
                new CustomerType { CustomerTypeId = 4, TypeName = "Government", DisplayOrder = 3 },
            };
        }
    }
}
