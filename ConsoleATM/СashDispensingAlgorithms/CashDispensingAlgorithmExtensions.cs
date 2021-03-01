﻿using System.Collections.Generic;
using System.Linq;

namespace ConsoleATM.СashDispensingAlgorithms
{
    public static class CashDispensingAlgorithmExtensions
    {
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
