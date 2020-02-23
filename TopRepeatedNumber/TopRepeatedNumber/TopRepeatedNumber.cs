using System;
using System.Collections.Generic;
using System.Linq;

namespace TopRepeatedNumber
{
    public static class TopRepeatedNumber
    {
        public static (int Number, int Count) FindIn(IEnumerable<int> numbers)
        {
            if (numbers == null) throw new ArgumentNullException(nameof(numbers));
            if (!numbers.Any()) throw new ArgumentException("Collection must contain at least one item", nameof(numbers));

            var counts = new Dictionary<int, int>();

            foreach (var num in numbers)
            {
                if (!counts.ContainsKey(num)) counts.Add(num, 0);
                counts[num]++;
            }

            var number = 0;
            var count = 0;

            foreach (var kvp in counts)
            {
                if (kvp.Value > count)
                {
                    number = kvp.Key;
                    count = kvp.Value;
                }
            }

            return (number, count);
        }
    }
}
