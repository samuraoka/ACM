using Moq;
using System.Collections.Generic;

namespace ACM.BL.Fixture.Test
{
    public class CustomerTypeRepositoryFixture
    {
        public CustomerTypeRepositoryFixture()
        {
            var mock = new Mock<CustomerTypeRepository>();
            mock.Setup(x => x.Retrieve()).Returns(() => new List<CustomerType> {
                new CustomerType { CustomerTypeId = 1, TypeName = "Corporate", DisplayOrder = 2 },
                new CustomerType { CustomerTypeId = 2, TypeName = "Individual", DisplayOrder = 1 },
                new CustomerType { CustomerTypeId = 3, TypeName = "Educator", DisplayOrder = 4 },
                new CustomerType { CustomerTypeId = 4, TypeName = "Government", DisplayOrder = 3 },
            });

            Repository = mock.Object;
        }

        public CustomerTypeRepository Repository { get; }
    }
}
