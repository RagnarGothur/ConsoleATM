using System.Collections.Generic;

namespace ConsoleATM.СashDispensingAlgorithms
{
    /// <summary>
    /// Алгоритм выдачи средств
    /// </summary>
    public interface IСashDispensingAlgorithm
    {
        /// <summary>
        /// Получить выдачу
        /// </summary>
        /// <param name="cashFullness">Баланс банкомата</param>
        /// <param name="requestedMoney">Запрошено денег</param>
        /// <returns>К выдаче в формате "номинал:количество купюр"</returns>
        public IDictionary<uint, uint> GetDispensing(IDictionary<uint, uint> cashFullness, uint requestedMoney);
    }
}
