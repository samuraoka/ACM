using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace ACM.BL.Test
{

    public class CustomerRepositoryTest
        : IClassFixture<CustomerRepositoryFixture>, IClassFixture<CustomerTypeRepositoryFixture>
    {
        private CustomerRepository customerRepo;
        private CustomerTypeRepository customerTypeRepo;
        private readonly ITestOutputHelper output;

        public CustomerRepositoryTest(CustomerRepositoryFixture customerRepo,
            CustomerTypeRepositoryFixture customerTypeRepo, ITestOutputHelper output)
        {
            this.customerRepo = customerRepo.Repository;
            this.customerTypeRepo = customerTypeRepo.Repository;
            this.output = output;
        }

        //TODO

        [Fact]
        public void ShouldReturnExistingCustomer()
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
        public void ShouldReturnNullIfNoCustomerFound()
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
        public void ShouldSkipSomeCustomers()
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

        public static IEnumerable<object[]> GetExpectedData(string type)
        {
            switch (type)
            {
                case nameof(ShouldSortByName):
                    yield return new object[]
                    {
                        new List<Customer>
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
                        }
                    };
                    break;

                case nameof(ShouldSortByNameInReverse):
                    yield return new object[]
                    {
                        new List<Customer>
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
                        }
                    };
                    break;

                case nameof(ShouldSortByType):
                    yield return new object[]
                    {
                        new List<Customer>
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
                        }
                    };
                    break;

                default:
                    yield return new object[] { };
                    break;
            }
        }

        [Theory]
        [MemberData(nameof(GetExpectedData), nameof(ShouldSortByName))]
        public void ShouldSortByName(IList<Customer> expected)
        {
            // Arrange
            var customerList = customerRepo.Retrieve();

            // Act
            var result = customerRepo.SortByName(customerList);

            // Assert
            // xUnit : Assert two List<T> are equal?
            // https://stackoverflow.com/questions/419659/xunit-assert-two-listt-are-equal
            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(GetExpectedData), nameof(ShouldSortByNameInReverse))]
        public void ShouldSortByNameInReverse(IList<Customer> expected)
        {
            // Arrange
            var customerList = customerRepo.Retrieve();

            // Act
            var result = customerRepo.SortByNameInReverse(customerList);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(GetExpectedData), nameof(ShouldSortByType))]
        public void ShouldSortByType(IList<Customer> expected)
        {
            // Arrange
            var customerList = customerRepo.Retrieve();

            // Act
            var result = customerRepo.SortByType(customerList);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ShouldGetNames()
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
        public void ShouldGetNameAndEmails()
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
        public void ShouldGetNameAndTypes()
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
    }
}
