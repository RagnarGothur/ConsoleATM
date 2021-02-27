using System.Collections.Generic;

namespace ConsoleATM.СashDispensingAlgorithms
{
    public interface IСashDispensingAlgorithm
    {
        public Dictionary<int, int> GetDispensing(IDictionary<int, int> cashFullness, int requestedMoney);
    }
}
