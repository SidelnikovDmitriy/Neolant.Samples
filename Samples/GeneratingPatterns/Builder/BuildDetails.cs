using Samples.Abstract.Classes;

namespace Samples.GeneratingPatterns.Builder
{
    public class BuildDetails : Base
    {
        /// <summary>
        /// Context
        /// </summary>
        public BuildDetails(string partName)
        {
            DisplayName = partName;
        }

        public override string ToString()
        {
            return DisplayName;
        }
    }
}
