using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Xunit;

namespace ACM.BL.Test
{
    public class CustomerRepositoryTest
    {
        //TODO

        [Fact]
        public void ShouldReturnExistingCustomer()
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
        public void ShouldReturnNullIfNoCustomerFound()
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
        public void ShouldSkipSomeCustomers()
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

        [Fact]
        public void ShouldSortByName()
        {
            // Arrange
            var repository = new CustomerRepository();
            var customerList = repository.Retrieve();

            // Act
            var result = repository.SortByName(customerList);

            // Assert
            // xUnit : Assert two List<T> are equal?
            // https://stackoverflow.com/questions/419659/xunit-assert-two-listt-are-equal
            var expected = new List<Customer>
            {
                new Customer
                {
                    CustomerId = 2,
                    FirstName = "Bilbo",
                    LastName = "Baggins",
                    EmailAddress = "bb@hob.me",
                    CustomerTypeId = null
                },
                new Customer
                {
                    CustomerId = 1,
                    FirstName = "Frodo",
                    LastName = "Baggins",
                    EmailAddress = "fb@hob.me",
                    CustomerTypeId = 1,
                },
                new Customer
                {
                    CustomerId = 4,
                    FirstName = "Rosie",
                    LastName = "Cotton",
                    EmailAddress = "rc@hob.me",
                    CustomerTypeId = 2
                },
                new Customer
                {
                    CustomerId = 3,
                    FirstName = "Samwise",
                    LastName = "Gamgee",
                    EmailAddress = "sg@hob.me",
                    CustomerTypeId = 1
                },
            };
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ShouldSortByNameInReverse()
        {
            // Arrange
            var repository = new CustomerRepository();
            var customerList = repository.Retrieve();

            // Act
            var result = repository.SortByNameInReverse(customerList);

            // Assert
            var expected = new List<Customer>
            {
                new Customer
                {
                    CustomerId = 3,
                    FirstName = "Samwise",
                    LastName = "Gamgee",
                    EmailAddress = "sg@hob.me",
                    CustomerTypeId = 1
                },
                new Customer
                {
                    CustomerId = 4,
                    FirstName = "Rosie",
                    LastName = "Cotton",
                    EmailAddress = "rc@hob.me",
                    CustomerTypeId = 2
                },
                new Customer
                {
                    CustomerId = 1,
                    FirstName = "Frodo",
                    LastName = "Baggins",
                    EmailAddress = "fb@hob.me",
                    CustomerTypeId = 1,
                },
                new Customer
                {
                    CustomerId = 2,
                    FirstName = "Bilbo",
                    LastName = "Baggins",
                    EmailAddress = "bb@hob.me",
                    CustomerTypeId = null
                },
            };
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ShouldSortByType()
        {
            // Arrange
            var repository = new CustomerRepository();
            var customerList = repository.Retrieve();

            // Act
            var result = repository.SortByType(customerList);

            // Assert
            var expected = new List<Customer>
            {
                new Customer
                {
                    CustomerId = 1,
                    FirstName = "Frodo",
                    LastName = "Baggins",
                    EmailAddress = "fb@hob.me",
                    CustomerTypeId = 1,
                },
                new Customer
                {
                    CustomerId = 3,
                    FirstName = "Samwise",
                    LastName = "Gamgee",
                    EmailAddress = "sg@hob.me",
                    CustomerTypeId = 1
                },
                new Customer
                {
                    CustomerId = 4,
                    FirstName = "Rosie",
                    LastName = "Cotton",
                    EmailAddress = "rc@hob.me",
                    CustomerTypeId = 2
                },
                new Customer
                {
                    CustomerId = 2,
                    FirstName = "Bilbo",
                    LastName = "Baggins",
                    EmailAddress = "bb@hob.me",
                    CustomerTypeId = null
                },
            };
            Assert.Equal(expected, result);
        }
    }
}
