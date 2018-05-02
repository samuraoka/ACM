using ACM.Data;

namespace ACM.BL.Fixture.Test
{
    public class CustomerRepositoryFixture
    {
        public CustomerRepository CustomerRepository { get; }
        public InvoiceRepository InvoiceRepository { get; }

        public CustomerRepositoryFixture()
        {
            InvoiceRepository = new InvoiceRepositoryFixture().Repository;
            CustomerRepository = new ACMCustomerRepository(InvoiceRepository);
        }
    }
}
