using ConsoleATM.СashDispensingAlgorithms;

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace ConsoleATM
{
    public class ATM
    {
        public List<IСashDispensingAlgorithm> DispensingAlgorithmPriority { get; set; }
            = new List<IСashDispensingAlgorithm>()
            {
                new GreedyСashDispensingAlgorithm(),
                new UniformСashDispensingAlgorithm(),
                new SingleNominalCashDispensingAlgorithm()
            };

        /// <summary>
        /// Остаток банкнот в банкомате. Сеттер для инкассации
        /// </summary>
        public Dictionary<uint, uint> Balance { get; set; }

        private readonly uint[] _default_banknotes = new uint[]
        {
            5, 20, 50, 100
        };

        public ATM(uint banknotesNum)
        {
            Balance = _default_banknotes.ToDictionary(bn => bn, _ => banknotesNum);
        }

        public ATM(Func<Dictionary<uint, uint>> atmStateCreator)
        {
            Balance = atmStateCreator();
        }

        public Dictionary<uint, uint> DispenseMoney(uint requestedCash)
        {
            var immutableState = Balance.ToImmutableDictionary();

            var result = new Dictionary<uint, uint>();
            foreach (IСashDispensingAlgorithm algorithm in DispensingAlgorithmPriority)
            {
                try
                {
                    result = algorithm.GetDispensing(immutableState, requestedCash);
                    break;
                }
                catch (CannotDispenseCashException) 
                { 
                    //TODO: log
                }
            }

            if (result.Select(e => (int)e.Key * e.Value).Sum() != requestedCash)
            {
                throw new CannotDispenseCashException();
            }

            foreach (var d in result)
                Balance[d.Key] -= d.Value;

            return result;
        }
    }
}
