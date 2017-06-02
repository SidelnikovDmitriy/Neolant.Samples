using System;

namespace Samples.Factory.Abstract_Factory.Humans
{
    public class NiggerMale : Male
    {
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

        protected override string GetDescription(string description = null)
        {
            return base.GetDescription("real nigga");
        }
    }

    public class NiggerFemale : Female
    {
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

        protected override string GetDescription(string description = null)
        {
            return base.GetDescription("nigga");
        }
    }


}
