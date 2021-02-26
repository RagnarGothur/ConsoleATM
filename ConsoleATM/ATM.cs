using ConsoleATM.СashDispensingAlgorithms;

using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleATM
{
    public class ATM
    {
        public IСashDispensingAlgorithm DispensingAlgorithm { get; set; } = new UniformСashDispensingAlgorithm();

        private readonly int[] _default_banknotes = new int[]
        {
            5, 20, 50, 100
        };

        private readonly Dictionary<int, int> _state;

        public ATM(int banknotesNum)
        {
            _state = _default_banknotes.ToDictionary(bn => bn, _ => banknotesNum);
        }

        public ATM(Func<Dictionary<int, int>> atmStateCreator)
        {
            _state = atmStateCreator();
        }

        public Dictionary<int, int> GetMoney(int requestedCash)
        {
            if (!DispensingAlgorithm.CanDispense(_state, requestedCash))
            {
                throw new CannotDispenseCashException();
            }

            return DispensingAlgorithm.Dispense(_state, requestedCash);
        }
    }
}
