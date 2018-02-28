using System.Diagnostics;
using System.Linq;
using Xunit;

namespace ACM.BL.Test
{
    public class CustomerRepositoryTest
    {
        //TODO

        [Fact]
        public void FindTestExistingCustomer()
        {
            // Arrange
            var repository = new CustomerRepository();
            var customerList = repository.Retrieve();

            // Act
            var result = customerList.FirstOrDefault(c =>
            {
                Debug.WriteLine(c.LastName);
                return c.CustomerId == 2;
            });

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.CustomerId);
            Assert.Equal("Baggins", result.LastName);
            Assert.Equal("Bilbo", result.FirstName);
        }

        [Fact]
        public void FindTestNotFound()
        {
            // Arrange
            var repository = new CustomerRepository();
            var customerList = repository.Retrieve();

            // Act
            var result = customerList.FirstOrDefault(c =>
            {
                Debug.WriteLine(c.LastName);
                return c.CustomerId == 42;
            });

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void SkipTest()
        {
            // Arrange
            var repository = new CustomerRepository();
            var customerList = repository.Retrieve();

            // Act
            var result = customerList
                .Where(c => c.CustomerTypeId == 1)
                .Skip(1).FirstOrDefault();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(3, result.CustomerId);
            Assert.Equal("Gamgee", result.LastName);
            Assert.Equal("Samwise", result.FirstName);
        }
    }
}
