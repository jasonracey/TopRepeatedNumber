using System;
using System.Collections.Generic;
using System.Linq;

namespace TopRepeatedNumber
{
    public static class TopRepeatedNumber
    {
        public static (IEnumerable<int> NumbersWithMaxCount, int MaxCount) FindIn(IEnumerable<int> numbers)
        {
            if (numbers == null) throw new ArgumentNullException(nameof(numbers));
            if (!numbers.Any()) throw new ArgumentException("Collection must contain at least one item", nameof(numbers));

            var counts = new Dictionary<int, int>();
            var maxCount = 0;

            foreach (var num in numbers)
            {
                if (!counts.ContainsKey(num)) counts.Add(num, 0);
                counts[num]++;
                if (counts[num] > maxCount) maxCount = counts[num];
            }

            var numbersWithMaxCount = counts
                .Where(c => c.Value == maxCount)
                .Select(c => c.Key);

            return (numbersWithMaxCount, maxCount);
        }
    }
}
