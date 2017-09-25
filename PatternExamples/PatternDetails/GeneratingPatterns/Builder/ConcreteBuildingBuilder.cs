namespace Pattern.Details
{
    public class ConcreteBuildingBuilder : BuilderBase
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public ConcreteBuildingBuilder() : base("Панельное здание")
        {
        }
        /// <summary>
        /// Строим крышу
        /// </summary>
        public override void BuildRoof()
        {
            Building.Add("Черепица");
        }
        /// <summary>
        /// Стены
        /// </summary>
        public override void BuildWalls()
        {
            Building.Add("Бетонные панели");
        }
        /// <summary>
        /// Пол
        /// </summary>
        public override void BuildFloor()
        {
            Building.Add("Бетонный пол");
        }

        public override Building CreateBuilding()
        {
            return Building;
        }
    }
}
