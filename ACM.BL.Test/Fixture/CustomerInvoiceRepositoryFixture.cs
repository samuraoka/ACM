namespace ACM.BL.Fixture.Test
{
    public class CustomerInvoiceRepositoryFixture
    {
        public CustomerRepositoryFixture CustomerRepoFixture { get; }
        public InvoiceRepositoryFixture InvoiceRepoFixture { get; }

        public CustomerInvoiceRepositoryFixture()
        {
            InvoiceRepoFixture = new InvoiceRepositoryFixture();
            CustomerRepoFixture = new CustomerRepositoryFixture(InvoiceRepoFixture.Repository);
        }
    }
}
