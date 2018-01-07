using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.Linq;

namespace ACM.BL.Test
{
    [TestClass]
    public class CustomerRepositoryTest
    {
        //TODO

        [TestMethod]
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
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.CustomerId);
            Assert.AreEqual("Baggins", result.LastName);
            Assert.AreEqual("Bilbo", result.FirstName);
        }

        [TestMethod]
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
            Assert.IsNull(result);
        }

        [TestMethod]
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
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.CustomerId);
            Assert.AreEqual("Gamgee", result.LastName);
            Assert.AreEqual("Samwise", result.FirstName);
        }
    }
}
