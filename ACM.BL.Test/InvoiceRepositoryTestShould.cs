using ACM.Data;
using Xunit;
using Xunit.Abstractions;

namespace ACM.BL.Test
{
    public class InvoiceRepositoryTestShould
    {
        private readonly ITestOutputHelper output;
        private readonly ACMInvoiceRepository repo;

        public InvoiceRepositoryTestShould(ITestOutputHelper output)
        {
            this.output = output;
            repo = new ACMInvoiceRepository();
        }

        [Fact]
        public void CalculateTotalAmountInvoiced()
        {
            // Arrange
            var invoiceList = repo.Retrieve();

            // Act
            var actual = repo.CalculateTotalAmountInvoiced(invoiceList);

            // Assert
            Assert.Equal(1333.14M, actual);
        }

        [Fact]
        public void CalculateTotalUnitsSold()
        {
            // Arrange
            var invoiceList = repo.Retrieve();

            // Act
            var actual = repo.CalculateTotalUnitsSold(invoiceList);

            // Assert
            Assert.Equal(136M, actual);
        }
    }
}
