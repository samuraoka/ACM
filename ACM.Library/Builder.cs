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

        public IEnumerable<int> Intersect(ISet<int> first, ISet<int> second)
        {
            return Enumerable.Intersect(first, second);
        }

        public IEnumerable<int> Except(IEnumerable<int> first, IEnumerable<int> second)
        {
            return first.Except(second);
        }

        public IEnumerable<int> Concat(ISet<int> first, ISet<int> second, bool distinct, bool sort)
        {
            var temp = first.Concat(second);
            if (distinct)
            {
                temp = temp.Distinct();
            }
            if (sort)
            {
                temp = temp.OrderBy(i => i);
            }
            return temp;
        }

        public IEnumerable<int> Union(ISet<int> first, ISet<int> second)
        {
            return first.Union(second);
        }
    }
}
