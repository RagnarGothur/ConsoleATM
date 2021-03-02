using ConsoleATM.СashDispensingAlgorithms;

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;

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
        public string BalanceString
        {
            get => Balance.Aggregate(
                new StringBuilder(),
                (builder, entry) => builder.Append($"\"{entry.Key}\" рублей: {entry.Value} банкнот\n")
            )
                .ToString();
        }

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

        public IDictionary<uint, uint> DispenseMoney(uint requestedCash)
        {
            var immutableState = Balance.ToImmutableDictionary();

            IDictionary<uint, uint> result = new Dictionary<uint, uint>();
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

        public IDictionary<uint, uint> PutMoney(uint nominal, uint count)
        {
            if (!Balance.ContainsKey(nominal))
                throw new AtmException($"Unexpected nominal {nominal}");

            Balance[nominal] += count;

            return Balance;
        }
    }
}
