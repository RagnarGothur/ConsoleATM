using System.Collections.Generic;

namespace ConsoleATM.СashDispensingAlgorithms
{
    public class GreedyСashDispensingAlgorithm : IСashDispensingAlgorithm
    {
        public Dictionary<uint, uint> GetDispensing(IDictionary<uint, uint> cashFullness, uint requestedMoney)
        {
            var result = new Dictionary<uint, uint>();
            var sorted = new SortedDictionary<uint, uint>(
                cashFullness,
                Comparer<uint>.Create(
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
