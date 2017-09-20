namespace Samples.GeneratingPatterns.Builder
{
    public class YourBuildingBuilder : BuilderBase
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public YourBuildingBuilder() : base("Дом, в котором ты живешь...")
        {
        }
        /// <summary>
        /// Строим крышу
        /// </summary>
        public override void BuildRoof()
        {
            Building.Add("Крыша течет");
        }
        /// <summary>
        /// Строим стены
        /// </summary>
        public override void BuildWalls()
        {
            Building.Add("Стены побиты");
        }
        /// <summary>
        /// Строим пол
        /// </summary>
        public override void BuildFloor()
        {
            Building.Add("Земля матушка");
        }
        /// <summary>
        /// Создаем постройку
        /// </summary>
        /// <returns></returns>
        public override Building CreateBuilding()
        {
            Building.DisplayName = "Твоё здание";
            return Building;
        }
    }
}
