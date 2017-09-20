using System.Linq;

namespace Samples.Factory.Abstract_Factory.Humans
{
    /// <summary>
    /// прост европейцы: мужик
    /// </summary>
    public class EuropeanMale : Male
    {
        /// <summary>
        /// Фразы европейцев
        /// </summary>
        public static string[] EuropeanReplies
        {
            get
            {
                return new string[]
                {
                    "How are you?",
                    "Как дела?",
                    "jak się masz?",
                    "Wie geht es Ihnen?"
                };
            }
        }
        /// <summary>
        /// Фразы европейцев
        /// </summary>
        public override string[] Replies { get { return EuropeanReplies; } }
        /// <summary>
        /// Описание
        /// </summary>
        protected override string GetDescription(string description = null)
        {
           return base.GetDescription("european"); 
        }
    }
    /// <summary>
    /// прост европейцы: женщина
    /// </summary>
    public class EuropeanFemale : Female
    {
        /// <summary>
        /// Фразы европейцев
        /// </summary>
        public override string[] Replies
        {
            get
            {
                return EuropeanMale.EuropeanReplies.Union(new[] {
                    "ОЙ, ВСЁ!",
                    "oh, wszystko!",
                    "Oh, that's all!",
                    "oh, alles!"
                }).ToArray();
            }
        }
        /// <summary>
        /// Описание
        /// </summary>
        protected override string GetDescription(string description = null)
        {
            return base.GetDescription("european woman");
        }
    }
}
