﻿using ACM.BL;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace ACM.Library.Test
{
    public class BuilderTest
    {
        // Capturing Output
        // https://xunit.github.io/docs/capturing-output
        private readonly ITestOutputHelper output;

        public BuilderTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void ShouldBuildIntegerSequence()
        {
            // Arrange
            var builder = new Builder();

            // Act
            var actual = builder.BuildIntegerSequence();

            // Analyze
            // C# List<string> to string with delimiter
            // https://stackoverflow.com/questions/3575029/c-sharp-liststring-to-string-with-delimiter
            output.WriteLine(string.Join(", ", actual));

            // Assert
            var expected = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldBuildProjectedSequence()
        {
            // Arrange
            var builder = new Builder();

            // Act
            var actual = builder.BuildIntegerSequence(e => 5 + (10 * e));

            // Analyze
            output.WriteLine(string.Join(", ", actual));

            // Assert
            var expected = new List<int> { 5, 15, 25, 35, 45, 55, 65, 75, 85, 95 };
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldBuildStringSequence()
        {
            // Arrange
            var builder = new Builder();

            // Act
            var actual = builder.BuildStringSequence();

            // Analyze
            output.WriteLine(string.Join(", ", actual));

            // Assert
            var expected = new List<string> { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldBuildRandomStringSequence()
        {
            // Arrange
            var buildre = new Builder();

            // Act
            var actual = buildre.BuildRandomStringSequence();

            // Analyze
            output.WriteLine(string.Join(", ", actual));

            // Assert
            int count = 0;
            foreach (var item in actual)
            {
                count += 1;
            }
            Assert.Equal(10, count);
            Assert.All(actual, e => Assert.InRange(e[0], 'A', 'Z'));
        }

        // nameof (C# Reference)
        // https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/nameof
        [Theory]
        [InlineData(-1)]
        [InlineData("baseball")]
        [MemberData(nameof(GetCustomerData))]
        public void ShouldBuildRepeatedElement<T>(T element)
        {
            // Arrange
            var builder = new Builder();

            // Act
            var actual = builder.BuildRepeatElement10Times(element);

            // Analyze
            output.WriteLine(string.Join(", ", actual));

            // Assert
            var expected = new List<T>
            {
                element, element, element, element, element,
                element, element, element, element, element
            };
            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> GetCustomerData()
        {
            // xUnit Theory: Working With InlineData, MemberData, ClassData
            // http://hamidmosalla.com/2017/02/25/xunit-theory-working-with-inlinedata-memberdata-classdata/
            yield return new object[] { new Customer { } };
        }

        [Theory]
        [MemberData(nameof(GetDataForIntersectOperation))]
        public void ShouldIntercectTwoSets(ISet<int> first, ISet<int> second, ISet<int> expected)
        {
            // Arrange
            var builder = new Builder();

            // Act
            var actual = builder.Intersect(first, second);

            // Assert
            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> GetDataForIntersectOperation()
        {
            var first = new HashSet<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var second = new HashSet<int> { 0, 1, 4, 9, 16, 25, 36, 49, 64, 81 };

            yield return new object[] {
                first, second, new HashSet<int> { 0, 1, 4, 9 }
            };
            yield return new object[] {
                second, first, new HashSet<int> { 0, 1, 4, 9 }
            };
        }

        [Theory]
        [MemberData(nameof(GetDataForExceptOperation))]
        public void ShouldExceptTwoSets(ISet<int> first, ISet<int> second, ISet<int> expected)
        {
            // Arrange
            var builder = new Builder();

            // Act
            var actual = builder.Except(first, second);

            // Assert
            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> GetDataForExceptOperation()
        {
            var first = new HashSet<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var second = new HashSet<int> { 0, 1, 4, 9, 16, 25, 36, 49, 64, 81 };

            yield return new object[] {
                first, second, new HashSet<int> { 2, 3, 5, 6, 7, 8 }
            };
            yield return new object[] {
                second, first, new HashSet<int> { 16, 25, 36, 49, 64, 81 }
            };
        }

        [Theory]
        [MemberData(nameof(GetDataForConcatOperation))]
        public void ShouldConcatTwoSets(ISet<int> first, ISet<int> second, IEnumerable<int> expected, bool distinct, bool sort)
        {
            // Arrange
            var builder = new Builder();

            // Act
            var actual = builder.Concat(first, second, distinct, sort);

            // Analyze
            output.WriteLine(string.Join(", ", actual).ToString());

            // Assert
            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> GetDataForConcatOperation()
        {
            var first = new HashSet<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var second = new HashSet<int> { 0, 1, 4, 9, 16, 25, 36, 49, 64, 81 };

            yield return new object[] {
                first, second,
                new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 4, 9, 16, 25, 36, 49, 64, 81 },
                false, false
            };

            yield return new object[] {
                first, second,
                new HashSet<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 16, 25, 36, 49, 64, 81 },
                true, true
            };

            yield return new object[] {
                second, first,
                new List<int> { 0, 1, 4, 9, 16, 25, 36, 49, 64, 81, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                false, false
            };

            yield return new object[] {
                second, first,
                new HashSet<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 16, 25, 36, 49, 64, 81 },
                true, true
            };
        }

        [Theory]
        [MemberData(nameof(GetDataForUnionOperation))]
        public void ShouldUnionTwoSets(ISet<int> first, ISet<int> second, IEnumerable<int> expected)
        {
            // Arrange
            var builder = new Builder();

            // Act
            var actual = builder.Union(first, second);

            // Analyze
            output.WriteLine(string.Join(", ", actual).ToString());

            // Assert
            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> GetDataForUnionOperation()
        {
            var first = new HashSet<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var second = new HashSet<int> { 0, 1, 4, 9, 16, 25, 36, 49, 64, 81 };

            yield return new object[] {
                first, second,
                new HashSet<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 16, 25, 36, 49, 64, 81 },
            };

            yield return new object[] {
                second, first,
                new HashSet<int> { 0, 1, 4, 9, 16, 25, 36, 49, 64, 81, 2, 3, 5, 6, 7, 8 },
            };
        }
    }
}
