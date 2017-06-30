using Samples.AbstractBase.Classes;
using Samples.GeneratingPatterns.Builder;
using System;
using System.Collections.Generic;

namespace Samples.Examples.Builder
{
    public class BuilderExample : ExampleBase
    {

        public BuilderExample() :
            base("Builder (Строитель)")
        {
        }

        public override void Run()
        {
            var builders = new List<BuilderBase>()
            {
                new ConcreteBuildingBuilder(),
                new WoodenBuildingBuilder(),
                new YourBuildingBuilder()
            };

            //билдеры
            foreach (var builder in builders)
            {
                //застройщик
                var builderFactory = new BuildingFactory(builder);
                //застройщик построил здание
                var building = builderFactory.Create();
                //показываю
                Show(building);
            }


        }
        /// <summary>
        /// Показываем здание
        /// </summary>
        /// <param name="building"></param>
        private void Show(Building building)
        {
            Console.WriteLine(building);
        }
    }
}
