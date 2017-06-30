using Samples.Abstract.Classes;
using System.Collections.Generic;
using System.Text;

namespace Samples.GeneratingPatterns.Builder
{
    public class Building : Base
    {
        /// <summary>
        /// Детали
        /// </summary>
        public IList<BuildDetails> Details { get; set; }
        /// <summary>
        /// Ctor
        /// </summary>
        public Building()
        {
            Details = new List<BuildDetails>();
        }
        /// <summary>
        ///  Добавляет часть
        /// </summary>
        /// <param name="detailName"></param>
        public void Add(string partName)
        {
            Details.Add(new BuildDetails(partName));
        }
        /// <summary>
        /// Приводим к строке
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var line = string.Format("Здание: {0}...", DisplayName);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(line);

            foreach (var item in Details)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();

        }


    }

}
