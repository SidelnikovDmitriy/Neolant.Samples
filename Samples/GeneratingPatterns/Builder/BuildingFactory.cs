namespace Samples.GeneratingPatterns.Builder
{
    public class BuildingFactory
    {   
        /// <summary>
        /// Билдер
        /// </summary>
        private BuilderBase mBuilder;
        /// <summary>
        /// <summary>
        /// Билдер
        /// </summary>
        /// <param name="builder"></param>
        public BuildingFactory(BuilderBase builder)
        {
            mBuilder = builder;
        }
      
        /// Создает здание
        /// </summary>
        /// <returns></returns>
        public Building Create()
        {
            mBuilder.BuildRoof();
            mBuilder.BuildWalls();
            mBuilder.BuildFloor();

            return  mBuilder.CreateBuilding();
        }

    }
}
