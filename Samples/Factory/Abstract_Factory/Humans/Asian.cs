namespace Samples.Factory.Abstract_Factory.Humans
{
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
            return base.GetDescription("シチュー");
        }
    }

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
            return base.GetDescription("茄子");
        }
    }
}
