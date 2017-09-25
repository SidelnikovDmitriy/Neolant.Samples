namespace Pattern.Details
{
    /// <summary>
    /// Мужчина нигер
    /// </summary>
    public class AfricanMale : Male
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
                    "hoe gaan dit met jou",
                    "jou?",
                    "Hallo, wat doen jy?"
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
            return base.GetDescription("real man");
        }
    }
    /// <summary>
    /// Женщина нигер
    /// </summary>
    public class AfricanFemale : Female
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
                    "Any text for sample...",
                    "Hallo, wat doen jy?",
                    "O, dis alles!"
                };
            }
        }
        /// <summary>
        /// Описание
        /// </summary>
        /// <param name="description"></param>
        protected override string GetDescription(string description = null)
        {
            return base.GetDescription("real woman");
        }
    }


}
