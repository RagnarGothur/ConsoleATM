using System.Collections.Generic;
using System.Linq;

namespace ConsoleATM.СashDispensingAlgorithms
{
    /// <summary>
    /// Пытается выдать деньги одним номиналом
    /// </summary>
    public class SingleNominalCashDispensingAlgorithm : IСashDispensingAlgorithm
    {
        /// <summary>
        /// Получить выдачу
        /// </summary>
        /// <param name="cashFullness">Баланс банкомата</param>
        /// <param name="requestedMoney">Запрошено денег</param>
        /// <returns>К выдаче в формате "номинал:количество купюр"</returns>
        public IDictionary<uint, uint> GetDispensing(IDictionary<uint, uint> cashFullness, uint requestedMoney)
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
