using System.Collections.Generic;

namespace ACM.BL
{
    public abstract class CustomerTypeRepository
    {
        public abstract IList<CustomerType> Retrieve();
    }
}
