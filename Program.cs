using System;
using System.Collections.Generic;

namespace TopRepeatedNumber
{
    public class Program
    {
        public static void Main(string[] args)
        {
            const int OneThousand = 1000;

            var minValue = 1;
            var maxValue = 500 * OneThousand;
            var iterations = 100 * OneThousand;
            
            var randomNumberCounts = GetRandomNumberCounts(minValue, maxValue, iterations);
            var topRepeatedNumbers = GetTopRepeatedNumbers(randomNumberCounts);

            var countOfNumbers = topRepeatedNumbers.Count;
            var timesReapeated = randomNumberCounts[topRepeatedNumbers[0]];

            Console.WriteLine("Unique instance count: {0}", randomNumberCounts.Count);
            var message = countOfNumbers == 1 
                ? string.Format("Top repeated number (1 value, {0} times):", timesReapeated)
                : string.Format("Top repeated numbers ({0} values, {1} times each):", countOfNumbers, timesReapeated);
            Console.WriteLine(message);
            foreach (var val in topRepeatedNumbers)
            {
                Console.WriteLine(val);
            }
        }

        private static Dictionary<int, int> GetRandomNumberCounts(int minValue, int maxValue, int iterations)
        {
            var randCounts = new Dictionary<int, int>();
            var rand = new Random();
            for (var i = 0; i < iterations; i++)
            {
                // +1 because maxValue arg to rand.Next() is an exclusive upper bound
                // todo: need to handle maxValue == int.MaxValue
                var val = rand.Next(minValue, maxValue + 1);
                if (!randCounts.ContainsKey(val))
                {
                    randCounts.Add(val, 0);
                }
                randCounts[val] += 1;
            }
            return randCounts;
        }

        private static List<int> GetTopRepeatedNumbers(Dictionary<int, int> randomNumberCounts)
        {
            var topRepeatedNumbers = new List<int>();
            var topCount = int.MinValue;
            foreach (var num in randomNumberCounts.Keys)
            {
                var count = randomNumberCounts[num];
                if (count > topCount)
                {
                    topCount = count;
                    topRepeatedNumbers.Clear();
                    topRepeatedNumbers.Add(num);
                }
                else if (count == topCount)
                {
                    topRepeatedNumbers.Add(num);
                }
            }
            return topRepeatedNumbers;
        }
    }
}
