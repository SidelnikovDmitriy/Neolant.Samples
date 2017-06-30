using System;

namespace Samples.GeneratingPatterns.Builder
{
    public class WoodenBuildingBuilder : BuilderBase
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public WoodenBuildingBuilder() : base("Деревянное здание")
        {
        }
        /// <summary>
        /// Строим крышу
        /// </summary>
        public override void BuildRoof()
        {
            Building.Add("Гонт");
        }
        /// <summary>
        /// Строим стены
        /// </summary>
        public override void BuildWalls()
        {
            Building.Add("Деревянные стены");
        }
        /// <summary>
        /// Строим пол
        /// </summary>
        public override void BuildFloor()
        {
            Building.Add("Деревянный пол");
        }
        /// <summary>
        /// Создаем постройку
        /// </summary>
        /// <returns></returns>
        public override Building CreateBuilding()
        {
            return Building;
        }
    }
}
