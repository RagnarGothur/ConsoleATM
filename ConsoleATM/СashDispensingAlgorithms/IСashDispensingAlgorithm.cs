using System.Collections.Generic;

namespace ConsoleATM.СashDispensingAlgorithms
{
    public interface IСashDispensingAlgorithm
    {
        public Dictionary<int, int> Dispense(Dictionary<int, int> cashFullness, int requestedMoney);
    }
}
