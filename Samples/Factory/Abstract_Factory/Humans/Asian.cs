namespace Samples.Factory.Abstract_Factory.Humans
{
    /// <summary>
    /// Мужик азиат
    /// </summary>
    public class AsianMale : Male
    {
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

        protected override string GetDescription(string description = null)
        {
            return base.GetDescription("asian 茄子");
        }
    }
}
