using System;

namespace Samples.Utils.Randomizer
{
    public sealed class Randomizer
    {
        static Randomizer mRandomizer;

        static object mSunc = new object();
        public Random Random { get; private set; }

        private Randomizer()
        {
            Random = new Random();
        }

        public static Randomizer Instance()
        {

            if (mRandomizer == null)
            {
                lock (mSunc)
                {
                    if (mRandomizer == null)
                    {
                        mRandomizer = new Randomizer();
                    }
                }
            }

            return mRandomizer;
        }
    }
}
