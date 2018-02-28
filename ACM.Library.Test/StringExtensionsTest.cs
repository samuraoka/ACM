using Xunit;

namespace ACM.Library.Test
{
    public class StringExtensionsTest
    {
        [Fact]
        public void ConvertToTitleCase()
        {
            // Arrange
            var source = "the return of the king";
            var expected = "The Return Of The King";

            // Act
            var result = source.ConvertToTitleCase();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expected, result);
        }
    }
}
