using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleATM
{
    public static class RandomExtensions
    {
        public static T RandomElement<T>(this Random random, IEnumerable<T> enumerable)
        {
            var count = enumerable.Count();
            var index = random.Next(count);

            return enumerable.ElementAt(index);
        }
    }
}
