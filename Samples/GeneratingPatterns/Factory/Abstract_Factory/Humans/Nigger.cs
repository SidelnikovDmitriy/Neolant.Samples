namespace Samples.Factory.Abstract_Factory.Humans
{
    /// <summary>
    /// Мужчина нигер
    /// </summary>
    public class NiggerMale : Male
    {
        /// <summary>
        /// Фразы негра
        /// </summary>
        public override string[] Replies
        {
            get
            {
                return new[]
                {
                    "Give me the money bitch! 🔫 🔫",
                    "Where is KFC?",
                    "Let's play basketball?",
                    "What's up motherf**ker?"
                };
            }
        }
        /// <summary>
        /// Описание
        /// </summary>
        /// <param name="description"></param>
        /// <returns></returns>
        protected override string GetDescription(string description = null)
        {
            return base.GetDescription("real nigga");
        }
    }
    /// <summary>
    /// Женщина нигер
    /// </summary>
    public class NiggerFemale : Female
    {
        /// <summary>
        /// Фразы негра
        /// </summary>
        public override string[] Replies
        {
            get
            {
                return new[]
                {
                    "KFC? Where is KFC?",
                    "What's up motherf**ker?",
                    "Oj wsyo!"
                };
            }
        }
        /// <summary>
        /// Описание
        /// </summary>
        /// <param name="description"></param>
        protected override string GetDescription(string description = null)
        {
            return base.GetDescription("nigga");
        }
    }


}
