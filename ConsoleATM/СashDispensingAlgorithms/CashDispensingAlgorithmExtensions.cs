using System.Collections.Generic;
using System.Linq;

namespace ConsoleATM.СashDispensingAlgorithms
{
    /// <summary>
    /// Расширения для IСashDispensingAlgorithm
    /// </summary>
    public static class CashDispensingAlgorithmExtensions
    {
        /// <summary>
        /// Определяет теоретическую возможность выдачи денег
        /// </summary>
        /// <param name="algorithm">this</param>
        /// <param name="moneyFullness">Баланс</param>
        /// <param name="requestedMoney">Запрошено денег</param>
        /// <returns></returns>
        public static bool CanDispense(
            this IСashDispensingAlgorithm algorithm,
            IDictionary<uint, uint> moneyFullness,
            uint requestedMoney
        )
        {
            return moneyFullness.Any(e => e.Key <= requestedMoney && e.Value > 0);
        }
    }
}
