using Samples.Utils.Randomizer;

namespace Samples.Factory.Abstract_Factory
{
    /// <summary>
    /// Прост человек
    /// </summary>
    public abstract class Human
    {
        /// <summary>
        /// Фразы
        /// </summary>
        public virtual string[] Replies
        {
            get
            {
                return new []
                {
                    "How are you ?"
                };
            }
        }
        /// <summary>
        /// Кто-я?
        /// </summary>
        /// <returns></returns>
        public virtual string WhoAreYoure()
        {
            var rand = Randomizer.Instance();
            return string.Format("Hey! i'm {0}! {1}", GetDescription(), Replies[rand.Random.Next(0, Replies.Length)]);
        }
        /// <summary>
        /// Задает описание
        /// </summary>
        /// <returns></returns>
        protected abstract string GetDescription(string description = null);

    }
}
