using System.Collections.Generic;
using System.Linq;

namespace Samples.Factory.Abstract_Factory.Humans
{
    /// <summary>
    /// прост европейцы: мужик
    /// </summary>
    public class EuropeanMale : Male
    {
        public static string[] EuropeanReplies
        {
            get
            {
                return new string[]
                {
                    "How are you?",
                    "Как дела?",
                    "ЦЕ-ЄВРОПА!",
                    "K**wa! Per**le!",
                    "jak się masz?",
                    "Wie geht es Ihnen?"
                };
            }
        }

        public override string[] Replies { get { return EuropeanReplies; } }

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
        protected override string GetDescription(string description = null)
        {
            return base.GetDescription("european");
        }
    }
}
