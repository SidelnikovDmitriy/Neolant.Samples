using System.Collections.Generic;
using System.Linq;
using Common.Utils;

namespace Common.Extenssions
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
