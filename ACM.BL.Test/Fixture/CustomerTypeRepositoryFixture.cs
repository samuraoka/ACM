using ACM.Data;

namespace ACM.BL.Fixture.Test
{
    public class CustomerTypeRepositoryFixture
    {
        public CustomerTypeRepositoryFixture()
        {
            Repository = new ACMCustomerTypeRepository();
        }

        public CustomerTypeRepository Repository { get; }
    }
}
