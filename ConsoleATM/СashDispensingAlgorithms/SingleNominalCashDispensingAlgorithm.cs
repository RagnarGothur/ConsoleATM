using System.Collections.Generic;
using System.Linq;

namespace ConsoleATM.СashDispensingAlgorithms
{
    public class SingleNominalCashDispensingAlgorithm : IСashDispensingAlgorithm
    {
        public Dictionary<uint, uint> GetDispensing(IDictionary<uint, uint> cashFullness, uint requestedMoney)
        {
            var toDispense = cashFullness
                .Where(e => e.Value > 0)
                .FirstOrDefault(e => requestedMoney % (e.Key * e.Value) == 0);

            return toDispense.Equals(default)
                ? throw new CannotDispenseCashException()
                : new Dictionary<uint, uint>() { { toDispense.Key, toDispense.Value } };
        }
    }
}
