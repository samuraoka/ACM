using System;
using System.Collections.Generic;
using System.Linq;

namespace ACM.Library
{
    public class Builder
    {
        public object Rondom { get; private set; }

        public IEnumerable<int> BuildIntegerSequence()
        {
            return Enumerable.Range(0, 10);
        }

        public IEnumerable<int> BuildIntegerSequence(Func<int, int> selector)
        {
            return BuildIntegerSequence().Select(selector);
        }

        public IEnumerable<string> BuildStringSequence()
        {
            return BuildIntegerSequence()
                .Select(i => ((char)('A' + i)).ToString());
        }

        public IEnumerable<string> BuildRandomStringSequence()
        {
            // How do I seed a random class to avoid getting duplicate random values [duplicate]
            // https://stackoverflow.com/questions/1785744/how-do-i-seed-a-random-class-to-avoid-getting-duplicate-random-values
            var rand = new Random(Guid.NewGuid().GetHashCode());
            return BuildIntegerSequence()
                .Select(i => ((char)('A' + rand.Next(0, 26))).ToString());
        }

        public IEnumerable<T> BuildRepeatElement10Times<T>(T element)
        {
            return Enumerable.Repeat(element, 10);
        }
    }
}
