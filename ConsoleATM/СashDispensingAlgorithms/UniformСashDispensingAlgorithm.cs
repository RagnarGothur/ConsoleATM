using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleATM.СashDispensingAlgorithms
{
    public class UniformСashDispensingAlgorithm : IСashDispensingAlgorithm
    {
        private readonly Random _random = new Random();

        public Dictionary<int, int> Dispense(Dictionary<int, int> cashFullness, int requestedMoney)
        {
            var result = new Dictionary<int, int>();
            var changes = cashFullness.ToDictionary(e => e.Key, e => e.Value);

            while (requestedMoney > 0)
            {
                if (!this.CanDispense(changes, requestedMoney))
                {
                    throw new CannotDispenseCashException();
                }

                var elem = _random.RandomElement(changes);
                if (elem.Key > requestedMoney) continue;
                if (elem.Value == 0) continue;

                requestedMoney -= elem.Value;
                changes[elem.Key]--;

                if (result.ContainsKey(elem.Key))
                {
                    result[elem.Key]++;
                }
                else
                {
                    result[elem.Key] = 1;
                }
            }

            foreach(var changedEntry in changes)
                cashFullness[changedEntry.Key] = changedEntry.Value;

            return result;
        }
    }
}
