using ACM.BL.Fixture.Test;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace ACM.BL.Test
{

    public class CustomerRepositoryTestShould
        : IClassFixture<CustomerInvoiceRepositoryFixture>, IClassFixture<CustomerTypeRepositoryFixture>
    {
        private CustomerRepository customerRepo;
        private InvoiceRepository invoiceRepo;
        private CustomerTypeRepository customerTypeRepo;
        private readonly ITestOutputHelper output;

        public CustomerRepositoryTestShould(CustomerInvoiceRepositoryFixture customerInvoiceRepoFixture,
            CustomerTypeRepositoryFixture customerTypeRepoFixture, ITestOutputHelper output)
        {
            customerRepo = customerInvoiceRepoFixture.CustomerRepoFixture.Repository;
            invoiceRepo = customerInvoiceRepoFixture.InvoiceRepoFixture.Repository;
            this.customerTypeRepo = customerTypeRepoFixture.Repository;
            this.output = output;
        }

        //TODO

        [Fact]
        public void ReturnExistingCustomer()
        {
            // Arrange
            var customerList = customerRepo.Retrieve();

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
        public void ReturnNullIfNoCustomerFound()
        {
            // Arrange
            var customerList = customerRepo.Retrieve();

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
        public void SkipSomeCustomers()
        {
            // Arrange
            var customerList = customerRepo.Retrieve();

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
        public void SortByName()
        {
            // Arrange
            var customerList = customerRepo.Retrieve();

            // Act
            var result = customerRepo.SortByName(customerList);

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
                    CustomerTypeId = null,
                    InvoiceList = invoiceRepo.Retrieve(2),
                },
                new Customer
                {
                    CustomerId = 1,
                    FirstName = "Frodo",
                    LastName = "Baggins",
                    EmailAddress = "fb@hob.me",
                    CustomerTypeId = 1,
                    InvoiceList = invoiceRepo.Retrieve(1),
                },
                new Customer
                {
                    CustomerId = 4,
                    FirstName = "Rosie",
                    LastName = "Cotton",
                    EmailAddress = "rc@hob.me",
                    CustomerTypeId = 2,
                    InvoiceList = invoiceRepo.Retrieve(4),
                },
                new Customer
                {
                    CustomerId = 3,
                    FirstName = "Samwise",
                    LastName = "Gamgee",
                    EmailAddress = "sg@hob.me",
                    CustomerTypeId = 1,
                    InvoiceList = invoiceRepo.Retrieve(3),
                },
            };
            Assert.Equal(expected, result);
        }

        [Fact]
        public void SortByNameInReverse()
        {
            // Arrange
            var customerList = customerRepo.Retrieve();

            // Act
            var result = customerRepo.SortByNameInReverse(customerList);

            // Assert
            var expected = new List<Customer>
            {
                new Customer
                {
                    CustomerId = 3,
                    FirstName = "Samwise",
                    LastName = "Gamgee",
                    EmailAddress = "sg@hob.me",
                    CustomerTypeId = 1,
                    InvoiceList = invoiceRepo.Retrieve(3),
                },
                new Customer
                {
                    CustomerId = 4,
                    FirstName = "Rosie",
                    LastName = "Cotton",
                    EmailAddress = "rc@hob.me",
                    CustomerTypeId = 2,
                    InvoiceList = invoiceRepo.Retrieve(4),
                },
                new Customer
                {
                    CustomerId = 1,
                    FirstName = "Frodo",
                    LastName = "Baggins",
                    EmailAddress = "fb@hob.me",
                    CustomerTypeId = 1,
                    InvoiceList = invoiceRepo.Retrieve(1),
                },
                new Customer
                {
                    CustomerId = 2,
                    FirstName = "Bilbo",
                    LastName = "Baggins",
                    EmailAddress = "bb@hob.me",
                    CustomerTypeId = null,
                    InvoiceList = invoiceRepo.Retrieve(2),
                },
            };
            Assert.Equal(expected, result);
        }

        [Fact]
        public void SortByType()
        {
            // Arrange
            var customerList = customerRepo.Retrieve();

            // Act
            var result = customerRepo.SortByType(customerList);

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
                    InvoiceList = invoiceRepo.Retrieve(1),
                },
                new Customer
                {
                    CustomerId = 3,
                    FirstName = "Samwise",
                    LastName = "Gamgee",
                    EmailAddress = "sg@hob.me",
                    CustomerTypeId = 1,
                    InvoiceList = invoiceRepo.Retrieve(3),
                },
                new Customer
                {
                    CustomerId = 4,
                    FirstName = "Rosie",
                    LastName = "Cotton",
                    EmailAddress = "rc@hob.me",
                    CustomerTypeId = 2,
                    InvoiceList = invoiceRepo.Retrieve(4),
                },
                new Customer
                {
                    CustomerId = 2,
                    FirstName = "Bilbo",
                    LastName = "Baggins",
                    EmailAddress = "bb@hob.me",
                    CustomerTypeId = null,
                    InvoiceList = invoiceRepo.Retrieve(2),
                },
            };
            Assert.Equal(expected, result);
        }

        [Fact]
        public void GetNames()
        {
            // Arrange
            var customerList = customerRepo.Retrieve();

            // Act
            var result = customerRepo.GetNames(customerList);

            // Assert
            var expected = new List<string> {
                "Baggins, Frodo",
                "Baggins, Bilbo",
                "Gamgee, Samwise",
                "Cotton, Rosie",
            };
            Assert.Equal(expected, result);
        }

        [Fact]
        public void GetNameAndEmails()
        {
            // Arrange
            var customerList = customerRepo.Retrieve();

            // Act
            var actual = customerRepo.GetNameAndEmails(customerList);

            // Analyze
            output.WriteLine(string.Join(", ", actual));

            // Assert
            var expected = new HashSet<CustomerNameAndEmail> {
                new CustomerNameAndEmail { Name = "Baggins, Frodo", EmailAddress = "fb@hob.me" },
                new CustomerNameAndEmail { Name = "Baggins, Bilbo", EmailAddress = "bb@hob.me" },
                new CustomerNameAndEmail { Name = "Gamgee, Samwise", EmailAddress = "sg@hob.me" },
                new CustomerNameAndEmail { Name = "Cotton, Rosie", EmailAddress = "rc@hob.me" },
            };
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetNameAndTypes()
        {
            // Arrange
            var customerList = customerRepo.Retrieve();
            var customerTypeList = customerTypeRepo.Retrieve();

            // Act
            var actual = customerRepo.GetNameAndTypes(customerList, customerTypeList);

            // Analyze
            output.WriteLine(string.Join(", ", actual));

            // Assert
            var expected = new HashSet<CustomerNameAndType> {
                new CustomerNameAndType { Name = "Baggins, Frodo",  CustomerTypeName = "Corporate" },
                new CustomerNameAndType { Name = "Gamgee, Samwise", CustomerTypeName = "Corporate" },
                new CustomerNameAndType { Name = "Cotton, Rosie",  CustomerTypeName = "Individual" },
            };
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetOverdueCustomers()
        {
            // Arrange
            var customerList = customerRepo.Retrieve();

            // Act
            var actual = customerRepo.GetOverdueCustomers(customerList);

            // Analyze
            output.WriteLine(string.Join(", ", actual));

            // Assert
            var expected = new HashSet<Customer> {
                new Customer
                {
                    CustomerId = 1,
                    FirstName = "Frodo",
                    LastName = "Baggins",
                    EmailAddress = "fb@hob.me",
                    CustomerTypeId = 1,
                    InvoiceList = invoiceRepo.Retrieve(1),
                },
                new Customer
                {
                    CustomerId = 2,
                    FirstName = "Bilbo",
                    LastName = "Baggins",
                    EmailAddress = "bb@hob.me",
                    CustomerTypeId = null,
                    InvoiceList = invoiceRepo.Retrieve(2),
                },
            };
            Assert.Equal(expected, actual);
        }
    }
}
