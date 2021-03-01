using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleATM.СashDispensingAlgorithms
{
    public class UniformСashDispensingAlgorithm : IСashDispensingAlgorithm
    {
        private readonly Random _random = new Random();

        public Dictionary<uint, uint> GetDispensing(IDictionary<uint, uint> cashFullness, uint requestedMoney)
        {
            var result = new Dictionary<uint, uint>();
            var cashFulnessCopy = cashFullness.ToDictionary(e => e.Key, e => e.Value);

            while (requestedMoney > 0)
            {
                if (!this.CanDispense(cashFulnessCopy, requestedMoney))
                {
                    throw new CannotDispenseCashException();
                }

                var elem = _random.RandomElement(cashFulnessCopy);
                if (elem.Key > requestedMoney) continue;
                if (elem.Value == 0) continue;

                requestedMoney -= elem.Value;
                cashFulnessCopy[elem.Key]--;

                if (result.ContainsKey(elem.Key))
                {
                    result[elem.Key]++;
                }
                else
                {
                    result[elem.Key] = 1;
                }
            }

            return result;
        }
    }
}
