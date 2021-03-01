using System.Collections.Generic;

namespace ConsoleATM.СashDispensingAlgorithms
{
    public interface IСashDispensingAlgorithm
    {
        public Dictionary<uint, uint> GetDispensing(IDictionary<uint, uint> cashFullness, uint requestedMoney);
    }
}
