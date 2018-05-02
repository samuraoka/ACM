using ACM.Data;

namespace ACM.BL.Fixture.Test
{
    public class CustomerRepositoryFixture
    {
        public CustomerRepositoryFixture(InvoiceRepository invoiceRepository)
        {
            Repository = new ACMCustomerRepository(invoiceRepository);
        }

        public CustomerRepository Repository { get; private set; }
    }
}
