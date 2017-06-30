using Samples.Utils.Randomizer;

namespace Samples.Factory.Abstract_Factory
{
    /// <summary>
    /// Человеческая фабрика
    /// </summary>
    public abstract class HumanFactory
    {
        /// <summary>
        /// Маке мужик
        /// </summary>
        /// <returns></returns>
        public abstract Male MakeMale();
        /// <summary>
        /// Маке баба
        /// </summary>
        /// <returns></returns>
        public abstract Female MakeFemale();
        /// <summary>
        /// Дает рандомно либо мужика, либо женщину
        /// </summary>
        /// <returns></returns>
        public virtual Human GetRandom()
        {
            var rand = Randomizer.Instance();
            var result = rand.Random.Next(0, 100) < 50;

            if (result)
                return MakeFemale();

            return MakeMale();
        }

    }
}
