using System.Collections.Generic;
using System.Linq;

namespace ConsoleATM.СashDispensingAlgorithms
{
    public class SingleNominalCashDispensingAlgorithm : IСashDispensingAlgorithm
    {
        public Dictionary<int, int> GetDispensing(IDictionary<int, int> cashFullness, int requestedMoney)
        {
            var toDispense = cashFullness
                .Where(e => e.Value > 0)
                .FirstOrDefault(e => requestedMoney % (e.Key * e.Value) == 0);

            return toDispense.Equals(default)
                ? throw new CannotDispenseCashException()
                : new Dictionary<int, int>() { { toDispense.Key, toDispense.Value } };
        }
    }
}
