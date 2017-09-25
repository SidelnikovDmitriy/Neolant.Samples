namespace Pattern.Details
{
    /// <summary>
    /// Мужик азиат
    /// </summary>
    public class AsianMale : Male
    {
        /// <summary>
        /// То, что говорит азиат
        /// </summary>
        public override string[] Replies
        {
            get
            {
                return new[]
                {
                    "白人コック",
                    "たばこのためのアニメ",
                    "日本の複雑な",
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
            return base.GetDescription("asian シチュー");
        }
    }
    /// <summary>
    /// Женщина азиат
    /// </summary>
    public class AsianFemale : Female
    {
        /// <summary>
        /// То, что говорит азиатка
        /// </summary>
        public override string[] Replies
        {
            get
            {
                return new[]
                {
                    "パン",
                    "鰊",
                    "サンドイッチ"
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
            return base.GetDescription("asian 茄子");
        }
    }
}
