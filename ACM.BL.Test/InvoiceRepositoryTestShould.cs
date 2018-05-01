using ACM.Data;
using System;
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

        [Theory]
        [InlineData(true, "294.5")]
        [InlineData(false, "1038.64")]
        public void GetInvoiceTotalByIsPaid(bool isPaid, string invoiceTotal)
        {
            // Arrange
            var invoiceList = repo.Retrieve();

            // Act
            var actual = repo.GetInvoiceTotalByIsPaid(invoiceList);

            // Assert
            // Having an actual decimal value as parameter for an attribute (example xUnit.net's [InlineData]
            // https://stackoverflow.com/questions/37854264/having-an-actual-decimal-value-as-parameter-for-an-attribute-example-xunit-net
            Assert.Equal(Convert.ToDecimal(invoiceTotal), actual[isPaid]);
        }
    }
}
