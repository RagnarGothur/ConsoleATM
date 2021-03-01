using System.Collections.Generic;

namespace ConsoleATM.СashDispensingAlgorithms
{
    public class GreedyСashDispensingAlgorithm : IСashDispensingAlgorithm
    {
        public Dictionary<int, int> GetDispensing(IDictionary<int, int> cashFullness, int requestedMoney)
        {
            var result = new Dictionary<int, int>();
            var sorted = new SortedDictionary<int, int>(
                cashFullness,
                Comparer<int>.Create(
                    (key1, key2) => -key1.CompareTo(key2) //desc по номиналу
                )
            );

            foreach (var entry in sorted)
            {
                if (!this.CanDispense(sorted, requestedMoney))
                {
                    throw new CannotDispenseCashException();
                }

                while (requestedMoney >= entry.Key && entry.Value > 0)
                {
                    sorted[entry.Key]--;

                    if (result.ContainsKey(entry.Key))
                    {
                        result[entry.Key]++;
                    }
                    else
                    {
                        result[entry.Key] = 1;
                    }
                }
            }

            return result;
        }
    }
}
