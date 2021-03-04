using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleATM
{
    /// <summary>
    /// Расширения для класса Random
    /// </summary>
    public static class RandomExtensions
    {
        /// <summary>
        /// Достаёт случайный элемент последовательности
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="random"></param>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static T RandomElement<T>(this Random random, IEnumerable<T> enumerable)
        {
            var count = enumerable.Count();
            var index = random.Next(count);

            //Если есть индексатор
            if (enumerable is IList<T> list)
                return list[index];

            return enumerable.ElementAt(index);
        }
    }
}
