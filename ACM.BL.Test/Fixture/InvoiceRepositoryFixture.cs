using ACM.Data;

namespace ACM.BL.Fixture.Test
{
    public class InvoiceRepositoryFixture
    {
        public InvoiceRepositoryFixture()
        {
            Repository = new ACMInvoiceRepository();
        }

        public InvoiceRepository Repository { get; }
    }
}
