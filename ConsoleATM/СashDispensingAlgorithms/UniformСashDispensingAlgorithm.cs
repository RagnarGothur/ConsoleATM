using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleATM.СashDispensingAlgorithms
{
    /// <summary>
    /// Пытается выдать деньги случайным образом для равномерного опустошения кассет
    /// </summary>
    public class UniformСashDispensingAlgorithm : IСashDispensingAlgorithm
    {
        private readonly Random _random = new Random();

        /// <summary>
        /// Получить выдачу
        /// </summary>
        /// <param name="cashFullness">Баланс банкомата</param>
        /// <param name="requestedMoney">Запрошено денег</param>
        /// <returns>К выдаче в формате "номинал:количество купюр"</returns>
        public IDictionary<uint, uint> GetDispensing(IDictionary<uint, uint> cashFullness, uint requestedMoney)
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
