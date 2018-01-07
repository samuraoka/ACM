using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ACM.Library.Test
{
    [TestClass]
    public class StringExtensionsTest
    {
        [TestMethod]
        public void ConvertToTitleCase()
        {
            // Arrange
            var source = "the return of the king";
            var expected = "The Return Of The King";

            // Act
            var result = StringExtensions.ConvertToTitleCase(source);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result);
        }
    }
}
