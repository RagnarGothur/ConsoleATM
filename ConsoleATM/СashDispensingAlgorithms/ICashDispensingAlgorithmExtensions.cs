using System.Collections.Generic;
using System.Linq;

namespace ConsoleATM.СashDispensingAlgorithms
{
    public static class ICashDispensingAlgorithmExtensions
    {
        public static bool CanDispense(this IСashDispensingAlgorithm algorithm, IDictionary<int, int> moneyFullness, int requestedMoney)
        {
            return moneyFullness.Any(e => e.Key <= requestedMoney && e.Value > 0);
        }
    }
}
