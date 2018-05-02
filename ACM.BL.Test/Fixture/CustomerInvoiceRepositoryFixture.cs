using ACM.Data;

namespace ACM.BL.Fixture.Test
{
    public class CustomerInvoiceRepositoryFixture
    {
        public CustomerRepository CustomerRepository { get; }
        public InvoiceRepository InvoiceRepository { get; }

        public CustomerInvoiceRepositoryFixture()
        {
            InvoiceRepository = new InvoiceRepositoryFixture().Repository;
            CustomerRepository = new ACMCustomerRepository(InvoiceRepository);
        }
    }
}
