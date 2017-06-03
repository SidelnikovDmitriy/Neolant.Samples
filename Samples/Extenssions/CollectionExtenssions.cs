using Samples.Utils.Randomizer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Samples.Extenssions
{
    public static class CollectionExtenssions
    {
        /// <summary>
        /// Случайный порядок
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IEnumerable<T> Randomize<T>(this IEnumerable<T> source) where T : class
        {
            var rnd = Randomizer.Instance(); 
            source = source.OrderBy(x => rnd.Random.Next());
            return source;
        }

    }
}
